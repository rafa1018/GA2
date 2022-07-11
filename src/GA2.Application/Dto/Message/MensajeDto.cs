using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Dto de mensaje
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>28/05/2021</date>
    /// </summary>
    public class MensajeDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Mensaje { get; set; }
        public string Tipo { get; set; }
        public Guid CreadoPor { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}