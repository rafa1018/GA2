using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Actividad Economica Dto
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ActividadEconomicaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string CodigoCiiu { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPor { get; set; }
        public DateTime FechaActualizado { get; set; }
    }
}
