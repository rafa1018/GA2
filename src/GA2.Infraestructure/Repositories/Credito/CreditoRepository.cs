using Dapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public class CreditoRepository : DapperGenerycRepository, ICreditoRepository
    {
        public CreditoRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Repositorio Actualiza Actividad Tramite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="actualizacion"></param>
        /// <returns></returns>
        public async Task<RespuestaActividadTramite> ActualizaActividadTramite(ActividadTramiteSolicitud actualizacion)
        {
            DynamicParameters parameters = new();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.TRS_ID), actualizacion.TRS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.AFL_ID), actualizacion.AFL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_OBSERVACION), actualizacion.ACT_OBSERVACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_MODIFICADO_POR), actualizacion.ACT_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_FECHA_MODIFICACION), actualizacion.ACT_FECHA_MODIFICACION);

            return await GetAsyncFirst<RespuestaActividadTramite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene Documentos Act Solicitud
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DocumentosActRespuesta>> ObtenerDocumentosActSolicitud(DocumentosActSolicitud request)
        {
            DynamicParameters parameters = new();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentosActRespuestaParameters.AFL_ID), request.AFL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentosActRespuestaParameters.SOC_ID), request.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentosActRespuestaParameters.TCR_ID), request.TCR_ID);

            return await GetAsyncList<DocumentosActRespuesta>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene Documentos flujo
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RespuestaFlujoDocumentos>> ObtenerDocumentosFlujo(PeticionFlujoDocumentos solicitud)
        {
            DynamicParameters parameters = new();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumFlujoDocumentosParameters.SOC_ID), solicitud.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFlujoDocumentosParameters.TCR_ID), solicitud.TCR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFlujoDocumentosParameters.ORDEN), solicitud.ORDEN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFlujoDocumentosParameters.PRINCIPAL), solicitud.PRINCIPAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumFlujoDocumentosParameters.AFL_ID), solicitud.AFL_ID);

            return await GetAsyncList<RespuestaFlujoDocumentos>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene solicitud credito producto
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="peticion"></param>
        /// <returns></returns>
        public async Task<RespuestaCreditoProducto> ObtenerSolicCreditoProducto(PeticionSolicitudCreditoProducto peticion)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoProductoParameters.SOC_ID), peticion.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoProductoParameters.SOP_ID), peticion.SOP_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoProductoParameters.IND), peticion.IND);

            return await GetAsyncFirst<RespuestaCreditoProducto>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene solicitud credito basica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="peticion"></param>
        /// <returns></returns>
        public async Task<RespuestaCreditoBasica> ObtenerSolicCreditoBasica(PeticionCreditoBasica peticion)
        {
            DynamicParameters parameters = new();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoBasicaParameters.SOC_ID), peticion.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoBasicaParameters.SOB_ID), peticion.SOB_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoBasicaParameters.IND), peticion.IND);

            var respuesta= await GetAsyncFirst<RespuestaCreditoBasica>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return respuesta;
        }

        /// <summary>
        /// Obtiene solicitud credito financieros
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="peticion"></param>
        /// <returns></returns>
        public async Task<RespuestaCreditoFinanciero> ObtenerSolicCreditoFinancieros(PeticionCreditoFinanciero peticion)
        {
            DynamicParameters parameters = new();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoFinancieroParameters.SOC_ID), peticion.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoFinancieroParameters.SOF_ID), peticion.SOF_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoFinancieroParameters.IND), peticion.IND);

            return await GetAsyncFirst<RespuestaCreditoFinanciero>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene tramite solicitud
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RespuestaSolicitudObtenerTramite>> ObtenerTramiteSolicitud(PeticionSolicitudObtenerTramite solicitud)
        {
#pragma warning disable IDE0090 // Use 'new(...)'
            DynamicParameters parameters = new DynamicParameters();
#pragma warning restore IDE0090 // Use 'new(...)'

            parameters.Add(HelpersEnums.GetEnumDescription(EnumTramiteSolicitudParameters.fecha), solicitud.FECHA_SOL != null ? solicitud.FECHA_SOL : null);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTramiteSolicitudParameters.identificacion), solicitud.CLI_IDENTIFICACION ?? null);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTramiteSolicitudParameters.usuario), solicitud.USUARIO_ID);
            if (solicitud.ESTADO_ACT != null) parameters.Add(HelpersEnums.GetEnumDescription(EnumTramiteSolicitudParameters.estado), solicitud.ESTADO_ACT);
            if (solicitud.TCR_ID != null) parameters.Add(HelpersEnums.GetEnumDescription(EnumTramiteSolicitudParameters.tipoCredito), solicitud.TCR_ID);


            var response = await GetAsyncList<RespuestaSolicitudObtenerTramite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            return response;
        }

        /// <summary>
        /// Obtiene observaciones tramite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<RespuestaObservacionTramite>> ObtenerObservacionTramite(PeticionObtenerObservacionTramite request)
        {
            DynamicParameters parameters = new();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumObservacionTramiteParameters.ACT_ID), request.ACT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumObservacionTramiteParameters.TRS_ID), request.TRS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumObservacionTramiteParameters.IND), request.IND);


            return await GetAsyncList<RespuestaObservacionTramite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Envia subsanacion Actividad Tramite
        /// </summary>
        /// <param name="actualizacion"></param>
        /// <returns></returns>
        public async Task<RespuestaActividadTramite> EnviaSubsancionActividadTramite(ActividadTramiteSolicitud actualizacion)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.TRS_ID), actualizacion.TRS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.AFL_ID), actualizacion.AFL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_OBSERVACION), actualizacion.ACT_OBSERVACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_MODIFICADO_POR), actualizacion.ACT_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_FECHA_MODIFICACION), actualizacion.ACT_FECHA_MODIFICACION);

            return await GetAsyncFirst<RespuestaActividadTramite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Aprueba Actividad tramite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="actualizacion"></param>
        /// <returns></returns>
        public async Task<RespuestaActividadTramite> ApruebaActividadTramite(ActividadTramiteSolicitud actualizacion)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.TRS_ID), actualizacion.TRS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.AFL_ID), actualizacion.AFL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_OBSERVACION), actualizacion.ACT_OBSERVACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_MODIFICADO_POR), actualizacion.ACT_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_FECHA_MODIFICACION), actualizacion.ACT_FECHA_MODIFICACION);

            return await GetAsyncFirst<RespuestaActividadTramite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Rechaza Actividad Tramite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="actualizacion"></param>
        /// <returns></returns>
        public async Task<RespuestaActividadTramite> RechazarActividadTramite(ActividadTramiteSolicitud actualizacion)
        {
            DynamicParameters parameters = new();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.TRS_ID), actualizacion.TRS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.AFL_ID), actualizacion.AFL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_OBSERVACION), actualizacion.ACT_OBSERVACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_MODIFICADO_POR), actualizacion.ACT_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudActividadTramiteParameters.ACT_FECHA_MODIFICACION), actualizacion.ACT_FECHA_MODIFICACION);

            return await GetAsyncFirst<RespuestaActividadTramite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crear Solicitud Credito Informacion Tecnica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicCreditoInfTecnica"></param>
        /// <returns></returns>
        public async Task<SolicCreditoInfTecnica> CrearSolicCreditoInfTecnica(SolicCreditoInfTecnica solicCreditoInfTecnica)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.idSolicitudInformacionTecnica), solicCreditoInfTecnica.SIT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.idSolicitudCredito), solicCreditoInfTecnica.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.valorAvaluoComercial), solicCreditoInfTecnica.SIT_VALOR_AVALUO_COMERCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.valorVentaInmueble), solicCreditoInfTecnica.SIT_VALOR_VENTA_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.consideracionesFinales), solicCreditoInfTecnica.SIT_CONSIDERACIONES_FINALES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.declaraCumplimiento), solicCreditoInfTecnica.SIT_DECLARA_CUMPLIMIENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.condicionesSalvedades), solicCreditoInfTecnica.SIT_CONDICIONES_SALVEADES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.conceptoEstTecnico), solicCreditoInfTecnica.SIT_CONCEPTO_EST_TECNICO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.estrato), solicCreditoInfTecnica.SIT_ESTRATO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.creadoPor), solicCreditoInfTecnica.SIT_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecnicaParameters.fechaCreacion), solicCreditoInfTecnica.SIT_FECHA_CREACION);

            return await GetAsyncFirst<SolicCreditoInfTecnica>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crear Solicitud Credito Informacion Tecnica Inmueble
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicCreditoInfTecInm"></param>
        /// <returns></returns>
        public async Task<SolicCreditoInfTecInm> CrearSolicCreditoInfTecInm(SolicCreditoInfTecInm solicCreditoInfTecInm)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecInmParams.idSolicitudInfoTecnicaInmueble), solicCreditoInfTecInm.STI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecInmParams.idSolicitudtecnica), solicCreditoInfTecInm.SIT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecInmParams.idSolicitudCredito), solicCreditoInfTecInm.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecInmParams.numeroMatricula), solicCreditoInfTecInm.STI_NUMERO_MATRICULA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecInmParams.fechaMatricula), solicCreditoInfTecInm.STI_FECHA_MATRICULA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecInmParams.numeroChip), solicCreditoInfTecInm.STI_NUMERO_CHIP);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecInmParams.cedulaCatastral), solicCreditoInfTecInm.STI_CEDULA_CATASTRAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecInmParams.creadoPor), solicCreditoInfTecInm.STI_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfTecInmParams.fechaCreacion), solicCreditoInfTecInm.STI_FECHA_CREACION);

            return await GetAsyncFirst<SolicCreditoInfTecInm>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crear Solicitud Credito Informacion Juridica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicCreditoInfJuridica"></param>
        /// <returns></returns>
        public async Task<SolicCreditoInfJuridica> CrearSolicCreditoInfJuridica(SolicCreditoInfJuridica solicCreditoInfJuridica)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.idSolicitudInformacionJuridica), solicCreditoInfJuridica.SIJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.idSolicitudCredito), solicCreditoInfJuridica.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.linderos), solicCreditoInfJuridica.SIJ_LINDEROS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.tipoParqueadero), solicCreditoInfJuridica.SIJ_TIPO_PARQUEADERO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.edadJuridica), solicCreditoInfJuridica.SIJ_EDAD_JURIDICA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.fechaPrimerActo), solicCreditoInfJuridica.SIJ_FECHA_PRIMER_ACTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.tradicionInmueble), solicCreditoInfJuridica.SIJ_TRADICION_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.analisisUlt20Años), solicCreditoInfJuridica.SIJ_ANALISIS_ULT_20_AÑOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.analisisSitJuridica), solicCreditoInfJuridica.SIJ_ANALISIS_SIT_JURIDICA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.AnalisisRegPropHorizontal), solicCreditoInfJuridica.SIJ_ANALISIS_REG_PROP_HOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.analisisPazySalvo), solicCreditoInfJuridica.SIJ_ANALISIS_PAZ_Y_SALVO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.analisisVendedor), solicCreditoInfJuridica.SIJ_ANALISIS_VENDEDOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.viabilidadJurNegocio), solicCreditoInfJuridica.SIJ_VIABILIDAD_JUR_NEGOCIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.recomendaciones), solicCreditoInfJuridica.SIJ_RECOMENDACIONES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.conceptoJuridicoFin), solicCreditoInfJuridica.SIJ_CONCEPTO_JURIDICO_FIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.conceptoEstJuridicio), solicCreditoInfJuridica.SIJ_CONCEPTO_EST_JURIDICO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.ciudad), solicCreditoInfJuridica.DPC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.departamento), solicCreditoInfJuridica.DPD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.direccion), solicCreditoInfJuridica.SIJ_DIRECCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.creadoPor), solicCreditoInfJuridica.SIJ_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJuridicaParams.fechaCreacion), solicCreditoInfJuridica.SIJ_FECHA_CREACION);

            return await GetAsyncFirst<SolicCreditoInfJuridica>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crear Olicitud Informacion Juridica Inmueble
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicCreditoInfJurInm"></param>
        /// <returns></returns>
        public async Task<SolicCreditoInfJurInm> CrearSolicCreditoInfJurInm(SolicCreditoInfJurInm solicCreditoInfJurInm)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJurInmParams.IdSolicitudInfJuridicaInmueble), solicCreditoInfJurInm.SJI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJurInmParams.idSolicitudInformacionJuridica), solicCreditoInfJurInm.SIJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJurInmParams.idSolicitudCredito), solicCreditoInfJurInm.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJurInmParams.numeroMatricula), solicCreditoInfJurInm.SJI_NUMERO_MATRICULA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJurInmParams.cedulaCatastral), solicCreditoInfJurInm.SJI_CEDULA_CATASTRAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJurInmParams.areaPrivada), solicCreditoInfJurInm.SJI_AREA_PRIVADA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJurInmParams.avaluoComercial), solicCreditoInfJurInm.SJI_VALOR_AVALUO_COMERCIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJurInmParams.avaluoCatastral), solicCreditoInfJurInm.SJI_VALOR_AVALUO_CATASTRAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJurInmParams.creadoPor), solicCreditoInfJurInm.SJI_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicCreditoInfJurInmParams.fechaCreacion), solicCreditoInfJurInm.SJI_FECHA_CREACION);

            return await GetAsyncFirst<SolicCreditoInfJurInm>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener Solicitud Credito Informacion tecnica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="requestSolicCreditoInfTecnica"></param>
        /// <returns></returns>
        public async Task<SolicCreditoInfTecnica> ObtenerSolicCreditoInfTecnica(RequestSolicCreditoInfTecnica requestSolicCreditoInfTecnica)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfTecnicaParams.idSolicitudInformacionJuridica), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfTecnicaParams.solicitudCredito), requestSolicCreditoInfTecnica.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfTecnicaParams.indicador), requestSolicCreditoInfTecnica.IND);

            return await GetAsyncFirst<SolicCreditoInfTecnica>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener solicitud Credito Informacion Tecnica Inmueble
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="requestSolicCreditoInfTecnica"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SolicCreditoInfTecInm>> ObtenerSolicCreditoInfTecInm(RequestSolicCreditoInfTecInm requestSolicCreditoInfTecInm)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfTecInmParams.idSolicitudInformaciontecnicaInmueble), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfTecInmParams.idSolicitudInformacionTecnica), requestSolicCreditoInfTecInm.SIT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfTecInmParams.idSolicitudCredito), requestSolicCreditoInfTecInm.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfTecInmParams.indicador), requestSolicCreditoInfTecInm.IND);

            return await GetAsyncList<SolicCreditoInfTecInm>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener Solicitud Credito Informacion juridica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="requestSolicCreditoInfTecnica"></param>
        /// <returns></returns>
        public async Task<SolicCreditoInfJuridica> ObtenerSolicCreditoInfJuridica(RequestSolicCreditoInfJuridica requestSolicCreditoInfJuridica)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfJuridicaParams.idSolicitudInformacionJuridica), requestSolicCreditoInfJuridica.SIJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfJuridicaParams.idSolicitudCredito), requestSolicCreditoInfJuridica.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfJuridicaParams.indicador), requestSolicCreditoInfJuridica.IND);

            return await GetAsyncFirst<SolicCreditoInfJuridica>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener solicitud credito informacion juridica inmueble
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="requestSolicCreditoInfTecnica"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SolicCreditoInfJurInm>> ObtenerSolicCreditoInfJurInm(RequestSolicCreditoInfJurInm requestSolicCreditoInfJurInm)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfJurInmParams.idSolicitudInformacionJuridicaInmueble), requestSolicCreditoInfJurInm.SJI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfJurInmParams.idSolicitudInformacionJuridica), requestSolicCreditoInfJurInm.SIJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfJurInmParams.idSolicitudCredito), requestSolicCreditoInfJurInm.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestSolicCreditoInfJurInmParams.indicador), requestSolicCreditoInfJurInm.IND);

            return await GetAsyncList<SolicCreditoInfJurInm>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crea Documento Solicitud Credito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="documentoSolicCredito"></param>
        /// <returns></returns>
        public async Task<ResponseDocumentoSolicCredito> CrearDocumentoSolicCredito(ResponseDocumentoSolicCredito documentoSolicCredito)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.idDocumentoSolicitud), documentoSolicCredito.DCS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.idSolicitudCredito), documentoSolicCredito.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.idTipoDocumento), documentoSolicCredito.TDC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.codigoBarras), documentoSolicCredito.DCS_CODIGO_BARRAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.fechaDocumento), documentoSolicCredito.DCS_FECHA_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.numeroFolios), documentoSolicCredito.DCS_NUMERO_FOLIOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.tamaño), documentoSolicCredito.DCS_TAMAÑO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.rutaImagen), documentoSolicCredito.DCS_RUTA_IMAGEN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.estado), documentoSolicCredito.DCS_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.creadoPor), documentoSolicCredito.DCS_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDocumentoSolicCreditoParams.fechaCreacion), documentoSolicCredito.DCS_FECHA_CREACION);

            return await GetAsyncFirst<ResponseDocumentoSolicCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Realiza la consulta de simulacion de cliente
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="numeroDocumento"></param>
        /// <returns></returns>
        public async Task<SimulacionCliente> ConsultarSimulacionCliente(string numeroDocumento)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSimulacionClienteParams.numeroDocumento), numeroDocumento);

            return await GetAsyncFirst<SimulacionCliente>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene los datos de solicitud de comite crédito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="datosSolicitudComite"></param>
        /// <returns></returns>
        public async Task<DatosSolicitudComite> ObtenerDatosSolicComite(Guid guid)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosSolicComiteParams.idSolicitudCredito), guid);

            return await GetAsyncFirst<DatosSolicitudComite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Repositorio actualiza solciitud credito recomendacion
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<SolicCreditoRecomendacion> ActualizaSolicCreditoRecomendacion(SolicCreditoRecomendacion request)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicCreditoRecomendacionParams.idSolicitudCredito), request.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicCreditoRecomendacionParams.observacionRecomendacion), request.SOC_OBSERVACION_RECOMENDACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicCreditoRecomendacionParams.valorRecomendadoCredito), request.SOC_VALOR_RECOMENDADO_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicCreditoRecomendacionParams.fechaActualiza), request.SOC_FECHA_ACTUALIZA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicCreditoRecomendacionParams.actualizadoPor), request.SOC_ACTUALIZADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicCreditoRecomendacionParams.tipoAlivio), request.SOC_TIPO_ALIVIO);

            return await GetAsyncFirst<SolicCreditoRecomendacion>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Consultar Solicitud Credito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ConsultaSolicitudCredito> ConsultarSolicitudCredito(ConsultaSolicitudCredito request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultarSolicitudCreditoParams.idSolicitudCredito), request.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultarSolicitudCreditoParams.identificacion), request.CLI_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumConsultarSolicitudCreditoParams.estado), request.SOC_ESTADO);

            return await GetAsyncFirst<ConsultaSolicitudCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Actualiza los datos de la solicitud de credito en Seguro
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ConsultaSolicitudCredito> ActualizaSolicCreditoSeguro(DatosActualizaSolicCreditoSeguro request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActuDatosSolicCreditoParams.idSolicitudCredito), request.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActuDatosSolicCreditoParams.convenioAseguradora), request.SOC_CONVENIO_ASEGURADORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActuDatosSolicCreditoParams.convenioAseguradoraHogar), request.SOC_CONVENIO_ASEGURADORA_HOGAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActuDatosSolicCreditoParams.idAseguradora), request.ASE_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActuDatosSolicCreditoParams.idAseguradoraHogar), request.ASE_ID_HOGAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActuDatosSolicCreditoParams.porcentajeExtraprima), request.SOC_PORC_EXTRAPRIMA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActuDatosSolicCreditoParams.actualizadoPor), request.SOC_ACTUALIZADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActuDatosSolicCreditoParams.fechaActualiza), request.SOC_FECHA_ACTUALIZA);

            return await GetAsyncFirst<ConsultaSolicitudCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crea la planilla de simulacion del cliente
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PlanillaSimulacionCredito>> CrearSimulacionCliente(CreacionSimulacionClienteDto request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSimulacionParams.numDocumento), request.documento);
            //parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSimulacionParams.tipoAbono),request.tipoAbono);
            //parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSimulacionParams.tipoVivienda), request.tipoVivienda);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSimulacionParams.valorVivienda), request.valor);
            //parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSimulacionParams.subsidio), request.subsidio);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSimulacionParams.plazo), request.plazo);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSimulacionParams.valorPrestamo), request.valorPrestamo);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSimulacionParams.valorCuota), request.valorCuota);

            return await GetAsyncList<PlanillaSimulacionCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Realiza la verificaciond e seguridad del cierre de actividad
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ResponseVerificarCierreActSeg> VerificarCierreActSeg(RequestVerificarCierreActSeg request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarCierreActSegParams.AFL_ID), request.AFL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarCierreActSegParams.TRS_ID), request.TRS_ID);

            return await GetAsyncFirst<ResponseVerificarCierreActSeg>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }



        #region Consecutivo

        /// <summary>
        /// CrearConsecutivo
        /// </summary>
        /// <param name="consecutivo"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Consecutivo> CrearConsecutivo(Consecutivo consecutivo)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_ID), consecutivo.CNS_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_DESCRIPCION), consecutivo.CNS_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_ULTIMO_NUMERO), consecutivo.CNS_ULTIMO_NUMERO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_ESTADO), consecutivo.CNS_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_CREADO_POR), consecutivo.CNS_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_ACTUALIZADO_POR), String.Empty);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_FECHA_ACTUALIZA), null);


            return await GetAsyncFirst<Consecutivo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ActualizarConsecutivo
        /// </summary>
        /// <param name="consecutivo"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Consecutivo> ActualizarConsecutivo(Consecutivo consecutivo)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_ID), consecutivo.CNS_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_DESCRIPCION), consecutivo.CNS_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_ULTIMO_NUMERO), consecutivo.CNS_ULTIMO_NUMERO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_ESTADO), consecutivo.CNS_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_CREADO_POR), consecutivo.CNS_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_ACTUALIZADO_POR), consecutivo.CNS_ACTUALIZADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_FECHA_ACTUALIZA), DateTime.Now);


            return await GetAsyncFirst<Consecutivo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerConsecutivoPorId
        /// </summary>
        /// <param name="consecutivoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Consecutivo> ObtenerConsecutivoPorId(string consecutivoid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_ID), consecutivoid);

            return await GetAsyncFirst<Consecutivo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarConsecutivoPorid
        /// </summary>
        /// <param name="consecutivoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Consecutivo> EliminarConsecutivoPorid(string consecutivoid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumConsecutivoParametros.CNS_ID), consecutivoid);

            return await GetAsyncFirst<Consecutivo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerConsecutivo
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<IEnumerable<Consecutivo>> ObtenerConsecutivo()
        {
            return await GetAsyncList<Consecutivo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        #endregion

        #region Aseguradora

        /// <summary>
        /// CrearAseguradoras
        /// </summary>
        /// <param name="aseguradoras"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Aseguradoras> CrearAseguradoras(Aseguradoras aseguradoras)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_RAZON_SOCIAL), aseguradoras.ASE_RAZON_SOCIAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_SITIO_WEB), aseguradoras.ASE_SITIO_WEB);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_ESTADO), aseguradoras.ASE_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_CREADO_POR), aseguradoras.ASE_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_ACTUALIZADO_POR), aseguradoras.ASE_ACTUALIZADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_FECHA_ACTUALIZA), DateTime.Now);

            return await GetAsyncFirst<Aseguradoras>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ActualizarAseguradoras
        /// </summary>
        /// <param name="aseguradoras"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Aseguradoras> ActualizarAseguradoras(Aseguradoras aseguradoras)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_ID), aseguradoras.ASE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_RAZON_SOCIAL), aseguradoras.ASE_RAZON_SOCIAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_SITIO_WEB), aseguradoras.ASE_SITIO_WEB);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_ESTADO), aseguradoras.ASE_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_CREADO_POR), aseguradoras.ASE_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_ACTUALIZADO_POR), aseguradoras.ASE_ACTUALIZADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_FECHA_ACTUALIZA), DateTime.Now);


            return await GetAsyncFirst<Aseguradoras>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerAseguradorasPorId
        /// </summary>
        /// <param name="aseguradorasid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Aseguradoras> ObtenerAseguradorasPorId(string aseguradorasid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_ID), aseguradorasid);

            return await GetAsyncFirst<Aseguradoras>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarAseguradorasPorid
        /// </summary>
        /// <param name="aseguradorasId"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Aseguradoras> EliminarAseguradorasPorid(string aseguradorasid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumAseguradorasParametros.ASE_ID), aseguradorasid);

            return await GetAsyncFirst<Aseguradoras>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerAseguradoras
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<IEnumerable<Aseguradoras>> ObtenerAseguradoras()
        {
            return await GetAsyncList<Aseguradoras>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }
        #endregion

        #region Alertas Automaticas


        /// <summary>
        /// CrearAlertaAutomaticas
        /// </summary>
        /// <param name="alertaautomaticas"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<AlertaAutomaticas> CrearAlertaAutomaticas(AlertaAutomaticas alertaautomaticas)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_ID), alertaautomaticas.ALA_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_DESCRIPCION), alertaautomaticas.ALA_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_MENSAJE), alertaautomaticas.ALA_MENSAJE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_MODIFICADO_POR), alertaautomaticas.ALA_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_FECHA_MODIFICACION), DateTime.Now);


            return await GetAsyncFirst<AlertaAutomaticas>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }


        /// <summary>
        /// ActualizarAlertaAutomaticas
        /// </summary>
        /// <param name="alertaautomaticas"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<AlertaAutomaticas> ActualizarAlertaAutomaticas(AlertaAutomaticas alertaautomaticas)
        {
            DynamicParameters parametros = new DynamicParameters();


            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_ID), alertaautomaticas.ALA_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_DESCRIPCION), alertaautomaticas.ALA_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_MENSAJE), alertaautomaticas.ALA_MENSAJE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_MODIFICADO_POR), alertaautomaticas.ALA_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_FECHA_MODIFICACION), DateTime.Now);


            return await GetAsyncFirst<AlertaAutomaticas>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerAlertaAutomaticasPorId
        /// </summary>
        /// <param name="alertaautomaticasid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<AlertaAutomaticas> ObtenerAlertaAutomaticasPorId(string alertaautomaticasid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_ID), alertaautomaticasid);

            return await GetAsyncFirst<AlertaAutomaticas>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarAseguradorasPorid
        /// </summary>
        /// <param name="alertaautomaticasid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<AlertaAutomaticas> EliminarAlertaAutomaticasPorid(string alertaautomaticasid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumAlertaParametros.ALA_ID), alertaautomaticasid);

            return await GetAsyncFirst<AlertaAutomaticas>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarAseguradorasPorid
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<IEnumerable<AlertaAutomaticas>> ObtenerAlertaAutomaticas()
        {
            return await GetAsyncList<AlertaAutomaticas>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        #endregion

        #region ColorGrilla

        /// <summary>
        /// CrearColorGrilla
        /// </summary>
        /// <param name="colorGrilla"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<ColorGrilla> CrearColorGrilla(ColorGrilla colorgrilla)


        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_DESCRIPCION), colorgrilla.CLG_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_ESTILO_COLOR), colorgrilla.CLG_ESTILO_COLOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_ESTADO), colorgrilla.CLG_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_CREADO_POR), colorgrilla.CLG_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_ACTUALIZADO_POR), colorgrilla.CLG_ACTUALIZADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_FECHA_ACTUALIZA), DateTime.Now);


            return await GetAsyncFirst<ColorGrilla>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ActualizarColorGrilla
        /// </summary>
        /// <param name="colorgrilla"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<ColorGrilla> ActualizarColorGrilla(ColorGrilla colorgrilla)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_ID), colorgrilla.CLG_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_DESCRIPCION), colorgrilla.CLG_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_ESTILO_COLOR), colorgrilla.CLG_ESTILO_COLOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_ESTADO), colorgrilla.CLG_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_CREADO_POR), colorgrilla.CLG_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_ACTUALIZADO_POR), colorgrilla.CLG_ACTUALIZADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_FECHA_ACTUALIZA), DateTime.Now);


            return await GetAsyncFirst<ColorGrilla>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerColorGrillaPorId
        /// </summary>
        /// <param name="colorgrillaid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<ColorGrilla> ObtenerColorGrillaPorId(string colorgrillaid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_ID), colorgrillaid);

            return await GetAsyncFirst<ColorGrilla>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarColorGrillaPorid
        /// </summary>
        /// <param name="colorgrillaid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<ColorGrilla> EliminarColorGrillaPorid(string colorgrillaid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumColorGrillaParametros.CLG_ID), colorgrillaid);

            return await GetAsyncFirst<ColorGrilla>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerColorGrilla
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<IEnumerable<ColorGrilla>> ObtenerColorGrilla()
        {
            return await GetAsyncList<ColorGrilla>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }




        #endregion

        #region Estado Actividad

        /// <summary>
        /// CrearEstadoActividad
        /// </summary>
        /// <param name="estadoActividad"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<EstadoActividad> CrearEstadoActividad(EstadoActividad estadoActividad)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_DESCRIPCION), estadoActividad.ESA_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_ESTADO), estadoActividad.ESA_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_CREADO_POR), estadoActividad.ESA_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_MODIFICADO_POR), estadoActividad.ESA_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_FECHA_MODIFICACION), DateTime.Now);

            return await GetAsyncFirst<EstadoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ActualizarEstadoActividad
        /// </summary>
        /// <param name="estadoActividad"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<EstadoActividad> ActualizarEstadoActividad(EstadoActividad estadoActividad)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_ID), estadoActividad.ESA_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_DESCRIPCION), estadoActividad.ESA_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_ESTADO), estadoActividad.ESA_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_CREADO_POR), estadoActividad.ESA_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_MODIFICADO_POR), estadoActividad.ESA_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_FECHA_MODIFICACION), DateTime.Now);


            return await GetAsyncFirst<EstadoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerEstadoActividadPorId
        /// </summary>
        /// <param name="estadoActividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>03/05/2021</date>
        /// 

        public async Task<EstadoActividad> ObtenerEstadoActividadPorId(string estadoActividadid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_ID), estadoActividadid);

            return await GetAsyncFirst<EstadoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarEstadoActividadPorid
        /// </summary>
        /// <param name="estadoActividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>03/05/2021</date>
        /// 
        public async Task<EstadoActividad> EliminarEstadoActividadPorid(string estadoActividadid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoActividadParametros.ESA_ID), estadoActividadid);

            return await GetAsyncFirst<EstadoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerEstadoActividad
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>03/05/2021</date>
        /// 
        public async Task<IEnumerable<EstadoActividad>> ObtenerEstadoActividad()
        {
            return await GetAsyncList<EstadoActividad>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }


        #endregion

        #region Estado Solicitud
        /// <summary>
        /// CrearEstadoSolicitud
        /// </summary>
        /// <param name="estadosolicitud"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<EstadoSolicitud> CrearEstadoSolicitud(EstadoSolicitud estadosolicitud)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_DESCRIPCION), estadosolicitud.ESS_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_SIGLA), estadosolicitud.ESS_SIGLA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_ESTADO), estadosolicitud.ESS_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_CREADO_POR), estadosolicitud.ESS_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_MODIFICADO_POR), estadosolicitud.ESS_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_FECHA_MODIFICACION), DateTime.Now);

            return await GetAsyncFirst<EstadoSolicitud>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ActualizarEstadoSolicitud
        /// </summary>
        /// <param name="estadosolicitud"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<EstadoSolicitud> ActualizarEstadoSolicitud(EstadoSolicitud estadosolicitud)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_ID), estadosolicitud.ESS_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_DESCRIPCION), estadosolicitud.ESS_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_SIGLA), estadosolicitud.ESS_SIGLA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_ESTADO), estadosolicitud.ESS_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_CREADO_POR), estadosolicitud.ESS_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_MODIFICADO_POR), estadosolicitud.ESS_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_FECHA_MODIFICACION), DateTime.Now);


            return await GetAsyncFirst<EstadoSolicitud>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerEstadoSolicitudPorId
        /// </summary>
        /// <param name="estadodolicitudid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<EstadoSolicitud> ObtenerEstadoSolicitudPorId(string estadosolicitudid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_ID), estadosolicitudid);

            return await GetAsyncFirst<EstadoSolicitud>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarEstadoSolicitudPorid
        /// </summary>
        /// <param name="estadosolicitudid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<EstadoSolicitud> EliminarEstadoSolicitudPorid(string estadosolicitudid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumEstadoSolicitudParametros.ESS_ID), estadosolicitudid);

            return await GetAsyncFirst<EstadoSolicitud>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ObtenerEstadoSolicitud
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<IEnumerable<EstadoSolicitud>> ObtenerEstadoSolicitud()
        {
            return await GetAsyncList<EstadoSolicitud>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        #endregion

        #region Tipo Actividad

        /// <summary>
        /// CrearTipoActividad
        /// </summary>
        /// <param name="tipoActividad"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<TipoActividad> CrearTipoActividad(TipoActividad tipoActividad)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_DESCRIPCION), tipoActividad.TAC_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_ESTADO), tipoActividad.TAC_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_CREADO_POR), tipoActividad.TAC_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_MODIFICADO_POR), tipoActividad.TAC_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_FECHA_MODIFICACION), DateTime.Now);


            return await GetAsyncFirst<TipoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ActualizarTipoActividad
        /// </summary>
        /// <param name="tipoActividad"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<TipoActividad> ActualizarTipoActividad(TipoActividad tipoActividad)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_ID), tipoActividad.TAC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_DESCRIPCION), tipoActividad.TAC_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_ESTADO), tipoActividad.TAC_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_CREADO_POR), tipoActividad.TAC_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_MODIFICADO_POR), tipoActividad.TAC_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_FECHA_MODIFICACION), DateTime.Now);


            return await GetAsyncFirst<TipoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerTipoActividadPorId
        /// </summary>
        /// <param name="tipoActividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<TipoActividad> ObtenerTipoActividadPorId(string tipoActividadid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_ID), tipoActividadid);

            return await GetAsyncFirst<TipoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarTipoActividadPorid
        /// </summary>
        /// <param name="tipoActividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<TipoActividad> EliminarTipoActividadPorid(string tipoActividadid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoActividadParametros.TAC_ID), tipoActividadid);

            return await GetAsyncFirst<TipoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ObtenerTipoActividad
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<IEnumerable<TipoActividad>> ObtenerTipoActividad()
        {
            return await GetAsyncList<TipoActividad>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        #endregion

        #region tipo Documento

        /// <summary>
        /// CrearTipoDocumento
        /// </summary>
        /// <param name="tipodocumento"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<TipoDocumento> CrearTipoDocumento(TipoDocumento tipodocumento)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_DESCRIPCION), tipodocumento.TDC_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_ESTADO), tipodocumento.TDC_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_CREADO_POR), tipodocumento.TDC_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_MODIFICADO_POR), tipodocumento.TDC_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_FECHA_MODIFICACION), DateTime.Now);


            return await GetAsyncFirst<TipoDocumento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ActualizarTipoDocumento
        /// </summary>
        /// <param name="tipodocumento"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<TipoDocumento> ActualizarTipoDocumento(TipoDocumento tipodocumento)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_ID), tipodocumento.TDC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_DESCRIPCION), tipodocumento.TDC_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_ESTADO), tipodocumento.TDC_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_CREADO_POR), tipodocumento.TDC_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_MODIFICADO_POR), tipodocumento.TDC_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_FECHA_MODIFICACION), DateTime.Now);


            return await GetAsyncFirst<TipoDocumento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerTipoDocumentoPorId
        /// </summary>
        /// <param name="tipodocumentoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 

        public async Task<TipoDocumento> ObtenerTipoDocumentoPorId(string tipodocumentoid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_ID), tipodocumentoid);

            return await GetAsyncFirst<TipoDocumento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarTipoDocumentoPorid
        /// </summary>
        /// <param name="tipodocumentoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<TipoDocumento> EliminarTipoDocumentoPorid(string tipodocumentoid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumTipoDocumentoParametros.TDC_ID), tipodocumentoid);

            return await GetAsyncFirst<TipoDocumento>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ObtenerTipoDocumento
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<IEnumerable<TipoDocumento>> ObtenerTipoDocumento()
        {
            return await GetAsyncList<TipoDocumento>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        #endregion

        #region Flujo

        /// <summary>
        /// CrearFlujo
        /// </summary>
        /// <param name="flujo"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<Flujo> CrearFlujo(Flujo flujo)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_DESCRIPCION), flujo.FLU_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_ESTADO), flujo.FLU_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_ORDEN), flujo.FLU_ORDEN);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_CREADO_POR), flujo.FLU_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_MODIFICADO_POR), flujo.FLU_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_FECHA_MODIFICACION), DateTime.Now);


            return await GetAsyncFirst<Flujo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ActualizarFlujo
        /// </summary>
        /// <param name="flujo"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<Flujo> ActualizarFlujo(Flujo flujo)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_ID), flujo.FLU_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_DESCRIPCION), flujo.FLU_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_ORDEN), flujo.FLU_ORDEN);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_ESTADO), flujo.FLU_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_CREADO_POR), flujo.FLU_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_MODIFICADO_POR), flujo.FLU_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_FECHA_MODIFICACION), DateTime.Now);


            return await GetAsyncFirst<Flujo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerFlujoPorId
        /// </summary>
        /// <param name="flujoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 

        public async Task<Flujo> ObtenerFlujoPorId(string flujoid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_ID), flujoid);

            return await GetAsyncFirst<Flujo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarFlujoPorid
        /// </summary>
        /// <param name="flujoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<Flujo> EliminarFlujoPorid(string flujoid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoParametros.FLU_ID), flujoid);

            return await GetAsyncFirst<Flujo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ObtenerFlujoPorId
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<IEnumerable<Flujo>> ObtenerFlujo()
        {
            return await GetAsyncList<Flujo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        #endregion

        #region FlujoTipoCredito
        /// <summary>
        /// CrearFlujoTipoCredito
        /// </summary>
        /// <param name="flujotipoCredito"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<FlujoTipoCredito> CrearFlujoTipoCredito(FlujoTipoCredito flujotipoCredito)
        {
            DynamicParameters parametros = new DynamicParameters();


            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FLU_ID), flujotipoCredito.FLU_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.TCR_ID), flujotipoCredito.TCR_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_ESTADO), flujotipoCredito.FTC_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_CREADO_POR), flujotipoCredito.FTC_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_FECHA_CREACION), flujotipoCredito.FTC_FECHA_CREACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_MODIFICADO_POR), flujotipoCredito.FTC_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_FECHA_MODIFICACION), flujotipoCredito.FTC_FECHA_MODIFICACION);


            return await GetAsyncFirst<FlujoTipoCredito>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ActualizarFlujoTipoCredito
        /// </summary>
        /// <param name="flujotipoCredito"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<FlujoTipoCredito> ActualizarFlujoTipoCredito(FlujoTipoCredito flujotipoCredito)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_ID), flujotipoCredito.FTC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FLU_ID), flujotipoCredito.FLU_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.TCR_ID), flujotipoCredito.TCR_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_ESTADO), flujotipoCredito.FTC_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_CREADO_POR), flujotipoCredito.FTC_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_FECHA_CREACION), flujotipoCredito.FTC_FECHA_CREACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_MODIFICADO_POR), flujotipoCredito.FTC_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_FECHA_MODIFICACION), flujotipoCredito.FTC_FECHA_MODIFICACION);


            return await GetAsyncFirst<FlujoTipoCredito>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerFlujoTipoCreditoPorId
        /// </summary>
        /// <param name="flujotipoCreditoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 

        public async Task<FlujoTipoCredito> ObtenerFlujoTipoCreditoPorId(string flujotipoCreditoid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_ID), flujotipoCreditoid);

            return await GetAsyncFirst<FlujoTipoCredito>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarFlujoTipoCreditoPorid
        /// </summary>
        /// <param name="flujotipoCreditoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<FlujoTipoCredito> EliminarFlujoTipoCreditoPorid(string flujotipoCreditoid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumFlujoTipoCreditoParametros.FTC_ID), flujotipoCreditoid);

            return await GetAsyncFirst<FlujoTipoCredito>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ObtenerFlujoTipoCredito
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 

        public async Task<IEnumerable<FlujoTipoCredito>> ObtenerFlujoTipoCredito()
        {
            return await GetAsyncList<FlujoTipoCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        #endregion

        #region Actividad Flujo

        /// <summary>
        /// CrearActividadFlujo
        /// </summary>
        /// <param name="actividadflujo"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<ActividadFlujo> CrearActividadFlujo(ActividadFlujo actividadflujo)
        {
            DynamicParameters parametros = new DynamicParameters();


            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.FLU_ID), actividadflujo.FLU_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.TAC_ID), actividadflujo.TAC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_ORDEN), actividadflujo.AFL_ORDEN);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_TIEMPO), actividadflujo.AFL_TIEMPO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_ACTIVIDAD_AUTOMATICA), actividadflujo.AFL_ACTIVIDAD_AUTOMATICA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_ACTIVIDAD_PRINCIPAL), actividadflujo.AFL_ACTIVIDAD_PRINCIPAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_PUEDE_DELEGAR), actividadflujo.AFL_PUEDE_DELEGAR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_CARGA_ARCHIVOS), actividadflujo.AFL_CARGA_ARCHIVOS);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_VISUALIZA_ARCHIVOS), actividadflujo.AFL_VISUALIZA_ARCHIVOS);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_CAPTURA_DATOS_TEC), actividadflujo.AFL_CAPTURA_DATOS_TEC);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_CAPTURA_DATOS_JUR), actividadflujo.AFL_CAPTURA_DATOS_JUR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_CAPTURA_DATOS_FIN), actividadflujo.AFL_CAPTURA_DATOS_FIN);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_VISUALIZA_DATOS_BAS), actividadflujo.AFL_VISUALIZA_DATOS_BAS);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_VIISUALIZA_DATOS_GAR), actividadflujo.AFL_VIISUALIZA_DATOS_GAR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_VISUALIZA_DATOS_FIN), actividadflujo.AFL_VISUALIZA_DATOS_FIN);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_GENERA_PDF_RESUMEN), actividadflujo.AFL_GENERA_PDF_RESUMEN);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_CONSULTA_BURO), actividadflujo.AFL_CONSULTA_BURO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_ENVIO_NOTIFICACION), actividadflujo.AFL_ENVIO_NOTIFICACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_ENVIO_NOTIFICACION_VENC), actividadflujo.AFL_ENVIO_NOTIFICACION_VENC);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_ENVIA_NOTIFICACION_CLIENTE), actividadflujo.AFL_ENVIA_NOTIFICACION_CLIENTE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_ESTADO), actividadflujo.AFL_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_CREADO_POR), actividadflujo.AFL_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_FECHA_CREACION), actividadflujo.AFL_FECHA_CREACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_MODIFICADO_POR), actividadflujo.AFL_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_FECHA_MODIFICACION), actividadflujo.AFL_FECHA_MODIFICACION);



            return await GetAsyncFirst<ActividadFlujo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerActividadFlujoPorId
        /// </summary>
        /// <param name="actividadflujoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 

        public async Task<ActividadFlujo> ObtenerActividadFlujoPorId(string actividadflujoid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_ID), actividadflujoid);

            return await GetAsyncFirst<ActividadFlujo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarActividadFlujoPorid
        /// </summary>
        /// <param name="actividadflujoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<ActividadFlujo> EliminarActividadFlujoPorid(string actividadflujoid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumActividadFlujoParametros.AFL_ID), actividadflujoid);

            return await GetAsyncFirst<ActividadFlujo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ObtenerActividadFlujo
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 

        public async Task<IEnumerable<ActividadFlujo>> ObtenerActividadFlujo()
        {
            return await GetAsyncList<ActividadFlujo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        #endregion

        #region Usuario Actividad

        /// <summary>
        /// CrearUsuarioActividad
        /// </summary>
        /// <param name="usuarioactividad"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 

        public async Task<UsuarioActividad> CrearUsuarioActividad(UsuarioActividad usuarioactividad)
        {
            DynamicParameters parametros = new DynamicParameters();


            parametros.Add(HelpersEnums.GetEnumDescription(EnumUsuarioActividadParametros.AFL_ID), usuarioactividad.AFL_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumUsuarioActividadParametros.ID_USERS), usuarioactividad.ID_USERS);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumUsuarioActividadParametros.USA_ESTADO), usuarioactividad.USA_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumUsuarioActividadParametros.USA_CREADO_POR), usuarioactividad.USA_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumUsuarioActividadParametros.USA_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumUsuarioActividadParametros.USA_MODIFICADO_POR), usuarioactividad.USA_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumUsuarioActividadParametros.USA_FECHA_MODIFICACION), DateTime.Now);



            return await GetAsyncFirst<UsuarioActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerUsuarioActividadPorId
        /// </summary>
        /// <param name="usuarioactividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 

        public async Task<UsuarioActividad> ObtenerUsuarioActividadPorId(string usuarioactividadid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumUsuarioActividadParametros.USA_ID), usuarioactividadid);

            return await GetAsyncFirst<UsuarioActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarUsuarioActividadPorid
        /// </summary>
        /// <param name="usuarioactividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<UsuarioActividad> EliminarUsuarioActividadPorid(string usuarioactividadid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumUsuarioActividadParametros.USA_ID), usuarioactividadid);

            return await GetAsyncFirst<UsuarioActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
        /// <summary>
        /// ObtenerUsuarioActividad
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<IEnumerable<UsuarioActividad>> ObtenerUsuarioActividad()
        {
            return await GetAsyncList<UsuarioActividad>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }
        #endregion

        #region Documento Actividad

        /// <summary>
        /// CrearDocumentoActividad
        /// </summary>
        /// <param name="documentoactividad"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 


        public async Task<DocumentoActividad> CrearDocumentoActividad(DocumentoActividad documentoactividad)
        {
            DynamicParameters parametros = new DynamicParameters();


            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.AFL_ID), documentoactividad.AFL_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.TDC_ID), documentoactividad.TDC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_ORDEN), documentoactividad.DCA_ORDEN);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_OBLIGATORIO), documentoactividad.DCA_OBLIGATORIO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_CARGA), documentoactividad.DCA_CARGA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_VISUALIZA), documentoactividad.DCA_VISUALIZA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_VISUALIZA_CLIENTE), documentoactividad.DCA_VISUALIZA_CLIENTE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_ESTADO), documentoactividad.DCA_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_FECHA_CREACION), documentoactividad.DCA_FECHA_CREACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_CREADO_POR), documentoactividad.DCA_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_MODIFICADO_POR), documentoactividad.DCA_MODIFICADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_FECHA_MODIFICACION), documentoactividad.DCA_FECHA_MODIFICACION);


            return await GetAsyncFirst<DocumentoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerDocumentoActividadPorId
        /// </summary>
        /// <param name="documentoactividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 

        public async Task<DocumentoActividad> ObtenerDocumentoActividadPorId(string documentoactividadid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_ID), documentoactividadid);

            return await GetAsyncFirst<DocumentoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarDocumentoActividadPorid
        /// </summary>
        /// <param name="documentoactividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 
        public async Task<DocumentoActividad> EliminarDocumentoActividadPorid(string documentoactividadid)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumDocumentoActividadParametros.DCA_ID), documentoactividadid);

            return await GetAsyncFirst<DocumentoActividad>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerDocumentoActividad
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>06/05/2021</date>
        /// 

        public async Task<IEnumerable<DocumentoActividad>> ObtenerDocumentoActividad()
        {
            return await GetAsyncList<DocumentoActividad>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }



        #endregion

        /// <summary>
        /// Obtiene los datos de un comite de credito
        /// </summary>
        /// <param name="datosComiteCredito"></param>
        /// <returns></returns>
        public async Task<IEnumerable<DatosComiteCredito>> ObtenerComiteCredito(DatosComiteCredito datosComiteCredito)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.codigoComite), datosComiteCredito.COC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.fecha), datosComiteCredito.COC_FECHA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.numeroComite), datosComiteCredito.COC_NUMERO_COMITE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.codigoEstado), datosComiteCredito.COC_ESTADO);

            var respuesta = await GetAsyncList<DatosComiteCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return respuesta;
        }

        /// <summary>
        /// Aprueba el comite de crédito
        /// </summary>
        /// <param name="datosComiteCredito"></param>
        /// <returns></returns>
        public async Task<DatosComiteCredito> AprobarComiteCredito(DatosComiteCredito datosComiteCredito)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.codigoComite), datosComiteCredito.COC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.fechaActualiza), datosComiteCredito.COC_FECHA_ACTUALIZA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.actualizadoPor), datosComiteCredito.COC_ACTUALIZADO_POR);

            return await GetAsyncFirst<DatosComiteCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }


        /// <summary>
        /// Obtiene todos los integrantes del comite de credito
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<IntegranteComite>> ObtenerIntegranteComite()
        {
            return await GetAsyncList<IntegranteComite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene todos los integrantes del comite de credito
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TemaComite>> ObtenerTemasComite()
        {
            return await GetAsyncList<TemaComite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene los integrantes d eun comité segun el numero de comité
        /// </summary>
        /// <param name="integranteComite"></param>
        /// <returns></returns>
        public async Task<IEnumerable<IntegrantePorComite>> ObtenerComiteCreditoIntegrante(IntegrantePorComite integrantePorComite)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumObtenerComiteCreditoIntegranteParams.idIntegrantePorComite), integrantePorComite.COI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumObtenerComiteCreditoIntegranteParams.idComite), integrantePorComite.COC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumObtenerComiteCreditoIntegranteParams.indicador), integrantePorComite.INDICADOR!=0? integrantePorComite.INDICADOR:2);

            return await GetAsyncList<IntegrantePorComite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crea comite credito
        /// </summary>
        /// <param name="datosComiteCredito"></param>
        /// <returns></returns>
        public async Task<DatosComiteCredito> CrearComiteCredito(DatosComiteCredito datosComiteCredito)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.codigoComite), datosComiteCredito.COC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.fecha), datosComiteCredito.COC_FECHA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.lugar), datosComiteCredito.COC_LUGAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.horaInicio), datosComiteCredito.COC_HORA_INICIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.horaFinalizacion), datosComiteCredito.COC_HORA_FINALIZACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.desarrollo), datosComiteCredito.COC_DESARROLLO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.temasAprobacion), datosComiteCredito.COC_TEMAS_APROBACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.anotacion), datosComiteCredito.COC_ANOTACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.cargoAnalista), datosComiteCredito.COC_CARGO_ANALISTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.creadoPor), datosComiteCredito.COC_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.fechaCreacion), DateTime.Today);

            return await GetAsyncFirst<DatosComiteCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crea untegrante comite credito
        /// </summary>
        /// <param name="integrante"></param>
        /// <returns></returns>
        public async Task<ComiteIntegrante> CrearComiteCreditoIntegrante(ComiteIntegrante integrante)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCrearIntegranteParams.idIntegranteComite), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCrearIntegranteParams.idComiteCredito), integrante.COC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCrearIntegranteParams.idAsistente), integrante.ICO_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCrearIntegranteParams.orden), integrante.COI_ORDEN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCrearIntegranteParams.creadoPor), integrante.COI_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCrearIntegranteParams.fechaCreacion), DateTime.Now);

            return await GetAsyncFirst<ComiteIntegrante>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crea tema para comite decrédito
        /// </summary>
        /// <param name="temaComiteCredito"></param>
        /// <returns></returns>
        public async Task<TemaComiteCredito> CrearComiteCreditoTemas(TemaComiteCredito temaComiteCredito)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnmuCrearTemaComiteCreditoParams.idTema), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnmuCrearTemaComiteCreditoParams.idComiteCredito), temaComiteCredito.COC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnmuCrearTemaComiteCreditoParams.codigoTema), temaComiteCredito.TCO_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnmuCrearTemaComiteCreditoParams.orden), temaComiteCredito.COT_ORDEN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnmuCrearTemaComiteCreditoParams.observacion), temaComiteCredito.COT_OBSERVACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnmuCrearTemaComiteCreditoParams.creadoPor), temaComiteCredito.COT_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnmuCrearTemaComiteCreditoParams.fechaCreacion), DateTime.Now);

            return await GetAsyncFirst<TemaComiteCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene la solicitud de comite de credito
        /// </summary>
        /// <param name="solicitudComite"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SolicitudComite>> ObtenerComiteCreditoSolicitud(SolicitudComite solicitudComite)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoParams.idComiteCredito), solicitudComite.COC_ID);

            return await GetAsyncList<SolicitudComite>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Crear solicitud Credito comité
        /// </summary>
        /// <param name="solicitudComite"></param>
        /// <returns></returns>
        public async Task<SolicitudComiteCreacion> CrearComiteCreditoSolicitud(SolicitudComiteCreacion solicitudComite)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.idComiteSolicitud), solicitudComite.COS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.idSolicitudCredito), solicitudComite.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.idComiteCredito), solicitudComite.COC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.resultado), solicitudComite.COS_RESULTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.aprobada), solicitudComite.COS_APROBADA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.rechazada), solicitudComite.COS_RECHAZADA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.creadoPor), solicitudComite.COS_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.fechaCreacion), solicitudComite.COS_FECHA_CREACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.valorCredito), solicitudComite.COS_VALOR_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.plazoCredito), solicitudComite.COS_PLAZO_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionComiteSolicitudCreditoParams.teaCredito), solicitudComite.COS_TEA_CREDITO);

            return await GetAsyncFirst<SolicitudComiteCreacion>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener Historial Comercial Buro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<HistorialCredito> ObtenerHistorialComercialBuro(string request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumHistorialCreditioParams.identificacion), request);

            var historialBuro = await GetAsyncFirst<HistorialCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return historialBuro;
        }

        /// <summary>
        /// Obtiene comite de credito temas
        /// </summary>
        /// <param name="solicitudComite"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TemaComiteCredito>> ObtenerComiteCreditoTemas(RequestTemaComiteCredito solicitudComite)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestTemasComiteParams.idTema), solicitudComite.COT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestTemasComiteParams.idComite), solicitudComite.COC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRequestTemasComiteParams.indicador), solicitudComite.IND);

            return await GetAsyncList<TemaComiteCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Actualiza Solic Credito Tasas
        /// </summary>
        /// <param name="TasaSolicitudCredito"></param>
        /// <returns></returns>
        public async Task<TasaSolicitudCredito> ActualizaSolicCreditoTasas(TasaSolicitudCredito TasaSolicitudCredito)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSolicitudCreditoParams.IdSolicitudCredito), TasaSolicitudCredito.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSolicitudCreditoParams.TasaFrech), TasaSolicitudCredito.SOC_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSolicitudCreditoParams.ValorAlivio), TasaSolicitudCredito.SOC_VALOR_ALIVIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSolicitudCreditoParams.ActualizadoPor), TasaSolicitudCredito.SOC_ACTUALIZADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSolicitudCreditoParams.FechaActualizacion), DateTime.Now);

            return await GetAsyncFirst<TasaSolicitudCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener Fuentes Recursos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<FuenteRecursos>> ObtenerFuentesRecursos()
        {
            return await GetAsyncList<FuenteRecursos>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener Desembolsos Solicitud
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SolicitudDesembolso>> ObtenerDesembolsosSolicitud(SolicitudDesembolso solicitud)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParams.FechaDesembolso), solicitud.SID_FECHA_DESEMBOLSO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParams.DocumentoCliente), solicitud.DOCUMENTO_CLIENTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParams.Aplicado), solicitud.APLICADO);

            var retornado= await GetAsyncList<SolicitudDesembolso>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            foreach (var retorno in retornado)
            {
                retorno.SID_APLICADO_POR = Guid.NewGuid();
            }

            return retornado;
        }

        /// <summary>
        /// Crear Solic Credito Desembolsos
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<SolicitudCreditosDesembolsos> CrearSolicCreditoDesembolsos(SolicitudCreditosDesembolsos solicitud)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParameters.IdSolicitudDesembolso), solicitud.SID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParameters.IdSolicitudCredito), solicitud.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParameters.IdFuenteRecursos), solicitud.FRC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParameters.ValorDesembolso), solicitud.SID_VALOR_DESEMBOLSO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParameters.FechaDesembolso), solicitud.SID_FECHA_DESEMBOLSO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParameters.CreadoPor), solicitud.CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParameters.FechaCreacion), DateTime.Now);

            return await GetAsyncFirst<SolicitudCreditosDesembolsos>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// AplicarDesembolsoSolicitud
        /// </summary>
        /// <param name="desembolso"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<DesembolsoCreditoSolicitud> AplicarDesembolsoSolicitud(DesembolsoCreditoSolicitud desembolso)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumDesembolsoCreditoSolicitudParametros.SOC_ID), desembolso.SOC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDesembolsoCreditoSolicitudParametros.SID_ID), desembolso.SID_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDesembolsoCreditoSolicitudParametros.SID_FECHA_APLICACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDesembolsoCreditoSolicitudParametros.SID_APLICADO_POR), desembolso.SID_APLICADO_POR);


            return await GetAsyncFirst<DesembolsoCreditoSolicitud>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerCausalDesistimiento
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<IEnumerable<ObtenerCausalDesistimiento>> ObtenerCausalDesistimiento()
        {
            return await GetAsyncList<ObtenerCausalDesistimiento>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerDatosReparto
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<IEnumerable<DatosReparto>> ObtenerDatosReparto()
        {
            return await GetAsyncList<DatosReparto>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<CreditoFinanciero> CrearSolicCreditoFinancieros(CreditoFinanciero solicitud)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.IdSolicitudF), solicitud.SOF_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.IdSolicitudCredito), solicitud.SOC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.ConceptoSalario), solicitud.SOF_CONCEPTO_SALARIO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.ValorConceptoSalario), solicitud.SOF_VALOR_CONCEPTO_SALARIO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.Concepto1), solicitud.SOF_CONCEPTO_1);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.ValorConcepto1), solicitud.SOF_VALOR_CONCEPTO_1);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.Concepto2), solicitud.SOF_CONCEPTO_2);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.ValorConcepto2), solicitud.SOF_VALOR_CONCEPTO_2);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.Concepto3), solicitud.SOF_CONCEPTO_3);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.ValorConcepto3), solicitud.SOF_VALOR_CONCEPTO_3);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.Concepto4), solicitud.SOF_CONCEPTO_4);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.ValorConcepto4), solicitud.SOF_VALOR_CONCEPTO_4);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.Concepto5), solicitud.SOF_CONCEPTO_5);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.ValorConcepto5), solicitud.SOF_VALOR_CONCEPTO_5);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.Concepto6), solicitud.SOF_CONCEPTO_6);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.ValorConcepto6), solicitud.SOF_VALOR_CONCEPTO_6);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.ValorTotalIngresos), solicitud.SOF_VALOR_TOTAL_INGRESOS);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.ValorTotalEgresos), solicitud.SOF_VALOR_TOTAL_EGRESOS);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.CreadoPor), solicitud.SOF_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoFinancieroParams.FechaCreacion), solicitud.SOF_FECHA_CREACION);


            return await GetAsyncFirst<CreditoFinanciero>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }


        /// <summary>
        /// Obtiene los datos de reparto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DatosReparto> ObtenerDatosReparto(Guid request)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumDatosRepartoParams.IdSolicitud), request);

            return await GetAsyncFirst<DatosReparto>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Desistir Desembolso Solicitud
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DesistimientoDesembolso> DesistirDesembolsoSolicitud(DesistimientoDesembolso solicitud)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumDesistimientoDesembolsoSolicitudParams.IdSolicitudDesistimiento), solicitud.SID_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDesistimientoDesembolsoSolicitudParams.IdCdd), solicitud.CDD_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDesistimientoDesembolsoSolicitudParams.ObservacionAnulacion), solicitud.SID_OBSERVACION_ANULACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDesistimientoDesembolsoSolicitudParams.AnuladoPor), solicitud.SID_ANULADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDesistimientoDesembolsoSolicitudParams.FechaAnulacion), DateTime.Now.ToString("yyyy-MM-dd"));

            return await GetAsyncFirst<DesistimientoDesembolso>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Validar documentos flujo
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ValidacionDocumentos>> ValidarDocumentosFlujo(ValidacionDocumentos solicitud)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumValidacionDocumentosParams.IdSolicitud), solicitud.SOC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumValidacionDocumentosParams.IdTipoCredito), solicitud.TCR_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumValidacionDocumentosParams.Orden), solicitud.ORDEN);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumValidacionDocumentosParams.Principal), solicitud.PRINCIPAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumValidacionDocumentosParams.DocSeguroVida), solicitud.DOC_SEGURO_VIDA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumValidacionDocumentosParams.DocSeguroHogar), solicitud.DOC_SEGURO_HOGAR);

            return await GetAsyncList<ValidacionDocumentos>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<ActualizacionSolicitudCreditoDesemFirma> ActualizaSolicCreditoDesembolso(ActualizacionSolicitudCreditoDesemFirma solicitud)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudDesembolsoParams.IdSolicitudCredito), solicitud.SOC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudDesembolsoParams.ValidaDesembolso), solicitud.SOC_VALIDA_DESEMBOLSO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudDesembolsoParams.ObservacionValidaDesembolso), solicitud.SOC_OBSERVACION_VALIDA_DES);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudDesembolsoParams.ActualizadoPor), solicitud.SOC_ACTUALIZADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudDesembolsoParams.FechaActualiza), solicitud.SOC_FECHA_ACTUALIZA);

            return await GetAsyncFirst<ActualizacionSolicitudCreditoDesemFirma>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        /// <summary>
        /// Actualiza solicitud de firmas
        /// </summary>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<ActualizacionSolicitudCreditoDesemFirma> ActualizaSolicCreditoFirmas(ActualizacionSolicitudCreditoDesemFirma solicitud)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudFirmasParams.IdSolicitudCredito), solicitud.SOC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudFirmasParams.ValidaFirmas), solicitud.SOC_VALIDA_FIRMAS);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudFirmasParams.ObservacionValidaFirmas), solicitud.SOC_OBSERVACION_VALIDA_FIRMA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudFirmasParams.ActualizadoPor), solicitud.SOC_ACTUALIZADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaSolicitudFirmasParams.FechaActualiza), solicitud.SOC_FECHA_ACTUALIZA);

            return await GetAsyncFirst<ActualizacionSolicitudCreditoDesemFirma>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        /// <summary>
        /// Actualiza el radicado de una solicitud
        /// </summary>
        /// <param name="sOC_ID"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public async Task<object> ActualizarRadicadoSolicitud(Guid sOC_ID, string barCode)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaRadicadoParams.idSolicitud), sOC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumActualizaRadicadoParams.radicado), barCode);
            

            return await GetAsyncFirst<object>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        /// <summary>
        /// Obtener datos personales simulacion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<SimulacionDatosPersonales> ObtenerSimulacionPersonales(string request)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonalesParams.NumeroDocumento), request);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonalesParams.Indicador), 3);


            return await GetAsyncFirst<SimulacionDatosPersonales>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        /// <summary>
        /// Obtiene cuenta por cedula
        /// </summary>
        /// <param name="clienteIdentificacion"></param>
        /// <returns></returns>
        public async Task<Cuenta> ObtenerCuentaById(string clienteIdentificacion)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaParameters.IdCliente), clienteIdentificacion);


            return await GetAsyncFirst<Cuenta>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<DatosComiteCredito> ActualizarRadicadoComiteCredito(int comiteNumero, string barCode)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.numeroComite), comiteNumero);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumDatosComiteCreditoParams.radicado), barCode);


            return await GetAsyncFirst<DatosComiteCredito>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<DatosFinancierosPersonales> ObtenerDatosFinancierosPersonales(string request)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumDatosFinancierosPersonalesParams.identificacion), request);


            return await GetAsyncFirst<DatosFinancierosPersonales>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Actualiza5r datos personales vivienda
        /// </summary>
        /// <param name="peticion"></param>
        /// <returns></returns>
        public async Task<SimulacionDatosPersonales> ActualizarPersonalesVivienda(SimulacionDatosPersonales peticion)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonalesParams.ValorInmueble), peticion.SDP_VALOR_INMUEBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonalesParams.TipoVivienda), peticion.TIPO_VIVIENDA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonalesParams.DepartamentoInmueble), peticion.DPD_ID_INMUEBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonalesParams.CiudadInmueble), peticion.DPC_ID_INMUEBLE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonalesParams.NumeroDocumento), peticion.SDP_NUMERO_DOCUMENTO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSimulacionDatosPersonalesParams.Indicador), 3);


            return await GetAsyncFirst<SimulacionDatosPersonales>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<ActualizacionSolicitudCreditoDesemFirma> ObtenerSolicitudCredito(string request, int indicador)
        {
            DynamicParameters parametros = new DynamicParameters(); 

            parametros.Add(HelpersEnums.GetEnumDescription(EnumObtenerSolicitudCredito.idSolicitud),indicador==1?request:null);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumObtenerSolicitudCredito.idSls), null);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumObtenerSolicitudCredito.identificacion), indicador == 3 ? request : null);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumObtenerSolicitudCredito.indicador), indicador!=3?1:3);

            return await GetAsyncFirst<ActualizacionSolicitudCreditoDesemFirma>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SolicitudCreditosDesembolsos>> ObtenerFuentesRecursosSolicitud(Guid IdSolicitud)
        {
            DynamicParameters parameters = new();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParameters.IdSolicitudCredito), IdSolicitud);

            return await GetAsyncList<SolicitudCreditosDesembolsos>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SolicitudCreditosDesembolsos>> EliminarFuentesRecursosSolicitud(SolicitudCreditosDesembolsos solicitud)
        {
            DynamicParameters parameters = new();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParameters.IdSolicitudCredito), solicitud.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudDesembolsoParameters.IdSolicitudDesembolso), solicitud.SID_ID);

            return await GetAsyncList<SolicitudCreditosDesembolsos>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EqivalenciaSimulador>> ObtenerEquivalenciasSimuladorCredito()
        {
            return await GetAsyncList<EqivalenciaSimulador>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<SolicitudSimulacion> CrearSolicitudSimulacionCredito(SolicitudSimulacion solicitudSimulacion)
        {
            DynamicParameters parameters = new();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.Id), solicitudSimulacion.SLS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.FechaSolicitud), solicitudSimulacion.SLS_FECHA_SOLICITUD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.TcrId), solicitudSimulacion.TCR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.NumeroPreAprobado), solicitudSimulacion.SLS_NUMERO_PREAPROBADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.ProblemaEmail), solicitudSimulacion.SLS_PROBLEMA_EMAIL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.EnvioNotificacion), solicitudSimulacion.SLS_ENVIO_NOTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.RutaPdf), solicitudSimulacion.SLS_RUTA_PDF_RESUMEN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.PorcExtraprima), solicitudSimulacion.SLS_PORC_EXTRAPRIMA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.Estado), solicitudSimulacion.SLS_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.UsuarioActualiza), solicitudSimulacion.SLS_USUARIO_ACTUALIZA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.FechaActualiza), solicitudSimulacion.SLS_FECHA_ACTUALIZA);

            return await GetAsyncFirst<SolicitudSimulacion>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<SimulacionDetalle> CrearDetalleSimulacion(SimulacionDetalle simulacion)
        {
            DynamicParameters parameters = new();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_ID), simulacion.SMD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMC_ID), simulacion.SMC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_CUOTA), simulacion.SMD_CUOTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_FECHA_CORTE), simulacion.SMD_FECHA_CORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_FECHA_PAGO), simulacion.SMD_FECHA_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_SALDO), simulacion.SMD_SALDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_INTERESES), simulacion.SMD_INTERESES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_CAPITAL), simulacion.SMD_CAPITAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_SEGURO_VIDA), simulacion.SMD_SEGURO_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_SEGURO_TERREMOTO), simulacion.SMD_SEGURO_TERREMOTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_CUOTA_TOTAL), simulacion.SMD_CUOTA_TOTAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_ABONO_EXTRA), simulacion.SMD_ABONO_EXTRA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_ABONO_MENSUAL), simulacion.SMD_ABONO_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_CUOTA_UNIDAD_PAGADORA), simulacion.SMD_CUOTA_UNIDAD_PAGADORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_INTERESES_REDUCCION), simulacion.SMD_INTERESES_REDUCCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_CUOTA_REDUCCION), simulacion.SMD_CUOTA_REDUCCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_COBRO_FONVIVIENDA), simulacion.SMD_COBRO_FONVIVIENDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_SALDO_LEASING), simulacion.SMD_SALDO_LEASING);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_INTERES_LEASING), simulacion.SMD_INTERES_LEASING);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_CAPITAL_LEASING), simulacion.SMD_CAPITAL_LEASING);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_CUOTA_LEASING), simulacion.SMD_CUOTA_LEASING);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_CUOTA_LEASING_SUBSIDIO), simulacion.SMD_CUOTA_LEASING_SUBSIDIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_INTERES_TRADICIONAL_SUBSIDIO), simulacion.SMD_INTERES_TRADICIONAL_SUBSIDIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_INTERES_LEASING_SUBSIDIO), simulacion.SMD_INTERES_LEASING_SUBSIDIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumDetalleSimulacionParameters.SMD_SEGURO_VIDA_LEASING), simulacion.SMD_SEGURO_VIDA_LEASING);
           
            return await GetAsyncFirst<SimulacionDetalle>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<SMCSimulacionCliente> CrearSimulacionClienteSMC(SMCSimulacionCliente request)
        {
            DynamicParameters parameters = new();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.IdSimulacionCliente), request.SMC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.IdSimulacion), request.SLS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.IdDatosPersonales), request.SDP_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.TipoVivienda), request.SMC_TIPO_VIVIENDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.ValorVivienda), request.SMC_VALOR_VIVIENDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.TipoAlivio), request.SMC_TIPO_ALIVIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.TipoAbono), request.SMC_TIPO_ABONO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.Documento), request.SMC_NUMERO_DOCUMENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.ValorPrestamo), request.SMC_VALOR_PRESTAMO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.TasaEa), request.SMC_VALOR_TASA_EA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.TasaMv), request.SMC_VALOR_TASA_MV);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.TasaFrech), request.SMC_VALOR_TASA_MV_FRESH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.ViviendaVis), request.SMC_VIVIENDA_VIS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.FechaSimulacion), request.SMC_FECHA_SIMULACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.UsaRecursosAcumulados), request.SMC_USA_REC_ACUMULADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.TomaSeguro), request.SMC_TOMA_SEGURO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.ValorPrestamosLeasing), request.SMC_VALOR_PRESTAMO_LSG);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.NumeroPreaprobado), request.SMC_NUMERO_PREAPROBADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.TotalCuotas), request.SMC_TOTAL_CUOTAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSMCParameters.OpcionCompra), request.SMC_OPCION_COMPRA);


            return await GetAsyncFirst<SMCSimulacionCliente>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<SolicitudSimulacion> CrearPreAprobado(SolicitudSimulacion request)
        {
            DynamicParameters parameters = new();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.Id), request.SLS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.TcrId), request.TCR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.UsuarioActualiza), /*request.SLS_USUARIO_ACTUALIZA*/Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudSimulacionParameters.FechaActualiza), DateTime.Now);

            return await GetAsyncFirst<SolicitudSimulacion>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<SolicitudCredito> CrearSolicitudCredito(SolicitudCredito solicitudCredito)
        {
            DynamicParameters parameters = new();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOC_ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOC_FECHA_SOLICITUD), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOC_NUMERO_SOLICITUD), 0);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.TCR_ID), solicitudCredito.TCR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.DPD_ID), solicitudCredito.DPD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.DPC_ID), solicitudCredito.DPC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SLS_ID), solicitudCredito.SLS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.TID_ID), solicitudCredito.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.CLI_IDENTIFICACION), solicitudCredito.CLI_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOC_DECLARACION_ORIGEN_FONDOS), solicitudCredito.SOC_DECLARACION_ORIGEN_FONDOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOC_AUTORIZA_USO_DATOS), solicitudCredito.SOC_AUTORIZA_USO_DATOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOC_AUTORIZA_CONSULTA_CENTRALES), solicitudCredito.SOC_AUTORIZA_CONSULTA_CENTRALES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOC_DECLARACION_ASEGURABILIDAD), solicitudCredito.SOC_DECLARACION_ASEGURABILIDAD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOC_ESTADO), solicitudCredito.SOC_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOC_CREADO_POR), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOC_FECHA_CREACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_ESTADO_INMUEBLE), solicitudCredito.SOP_ESTADO_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_TIPO_INMUEBLE), solicitudCredito.SOP_TIPO_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_TIENE_GARAJE), solicitudCredito.SOP_TIENE_GARAJE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_TIENE_DEPOSITO), solicitudCredito.SOP_TIENE_DEPOSITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_CONJUNTO_CERRADO), solicitudCredito.SOP_CONJUNTO_CERRADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.TVV_ID), solicitudCredito.TVV_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_AÑOS_CONSTRUCCION), solicitudCredito.SOP_AÑOS_CONSTRUCCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_MATRICULA_INMOBILIARIA1), solicitudCredito.SOP_MATRICULA_INMOBILIARIA1);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_MATRICULA_INMOBILIARIA2), solicitudCredito.SOP_MATRICULA_INMOBILIARIA2);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_MATRICULA_INMOBILIARIA3), solicitudCredito.SOP_MATRICULA_INMOBILIARIA3);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_VALOR_INMUEBLE), solicitudCredito.SOP_VALOR_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_DIRECCION_INMUEBLE), solicitudCredito.SOP_DIRECCION_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.DPD_ID_INMUEBLE), solicitudCredito.DPD_ID_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.DPC_ID_INMUEBLE), solicitudCredito.DPC_ID_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_VALOR_CREDITO), solicitudCredito.SOP_VALOR_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_PORC_FINANCIACION), solicitudCredito.SOP_PORC_FINANCIACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_PLAZO_FINANCIACION), solicitudCredito.SOP_PLAZO_FINANCIACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_FECHA_ENTREGA_INMUEBLE), solicitudCredito.SOP_FECHA_ENTREGA_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.TID_ID_VENDEDOR), solicitudCredito.TID_ID_VENDEDOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_NUMERO_DOCUMENTO_VENDEDOR), solicitudCredito.SOP_NUMERO_DOCUMENTO_VENDEDOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_NOMBRE_VENDEDOR), solicitudCredito.SOP_NOMBRE_VENDEDOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_DIRECCION_VENDEDOR), solicitudCredito.SOP_DIRECCION_VENDEDOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.DPD_ID_VENDEDOR), solicitudCredito.DPD_ID_VENDEDOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.DPC_ID_VENDEDOR), solicitudCredito.DPC_ID_VENDEDOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_CORREO_VENDEDOR), solicitudCredito.SOP_CORREO_VENDEDOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreacionSolicitudCreditoParams.SOP_TELEFONO_VENDEDOR), solicitudCredito.SOP_TELEFONO_VENDEDOR);
            return await GetAsyncFirst<SolicitudCredito>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<SocSolicitudInfobasica> CrearSolicCreditoBasicos(SocSolicitudInfobasica infoBasica)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_ID), Guid.NewGuid());
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOC_ID), infoBasica.SOC_ID);   
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.TID_ID), infoBasica.TID_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_NUMERO_DOCUMENTO), infoBasica.SOB_NUMERO_DOCUMENTO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_FECHA_EXPEDICION), infoBasica.SOB_FECHA_EXPEDICION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.DPD_ID_EXP), infoBasica.DPD_ID_EXP);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.DPC_ID_EXP), infoBasica.DPC_ID_EXP);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_PRIMER_APELLIDO), infoBasica.SOB_PRIMER_APELLIDO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_SEGUNDO_APELLIDO), infoBasica.SOB_SEGUNDO_APELLIDO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_PRIMER_NOMBRE), infoBasica.SOB_PRIMER_NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_SEGUNDO_NOMBRE), infoBasica.SOB_SEGUNDO_NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_FECHA_NACIMIENTO), infoBasica.SOB_FECHA_NACIMIENTO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.DPD_ID_NACIMIENTO), infoBasica.DPD_ID_NACIMIENTO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.DPC_ID_NACIMIENTO), infoBasica.DPC_ID_NACIMIENTO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_SEXO), infoBasica.SOB_SEXO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_ESTADO_CIVIL), infoBasica.SOB_ESTADO_CIVIL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_NIVEL_EDUCACION), infoBasica.SOB_NIVEL_EDUCACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.FRZ_ID), infoBasica.FRZ_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.CTG_ID), infoBasica.CTG_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.GRD_ID), infoBasica.GRD_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.DPD_ID_RESIDENCIA), infoBasica.DPD_ID_RESIDENCIA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.DPC_ID_RESIDENCIA), infoBasica.DPC_ID_RESIDENCIA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_DIRECCION_RESIDENCIA), infoBasica.SOB_DIRECCION_RESIDENCIA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_CORREO_PERSONAL), infoBasica.SOB_CORREO_PERSONAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_TELEFONO_RESIDENCIA), infoBasica.SOB_TELEFONO_RESIDENCIA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_CELULAR), infoBasica.SOB_CELULAR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.DPD_ID_OFICINA), infoBasica.DPD_ID_OFICINA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.DPC_ID_OFICINA), infoBasica.DPC_ID_OFICINA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_DIRECCION_OFICINA), infoBasica.SOB_DIRECCION_OFICINA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_CORREO_INSTITUCIONAL), infoBasica.SOB_CORREO_INSTITUCIONAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_TELEFONO_OFICINA), infoBasica.SOB_TELEFONO_OFICINA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.ACC_ID), infoBasica.ACC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.PRF_ID), infoBasica.PRF_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSocSolicitudInfobasicaParametros.SOB_CREADO_POR), infoBasica.SOB_CREADO_POR);

            return await GetAsyncFirst<SocSolicitudInfobasica>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<TasaHogarCiudad>> ObtenerTasasHogarCiudad()
        {
            return await GetAsyncList<TasaHogarCiudad>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<InformacionConyugue> ObtenerSolicCreditoConyugue(PeticionCreditoBasica IdSolicitud)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoBasicaParameters.SOY_ID), IdSolicitud.SOY_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoBasicaParameters.SOC_ID), IdSolicitud.SOC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCreditoBasicaParameters.IND), IdSolicitud.IND);

            return await GetAsyncFirst<InformacionConyugue>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<InformacionConyugue> CrearSolicCreditoConyugue(InformacionConyugue info)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_ID), Guid.NewGuid());
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOC_ID), info.SOC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.TID_ID), info.TID_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_NUMERO_DOCUMENTO), info.SOY_NUMERO_DOCUMENTO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.DPD_ID_EXP), info.DPD_ID_EXP);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.DPC_ID_EXP), info.DPC_ID_EXP);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_PRIMER_APELLIDO), info.SOY_PRIMER_APELLIDO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_SEGUNDO_APELLIDO), info.SOY_SEGUNDO_APELLIDO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_PRIMER_NOMBRE), info.SOY_PRIMER_NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_SEGUNDO_NOMBRE), info.SOY_SEGUNDO_NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_FECHA_NACIMIENTO), info.SOY_FECHA_NACIMIENTO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.DPD_ID_NACIMIENTO), info.DPD_ID_NACIMIENTO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_CELULAR), info.SOY_CELULAR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_CORREO_PERSONAL), info.SOY_CORREO_PERSONAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_ACTIVIDAD_LABORAL), info.SOY_ACTIVIDAD_LABORAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_OTRO_ACTIVIDAD), info.SOY_OTRO_ACTIVIDAD);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_EMPRESA_LABORA), info.SOY_EMPRESA_LABORA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_CREADO_POR), info.SOY_CREADO_POR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_FECHA_CREACION), DateTime.Now);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.SOY_FECHA_EXPEDICION), info.SOY_FECHA_EXPEDICION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCreditoConyugueParametros.DPC_ID_NACIMIENTO), info.DPC_ID_NACIMIENTO);

            return await GetAsyncFirst<InformacionConyugue>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
    }
}
