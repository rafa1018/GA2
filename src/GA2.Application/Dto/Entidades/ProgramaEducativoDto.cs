using System;

namespace GA2.Application.Dto
{
    /// <summary>
    /// Programa Educativa Dto
    /// </summary>
    public class ProgramaEducativoDto
    {
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificacionPor { get; set; }
        public DateTime FechaModificacion { get; set; }
    }
}
