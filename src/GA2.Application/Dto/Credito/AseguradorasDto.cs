using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Tabla de seguradoras
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>29/04/2021</date>
    public class AseguradorasDto
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string SitioWeb { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPor { get; set; }
        public DateTime FechaActualiza { get; set; }
    }
}
