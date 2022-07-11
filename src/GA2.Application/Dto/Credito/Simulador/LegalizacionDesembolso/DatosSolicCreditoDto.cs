using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class DatosSolicCreditoDto
    {
        public IEnumerable<SolicitudCreditosDesembolsosDto> SolicitudCreditosDesembolsos { get; set; }
        public TasaSolicitudCreditoDto TasaSolicitudCreditoDto { get; set; }
    }
}
