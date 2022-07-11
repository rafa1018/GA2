using System;

namespace GA2.Application.Dto
{
    public class EstadoActividadDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }
        public Guid CreadoPor { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Guid ModificadoPor { get; set; }
        public DateTime FechaModificacion { get; set; }

    }
}
