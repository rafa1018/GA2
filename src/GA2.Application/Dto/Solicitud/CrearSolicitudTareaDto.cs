using System;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    public class CrearSolicitudTareaDto
    {
        public CrearSolicitudTareaDto() {
            valorRetirar = 0;
        }

        public Guid SolicitudId { get; set; }
        public Guid solicitudTareaId { get; set; }
        public Guid CreadoPor { get; set; }
        public decimal valorRetirar { get; set; }
        public List<SolicitudMatriculaDto> SolicitudMatriculaDto { get; set; }
        public List<SolicitudPropietarioDto> SolicitudPropietarioDto { get; set; }
        public List<SolicitudTerceroApoderadoDto> SolicitudTerceroApoderadoDto { get; set; }
        public List<SolicitudTerceroBeneficiarioDto> SolicitudTerceroBeneficiarioDto { get; set; }
        public List<SolicitudTerceroVendedorDto> SolicitudTerceroVendedorDto { get; set; }
        public SolicitudTerceroConstructorDto SolicitudTerceroConstructorDto { get; set; }
        public SolicitudTerceroAutorizadoDto SolicitudTerceroAutorizadoDto { get; set; }
        public SolicitudTerceroEntidadEducativaDto SolicitudTerceroEntidadEducativaDto { get; set; }
        public List<SolicitudTerceroBeneficiarioEstudioDto> SolicitudTerceroBeneficiarioEstudioDto { get; set; }
        public List<SolicitudTerceroBeneficiarioEstudioEntidadEducativaDto> SolicitudTerceroBeneficiarioEstudioEntidadEducativaDto { get; set; }
        public SolicitudTerceroEntidadSeguroEducativoDto SolicitudTerceroEntidadSeguroEducativoDto { get; set; }
        public SolicitudTerceroTenedorAccionesDto SolicitudTerceroTenedorAccionesDto { get; set; }
    }
}
