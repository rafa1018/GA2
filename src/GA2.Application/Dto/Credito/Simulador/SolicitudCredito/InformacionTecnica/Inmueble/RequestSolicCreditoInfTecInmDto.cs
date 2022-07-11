using System;

namespace GA2.Application.Dto
{
    public class RequestSolicCreditoInfTecInmDto
    {
        public string idSolicitudInformaciontecnicaInmueble { get; set; }
        public string idSolicitudInformacionTecnica { get; set; }
        public Guid idSolicitudCredito { get; set; }
        public int indicador { get; set; }
    }
}
