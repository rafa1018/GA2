using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface ICreditoRepository
    {
        Task<IEnumerable<RespuestaSolicitudObtenerTramite>> ObtenerTramiteSolicitud(PeticionSolicitudObtenerTramite solicitud);
        Task<IEnumerable<RespuestaFlujoDocumentos>> ObtenerDocumentosFlujo(PeticionFlujoDocumentos solicitud);
        Task<IEnumerable<DocumentosActRespuesta>> ObtenerDocumentosActSolicitud(DocumentosActSolicitud request);
        Task<IEnumerable<RespuestaObservacionTramite>> ObtenerObservacionTramite(PeticionObtenerObservacionTramite request);
        Task<RespuestaActividadTramite> ActualizaActividadTramite(ActividadTramiteSolicitud actualizacion);
        Task<RespuestaActividadTramite> EnviaSubsancionActividadTramite(ActividadTramiteSolicitud actualizacion);
        Task<RespuestaActividadTramite> ApruebaActividadTramite(ActividadTramiteSolicitud actualizacion);
        Task<RespuestaActividadTramite> RechazarActividadTramite(ActividadTramiteSolicitud actualizacion);
        Task<RespuestaCreditoProducto> ObtenerSolicCreditoProducto(PeticionSolicitudCreditoProducto peticion);
        Task<RespuestaCreditoBasica> ObtenerSolicCreditoBasica(PeticionCreditoBasica peticion);
        Task<RespuestaCreditoFinanciero> ObtenerSolicCreditoFinancieros(PeticionCreditoFinanciero peticion);
        Task<SolicCreditoInfTecnica> CrearSolicCreditoInfTecnica(SolicCreditoInfTecnica solicCreditoInfTecnica);
        Task<SolicCreditoInfTecInm> CrearSolicCreditoInfTecInm(SolicCreditoInfTecInm solicCreditoInfTecInm);
        Task<SolicCreditoInfJuridica> CrearSolicCreditoInfJuridica(SolicCreditoInfJuridica solicCreditoInfJuridica);
        Task<SolicCreditoInfJurInm> CrearSolicCreditoInfJurInm(SolicCreditoInfJurInm solicCreditoInfJurInm);
        Task<SolicCreditoInfTecnica> ObtenerSolicCreditoInfTecnica(RequestSolicCreditoInfTecnica requestSolicCreditoInfTecnica);
        Task<IEnumerable<SolicCreditoInfTecInm>> ObtenerSolicCreditoInfTecInm(RequestSolicCreditoInfTecInm requestSolicCreditoInfTecInm);
        Task<SolicCreditoInfJuridica> ObtenerSolicCreditoInfJuridica(RequestSolicCreditoInfJuridica requestSolicCreditoInfJuridica);
        Task<IEnumerable<SolicCreditoInfJurInm>> ObtenerSolicCreditoInfJurInm(RequestSolicCreditoInfJurInm requestSolicCreditoInfJurInm);
        Task<ResponseDocumentoSolicCredito> CrearDocumentoSolicCredito(ResponseDocumentoSolicCredito documentoSolicCredito);
        Task<SimulacionCliente> ConsultarSimulacionCliente(string numeroDocumento);
        Task<DatosSolicitudComite> ObtenerDatosSolicComite(Guid guid);
        Task<SolicCreditoRecomendacion> ActualizaSolicCreditoRecomendacion(SolicCreditoRecomendacion request);
        Task<ConsultaSolicitudCredito> ConsultarSolicitudCredito(ConsultaSolicitudCredito request);
        Task<ConsultaSolicitudCredito> ActualizaSolicCreditoSeguro(DatosActualizaSolicCreditoSeguro request);
        Task<IEnumerable<PlanillaSimulacionCredito>> CrearSimulacionCliente(CreacionSimulacionClienteDto request);
        Task<ResponseVerificarCierreActSeg> VerificarCierreActSeg(RequestVerificarCierreActSeg request);

        #region Consecutivo

        Task<Consecutivo> ActualizarConsecutivo(Consecutivo consecutivo);
        Task<Consecutivo> CrearConsecutivo(Consecutivo consecutivo);
        Task<Consecutivo> ObtenerConsecutivoPorId(string consecutivoid);
        Task<Consecutivo> EliminarConsecutivoPorid(string consecutivoid);
        Task<IEnumerable<Consecutivo>> ObtenerConsecutivo();
        #endregion

        #region Aseguradoras
        Task<Aseguradoras> CrearAseguradoras(Aseguradoras aseguradoras);
        Task<Aseguradoras> ActualizarAseguradoras(Aseguradoras aseguradoras);
        Task<Aseguradoras> ObtenerAseguradorasPorId(string aseguradorasid);
        Task<Aseguradoras> EliminarAseguradorasPorid(string aseguradorasid);
        Task<object> ActualizarRadicadoSolicitud(Guid sOC_ID, string barCode);
        Task<IEnumerable<Aseguradoras>> ObtenerAseguradoras();
        #endregion

        #region AlertaAutomaticas
        Task<AlertaAutomaticas> CrearAlertaAutomaticas(AlertaAutomaticas alertaautomaticas);
        Task<AlertaAutomaticas> ActualizarAlertaAutomaticas(AlertaAutomaticas alertaautomaticas);
        Task<AlertaAutomaticas> ObtenerAlertaAutomaticasPorId(string alertaautomaticasid);
        Task<AlertaAutomaticas> EliminarAlertaAutomaticasPorid(string alertaautomaticasid);
        Task<IEnumerable<AlertaAutomaticas>> ObtenerAlertaAutomaticas();

        #endregion

        #region ColorGrilla
        Task<ColorGrilla> EliminarColorGrillaPorid(string colorgrillaid);
        Task<ColorGrilla> ObtenerColorGrillaPorId(string colorgrillaid);
        Task<ColorGrilla> ActualizarColorGrilla(ColorGrilla colorgrilla);
        Task<ColorGrilla> CrearColorGrilla(ColorGrilla colorgrilla);
        Task<IEnumerable<ColorGrilla>> ObtenerColorGrilla();

        #endregion

        #region EstadoActividad
        Task<EstadoActividad> CrearEstadoActividad(EstadoActividad estadoActividad);
        Task<EstadoActividad> ActualizarEstadoActividad(EstadoActividad estadoActividad);
        Task<EstadoActividad> ObtenerEstadoActividadPorId(string estadoActividadid);
        Task<EstadoActividad> EliminarEstadoActividadPorid(string estadoActividadid);
        Task<IEnumerable<EstadoActividad>> ObtenerEstadoActividad();
        #endregion

        #region Estado Solicitud
        Task<EstadoSolicitud> CrearEstadoSolicitud(EstadoSolicitud estadosolicitud);
        Task<EstadoSolicitud> ActualizarEstadoSolicitud(EstadoSolicitud estadosolicitud);
        Task<EstadoSolicitud> ObtenerEstadoSolicitudPorId(string estadosolicitudid);
        Task<EstadoSolicitud> EliminarEstadoSolicitudPorid(string estadosolicitudid);
        Task<IEnumerable<EstadoSolicitud>> ObtenerEstadoSolicitud();

        #endregion

        #region Tipo Actividad

        Task<TipoActividad> CrearTipoActividad(TipoActividad tipoActividad);
        Task<TipoActividad> ActualizarTipoActividad(TipoActividad tipoActividad);
        Task<TipoActividad> ObtenerTipoActividadPorId(string tipoActividadid);
        Task<TipoActividad> EliminarTipoActividadPorid(string tipoActividadid);
        Task<IEnumerable<TipoActividad>> ObtenerTipoActividad();

        #endregion

        #region Tipo documento
        Task<TipoDocumento> CrearTipoDocumento(TipoDocumento tipodocumento);
        Task<TipoDocumento> ActualizarTipoDocumento(TipoDocumento tipodocumento);
        Task<TipoDocumento> ObtenerTipoDocumentoPorId(string tipodocumentoid);
        Task<TipoDocumento> EliminarTipoDocumentoPorid(string tipodocumentoid);
        Task<IEnumerable<TipoDocumento>> ObtenerTipoDocumento();

        #endregion

        #region Flujo
        Task<Flujo> CrearFlujo(Flujo flujo);
        Task<Flujo> ActualizarFlujo(Flujo flujo);
        Task<Flujo> ObtenerFlujoPorId(string flujoid);
        Task<Flujo> EliminarFlujoPorid(string flujoid);
        Task<IEnumerable<Flujo>> ObtenerFlujo();

        #endregion

        #region flujo Tipo Credito
        Task<FlujoTipoCredito> CrearFlujoTipoCredito(FlujoTipoCredito flujotipoCredito);
        Task<FlujoTipoCredito> ActualizarFlujoTipoCredito(FlujoTipoCredito flujotipoCredito);
        Task<FlujoTipoCredito> ObtenerFlujoTipoCreditoPorId(string flujotipoCreditoid);
        Task<FlujoTipoCredito> EliminarFlujoTipoCreditoPorid(string flujotipoCreditoid);
        Task<IEnumerable<FlujoTipoCredito>> ObtenerFlujoTipoCredito();

        #endregion

        #region Actividad flujo

        Task<ActividadFlujo> CrearActividadFlujo(ActividadFlujo actividadflujo);
        Task<ActividadFlujo> ObtenerActividadFlujoPorId(string actividadflujoid);
        Task<ActividadFlujo> EliminarActividadFlujoPorid(string actividadflujoid);
        Task<IEnumerable<ActividadFlujo>> ObtenerActividadFlujo();

        #endregion

        #region Usuario Actividad
        Task<UsuarioActividad> ObtenerUsuarioActividadPorId(string usuarioactividadid);
        Task<UsuarioActividad> EliminarUsuarioActividadPorid(string usuarioactividadid);
        Task<IEnumerable<UsuarioActividad>> ObtenerUsuarioActividad();
        Task<UsuarioActividad> CrearUsuarioActividad(UsuarioActividad usuarioActividad);
        #endregion

        #region Documento Actividad
        Task<DocumentoActividad> CrearDocumentoActividad(DocumentoActividad documentoactividad);
        Task<DocumentoActividad> ObtenerDocumentoActividadPorId(string documentoactividadid);
        Task<DocumentoActividad> EliminarDocumentoActividadPorid(string documentoactividadid);
        Task<IEnumerable<DocumentoActividad>> ObtenerDocumentoActividad();


        #endregion

        Task<IEnumerable<DatosComiteCredito>> ObtenerComiteCredito(DatosComiteCredito datosComiteCredito);
        Task<DatosComiteCredito> AprobarComiteCredito(DatosComiteCredito datosComiteCredito);
        Task<DatosComiteCredito> CrearComiteCredito(DatosComiteCredito datosComiteCredito);
        Task<IEnumerable<IntegranteComite>> ObtenerIntegranteComite();
        Task<ComiteIntegrante> CrearComiteCreditoIntegrante(ComiteIntegrante integrante);
        Task<IEnumerable<TemaComite>> ObtenerTemasComite();
        Task<IEnumerable<IntegrantePorComite>> ObtenerComiteCreditoIntegrante(IntegrantePorComite integranteComite);
        Task<TemaComiteCredito> CrearComiteCreditoTemas(TemaComiteCredito temaComiteCredito);
        Task<IEnumerable<SolicitudComite>> ObtenerComiteCreditoSolicitud(SolicitudComite solicitudComite);
        Task<SolicitudComiteCreacion> CrearComiteCreditoSolicitud(SolicitudComiteCreacion solicitudComite);
        Task<IEnumerable<TemaComiteCredito>> ObtenerComiteCreditoTemas(RequestTemaComiteCredito solicitudComite);
        Task<HistorialCredito> ObtenerHistorialComercialBuro(string request);
        Task<TasaSolicitudCredito> ActualizaSolicCreditoTasas(TasaSolicitudCredito TasaSolicitudCredito);
        Task<DatosComiteCredito> ActualizarRadicadoComiteCredito(int comiteNumero, string barCode);
        Task<IEnumerable<FuenteRecursos>> ObtenerFuentesRecursos();
        Task<IEnumerable<SolicitudDesembolso>> ObtenerDesembolsosSolicitud(SolicitudDesembolso solicitud);
        Task<SolicitudCreditosDesembolsos> CrearSolicCreditoDesembolsos(SolicitudCreditosDesembolsos solicitud);
        Task<DesembolsoCreditoSolicitud> AplicarDesembolsoSolicitud(DesembolsoCreditoSolicitud desembolso);
        Task<IEnumerable<ObtenerCausalDesistimiento>> ObtenerCausalDesistimiento();
        Task<CreditoFinanciero> CrearSolicCreditoFinancieros(CreditoFinanciero solicitud);
        Task<DatosReparto> ObtenerDatosReparto(Guid request);
        Task<DesistimientoDesembolso> DesistirDesembolsoSolicitud(DesistimientoDesembolso solicitud);
        Task<IEnumerable<ValidacionDocumentos>> ValidarDocumentosFlujo(ValidacionDocumentos solicitud);
        Task<ActualizacionSolicitudCreditoDesemFirma> ActualizaSolicCreditoDesembolso(ActualizacionSolicitudCreditoDesemFirma solicitud);
        Task<ActualizacionSolicitudCreditoDesemFirma> ActualizaSolicCreditoFirmas(ActualizacionSolicitudCreditoDesemFirma solicitud);
        Task<SimulacionDatosPersonales> ObtenerSimulacionPersonales(string request);
        Task<Cuenta> ObtenerCuentaById(string clienteIdentificacion);
        Task<DatosFinancierosPersonales> ObtenerDatosFinancierosPersonales(string request);
        Task<SimulacionDatosPersonales> ActualizarPersonalesVivienda(SimulacionDatosPersonales peticion);
        Task<ActualizacionSolicitudCreditoDesemFirma> ObtenerSolicitudCredito(string request, int indicador);
        Task<IEnumerable<SolicitudCreditosDesembolsos>> ObtenerFuentesRecursosSolicitud(Guid IdSolicitud);
        Task<IEnumerable<SolicitudCreditosDesembolsos>> EliminarFuentesRecursosSolicitud(SolicitudCreditosDesembolsos solicitudCreditosDesembolsos);
        Task<IEnumerable<EqivalenciaSimulador>> ObtenerEquivalenciasSimuladorCredito();
        Task<SolicitudSimulacion> CrearSolicitudSimulacionCredito(SolicitudSimulacion solicitudSimulacion);
        Task<SimulacionDetalle> CrearDetalleSimulacion(SimulacionDetalle simulacion);
        Task<SMCSimulacionCliente> CrearSimulacionClienteSMC(SMCSimulacionCliente request);
        Task<SolicitudSimulacion> CrearPreAprobado(SolicitudSimulacion request);
        Task<SolicitudCredito> CrearSolicitudCredito(SolicitudCredito solicitudCredito);

        Task<SocSolicitudInfobasica> CrearSolicCreditoBasicos(SocSolicitudInfobasica infoBasica);
        Task<IEnumerable<TasaHogarCiudad>> ObtenerTasasHogarCiudad();

        Task<InformacionConyugue> ObtenerSolicCreditoConyugue(PeticionCreditoBasica IdSolicitud);

        Task<InformacionConyugue> CrearSolicCreditoConyugue(InformacionConyugue info);
    }
}
