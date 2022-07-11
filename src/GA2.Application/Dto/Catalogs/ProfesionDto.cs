using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Profesiones Dto
    /// </summary>
    public class ProfesionDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ActualizadoPor { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
