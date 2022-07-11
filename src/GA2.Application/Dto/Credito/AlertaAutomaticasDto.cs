using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Tabla de AlertaAutomaticas
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>29/04/2021</date>
    public class AlertaAutomaticasDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificado { get; set; }
    }
}
