using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Dto.GrupoOpciones;
using GA2.Application.Dto.Identity;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Domain.Entities.Email;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using GA2.Transversals.Commons.Constants;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Login business login GA2
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>25/03/2021</date>
    public class LoginBusinessLogic : ILoginBusinessLogic
    {
        /// <summary>
        /// Propiedades aplicacion 
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>03/05/2021</date>
        private readonly IMapper _mapper;
        private readonly ITokenClaims _tokenClaims;
        private readonly ILoginGA2Repository _loginGA2Repository;
        private readonly ILoginRequestProvider _loginRequestProvider;
        private readonly IOptions<AppMainOptions> _appOptions;
        private readonly ICryptoGA2 _cryptoGA2;
        private readonly IEmailRepository _emailRepository;

        /// <summary>
        /// Constructor de negocio login GA2
        /// </summary>
        /// <param name="mapper">Dependencia de mapper</param>
        /// <param name="tokenClaims">Dependencias de claims</param>
        /// <param name="loginGA2Repository">Dependencia de loginrepository</param>
        /// <param name="loginRequestProvider">Dependencia de loginrepository</param>
        /// <param name="configuration">Configuracion aplicacion</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>03/05/2021</date>
        public LoginBusinessLogic(
            IMapper mapper,
            ITokenClaims tokenClaims,
            ILoginGA2Repository loginGA2Repository,
            ILoginRequestProvider loginRequestProvider,
            ICryptoGA2 cryptoGA2,
            IEmailRepository emailRepository,
            IOptions<AppMainOptions> appOptions)
        {
            _mapper = mapper;
            _tokenClaims = tokenClaims;
            _loginGA2Repository = loginGA2Repository;
            _loginRequestProvider = loginRequestProvider;
            _cryptoGA2 = cryptoGA2;
            _appOptions = appOptions;
            _emailRepository = emailRepository;
        }

        /// <summary>
        /// Metodo login aplicacion GA2
        /// </summary>
        /// <param name="loginDto">Datos de logueo</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>03/05/2021</date>
        /// <returns>Claims Token Jwt</returns>
        public async Task<Response<ResponseLoginDto>> LoginGA2(LoginDto loginDto)
        {


            var phraseKey = _appOptions.Value.PhraseKey;
            var hash = _appOptions.Value.Hash;
            loginDto.Password = this._cryptoGA2.EncryptMD5(loginDto.Password + hash, phraseKey);

            var login = this._mapper.Map<User>(loginDto);

            var user = await this._loginGA2Repository.LoginUser(login);

            if (user != null)
            {

                var directory = user.ACTIVE_DIRECTORY;

                var op = await this._loginGA2Repository.ObtenerOpcionesUsuariosById(user.USR_ID);
                var token = await this._tokenClaims.GetTokenAsync(user);
                ResponseLoginDto response = new ResponseLoginDto();
                response.token = token;

                if (!directory)
                {
                    if (user.USR_PASSWORD.Equals(loginDto.Password))
                    {

                        if (op != null)
                        {
                            var opcions = this._mapper.Map<IEnumerable<GrupoOpciones>, IEnumerable<GrupoOpcionesDto>>(op);             // this._mapper.Map<GrupoOpciones>(await this._loginGA2Repository.ObtenerOpcionesUsuariosById(user.USR_ID));
                            response.opciones = (List<GrupoOpcionesDto>)opcions;
                        }
                        else
                        {
                            List<GrupoOpcionesDto> list = new List<GrupoOpcionesDto>();
                            response.opciones = list;

                        }

                        return new Response<ResponseLoginDto> { Data = response };
                    }
                    else {

                        return new Response<ResponseLoginDto> { Data = null, ReturnMessage = IdentityConstants.UsuarioInvalido };
                    }
                }
                else {


                   var autenticate= AutenticarDirectoryActive(loginDto.UserName, loginDto.Password);

                    if (autenticate)
                    {

                        if (op != null)
                        {
                            var opcions = this._mapper.Map<IEnumerable<GrupoOpciones>, IEnumerable<GrupoOpcionesDto>>(op);           
                            response.opciones = (List<GrupoOpcionesDto>)opcions;
                        }
                        else
                        {
                            List<GrupoOpcionesDto> list = new List<GrupoOpcionesDto>();
                            response.opciones = list;

                        }

                        return new Response<ResponseLoginDto> { Data = response };
                       
                    }
                    else {
                        return new Response<ResponseLoginDto> { Data = null, ReturnMessage = IdentityConstants.UsuarioInvalido };
                    }
                }
            }
            else {
                return new Response<ResponseLoginDto> { Data = null, ReturnMessage = IdentityConstants.UsuarioInvalido };

            }     
        }

      

        /// <summary>
        /// Metodo login aplicacion GA2
        /// </summary>
        /// <param name="loginDto">Datos de logueo</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>03/05/2021</date>
        /// <returns>Claims Token Jwt</returns>
        public async Task<Response<string>> LoginGA2Paa(LoginPaaDto loginPaaDto)
        {
            var cliente = await this._loginRequestProvider.ObtenerClienteLoginGA2Paa(loginPaaDto);
            if (cliente != null)
                if (cliente.Data != null)
                    return new Response<string> { Data = await this._tokenClaims.GetTokenToProviderAsync() };
            return new Response<string> { Data = null, ReturnMessage = IdentityConstants.LoginInvalidoPaa };
        }

        /// <summary>
        /// Obtener lista de menu
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>03/05/2021</date>
        /// <returns>Lista de menu</returns>
        public async Task<Response<IEnumerable<MenuDto>>> ObtenerMenu()
        {
            List<MenuDto> menu = this._mapper.Map<IEnumerable<MenuDto>>(await this._loginGA2Repository.ObtenerMenu()).ToList();
            List<SubMenuDto> submenus = this._mapper.Map<IEnumerable<SubMenuDto>>(await this._loginGA2Repository.ObtenerSubmenu()).ToList();
            foreach (MenuDto item in menu)
                item.SubMenus = submenus.Where(x => x.MenuId == item.Id).ToList();

            return new Response<IEnumerable<MenuDto>> { Data = menu };
        }

        public async  Task<Response<string>> RecuperaContrasena(RecuperarContrasenaDto recuperarContrasenaDto)
        {
          
            var repust = await this._loginGA2Repository.RecuperaContrasena(recuperarContrasenaDto.Tipo.ToString(),recuperarContrasenaDto.Numero);

            if (repust != null)
            {

                string token = GetSHA256(Guid.NewGuid().ToString());
                var user = await this._loginGA2Repository.ActualizaTokenUser(repust.USR_ID, token);

                if (user != null)
                {

                    string url = recuperarContrasenaDto.Url+user.TOKEN;

                    MailMessage correo = new MailMessage();
                    correo.From = new MailAddress("correo.cajahonor@cajahonor.gov.co", "CajaHonor", System.Text.Encoding.UTF8);
                    correo.To.Add(user.USR_EMAIL); 
                    correo.Subject = "Restablecer contraseña";
                    correo.Body = "<h3>Restablecer contraseña </h3> <p>Has realizado una solicitud de cambio de contraseña.</p> <p>Si el enlace no funciona, copia y pega el siguiente texto en labarra de direcciones de tu navegador:</p> <div><a href='"+ url+"'>" +url+"</a> </div>"; 
                    correo.IsBodyHtml = true;
                    correo.Priority = MailPriority.Normal;

                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = false;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.Credentials = new System.Net.NetworkCredential("correo.cajahonor@cajahonor.gov.co", "Ingreso.123");

                    ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                    smtp.EnableSsl = true;
                    smtp.Send(correo);

                    return new Response<string> { IsSuccess = true, ReturnMessage = IdentityConstants.LoginRecuperaContrasena };

                }
                else {
                    return new Response<string> { IsSuccess = true, ReturnMessage = IdentityConstants.LoginRecuperaContrasena };
                }
                
            }
            else {
                return new Response<string> { IsSuccess = true, ReturnMessage = IdentityConstants.LoginRecuperaContrasena };
            }

           


        }

        /// <summary>
        /// Autenticacion de directorio activo
        /// </summary>
        /// <param name="path">Dominio del directorio</param>
        /// <param name="userName">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        private bool AutenticarDirectoryActive(string userName, string password)
        {
            try
            {

                DirectoryEntry de = new DirectoryEntry("LDAP://cpvmp-01x.caprovimpo.local:389/DC=caprovimpo,DC=Local", userName, password);
                DirectorySearcher dsearch = new DirectorySearcher(de);
                dsearch.Filter = "sAMAccountName=" + userName + "";
                SearchResult results = null;
                results = dsearch.FindOne();
                return results.Properties.Count != 0;
               
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public async Task<Response<UsuarioDto>> validaToken(string token)
        {

            var userIdentificacion = await this._loginGA2Repository.ValidaTokenRestablecimiento(token);

            if (userIdentificacion != null)
            {
                return new Response<UsuarioDto> { IsSuccess = true, ReturnMessage = "El token es valido" };
            }
            else {
                return new Response<UsuarioDto> { IsSuccess = false, ReturnMessage = "El enlace de restablecimiento de contraseña ha expirado" };

            }
        }
    }
}
