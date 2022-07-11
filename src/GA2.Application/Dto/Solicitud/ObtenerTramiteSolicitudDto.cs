using System;
using System.Collections.Generic;

namespace GA2.Application.Dto
{
    public class ObtenerTramiteSolicitudDto
    {
        public ObtenerTramiteSolicitudDto() {
            solicitudEncontrada = false;
        }

        public Guid solicitudId { get; set; }
        public Guid solicitudTareaId { get; set; }
        public Guid ultimoSolicitudTareaId { get; set; }
        public int cuentaId { get; set; }
        public Guid tipoModalidadId { get; set; }
        public Guid tipoSubModalidadId { get; set; }
        public int solicitudEstadoId { get; set; }
        public int clienteId { get; set; }
        public int tipoIdentificacion { get; set; }
        public string direccionCliente { get; set; }
        public string telefonoCliente { get; set; }
        public string celularCliente { get; set; }
        public string correoCliente { get; set; }
        public DateTime fechaSolicitud { get; set; }
        public bool estadoSolicitud { get; set; }
        public int solicitudTareaEstadoId { get; set; }
        public string volverPantalla { get; set; }
        public string descripcionSubModalidad { get; set; }
        public string descripcionModalidad { get; set; }
        public string descripcionProceso { get; set; }
        public decimal valorRetirar { get; set; }
        public List<SaldoDto> SaldosE { get; set; }
        public decimal valorTotal { get; set; } = 0;
        public decimal valorCesantia { get; set; } = 0;
        public decimal valorAhorro { get; set; } = 0;
        public string pestanas { get; set; }

        #region Campos adicionales
        public bool solicitudEncontrada { get; set; }
        public string nombresCliente { get; set; }
        public string apellidosCliente { get; set; }
        public string identificacionCliente { get; set; }
        public Guid CreadoPor { get; set; }
        public List<MatriculaRespuestaDto> solicitudMatriculaDto { get; set; }
        public List<PropietarioRespuestaDto> solicitudPropietarioDto { get; set; }
        public List<TerceroVendedorRespuestaDto> solicitudTerceroVendedorDto { get; set; }
        public List<TerceroBeneficiarioRespuestaDto> solicitudTerceroBeneficiarioDto { get; set; }
        public List<TerceroApoderadoRespuestaDto> solicitudTerceroApoderadoDto { get; set; }
        public TerceroEntidadEducativaRespuestaDto solicitudTerceroEntidadEducativaDto { get; set; }
        public List<SolicitudTerceroBeneficiarioEstudioDto> solicitudTerceroBeneficiarioEstudioDto { get; set; }
        //public List<SolicitudTerceroBeneficiarioEstudioEntidadEducativaDto> solicitudTerceroBeneficiarioEstudioEntidadEducativaDto { get; set; }
        public SolicitudTerceroEntidadSeguroEducativoDto solicitudTerceroEntidadSeguroEducativoDto { get; set; }
        public SolicitudTerceroTenedorAccionesDto solicitudTerceroTenedorAccionesDto { get; set; }
        #endregion
    }
}
