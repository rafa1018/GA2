using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class SolicitudComiteCreacionDto
    {
        [Key]
        public Guid idComiteSolicitud { get; set; }
        public Guid idSolicitudCredito { get; set; }
        public int idComiteCredito { get; set; }
        public string resultado { get; set; }
        public string aprobada { get; set; }
        public string rechazada { get; set; }
        public Guid creadoPor { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Guid actualizadoPor { get; set; }
        public DateTime fechaActualizacion { get; set; }
        public decimal valorCredito { get; set; }
        public int plazoCredito { get; set; }
        public decimal teaCredito { get; set; }
    }
}
