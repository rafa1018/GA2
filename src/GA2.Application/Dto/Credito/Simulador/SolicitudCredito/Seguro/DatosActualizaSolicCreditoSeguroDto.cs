using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class DatosActualizaSolicCreditoSeguroDto
    {
        [Key]
        public Guid idSolicitudCredito { get; set; }
        public string convenioAseguradora { get; set; }
        public string convenioAseguradoraHogar { get; set; }
        public string idAseguradora { get; set; }
        public string idAseguradoraHogar { get; set; }
        public decimal porcentajeExtraprima { get; set; }
        public Guid actualizadoPor { get; set; }
        public DateTime fechaActualiza { get; set; }
    }
}
