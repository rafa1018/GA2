using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace GA2.Application.Dto
{
    public class SolicitudActaComiteDto
    {
        public List<DatosComiteCreditoDto> DatosComite { get; set; }
        public IEnumerable<IntegrantePorComiteDto> IntegrantesComite { get; set; }
        public IEnumerable<TemaComiteCreditoDto> TemasComite { get; set; }
        public IEnumerable<SolicitudComiteDto> Solicitudes { get; set; }
        public IEnumerable<DatosSolicitudComiteDto> DatosSolicitud { get; set; }

    }
}
