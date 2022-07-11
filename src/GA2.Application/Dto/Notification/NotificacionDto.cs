using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de notificacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>17/05/2021</date>
    /// </summary>
    public class NotificacionDto
    {
        public Guid Id { get; set; }
        public string Mensaje { get; set; }
        public Guid Receptor { get; set; }
        public string Tipo { get; set; }
        public bool Visto { get; set; }
        public Guid Emisor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public string AccessToken { get; set; }
    }
}