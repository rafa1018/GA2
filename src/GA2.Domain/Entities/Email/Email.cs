using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace GA2.Domain.Entities.Email
{
    /// <summary>
    /// Modelo de correo
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class EmailModel
    {
        public Guid Id { get; set; }
        public string NombreAplicacion { get; set; }
        public List<string> Destinatarios { get; set; }
        public List<string> Copias { get; set; } = new List<string>();
        public List<string> CopiasOcultas { get; set; } = new List<string>();
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public bool Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool IsHtmlBody { get; set; }
        public MailPriority Prioridad { get; set; }
    }
}
