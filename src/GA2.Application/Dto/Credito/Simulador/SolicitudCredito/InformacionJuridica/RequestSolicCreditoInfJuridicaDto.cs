using System;
using System.ComponentModel.DataAnnotations;

namespace GA2.Application.Dto
{
    public class RequestSolicCreditoInfJuridicaDto
    {
        [Key]
        public string idSolicitudInformacionJuridica { get; set; }
        public Guid idSolicitudCredito { get; set; }
        public int indicador { get; set; }
    }
}
