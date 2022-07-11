using Dapper;
using GA2.Domain.Entities.Email;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Email repository para enviar mensajes
    /// </summary>
    /// <auth>Oscar Julian Rojas</auth>
    /// <date>19/04/2021</date>
    public class EmailRepository : DapperGenerycRepository, IEmailRepository
    {
        /// <summary>
        /// Configuracion de aplicacion
        /// </summary>
        /// <auth>Oscar Julian Rojas</auth>
        /// <date>19/04/2021</date>
        private readonly IConfiguration _configuration;
        private static bool mailSent = false;

        /// <summary>
        /// Constructor Email Repository
        /// </summary>
        /// <param name="configuration">Configuracion de aplicacion</param>
        /// <auth>Oscar Julian Rojas</auth>
        /// <date>19/04/2021</date>
        public EmailRepository(IConfiguration configuration) : base(configuration) => _configuration = configuration;

        /// <summary>
        /// Obtener coneccion de cliente stmp
        /// </summary>
        /// <param name="configuracion">Configuracion de aplicacion</param>
        /// <auth>Oscar Julian Rojas</auth>
        /// <returns>SmtpClient</returns>
        /// <date>19/04/2021</date>
        private SmtpClient GetConnectionSmtpClient() => new SmtpClient()
        {
            Host = _configuration["smtp-mail.outlook.com"],
            Port = int.Parse(_configuration["587"]),
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(_configuration["correo.cajahonor@cajahonor.gov.co"], _configuration["Ingreso.123"]),
            Timeout = 20000

      
        };

        /// <summary>
        /// Metodo de enviar correo
        /// </summary>
        /// <param name="notificacion">Modelo correo</param>
        /// <returns>Booleano de confirmacion de envio</returns>
        /// <auth>Oscar Julian Rojas</auth>
        /// <date>19/04/2021</date>
        public async Task<bool> EnviarEmail(EmailModel email)
        {
            if (email is null) throw new ArgumentNullException(nameof(email));
            var clientStmp = GetConnectionSmtpClient();
            using var mensaje = new MailMessage();
           // mensaje.From = new MailAddress(_configuration["correo.cajahonor@cajahonor.gov.co"],_configuration["CajaHonor"]);
            mensaje.Subject = email.Asunto;
            mensaje.Body = email.Mensaje;
            mensaje.IsBodyHtml = email.IsHtmlBody;
            mensaje.Priority = email.Prioridad;
            foreach (var dest in email.Destinatarios)
                mensaje.To.Add(dest);
          /*
            foreach (var cc in email.Copias)
                mensaje.CC.Add(cc);
            foreach (var bcc in email.CopiasOcultas)
                mensaje.Bcc.Add(bcc);*/

            await clientStmp.SendMailAsync(mensaje);



            return mailSent;
        }

        /// <summary>
        /// Envio evento completo 
        /// </summary>
        /// <param name="sender">Emisor</param>
        /// <param name="e">Evento</param>
        /// <auth>Oscar Julian Rojas</auth>
        /// <date>19/04/2021</date>
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Guid Usuario Conectado.
            var token = (string)e.UserState;
            if (e.Cancelled) Console.WriteLine("[{0}] Envio Cancelado.", token);
            if (e.Error != null) Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            else Console.WriteLine("Correo Enviado.");
            mailSent = true;
        }

        public async Task<EmailModel> GuardarCorreo(EmailModel notificacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            return await GetAsyncFirst<EmailModel>("Poner el storeprocedure", parameters, typeCommand: CommandType.StoredProcedure);
        }
    }
}
