using System;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    public class CrearSolicitudConstruccionDto
    {
        public Guid SolicitudId { get; set; }
        public Guid CreadoPor { get; set; }
        public List<SolicitudMatriculaDto> SolicitudMatriculaDto { get; set; }
        public List<SolicitudPropietarioDto> SolicitudPropietarioDto { get; set; }
        public SolicitudTerceroApoderadoDto SolicitudTerceroApoderadoDto { get; set; }
        public SolicitudTerceroBeneficiarioDto SolicitudTerceroBeneficiarioDto { get; set; }
        public SolicitudTerceroConstructorDto SolicitudTerceroConstructorDto { get; set; }
        public SolicitudTerceroVendedorDto SolicitudTerceroVendedorDto { get; set; }
    }
}
