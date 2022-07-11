using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class SolicitudComiteDto
    {
        [Key]
        public Guid? idSolicitud { get; set; }
        public int numeroSolicitud { get; set; }
        public int idTipoCredito { get; set; }
        public string tipoCredito { get; set; }
        public string identificacion { get; set; }
        public int idComiteCredito { get; set; }
        public string nombreCliente { get; set; }
        public string resultado { get; set; }
        public string aprobada { get; set; }
        public string rechazada { get; set; }
        public string procesada { get; set; }
        public Guid usuarioCreacion { get; set; }
        public DateTime? fechaCreacion { get; set; }
        public int valorCredito { get; set; }
        public int plazoCredito { get; set; }
        public decimal teaCredito { get; set; }
        public decimal valorCuota { get; set; }
    }
}
