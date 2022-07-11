using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Core.DocumentsCreators.Riesgo;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Consecutivo Logica
    /// <author>Cristian Gonzalez </author>
    /// <date>24/04/2021</date>
    /// </summary>
    /// 
    public class CreditoBusinessLogic : ICreditoBusinessLogic
    {
        private readonly IMensajeRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly ICreditoRepository _creditoRepository;
        private readonly IOptions<BlobStorageOptions> _options;
        private readonly IOptions<AqmOptions> _optionsAqm;
        private readonly IOptions<IdVisionOptions> _optionsTu;
        private readonly IValidacionIdentidadBusinessLogic _validacionIdentidadBusinessLogic;
        private readonly IBlobStorageGenericRepository _blobStorageGenericRepository;
        private readonly IClientRequestProvider _iClientRequestProvider;
        private readonly ICatalogosRepository _catalogsRepository;

      

        public CreditoBusinessLogic(ICatalogosRepository catalogsRepository,IMensajeRepository messageRepository, IMapper mapper, ICreditoRepository creditoRepository, IOptions<BlobStorageOptions> options, IOptions<AqmOptions> optionsAqm, IOptions<IdVisionOptions> optionsTu, IValidacionIdentidadBusinessLogic validacionIdentidadBusinessLogic, IBlobStorageGenericRepository blobStorageGenericRepository, IClientRequestProvider iClientRequestProvider)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _creditoRepository = creditoRepository;
            _options = options;
            _optionsAqm = optionsAqm;
            _optionsTu = optionsTu;
            _validacionIdentidadBusinessLogic = validacionIdentidadBusinessLogic;
            _blobStorageGenericRepository = blobStorageGenericRepository;
            _iClientRequestProvider = iClientRequestProvider;
            _catalogsRepository = catalogsRepository;
        }





        /// <summary>
        /// Metodo actualiza actividad de tramite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="actualizacion"></param>
        /// <returns>ActualizaActividadTramiteDto</returns>
        public async Task<Response<ActualizaActividadTramiteDto>> ActualizaActividadTramite(ActividadTramiteSolicitudDto actualizacion)
        {
            var peticionActualizacion = this._mapper.Map<ActividadTramiteSolicitud>(actualizacion);
            return new Response<ActualizaActividadTramiteDto> { Data = this._mapper.Map<ActualizaActividadTramiteDto>(await this._creditoRepository.ActualizaActividadTramite(peticionActualizacion)) };
        }


        /// <summary>
        /// Metodo que obtiene los documentos Act solicitud
        /// </summary>
        /// <param name="request"></param>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <returns>IEnumerable<DocumentosActRespuestaDto></returns>
        public async Task<Response<IEnumerable<DocumentosActRespuestaDto>>> ObtenerDocumentosActSolicitud(DocumentosActSolicitudDto request)
        {
            var peticionDocumento = this._mapper.Map<DocumentosActSolicitud>(request);
            return new Response<IEnumerable<DocumentosActRespuestaDto>> { Data = this._mapper.Map<IEnumerable<DocumentosActRespuestaDto>>(await this._creditoRepository.ObtenerDocumentosActSolicitud(peticionDocumento)) };
        }



        /// <summary>
        /// metodo obtiene los docuemntos de flujo
        /// </summary>
        /// <param name="solicitud"></param>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <returns>IEnumerable<RespuestaFlujoDocumentosDto></returns>
        public async Task<Response<IEnumerable<RespuestaFlujoDocumentosDto>>> ObtenerDocumentosFlujo(PeticionFlujoDocumentosDto solicitud)
        {
            var peticionFlujo = this._mapper.Map<PeticionFlujoDocumentos>(solicitud);
            return new Response<IEnumerable<RespuestaFlujoDocumentosDto>> { Data = this._mapper.Map<IEnumerable<RespuestaFlujoDocumentosDto>>(await this._creditoRepository.ObtenerDocumentosFlujo(peticionFlujo)) };

        }

        /// <summary>
        /// Obtiene solicitud Credito producto
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="peticionSolicitud"></param>
        /// <returns>Response<RespuestaSolicitudCreditoProductoDto></returns>
        public async Task<Response<RespuestaSolicitudCreditoProductoDto>> ObtenerSolicCreditoProducto(PeticionSolicitudCreditoProductoDto peticionSolicitud)
        {
            var peticion = this._mapper.Map<PeticionSolicitudCreditoProducto>(peticionSolicitud);
            return new Response<RespuestaSolicitudCreditoProductoDto> { Data = this._mapper.Map<RespuestaSolicitudCreditoProductoDto>(await this._creditoRepository.ObtenerSolicCreditoProducto(peticion)) };
        }


        /// <summary>
        /// Obtiene solicitud Credito Basica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="peticionSolicitud"></param>
        /// <returns>Response<RespuestaCreditoBasicaDto></returns>
        public async Task<Response<RespuestaCreditoBasicaDto>> ObtenerSolicCreditoBasica(PeticionCreditoBasicaDto peticionSolicitud)
        {
            var peticion = this._mapper.Map<PeticionCreditoBasica>(peticionSolicitud);
            return new Response<RespuestaCreditoBasicaDto> { Data = this._mapper.Map<RespuestaCreditoBasicaDto>(await this._creditoRepository.ObtenerSolicCreditoBasica(peticion)) };
        }

        /// <summary>
        /// Obtener Solicitud Credito financiero
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="peticionSolicitud"></param>
        /// <returns>Response<RespuestaCreditoFinancieroDto></returns>
        public async Task<Response<RespuestaCreditoFinancieroDto>> ObtenerSolicCreditoFinancieros(PeticionCreditoFinancieroDto peticionSolicitud)
        {
            var peticion = this._mapper.Map<PeticionCreditoFinanciero>(peticionSolicitud);
            return new Response<RespuestaCreditoFinancieroDto> { Data = this._mapper.Map<RespuestaCreditoFinancieroDto>(await this._creditoRepository.ObtenerSolicCreditoFinancieros(peticion)) };
        }




        /// <summary>
        /// Metodo logica de negocio para obtener la solicitud del tramite para crédito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicitud"></param>
        /// <returns>Response<IEnumerable<RespuestaSolicitudObtenerTramiteDto>></returns>
        public async Task<Response<IEnumerable<RespuestaSolicitudObtenerTramiteDto>>> ObtenerTramiteSolicitud(PeticionSolicitudObtenerTramiteDto solicitud)
        {
            var tramiteSolicitud = this._mapper.Map<PeticionSolicitudObtenerTramite>(solicitud);
            return new Response<IEnumerable<RespuestaSolicitudObtenerTramiteDto>> { Data = this._mapper.Map<IEnumerable<RespuestaSolicitudObtenerTramiteDto>>(await this._creditoRepository.ObtenerTramiteSolicitud(tramiteSolicitud)) };
        }

        /// <summary>
        /// Metodo para obtener observacion tramite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns>Response<IEnumerable<RespuestaObservacionTramiteDto>></returns>
        public async Task<Response<IEnumerable<RespuestaObservacionTramiteDto>>> ObtenerObservacionTramite(PeticionObtenerObservacionTramiteDto request)
        {
            var requestObservacion = this._mapper.Map<PeticionObtenerObservacionTramite>(request);
            return new Response<IEnumerable<RespuestaObservacionTramiteDto>> { Data = this._mapper.Map<IEnumerable<RespuestaObservacionTramiteDto>>(await this._creditoRepository.ObtenerObservacionTramite(requestObservacion)) };
        }

        /// <summary>
        /// metodo envia subsanacion actividad tramite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="actualizacion"></param>
        /// <returns>Response<ActualizaActividadTramiteDto></returns>
        public async Task<Response<ActualizaActividadTramiteDto>> EnviaSubsancionActividadTramite(ActividadTramiteSolicitudDto actualizacion)
        {
            var peticionActualizacion = this._mapper.Map<ActividadTramiteSolicitud>(actualizacion);
            return new Response<ActualizaActividadTramiteDto> { Data = this._mapper.Map<ActualizaActividadTramiteDto>(await this._creditoRepository.EnviaSubsancionActividadTramite(peticionActualizacion)) };
        }
        /// <summary>
        /// Metodo aprueba actividad de tramite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="actualizacion"></param>
        /// <returns>Response<ActualizaActividadTramiteDto></returns>
        public async Task<Response<ActualizaActividadTramiteDto>> ApruebaActividadTramite(ActividadTramiteSolicitudDto actualizacion)
        {
            ResponseVerificarCierreActSeg confirmacion = new ResponseVerificarCierreActSeg();
            var peticionActualizacion = this._mapper.Map<ActividadTramiteSolicitud>(actualizacion);
            bool puedeAprobar = true;
            if (peticionActualizacion.ACTIVIDAD_PRINCIPAL?.ToUpper() == "S")
            {
                confirmacion = await this._creditoRepository.VerificarCierreActSeg(new RequestVerificarCierreActSeg { AFL_ID = peticionActualizacion.AFL_ID, TRS_ID = peticionActualizacion.TRS_ID });
                if (confirmacion.Mensaje != "OK")
                {
                    puedeAprobar = false;
                }
            }
            if (puedeAprobar)
            {
                return new Response<ActualizaActividadTramiteDto> { Data = this._mapper.Map<ActualizaActividadTramiteDto>(await this._creditoRepository.ApruebaActividadTramite(peticionActualizacion)) };
            }
            else return new Response<ActualizaActividadTramiteDto> { ReturnMessage = confirmacion.Mensaje };
        }
        /// <summary>
        /// Metodo rechazar actividad tramite
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="actualizacion"></param>
        /// <returns>Response<ActualizaActividadTramiteDto></returns>
        public async Task<Response<ActualizaActividadTramiteDto>> RechazarActividadTramite(ActividadTramiteSolicitudDto actualizacion)
        {
            ResponseVerificarCierreActSeg confirmacion = new ResponseVerificarCierreActSeg();
            var peticionActualizacion = this._mapper.Map<ActividadTramiteSolicitud>(actualizacion);
            bool puedeRechazar = true;
            if (peticionActualizacion.ACTIVIDAD_PRINCIPAL.ToUpper() == "S")
            {
                confirmacion = await this._creditoRepository.VerificarCierreActSeg(new RequestVerificarCierreActSeg { AFL_ID = peticionActualizacion.AFL_ID, TRS_ID = peticionActualizacion.TRS_ID });
                if (confirmacion.Mensaje == "OK")
                {
                    puedeRechazar = false;
                }
            }
            if (puedeRechazar)
            {
                return new Response<ActualizaActividadTramiteDto> { Data = this._mapper.Map<ActualizaActividadTramiteDto>(await this._creditoRepository.RechazarActividadTramite(peticionActualizacion)) };
            }
            else return new Response<ActualizaActividadTramiteDto> { ReturnMessage = confirmacion.Mensaje };

        }

        /// <summary>
        /// Metodo crear solicitud credito informacion Tecnica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicCreditoInfTecnica"></param>
        /// <returns>Response<SolicCreditoInfTecnicaDto></returns>
        public async Task<Response<SolicCreditoInfTecnicaDto>> CrearSolicCreditoInfTecnica(SolicCreditoInfTecnicaDto solicCreditoInfTecnica)
        {
            var solicitudInfTecnica = this._mapper.Map<SolicCreditoInfTecnica>(solicCreditoInfTecnica);
            if (solicCreditoInfTecnica.IdSolicitudInformacionTecnica == default) solicitudInfTecnica.SIT_ID = Guid.NewGuid();
            var responseInfoTecnica = await this._creditoRepository.CrearSolicCreditoInfTecnica(solicitudInfTecnica);
            var infInmueble = new List<SolicCreditoInfTecInmDto>();
            if (solicCreditoInfTecnica.solicitudesCreditoInfTecnicaInmueble != null)
            {
                foreach (SolicCreditoInfTecInmDto request in solicCreditoInfTecnica.solicitudesCreditoInfTecnicaInmueble)
                {
                    request.idSolicitudtecnica = solicitudInfTecnica.SIT_ID;
                    if (request.idSolicitudInfoTecnicaInmueble == default) request.idSolicitudInfoTecnicaInmueble = Guid.NewGuid();
                    var solicitudInfTecInm = this._mapper.Map<SolicCreditoInfTecInm>(request);
                    var responseInfoTecInm = await this._creditoRepository.CrearSolicCreditoInfTecInm(solicitudInfTecInm);
                    infInmueble.Add(this._mapper.Map<SolicCreditoInfTecInmDto>(responseInfoTecInm));
                }
            }
            SolicCreditoInfTecnicaDto response = new SolicCreditoInfTecnicaDto
            {
                IdSolicitudInformacionTecnica = responseInfoTecnica.SIT_ID,
                IdSolicitudCredito = responseInfoTecnica.SOC_ID,
                ValorAvaluoComercial = responseInfoTecnica.SIT_VALOR_AVALUO_COMERCIAL,
                ValorVentaInmueble = responseInfoTecnica.SIT_VALOR_VENTA_INMUEBLE,
                ConsideracionesFinales = responseInfoTecnica.SIT_CONSIDERACIONES_FINALES,
                DeclaraCumplimiento = responseInfoTecnica.SIT_DECLARA_CUMPLIMIENTO,
                CondicionesSalvedades = responseInfoTecnica.SIT_CONDICIONES_SALVEADES,
                ConceptoEstTecnico = responseInfoTecnica.SIT_CONCEPTO_EST_TECNICO,
                CreadoPor = responseInfoTecnica.SIT_CREADO_POR,
                FechaCreacion = responseInfoTecnica.SIT_FECHA_CREACION,
                solicitudesCreditoInfTecnicaInmueble = infInmueble,
                Estrato = responseInfoTecnica.SIT_ESTRATO,
                NombreAliado = responseInfoTecnica.NOMBRE_ALIADO
            };


            return new Response<SolicCreditoInfTecnicaDto> { Data = response };
        }

        /// <summary>
        /// Crear solicitud Credito Informacion Tecnica Inmueble
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicCreditoInfTecInm"></param>
        /// <returns>Response<SolicCreditoInfTecInmDto></returns>
        public async Task<Response<SolicCreditoInfTecInmDto>> CrearSolicCreditoInfTecInm(SolicCreditoInfTecInmDto solicCreditoInfTecInm)
        {
            var solicitud = this._mapper.Map<SolicCreditoInfTecInm>(solicCreditoInfTecInm);
            return new Response<SolicCreditoInfTecInmDto> { Data = this._mapper.Map<SolicCreditoInfTecInmDto>(await this._creditoRepository.CrearSolicCreditoInfTecInm(solicitud)) };
        }

        /// <summary>
        /// Metodo crear Solicitud Credito Informacion Juridica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicCreditoInfJuridica"></param>
        /// <returns>Response<SolicCreditoInfJuridicaDto></returns>
        public async Task<Response<SolicCreditoInfJuridicaDto>> CrearSolicCreditoInfJuridica(SolicCreditoInfJuridicaDto solicCreditoInfJuridica)
        {
            var solicitudInfJuridica = this._mapper.Map<SolicCreditoInfJuridica>(solicCreditoInfJuridica);

            if (solicCreditoInfJuridica.idSolicitudInformacionJuridica == default)
                solicitudInfJuridica.SIJ_ID = Guid.NewGuid();

            var responseInfoJuridica = await this._creditoRepository.CrearSolicCreditoInfJuridica(solicitudInfJuridica);
            var infInmueble = new List<SolicCreditoInfJurInmDto>();
            if (solicCreditoInfJuridica.solicitudesCreditoInfoJurInmueble != null)
            {
                foreach (SolicCreditoInfJurInmDto request in solicCreditoInfJuridica.solicitudesCreditoInfoJurInmueble)
                {
                    request.IdSolicitudInformacionJuridica = solicitudInfJuridica.SIJ_ID;
                    if (request.IdSolicitudInfJuridicaInmueble == default) request.IdSolicitudInfJuridicaInmueble = Guid.NewGuid();
                    var solicitudInfJurInm = this._mapper.Map<SolicCreditoInfJurInm>(request);
                    var responseInfoJurInm = await this._creditoRepository.CrearSolicCreditoInfJurInm(solicitudInfJurInm);
                    infInmueble.Add(this._mapper.Map<SolicCreditoInfJurInmDto>(responseInfoJurInm));
                }
            }
            SolicCreditoInfJuridicaDto response = new SolicCreditoInfJuridicaDto
            {
                idSolicitudInformacionJuridica = responseInfoJuridica.SIJ_ID,
                idSolicitudCredito = responseInfoJuridica.SOC_ID,
                linderos = responseInfoJuridica.SIJ_LINDEROS,
                tipoParqueadero = responseInfoJuridica.SIJ_TIPO_PARQUEADERO,
                edadJuridica = responseInfoJuridica.SIJ_EDAD_JURIDICA,
                fechaPrimerActo = responseInfoJuridica.SIJ_FECHA_PRIMER_ACTO,
                tradicionInmueble = responseInfoJuridica.SIJ_TRADICION_INMUEBLE,
                analisisUlt20Años = responseInfoJuridica.SIJ_ANALISIS_ULT_20_AÑOS,
                analisisSitJuridica = responseInfoJuridica.SIJ_ANALISIS_SIT_JURIDICA,
                analisisRegPropHorizontal = responseInfoJuridica.SIJ_ANALISIS_REG_PROP_HOR,
                analisisPazySalvo = responseInfoJuridica.SIJ_ANALISIS_PAZ_Y_SALVO,
                analisisVendedor = responseInfoJuridica.SIJ_ANALISIS_VENDEDOR,
                viabilidadJurNegocio = responseInfoJuridica.SIJ_VIABILIDAD_JUR_NEGOCIO,
                recomendaciones = responseInfoJuridica.SIJ_RECOMENDACIONES,
                conceptoJuridicoFin = responseInfoJuridica.SIJ_CONCEPTO_JURIDICO_FIN,
                conceptoEstJuridicio = responseInfoJuridica.SIJ_CONCEPTO_EST_JURIDICO,
                creadoPor = responseInfoJuridica.SIJ_CREADO_POR,
                fechaCreacion = responseInfoJuridica.SIJ_FECHA_CREACION,
                direccion = responseInfoJuridica.SIJ_DIRECCION,
                codigoDepartamento = responseInfoJuridica.DPD_ID,
                codigoCiudad = responseInfoJuridica.DPC_ID,
                solicitudesCreditoInfoJurInmueble = infInmueble
            };


            return new Response<SolicCreditoInfJuridicaDto> { Data = response };


        }

        /// <summary>
        /// Crear Solicitud Credito Informacion Juridica Inmueble
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicCreditoInfJuridica"></param>
        /// <returns>Response<SolicCreditoInfJurInmDto></returns>
        public async Task<Response<SolicCreditoInfJurInmDto>> CrearSolicCreditoInfJurInm(SolicCreditoInfJurInmDto solicCreditoInfJurInm)
        {
            var solicitud = this._mapper.Map<SolicCreditoInfJurInm>(solicCreditoInfJurInm);
            return new Response<SolicCreditoInfJurInmDto> { Data = this._mapper.Map<SolicCreditoInfJurInmDto>(await this._creditoRepository.CrearSolicCreditoInfJurInm(solicitud)) };
        }

        /// <summary>
        /// Obtener Solicitud Credito Informacion Tecnica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="solicCreditoInfJuridica"></param>
        /// <returns>Response<SolicCreditoInfTecnicaDto></returns>
        public async Task<Response<SolicCreditoInfTecnicaDto>> ObtenerSolicCreditoInfTecnica(RequestSolicCreditoInfTecnicaDto requestSolicCreditoInfTecnica)
        {
            var solicitudInfoTec = this._mapper.Map<RequestSolicCreditoInfTecnica>(requestSolicCreditoInfTecnica);
            var responseInfoTec = await this._creditoRepository.ObtenerSolicCreditoInfTecnica(solicitudInfoTec);
            if (responseInfoTec == null)
            {
                return new Response<SolicCreditoInfTecnicaDto> { Data = null };
            }
            else
            {
                var solicitudInfoTecInm = new RequestSolicCreditoInfTecInm { SOC_ID = responseInfoTec.SOC_ID, IND = 3 };
                var responseInfoTecInm = await this._creditoRepository.ObtenerSolicCreditoInfTecInm(solicitudInfoTecInm);

                var solicCreditoInfTecnica = new SolicCreditoInfTecnicaDto
                {
                    IdSolicitudInformacionTecnica = responseInfoTec.SIT_ID,
                    IdSolicitudCredito = responseInfoTec.SOC_ID,
                    ValorAvaluoComercial = responseInfoTec.SIT_VALOR_AVALUO_COMERCIAL,
                    ValorVentaInmueble = responseInfoTec.SIT_VALOR_VENTA_INMUEBLE,
                    ConsideracionesFinales = responseInfoTec.SIT_CONSIDERACIONES_FINALES,
                    DeclaraCumplimiento = responseInfoTec.SIT_DECLARA_CUMPLIMIENTO,
                    CondicionesSalvedades = responseInfoTec.SIT_CONDICIONES_SALVEADES,
                    ConceptoEstTecnico = responseInfoTec.SIT_CONCEPTO_EST_TECNICO,
                    NombreAliado = responseInfoTec.NOMBRE_ALIADO,
                    CreadoPor = responseInfoTec.SIT_CREADO_POR,
                    FechaCreacion = responseInfoTec.SIT_FECHA_CREACION,
                    Estrato = responseInfoTec.SIT_ESTRATO,
                    solicitudesCreditoInfTecnicaInmueble = this._mapper.Map<IEnumerable<SolicCreditoInfTecInmDto>>(responseInfoTecInm)
                };
                return new Response<SolicCreditoInfTecnicaDto> { Data = solicCreditoInfTecnica };
            }

        }

        /// <summary>
        /// Obtener Solicitud Credito Informacion Tecnica Inmueble
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="requestSolicCreditoInfTecInm"></param>
        /// <returns>Response<IEnumerable<SolicCreditoInfTecInmDto>></returns>
        public async Task<Response<IEnumerable<SolicCreditoInfTecInmDto>>> ObtenerSolicCreditoInfTecInm(RequestSolicCreditoInfTecInmDto requestSolicCreditoInfTecInm)
        {
            var solicitud = this._mapper.Map<RequestSolicCreditoInfTecInm>(requestSolicCreditoInfTecInm);
            return new Response<IEnumerable<SolicCreditoInfTecInmDto>> { Data = this._mapper.Map<IEnumerable<SolicCreditoInfTecInmDto>>(await this._creditoRepository.ObtenerSolicCreditoInfTecInm(solicitud)) };

        }

        /// <summary>
        /// Metodo obtener Solicitud Credito Informacion Juridica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="requestSolicCreditoInfJuridica"></param>
        /// <returns>Response<SolicCreditoInfJuridicaDto></returns>
        public async Task<Response<SolicCreditoInfJuridicaDto>> ObtenerSolicCreditoInfJuridica(RequestSolicCreditoInfJuridicaDto requestSolicCreditoInfJuridica)
        {
            var solicitudInfoJur = this._mapper.Map<RequestSolicCreditoInfJuridica>(requestSolicCreditoInfJuridica);
            var responseInfoJur = await this._creditoRepository.ObtenerSolicCreditoInfJuridica(solicitudInfoJur);
            if (responseInfoJur == null)
            {
                return new Response<SolicCreditoInfJuridicaDto> { Data = null };
            }
            else
            {
                var solicitudInfoJurInm = new RequestSolicCreditoInfJurInm { SOC_ID = responseInfoJur.SOC_ID, IND = 3 };
                var responseInfoJurInm = await this._creditoRepository.ObtenerSolicCreditoInfJurInm(solicitudInfoJurInm);

                var solicCreditoInfJuridica = new SolicCreditoInfJuridicaDto
                {
                    idSolicitudInformacionJuridica = responseInfoJur.SIJ_ID,
                    idSolicitudCredito = responseInfoJur.SOC_ID,
                    linderos = responseInfoJur.SIJ_LINDEROS,
                    tipoParqueadero = responseInfoJur.SIJ_TIPO_PARQUEADERO,
                    edadJuridica = responseInfoJur.SIJ_EDAD_JURIDICA,
                    fechaPrimerActo = responseInfoJur.SIJ_FECHA_PRIMER_ACTO,
                    tradicionInmueble = responseInfoJur.SIJ_TRADICION_INMUEBLE,
                    analisisUlt20Años = responseInfoJur.SIJ_ANALISIS_ULT_20_AÑOS,
                    analisisSitJuridica = responseInfoJur.SIJ_ANALISIS_SIT_JURIDICA,
                    analisisRegPropHorizontal = responseInfoJur.SIJ_ANALISIS_REG_PROP_HOR,
                    analisisPazySalvo = responseInfoJur.SIJ_ANALISIS_PAZ_Y_SALVO,
                    analisisVendedor = responseInfoJur.SIJ_ANALISIS_VENDEDOR,
                    viabilidadJurNegocio = responseInfoJur.SIJ_VIABILIDAD_JUR_NEGOCIO,
                    recomendaciones = responseInfoJur.SIJ_RECOMENDACIONES,
                    conceptoJuridicoFin = responseInfoJur.SIJ_CONCEPTO_JURIDICO_FIN,
                    conceptoEstJuridicio = responseInfoJur.SIJ_CONCEPTO_EST_JURIDICO,
                    codigoCiudad = responseInfoJur.DPC_ID,
                    direccion = responseInfoJur.SIJ_DIRECCION,
                    codigoDepartamento = responseInfoJur.DPD_ID,
                    departamento = responseInfoJur.DEPARTAMENTO,
                    ciudad = responseInfoJur.CIUDAD,
                    nombreAliado = responseInfoJur.NOMBRE_ALIADO,
                    creadoPor = responseInfoJur.SIJ_CREADO_POR,
                    fechaCreacion = responseInfoJur.SIJ_FECHA_CREACION,
                    solicitudesCreditoInfoJurInmueble = this._mapper.Map<IEnumerable<SolicCreditoInfJurInmDto>>(responseInfoJurInm)
                };
                return new Response<SolicCreditoInfJuridicaDto> { Data = solicCreditoInfJuridica };
            }

        }

        /// <summary>
        /// Metodo Obtener Solicitud Credito Informacion Juridica Inmueble
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="requestSolicCreditoInfJurInm"></param>
        /// <returns>Response<IEnumerable<SolicCreditoInfJurInmDto>></returns>
        public async Task<Response<IEnumerable<SolicCreditoInfJurInmDto>>> ObtenerSolicCreditoInfJurInm(RequestSolicCreditoInfJurInmDto requestSolicCreditoInfJurInm)
        {
            var solicitud = this._mapper.Map<RequestSolicCreditoInfJurInm>(requestSolicCreditoInfJurInm);
            return new Response<IEnumerable<SolicCreditoInfJurInmDto>> { Data = this._mapper.Map<IEnumerable<SolicCreditoInfJurInmDto>>(await this._creditoRepository.ObtenerSolicCreditoInfJurInm(solicitud)) };

        }

        /// <summary>
        /// Metodo Crear Documento Solicitud Credito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="documentoSolicCredito"></param>
        /// <returns></returns>
        public async Task<Response<ResponseDocumentoSolicCreditoDto>> CrearDocumentoSolicCredito(RequestDocumentoSolicCreditoDto request)
        {
            string FilePath = request.rutaImagen;

            var fileExtensions = new List<string> { ".pdf", ".tif" };
            int folios;


            var file = (await _blobStorageGenericRepository.DescargarArchivoStorage("credito", $"{request.rutaImagen}")).Content;
            //var fileSize = file.Length;
            if (fileExtensions.Contains(FilePath.Split(".")[1]))
            {
                using StreamReader sr = new StreamReader(file);
                folios = new Regex(@"/Type\s*/Page[^s]").Matches(sr.ReadToEnd()).Count;
            }
            else folios = 0;

            var filenamewhitoutext = Guid.Parse(FilePath.Split(".")[0]);
            var documento = new ResponseDocumentoSolicCredito
            {
                DCS_ID = filenamewhitoutext,
                SOC_ID = request.idSolicitudCredito,
                TDC_ID = request.idTipoDocumento,
                DCS_CODIGO_BARRAS = request.codigoBarras,
                DCS_FECHA_DOCUMENTO = DateTime.Now,
                DCS_NUMERO_FOLIOS = folios,
                DCS_TAMAÑO = 0,
                DCS_RUTA_IMAGEN = request.rutaImagen,
                DCS_ESTADO = "1",
                DCS_CREADO_POR = request.creadoPor,
                DCS_FECHA_CREACION = request.fechaCreacion
            };


            return new Response<ResponseDocumentoSolicCreditoDto> { Data = this._mapper.Map<ResponseDocumentoSolicCreditoDto>(await this._creditoRepository.CrearDocumentoSolicCredito(documento)) };

        }

        /// <summary>
        /// Consulta la simulacion dle cliente
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="documento"></param>
        /// <returns></returns>
        public async Task<Response<SimulacionClienteDto>> ConsultarSimulacionCliente(string documento)
        {
            var response = new Response<SimulacionClienteDto> { Data = this._mapper.Map<SimulacionClienteDto>(await this._creditoRepository.ConsultarSimulacionCliente(documento)) };
            return response;
        }

        /// <summary>
        /// Carga los documentos para la solicitud de crédito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<string>> CargaDocumentoSolicCredito(IFormFile request)
        {
            var _request = request;
            FileInfo fi = new FileInfo(_request.FileName);
            BlobContainerClient container = new BlobContainerClient(_options.Value.CadenaOne, "credito");
            await container.CreateIfNotExistsAsync();
            var newName = Guid.NewGuid() + fi.Extension;
            BlobClient blob = container.GetBlobClient(newName);
            var result = await blob.UploadAsync(request.OpenReadStream());
            return new Response<string> { Data = newName };

        }

        /// <summary>
        /// Descarga los archivos de la solicitud de crédito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task<FileResult> DescargaDocumentoSolicCredito(string request)
        {
            BlobContainerClient container = new BlobContainerClient(this._options.Value.CadenaOne, "credito");
            BlobClient blob = container.GetBlobClient(request);
            BlobDownloadInfo download = await blob.DownloadAsync();

            var descargado = new FileStreamResult(download.Content, download.ContentType);
            descargado.FileDownloadName = request;
            await descargado.FileStream.FlushAsync();
            return descargado;
        }
        /// <summary>
        /// Obtiene el documento de los datos de solicitud Comite de crédito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="datosSolicitudComite"></param>
        /// <returns></returns>
        public async Task<FileResult> ObtenerDatosSolicComite(Guid guid)
        {

            var fileBase = "8d2906d0-ac60-40cf-a25b-b5bae98fe50c.html";
            var cssBase = "3cd4863b-3b85-42ec-9027-25890b4fcf52.css";
            var respuesta = await this._creditoRepository.ObtenerDatosSolicComite(guid);
            var simulacion = await this._creditoRepository.ConsultarSimulacionCliente(respuesta.SOB_NUMERO_DOCUMENTO.ToString());
            var historial = await this._creditoRepository.ObtenerHistorialComercialBuro(respuesta.SOB_NUMERO_DOCUMENTO.ToString());
            PdfCreator pdf = new PdfCreator();
            if (respuesta != null)
            {
                BlobContainerClient container = new BlobContainerClient(this._options.Value.CadenaOne, "credito");
                BlobClient blobBase = container.GetBlobClient(fileBase);
                BlobClient blobCss = container.GetBlobClient(cssBase);
                BlobDownloadInfo downloadBase = await blobBase.DownloadAsync();
                BlobDownloadInfo downloadCss = await blobCss.DownloadAsync();

                var basefile = new FileStreamResult(downloadBase.Content, downloadBase.ContentType);
                var baseCss = new FileStreamResult(downloadCss.Content, downloadCss.ContentType);

                await basefile.FileStream.FlushAsync();
                await baseCss.FileStream.FlushAsync();

                var resultado = await pdf.GenerarDatosSolicComite(respuesta, simulacion, historial, basefile, baseCss);
                return resultado;
            }
            else throw new ArgumentNullException(nameof(respuesta));
        }

        /// <summary>
        /// Genera un pdf de un preaprobado
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FileResult> GenerarPDFPreAprobado(string request)
        {
            var solicitud = await this.ConsultarSimulacionCliente(request);

            BlobContainerClient container = new BlobContainerClient(this._options.Value.CadenaOne, "credito");
            BlobClient blobBase = container.GetBlobClient("0038c8b3-52a4-4b35-bcf6-d6e3b110d368.html");
            BlobClient blobCss = container.GetBlobClient("f040de05-083b-4699-be01-b66eaff830c1.css");

            BlobDownloadInfo downloadBase = await blobBase.DownloadAsync();
            BlobDownloadInfo downloadCss = await blobCss.DownloadAsync();

            var baseHtlm = new FileStreamResult(downloadBase.Content, downloadBase.ContentType);
            var baseCss = new FileStreamResult(downloadCss.Content, downloadCss.ContentType);

            await baseHtlm.FileStream.FlushAsync();
            await baseCss.FileStream.FlushAsync();

            PdfCreator pdf = new PdfCreator();
            return await pdf.GenerarConfirmacionPreAprobado(solicitud.Data, baseHtlm, baseCss);
        }

        /// <summary>
        /// Actualiza solicitud de credito Recomendacion
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<SolicCreditoRecomendacionDto>> ActualizarSolicCreditoRecomendacion(SolicCreditoRecomendacionDto request)
        {
            var solicitud = this._mapper.Map<SolicCreditoRecomendacion>(request);
            return new Response<SolicCreditoRecomendacionDto> { Data = this._mapper.Map<SolicCreditoRecomendacionDto>(await this._creditoRepository.ActualizaSolicCreditoRecomendacion(solicitud)) };
        }

        /// <summary>
        /// Consultar Solicitud Credito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<ConsultaSolicitudCreditoDto>> ConsultarSolicitudCredito(ConsultaSolicitudCreditoDto request)
        {
            var consulta = this._mapper.Map<ConsultaSolicitudCredito>(request);
            return new Response<ConsultaSolicitudCreditoDto> { Data = this._mapper.Map<ConsultaSolicitudCreditoDto>(await this._creditoRepository.ConsultarSolicitudCredito(consulta)) };
        }

        /// <summary>
        /// Actualiza informacion seguro en solicitud credito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<ConsultaSolicitudCreditoDto>> ActualizaSolicCreditoSeguro(DatosActualizaSolicCreditoSeguroDto request)
        {
            var datos = this._mapper.Map<DatosActualizaSolicCreditoSeguro>(request);
            if (datos.SOC_CONVENIO_ASEGURADORA == string.Empty || datos.SOC_CONVENIO_ASEGURADORA == null) datos.SOC_CONVENIO_ASEGURADORA = "0";
            if (datos.SOC_CONVENIO_ASEGURADORA_HOGAR == string.Empty || datos.SOC_CONVENIO_ASEGURADORA_HOGAR == null) datos.SOC_CONVENIO_ASEGURADORA = "0";
            return new Response<ConsultaSolicitudCreditoDto> { Data = this._mapper.Map<ConsultaSolicitudCreditoDto>(await this._creditoRepository.ActualizaSolicCreditoSeguro(datos)) };
        }
        /// <summary>
        /// Crea la simulacion del credito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<PlanillaSimulacionCreditoDto>>> CrearSimulacionCliente(CreacionSimulacionClienteDto request)
        {
            return new Response<IEnumerable<PlanillaSimulacionCreditoDto>> { Data = this._mapper.Map<IEnumerable<PlanillaSimulacionCreditoDto>>(await this._creditoRepository.CrearSimulacionCliente(request)) };
        }



        #region Consecutivo
        /// <summary>
        /// CrearConsecutivo
        /// </summary>
        /// <param name="consecutivo"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<ConsecutivoDto>> CrearConsecutivo(ConsecutivoDto consecutivo)
        {
            string codigoMensaje = "";
            var responseData = this._mapper.Map<ConsecutivoDto>(
                    await this._creditoRepository.CrearConsecutivo(
                         this._mapper.Map<Consecutivo>(consecutivo)));
            if (responseData != null)
            {
                codigoMensaje = ResponseMessageConstants.CodigoMensaje1;
            }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<ConsecutivoDto>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje

            };
        }



        /// <summary>
        /// ActualizarConsecutivo
        /// </summary>
        /// <param name="consecutivo"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<ConsecutivoDto>> ActualizarConsecutivo(ConsecutivoDto consecutivo)
        {
            var ResponseData = this._mapper.Map<ConsecutivoDto>(
                    await this._creditoRepository.ActualizarConsecutivo(
                         this._mapper.Map<Consecutivo>(consecutivo)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; };
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<ConsecutivoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }

        /// <summary>
        /// ObtenerConsecutivoPorId
        /// </summary>
        /// <param name="consecutivoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<ConsecutivoDto>> ObtenerConsecutivoPorId(string consecutivoid)
        {
            var ResponseData = this._mapper.Map<ConsecutivoDto>(
                    await this._creditoRepository.ObtenerConsecutivoPorId(consecutivoid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);

            return new Response<ConsecutivoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }

        /// <summary>
        /// ObtenerConsecutivo
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<IEnumerable<ConsecutivoDto>>> ObtenerConsecutivo()
        {
            IEnumerable<ConsecutivoDto> responseData = this._mapper.Map<IEnumerable<ConsecutivoDto>>(
                await this._creditoRepository.ObtenerConsecutivo());
            string codigoMensaje = "";
            if (responseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            else { codigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<IEnumerable<ConsecutivoDto>>
            {
                Data = responseData,
                ReturnMessage = mensaje.Mensaje
            };
        }

        /// <summary>
        /// EliminarConsecutivoPorid
        /// </summary>
        /// <param name="consecutivoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<ConsecutivoDto>> EliminarConsecutivoPorid(string consecutivoid)
        {
            var ResponseData = this._mapper.Map<ConsecutivoDto>(
                    await this._creditoRepository.EliminarConsecutivoPorid(consecutivoid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<ConsecutivoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        #endregion

        #region Aseguradoras
        /// <summary>
        /// CrearAseguradoras
        /// </summary>
        /// <param name="aseguradoras"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<AseguradorasDto>> CrearAseguradoras(AseguradorasDto aseguradoras)
        {
            var ResponseData = this._mapper.Map<AseguradorasDto>(
                    await this._creditoRepository.CrearAseguradoras(
                         this._mapper.Map<Aseguradoras>(aseguradoras)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<AseguradorasDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ActualizarAseguradoras
        /// </summary>
        /// <param name="aseguradoras"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<AseguradorasDto>> ActualizarAseguradoras(AseguradorasDto aseguradoras)
        {
            var ResponseData = this._mapper.Map<AseguradorasDto>(
                    await this._creditoRepository.ActualizarAseguradoras(
                         this._mapper.Map<Aseguradoras>(aseguradoras)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<AseguradorasDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerAseguradorasPorId
        /// </summary>
        /// <param name="aseguradorasid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<AseguradorasDto>> ObtenerAseguradorasPorId(string aseguradorasid)
        {
            var ResponseData = this._mapper.Map<AseguradorasDto>(
                    await this._creditoRepository.ObtenerAseguradorasPorId(aseguradorasid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<AseguradorasDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarAseguradorasPorid
        /// </summary>
        /// <param name="aseguradorasid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<AseguradorasDto>> EliminarAseguradorasPorid(string aseguradorasid)
        {
            var ResponseData = this._mapper.Map<AseguradorasDto>(
                    await this._creditoRepository.EliminarAseguradorasPorid(aseguradorasid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<AseguradorasDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerAseguradoras
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<IEnumerable<AseguradorasDto>>> ObtenerAseguradoras()
        {

            IEnumerable<AseguradorasDto> ResponseData = this._mapper.Map<IEnumerable<AseguradorasDto>>(
                await this._creditoRepository.ObtenerAseguradoras());
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            else { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<IEnumerable<AseguradorasDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }



        #endregion

        #region AlertaAutomaticas
        /// <summary>
        /// CrearAlertaAutomaticas
        /// </summary>
        /// <param name="alertaautomaticas"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<AlertaAutomaticasDto>> CrearAlertaAutomaticas(AlertaAutomaticasDto alertaautomaticas)
        {
            var ResponseData = this._mapper.Map<AlertaAutomaticasDto>(
                    await this._creditoRepository.CrearAlertaAutomaticas(
                         this._mapper.Map<AlertaAutomaticas>(alertaautomaticas)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<AlertaAutomaticasDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ActualizarAlertaAutomaticas
        /// </summary>
        /// <param name="alertaautomaticas"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        public async Task<Response<AlertaAutomaticasDto>> ActualizarAlertaAutomaticas(AlertaAutomaticasDto alertaautomaticas)
        {
            var ResponseData = this._mapper.Map<AlertaAutomaticasDto>(
                    await this._creditoRepository.ActualizarAlertaAutomaticas(
                         this._mapper.Map<AlertaAutomaticas>(alertaautomaticas)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<AlertaAutomaticasDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje

            };
        }
        /// <summary>
        /// ObtenerAlertaAutomaticasPorId
        /// </summary>
        /// <param name="alertaautomaticasid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<AlertaAutomaticasDto>> ObtenerAlertaAutomaticasPorId(string alertaautomaticasid)
        {
            var ResponseData = this._mapper.Map<AlertaAutomaticasDto>(
                    await this._creditoRepository.ObtenerAlertaAutomaticasPorId(alertaautomaticasid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<AlertaAutomaticasDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarAlertaAutomaticasPorid
        /// </summary>
        /// <param name="alertaautomaticasid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<AlertaAutomaticasDto>> EliminarAlertaAutomaticasPorid(string alertaautomaticasid)
        {
            var ResponseData = this._mapper.Map<AlertaAutomaticasDto>(
                    await this._creditoRepository.EliminarAlertaAutomaticasPorid(alertaautomaticasid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<AlertaAutomaticasDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerAlertaAutomaticas
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<IEnumerable<AlertaAutomaticasDto>>> ObtenerAlertaAutomaticas()
        {
            IEnumerable<AlertaAutomaticasDto> ResponseData =
                this._mapper.Map<IEnumerable<AlertaAutomaticasDto>>(await this._creditoRepository.ObtenerAlertaAutomaticas());
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            else { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<IEnumerable<AlertaAutomaticasDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }


        #endregion

        #region ColorGrilla
        /// <summary>
        /// CrearColorGrilla
        /// </summary>
        /// <param name="colorgrilla"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<ColorGrillaDto>> CrearColorGrilla(ColorGrillaDto colorgrilla)
        {
            var ResponseData = this._mapper.Map<ColorGrillaDto>(
                    await this._creditoRepository.CrearColorGrilla(
                         this._mapper.Map<ColorGrilla>(colorgrilla)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<ColorGrillaDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ActualizarColorGrilla
        /// </summary>
        /// <param name="colorGrilla"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<ColorGrillaDto>> ActualizarColorGrilla(ColorGrillaDto colorgrilla)
        {
            var ResponseData = this._mapper.Map<ColorGrillaDto>(
                    await this._creditoRepository.ActualizarColorGrilla(
                         this._mapper.Map<ColorGrilla>(colorgrilla)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<ColorGrillaDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerColorGrillaPorId
        /// </summary>
        /// <param name="colorGrillaId"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<ColorGrillaDto>> ObtenerColorGrillaPorId(string colorgrillaId)
        {
            var ResponseData = this._mapper.Map<ColorGrillaDto>(
                    await this._creditoRepository.ObtenerColorGrillaPorId(colorgrillaId));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<ColorGrillaDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarColorGrillaPorid
        /// </summary>
        /// <param name="colorgrillaId"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<ColorGrillaDto>> EliminarColorGrillaPorid(string colorgrillaId)
        {
            var ResponseData = this._mapper.Map<ColorGrillaDto>(
                    await this._creditoRepository.EliminarColorGrillaPorid(colorgrillaId));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<ColorGrillaDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerColorGrilla
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<IEnumerable<ColorGrillaDto>>> ObtenerColorGrilla()
        {
            IEnumerable<ColorGrillaDto> ResponseData =
                this._mapper.Map<IEnumerable<ColorGrillaDto>>(await this._creditoRepository.ObtenerColorGrilla());
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<IEnumerable<ColorGrillaDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
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
        public async Task<Response<EstadoActividadDto>> CrearEstadoActividad(EstadoActividadDto estadoActividad)
        {
            var ResponseData = this._mapper.Map<EstadoActividadDto>(
                    await this._creditoRepository.CrearEstadoActividad(
                         this._mapper.Map<EstadoActividad>(estadoActividad)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<EstadoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ActualizarEstadoActividad
        /// </summary>
        /// <param name="estadoActividad"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<EstadoActividadDto>> ActualizarEstadoActividad(EstadoActividadDto estadoActividad)
        {
            var ResponseData = this._mapper.Map<EstadoActividadDto>(
                    await this._creditoRepository.ActualizarEstadoActividad(
                         this._mapper.Map<EstadoActividad>(estadoActividad)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<EstadoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerEstadoActividadPorId
        /// </summary>
        /// <param name="estadoActividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<EstadoActividadDto>> ObtenerEstadoActividadPorId(string estadoActividadid)
        {
            var ResponseData = this._mapper.Map<EstadoActividadDto>(
                    await this._creditoRepository.ObtenerEstadoActividadPorId(estadoActividadid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<EstadoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarEstadoActividadPorid
        /// </summary>
        /// <param name="estadoActividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<EstadoActividadDto>> EliminarEstadoActividadPorid(string estadoActividadid)
        {
            var ResponseData = this._mapper.Map<EstadoActividadDto>(
                    await this._creditoRepository.EliminarEstadoActividadPorid(estadoActividadid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<EstadoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerEstadoActividad
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<IEnumerable<EstadoActividadDto>>> ObtenerEstadoActividad()
        {
            IEnumerable<EstadoActividadDto> ResponseData =
                this._mapper.Map<IEnumerable<EstadoActividadDto>>(await this._creditoRepository.ObtenerEstadoActividad());
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);

            return new Response<IEnumerable<EstadoActividadDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje

            };
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
        public async Task<Response<EstadoSolicitudDto>> CrearEstadoSolicitud(EstadoSolicitudDto estadosolicitud)
        {
            var ResponseData = this._mapper.Map<EstadoSolicitudDto>(
                    await this._creditoRepository.CrearEstadoSolicitud(
                         this._mapper.Map<EstadoSolicitud>(estadosolicitud)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<EstadoSolicitudDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ActualizarEstadoSolicitud
        /// </summary>
        /// <param name="estadosolicitud"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<EstadoSolicitudDto>> ActualizarEstadoSolicitud(EstadoSolicitudDto estadosolicitud)
        {
            var ResponseData = this._mapper.Map<EstadoSolicitudDto>(
                    await this._creditoRepository.ActualizarEstadoSolicitud(
                         this._mapper.Map<EstadoSolicitud>(estadosolicitud)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<EstadoSolicitudDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje

            };
        }
        /// <summary>
        /// ObtenerEstadoSolicitudPorId
        /// </summary>
        /// <param name="estadosolicitudid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<EstadoSolicitudDto>> ObtenerEstadoSolicitudPorId(string estadosolicitudid)
        {
            var ResponseData = this._mapper.Map<EstadoSolicitudDto>(
                    await this._creditoRepository.ObtenerEstadoSolicitudPorId(estadosolicitudid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<EstadoSolicitudDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarEstadoSolicitudPorid
        /// </summary>
        /// <param name="estadosolicitudid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<EstadoSolicitudDto>> EliminarEstadoSolicitudPorid(string estadosolicitudid)
        {
            var ResponseData = this._mapper.Map<EstadoSolicitudDto>(
                    await this._creditoRepository.EliminarEstadoSolicitudPorid(estadosolicitudid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<EstadoSolicitudDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerEstadoSolicitud
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<IEnumerable<EstadoSolicitudDto>>> ObtenerEstadoSolicitud()
        {
            IEnumerable<EstadoSolicitudDto> ResponseData =
                this._mapper.Map<IEnumerable<EstadoSolicitudDto>>(await this._creditoRepository.ObtenerEstadoSolicitud());
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<IEnumerable<EstadoSolicitudDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
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
        public async Task<Response<TipoActividadDto>> CrearTipoActividad(TipoActividadDto tipoActividad)
        {
            var ResponseData = this._mapper.Map<TipoActividadDto>(
                    await this._creditoRepository.CrearTipoActividad(
                         this._mapper.Map<TipoActividad>(tipoActividad)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<TipoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ActualizarTipoActividad
        /// </summary>
        /// <param name="TipoActividad"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<TipoActividadDto>> ActualizarTipoActividad(TipoActividadDto tipoActividad)
        {
            var ResponseData = this._mapper.Map<TipoActividadDto>(
                    await this._creditoRepository.ActualizarTipoActividad(
                         this._mapper.Map<TipoActividad>(tipoActividad)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<TipoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerTipoActividadPorId
        /// </summary>
        /// <param name="tipoActividaid
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<TipoActividadDto>> ObtenerTipoActividadPorId(string tipoActividaid)
        {
            var ResponseData = this._mapper.Map<TipoActividadDto>(
                    await this._creditoRepository.ObtenerTipoActividadPorId(tipoActividaid));
            string codigoMensaje = "";
            if (ResponseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<TipoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarTipoActividadPorid
        /// </summary>
        /// <param name="tipoActividaid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<TipoActividadDto>> EliminarTipoActividadPorid(string tipoActividaid)
        {
            var ResponseData = this._mapper.Map<TipoActividadDto>(
                    await this._creditoRepository.EliminarTipoActividadPorid(tipoActividaid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<TipoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerTipoActividad
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<IEnumerable<TipoActividadDto>>> ObtenerTipoActividad()
        {
            IEnumerable<TipoActividadDto> ResponseData =
                this._mapper.Map<IEnumerable<TipoActividadDto>>(await this._creditoRepository.ObtenerTipoActividad());
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<IEnumerable<TipoActividadDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }


        #endregion

        #region Tipo Documento
        /// <summary>
        /// CrearTipoDocumento
        /// </summary>
        /// <param name="tipodocumento"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<TipoDocumentoDto>> CrearTipoDocumento(TipoDocumentoDto tipodocumento)
        {
            var ResponseData = this._mapper.Map<TipoDocumentoDto>(
                    await this._creditoRepository.CrearTipoDocumento(
                         this._mapper.Map<TipoDocumento>(tipodocumento)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<TipoDocumentoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ActualizarTipoDocumento
        /// </summary>
        /// <param name="tipodocumento"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<TipoDocumentoDto>> ActualizarTipoDocumento(TipoDocumentoDto tipodocumento)
        {
            var ResponseData = this._mapper.Map<TipoDocumentoDto>(
                    await this._creditoRepository.ActualizarTipoDocumento(
                         this._mapper.Map<TipoDocumento>(tipodocumento)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<TipoDocumentoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerTipoDocumentoPorId
        /// </summary>
        /// <param name="tipodocumentoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<TipoDocumentoDto>> ObtenerTipoDocumentoPorId(string tipodocumentoid)
        {
            var ResponseData = this._mapper.Map<TipoDocumentoDto>(
                    await this._creditoRepository.ObtenerTipoDocumentoPorId(tipodocumentoid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<TipoDocumentoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarTipoDocumentoPorid
        /// </summary>
        /// <param name="tipodocumentoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<TipoDocumentoDto>> EliminarTipoDocumentoPorid(string tipodocumentoid)
        {
            var ResponseData = this._mapper.Map<TipoDocumentoDto>(
                    await this._creditoRepository.EliminarTipoDocumentoPorid(tipodocumentoid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<TipoDocumentoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }

        /// <summary>
        /// ObtenerTipoDocumento
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<IEnumerable<TipoDocumentoDto>>> ObtenerTipoDocumento()
        {
            IEnumerable<TipoDocumentoDto> ResponseData =
                this._mapper.Map<IEnumerable<TipoDocumentoDto>>(await this._creditoRepository.ObtenerTipoDocumento());
            string codigoMensaje = "";
            if (ResponseData != null) { codigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(codigoMensaje);
            return new Response<IEnumerable<TipoDocumentoDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }

        #endregion

        #region Flujo

        /// <summary>
        /// CrearFlujo
        /// </summary>
        /// <param name="flujo"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<FlujoDto>> CrearFlujo(FlujoDto flujo)
        {
            var ResponseData = this._mapper.Map<FlujoDto>(
                    await this._creditoRepository.CrearFlujo(
                         this._mapper.Map<Flujo>(flujo)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);

            return new Response<FlujoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ActualizarFlujo
        /// </summary>
        /// <param name="flujo"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<FlujoDto>> ActualizarFlujo(FlujoDto flujo)
        {
            var ResponseData = this._mapper.Map<FlujoDto>(
                    await this._creditoRepository.ActualizarFlujo(
                         this._mapper.Map<Flujo>(flujo)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<FlujoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerFlujoPorId
        /// </summary>
        /// <param name="flujoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<FlujoDto>> ObtenerFlujoPorId(string flujoid)
        {
            var ResponseData = this._mapper.Map<FlujoDto>(
                    await this._creditoRepository.ObtenerFlujoPorId(flujoid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<FlujoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarFlujoPorid
        /// </summary>
        /// <param name="flujoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<FlujoDto>> EliminarFlujoPorid(string flujoid)
        {
            var ResponseData = this._mapper.Map<FlujoDto>(
                    await this._creditoRepository.EliminarFlujoPorid(flujoid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<FlujoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerFlujo
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<IEnumerable<FlujoDto>>> ObtenerFlujo()
        {
            IEnumerable<FlujoDto> Responsedata =
                this._mapper.Map<IEnumerable<FlujoDto>>(await this._creditoRepository.ObtenerFlujo());
            string CodigoMensaje = "";
            if (Responsedata != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<IEnumerable<FlujoDto>>
            {
                Data = Responsedata,
                ReturnMessage = Mensaje.Mensaje
            };
        }

        #endregion

        #region Flujo Tipo Credito
        /// <summary>
        /// CrearFlujoTipoCredito
        /// </summary>
        /// <param name="flujotipoCredito"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<FlujoTipoCreditoDto>> CrearFlujoTipoCredito(FlujoTipoCreditoDto flujotipoCredito)
        {
            var ResponseData = this._mapper.Map<FlujoTipoCreditoDto>(
                    await this._creditoRepository.CrearFlujoTipoCredito(
                         this._mapper.Map<FlujoTipoCredito>(flujotipoCredito)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<FlujoTipoCreditoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ActualizarFlujoTipoCredito
        /// </summary>
        /// <param name="flujotipoCredito"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<FlujoTipoCreditoDto>> ActualizarFlujoTipoCredito(FlujoTipoCreditoDto flujotipoCredito)
        {
            var ResponseData = this._mapper.Map<FlujoTipoCreditoDto>(
                    await this._creditoRepository.ActualizarFlujoTipoCredito(
                         this._mapper.Map<FlujoTipoCredito>(flujotipoCredito)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<FlujoTipoCreditoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerFlujoTipoCreditoPorId
        /// </summary>
        /// <param name="flujotipoCreditoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<FlujoTipoCreditoDto>> ObtenerFlujoTipoCreditoPorId(string flujotipoCreditoid)
        {
            var ResponseData = this._mapper.Map<FlujoTipoCreditoDto>(
                    await this._creditoRepository.ObtenerFlujoTipoCreditoPorId(flujotipoCreditoid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<FlujoTipoCreditoDto>
            {
                Data = this._mapper.Map<FlujoTipoCreditoDto>(
                    await this._creditoRepository.ObtenerFlujoTipoCreditoPorId(flujotipoCreditoid))
            };

        }
        /// <summary>
        /// EliminarFlujoTipoCreditoPorid
        /// </summary>
        /// <param name="flujotipoCreditoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<FlujoTipoCreditoDto>> EliminarFlujoTipoCreditoPorid(string flujotipoCreditoid)
        {
            var ResponseDate = this._mapper.Map<FlujoTipoCreditoDto>(
                    await this._creditoRepository.EliminarFlujoTipoCreditoPorid(flujotipoCreditoid));
            string CodigoMensaje = "";
            if (ResponseDate != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<FlujoTipoCreditoDto>
            {
                Data = ResponseDate,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerFlujoTipoCredito
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<IEnumerable<FlujoTipoCreditoDto>>> ObtenerFlujoTipoCredito()
        {
            IEnumerable<FlujoTipoCreditoDto> ResponseData =
                this._mapper.Map<IEnumerable<FlujoTipoCreditoDto>>(await this._creditoRepository.ObtenerFlujoTipoCredito());
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<IEnumerable<FlujoTipoCreditoDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }

        #endregion

        #region Actividad Flujo
        /// <summary>
        /// CrearActividadFlujo
        /// </summary>
        /// <param name="actividadflujo"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<ActividadFlujoDto>> CrearActividadFlujo(ActividadFlujoDto actividadflujo)
        {
            var ResponseData = this._mapper.Map<ActividadFlujoDto>(
                    await this._creditoRepository.CrearActividadFlujo(
                         this._mapper.Map<ActividadFlujo>(actividadflujo)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<ActividadFlujoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerActividadFlujoPorId
        /// </summary>
        /// <param name="actividadflujoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<ActividadFlujoDto>> ObtenerActividadFlujoPorId(string actividadflujoid)
        {
            var ResponseData = this._mapper.Map<ActividadFlujoDto>(
                    await this._creditoRepository.ObtenerActividadFlujoPorId(actividadflujoid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<ActividadFlujoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarActividadFlujoPorid
        /// </summary>
        /// <param name="actividadflujoid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<ActividadFlujoDto>> EliminarActividadFlujoPorid(string actividadflujoid)
        {
            var ResponseData = this._mapper.Map<ActividadFlujoDto>(
                    await this._creditoRepository.EliminarActividadFlujoPorid(actividadflujoid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<ActividadFlujoDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerActividadFlujo
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 


        public async Task<Response<IEnumerable<ActividadFlujoDto>>> ObtenerActividadFlujo()
        {
            IEnumerable<ActividadFlujoDto> ResponseData =
                this._mapper.Map<IEnumerable<ActividadFlujoDto>>(await this._creditoRepository.ObtenerActividadFlujo());
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<IEnumerable<ActividadFlujoDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }

        #endregion

        #region Usuario Actividad
        /// <summary>
        /// CrearUsuarioActividad
        /// </summary>
        /// <param name="usuarioactividad"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<UsuarioActividadDto>> CrearUsuarioActividad(UsuarioActividadDto usuarioactividad)
        {
            var ResponseData = this._mapper.Map<UsuarioActividadDto>(
                    await this._creditoRepository.CrearUsuarioActividad(
                         this._mapper.Map<UsuarioActividad>(usuarioactividad)));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<UsuarioActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerUsuarioActividadPorId
        /// </summary>
        /// <param name="usuarioactividadId"></param>
        /// 
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 

        public async Task<Response<UsuarioActividadDto>> ObtenerUsuarioActividadPorId(string usuarioactividadid)
        {
            var ResponseData = this._mapper.Map<UsuarioActividadDto>(
                    await this._creditoRepository.ObtenerUsuarioActividadPorId(usuarioactividadid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<UsuarioActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarUsuarioActividadPorid
        /// </summary>
        /// <param name="usuarioactividadId"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<UsuarioActividadDto>> EliminarUsuarioActividadPorid(string usuarioactividadid)
        {
            var ResponseData = this._mapper.Map<UsuarioActividadDto>(
                    await this._creditoRepository.EliminarUsuarioActividadPorid(usuarioactividadid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<UsuarioActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }

        /// <summary>
        /// ObtenerUsuarioActividad
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<IEnumerable<UsuarioActividadDto>>> ObtenerUsuarioActividad()
        {
            IEnumerable<UsuarioActividadDto> ResponseData =
                this._mapper.Map<IEnumerable<UsuarioActividadDto>>(await this._creditoRepository.ObtenerUsuarioActividad());
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<IEnumerable<UsuarioActividadDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje

            };
        }

        #endregion

        #region Documento Actividad
        /// <summary>
        /// CrearDocumentoActividad
        /// </summary>
        /// <param name="documentoactividad"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<DocumentoActividadDto>> CrearDocumentoActividad(DocumentoActividadDto documentoactividad)
        {
            var ResponseData = this._mapper.Map<DocumentoActividadDto>(
                    await this._creditoRepository.CrearDocumentoActividad(
                         this._mapper.Map<DocumentoActividad>(documentoactividad)));
            string CodigoMenaje = "";
            if (ResponseData != null) { CodigoMenaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMenaje);
            return new Response<DocumentoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }
        /// <summary>
        /// ObtenerDocumentoActividadPorId
        /// </summary>
        /// <param name="documentoactividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<DocumentoActividadDto>> ObtenerDocumentoActividadPorId(string documentoactividadid)
        {

            var ResponseData = this._mapper.Map<DocumentoActividadDto>(
                    await this._creditoRepository.ObtenerDocumentoActividadPorId(documentoactividadid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<DocumentoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };

        }
        /// <summary>
        /// EliminarDocumentoActividadPorid
        /// </summary>
        /// <param name="documentoactividadid"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<DocumentoActividadDto>> EliminarDocumentoActividadPorid(string documentoactividadid)
        {
            var ResponseData = this._mapper.Map<DocumentoActividadDto>(
                    await this._creditoRepository.EliminarDocumentoActividadPorid(documentoactividadid));
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<DocumentoActividadDto>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }

        /// <summary>
        /// ObtenerDocumentoActividad
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<IEnumerable<DocumentoActividadDto>>> ObtenerDocumentoActividad()
        {

            IEnumerable<DocumentoActividadDto> ResponseData =
                this._mapper.Map<IEnumerable<DocumentoActividadDto>>
                (await this._creditoRepository.ObtenerDocumentoActividad());
            string CodigoMensaje = "";
            if (ResponseData != null) { CodigoMensaje = ResponseMessageConstants.CodigoMensaje1; }
            MensajeDto Mensaje = await ObtenerMensaje(CodigoMensaje);
            return new Response<IEnumerable<DocumentoActividadDto>>
            {
                Data = ResponseData,
                ReturnMessage = Mensaje.Mensaje
            };
        }

        #endregion

        /// <summary>
        /// Obtiene los datos del comite de crédito
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="datosComiteCredito"></param>
        /// <returns></returns>
        public async Task<Response<List<DatosComiteCreditoDto>>> ObtenerComiteCredito(DatosComiteCreditoDto datosComiteCredito)
        {
            var datos = this._mapper.Map<DatosComiteCredito>(datosComiteCredito);
            return new Response<List<DatosComiteCreditoDto>> { Data = this._mapper.Map<List<DatosComiteCreditoDto>>(await this._creditoRepository.ObtenerComiteCredito(datos)) };
        }

        /// <summary>
        /// Aprueba comite de credito
        /// </summary>
        /// <param name="datosComiteCredito"></param>
        /// <returns></returns>
        public async Task<Response<DatosComiteCreditoDto>> AprobarComiteCredito(DatosComiteCreditoDto datosComiteCredito)
        {
            var datos = this._mapper.Map<DatosComiteCredito>(datosComiteCredito);
            return new Response<DatosComiteCreditoDto> { Data = this._mapper.Map<DatosComiteCreditoDto>(await this._creditoRepository.AprobarComiteCredito(datos)) };
        }

        /// <summary>
        /// Obtiene la lista de integrantes del comité de credito
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<IntegranteComiteDto>>> ObtenerIntegranteComite()
        {
            return new Response<IEnumerable<IntegranteComiteDto>> { Data = this._mapper.Map<IEnumerable<IntegranteComiteDto>>(await this._creditoRepository.ObtenerIntegranteComite()) };
        }

        /// <summary>
        /// Obtiene la lista de temas del comité de credito
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<TemaComiteDto>>> ObtenerTemasComite()
        {
            return new Response<IEnumerable<TemaComiteDto>> { Data = this._mapper.Map<IEnumerable<TemaComiteDto>>(await this._creditoRepository.ObtenerTemasComite()) };
        }

        /// <summary>
        /// Obtiene los integrantes de un comite según el comité
        /// </summary>
        /// <param name="integranteComite"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<IntegrantePorComiteDto>>> ObtenerComiteCreditoIntegrante(IntegrantePorComiteDto integrantePorComite)
        {
            var datos = this._mapper.Map<IntegrantePorComite>(integrantePorComite);
            return new Response<IEnumerable<IntegrantePorComiteDto>> { Data = this._mapper.Map<IEnumerable<IntegrantePorComiteDto>>(await this._creditoRepository.ObtenerComiteCreditoIntegrante(datos)) };
        }

        /// <summary>
        /// Crea comité de crédito
        /// </summary>
        /// <param name="DatosComiteCredito"></param>
        /// <returns></returns>
        public async Task<Response<DatosComiteCreditoDto>> CrearComiteCredito(DatosComiteCreditoDto DatosComiteCredito)
        {
            if (DatosComiteCredito.ComiteIntegrantesDto != null && DatosComiteCredito.TemasComiteCreditoDto != null)
            {
                var Datos = this._mapper.Map<DatosComiteCredito>(DatosComiteCredito);
                var DatosComite = this._mapper.Map<DatosComiteCreditoDto>(await this._creditoRepository.CrearComiteCredito(Datos));

                List<ComiteIntegranteDto> ListaIntegrantesComite = new List<ComiteIntegranteDto>();
                foreach (var Integrante in DatosComiteCredito.ComiteIntegrantesDto)
                {
                    Integrante.idComiteCredito = DatosComiteCredito.CodigoComite;
                    var DatosIntegrante = this._mapper.Map<ComiteIntegrante>(Integrante);
                    var IntegranteCreado = this._mapper.Map<ComiteIntegranteDto>(await this._creditoRepository.CrearComiteCreditoIntegrante(DatosIntegrante));
                    IntegranteCreado.creadoPor = DatosComiteCredito.CreadoPor;
                    IntegranteCreado.fechaCreacion = DateTime.Now;
                    ListaIntegrantesComite.Add(IntegranteCreado);
                }

                List<TemaComiteCreditoDto> ListaTemasComite = new List<TemaComiteCreditoDto>();
                var contadorTemas = 1;
                foreach (var Tema in DatosComiteCredito.TemasComiteCreditoDto)
                {
                    var DatosTema = this._mapper.Map<TemaComiteCredito>(Tema);
                    DatosTema.COT_CREADO_POR = DatosComiteCredito.CreadoPor;
                    DatosTema.COT_FECHA_CREACION = DatosComiteCredito.FechaCreacion;
                    DatosTema.COC_ID = DatosComite.CodigoComite;
                    DatosTema.TCO_ID = contadorTemas;
                    ListaTemasComite.Add(this._mapper.Map<TemaComiteCreditoDto>(await this._creditoRepository.CrearComiteCreditoTemas(DatosTema)));
                    contadorTemas++;
                }

                DatosComite.ComiteIntegrantesDto = ListaIntegrantesComite;
                DatosComite.TemasComiteCreditoDto = ListaTemasComite;
                return new Response<DatosComiteCreditoDto> { Data = DatosComite };
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Crea integrante para comité de credito
        /// </summary>
        /// <param name="integrante"></param>
        /// <returns></returns>
        public async Task<Response<ComiteIntegranteDto>> CrearComiteCreditoIntegrante(ComiteIntegranteDto integrante)
        {
            var datos = this._mapper.Map<ComiteIntegrante>(integrante);
            return new Response<ComiteIntegranteDto> { Data = this._mapper.Map<ComiteIntegranteDto>(await this._creditoRepository.CrearComiteCreditoIntegrante(datos)) };
        }

        /// <summary>
        /// Crea tema para comite de credito
        /// </summary>
        /// <param name="temaComiteCredito"></param>
        /// <returns></returns>
        public async Task<Response<TemaComiteCreditoDto>> CrearComiteCreditoTemas(TemaComiteCreditoDto temaComiteCredito)
        {
            var datos = this._mapper.Map<TemaComiteCredito>(temaComiteCredito);
            return new Response<TemaComiteCreditoDto> { Data = this._mapper.Map<TemaComiteCreditoDto>(await this._creditoRepository.CrearComiteCreditoTemas(datos)) };
        }

        /// <summary>
        /// Obtiene Solicitud Comite Credito
        /// </summary>
        /// <param name="solicitudComite"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<SolicitudComiteDto>>> ObtenerComiteCreditoSolicitud(SolicitudComiteDto solicitudComite)
        {
            var datos = this._mapper.Map<SolicitudComite>(solicitudComite);
            return new Response<IEnumerable<SolicitudComiteDto>> { Data = this._mapper.Map<IEnumerable<SolicitudComiteDto>>(await this._creditoRepository.ObtenerComiteCreditoSolicitud(datos)) };
        }

        /// <summary>
        /// Crear solicitud comite credito
        /// </summary>
        /// <param name="solicitudComite"></param>
        /// <returns></returns>
        public async Task<Response<SolicitudComiteCreacionDto>> CrearComiteCreditoSolicitud(SolicitudComiteCreacionDto solicitudComite)
        {
            if (solicitudComite.aprobada.ToUpper() != solicitudComite.rechazada.ToUpper())
            {
                var datos = this._mapper.Map<SolicitudComiteCreacion>(solicitudComite);
                return new Response<SolicitudComiteCreacionDto> { Data = this._mapper.Map<SolicitudComiteCreacionDto>(await this._creditoRepository.CrearComiteCreditoSolicitud(datos)) };

            }
            else return new Response<SolicitudComiteCreacionDto> { ReturnMessage = "Aprobado y rechazado no pueden ser iguales" };
        }

        /// <summary>
        /// Obtener Historial Comercial Buro
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FileResult> ObtenerHistorialComercialBuro(RequestTuDto request)
        {
            request.IdValidation = Guid.NewGuid().ToString();
            var optionsAqm = _optionsAqm.Value;
            double diferenciaDias = 0;
            HistorialCredito consulta = new HistorialCredito();


            try
            {
                consulta = await this._creditoRepository.ObtenerHistorialComercialBuro(request.IdNumber);
                diferenciaDias = (DateTime.Now - consulta.CBC_FECHA_CONSULTA).TotalDays;
            }
            catch (Exception)
            {
                diferenciaDias = 0;
            }

            if (diferenciaDias > 90 || diferenciaDias == 0)
            {
                GestorIdVisionBusinessLogic ConsultasTransUnion = new GestorIdVisionBusinessLogic();

                request.usrId = optionsAqm.usuarioAqm;
                request.pasword = optionsAqm.claveAqm;
                request.solucionId = optionsAqm.solucionIdAqm;
                var ScoreCliente = await ConsultasTransUnion.obtenerScoreCliente(request);
                request.idAplication = ScoreCliente.Data.idAplication;
                var HistorialCliente = await ConsultasTransUnion.obtenerHistorialCliente(request);
                consulta = await this._creditoRepository.ObtenerHistorialComercialBuro(request.IdNumber);
            }

            BlobContainerClient container = new BlobContainerClient(this._options.Value.CadenaOne, "credito");
            BlobClient blobBase = container.GetBlobClient(@"f424b2cf-2b73-444a-b07e-af13264050d3.html");
            BlobClient blobCss = container.GetBlobClient(@"9ed25983-6561-44f4-b8dd-deecda8e0050.css");
            BlobClient BaseCuentasVigentes = container.GetBlobClient(@"5066ce7d-b246-4c67-920c-14fdad44ac38.html");
            BlobClient BaseObligacionesExtinguidas = container.GetBlobClient(@"3bc60303-81ab-4483-9e9e-2af89e632a40.html");
            BlobClient BaseObligacionesVigentes = container.GetBlobClient(@"fb124596-cc2f-4a5a-9054-d991baff9adb.html");
            BlobClient BaseInformacionConsolidadaTrimestreI = container.GetBlobClient(@"eb06817f-1c04-4c1a-80a6-d6ccc1fbd4c6.html");
            BlobClient BaseInformacionDetalladaTrimestreI = container.GetBlobClient(@"dc15ab68-593d-437c-b4ba-cea6c71086ac.html");
            BlobClient BaseInformacionConsolidadaTrimestreII = container.GetBlobClient(@"eb06817f-1c04-4c1a-80a6-d6ccc1fbd4c6.html");
            BlobClient BaseInformacionDetalladaTrimestreII = container.GetBlobClient(@"dc15ab68-593d-437c-b4ba-cea6c71086ac.html");
            BlobClient BaseInformacionConsolidadaTrimestreIII = container.GetBlobClient(@"eb06817f-1c04-4c1a-80a6-d6ccc1fbd4c6.html");
            BlobClient BaseInformacionDetalladaTrimestreIII = container.GetBlobClient(@"dc15ab68-593d-437c-b4ba-cea6c71086ac.html");
            BlobDownloadInfo downloadBase = await blobBase.DownloadAsync();
            BlobDownloadInfo downloadCss = await blobCss.DownloadAsync();
            BlobDownloadInfo downloadBaseCuentasVigentes = await BaseCuentasVigentes.DownloadAsync();
            BlobDownloadInfo downloadBaseObligacionesExtinguidas = await BaseObligacionesExtinguidas.DownloadAsync();
            BlobDownloadInfo downloadBaseObligacionesVigentes = await BaseObligacionesVigentes.DownloadAsync();
            BlobDownloadInfo downloadBaseInformacionConsolidadaTrimestreI = await BaseInformacionConsolidadaTrimestreI.DownloadAsync();
            BlobDownloadInfo downloadBaseInformacionDetalladaTrimestreI = await BaseInformacionDetalladaTrimestreI.DownloadAsync();
            BlobDownloadInfo downloadBaseInformacionConsolidadaTrimestreII = await BaseInformacionConsolidadaTrimestreII.DownloadAsync();
            BlobDownloadInfo downloadBaseInformacionDetalladaTrimestreII = await BaseInformacionDetalladaTrimestreII.DownloadAsync();
            BlobDownloadInfo downloadBaseInformacionConsolidadaTrimestreIII = await BaseInformacionConsolidadaTrimestreIII.DownloadAsync();
            BlobDownloadInfo downloadBaseInformacionDetalladaTrimestreIII = await BaseInformacionDetalladaTrimestreIII.DownloadAsync();

            var basefile = new FileStreamResult(downloadBase.Content, downloadBase.ContentType);
            var baseCss = new FileStreamResult(downloadCss.Content, downloadCss.ContentType);
            var baseCuentasVigentes = new FileStreamResult(downloadBaseCuentasVigentes.Content, downloadBaseCuentasVigentes.ContentType);
            var baseObligacionesExtinguidas = new FileStreamResult(downloadBaseObligacionesExtinguidas.Content, downloadBaseObligacionesExtinguidas.ContentType);
            var baseObligacionesVigentes = new FileStreamResult(downloadBaseObligacionesVigentes.Content, downloadBaseObligacionesVigentes.ContentType);
            var baseInformacionConsolidadaTrimestreI = new FileStreamResult(downloadBaseInformacionConsolidadaTrimestreI.Content, downloadBaseInformacionConsolidadaTrimestreI.ContentType);
            var baseInformacionDetalladaTrimestreI = new FileStreamResult(downloadBaseInformacionDetalladaTrimestreI.Content, downloadBaseInformacionDetalladaTrimestreI.ContentType);
            var baseInformacionConsolidadaTrimestreII = new FileStreamResult(downloadBaseInformacionConsolidadaTrimestreII.Content, downloadBaseInformacionConsolidadaTrimestreII.ContentType);
            var baseInformacionDetalladaTrimestreII = new FileStreamResult(downloadBaseInformacionDetalladaTrimestreII.Content, downloadBaseInformacionDetalladaTrimestreII.ContentType);
            var baseInformacionConsolidadaTrimestreIII = new FileStreamResult(downloadBaseInformacionConsolidadaTrimestreIII.Content, downloadBaseInformacionConsolidadaTrimestreIII.ContentType);
            var baseInformacionDetalladaTrimestreIII = new FileStreamResult(downloadBaseInformacionDetalladaTrimestreIII.Content, downloadBaseInformacionDetalladaTrimestreIII.ContentType);

            await basefile.FileStream.FlushAsync();
            await baseCss.FileStream.FlushAsync();
            await baseCuentasVigentes.FileStream.FlushAsync();
            await baseObligacionesExtinguidas.FileStream.FlushAsync();
            await baseObligacionesVigentes.FileStream.FlushAsync();
            await baseInformacionConsolidadaTrimestreI.FileStream.FlushAsync();
            await baseInformacionDetalladaTrimestreI.FileStream.FlushAsync();
            await baseInformacionConsolidadaTrimestreII.FileStream.FlushAsync();
            await baseInformacionDetalladaTrimestreII.FileStream.FlushAsync();
            await baseInformacionConsolidadaTrimestreIII.FileStream.FlushAsync();
            await baseInformacionDetalladaTrimestreIII.FileStream.FlushAsync();



            var historialCial = JsonConvert.DeserializeObject<Root>(consulta.CBC_HISTORIAL_CREDITO);
            PdfCreator archivoHistorial = new PdfCreator();
            var documento = await archivoHistorial.GenerarHistorialComercial(historialCial, basefile, baseCss, baseCuentasVigentes, baseObligacionesExtinguidas, baseObligacionesVigentes, baseInformacionConsolidadaTrimestreI, baseInformacionDetalladaTrimestreI, baseInformacionConsolidadaTrimestreII, baseInformacionDetalladaTrimestreII, baseInformacionConsolidadaTrimestreIII, baseInformacionDetalladaTrimestreIII);

            return documento;
        }

        /// <summary>
        /// Obtener Comite Credito Temas
        /// </summary>
        /// <param name="requestTemaComite"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<TemaComiteCreditoDto>>> ObtenerComiteCreditoTemas(RequestTemaComiteCreditoDto requestTemaComite)
        {
            var Solicitud = this._mapper.Map<RequestTemaComiteCredito>(requestTemaComite);
            return new Response<IEnumerable<TemaComiteCreditoDto>> { Data = this._mapper.Map<IEnumerable<TemaComiteCreditoDto>>(await this._creditoRepository.ObtenerComiteCreditoTemas(Solicitud)) };
        }

        /// <summary>
        /// Actualiza Solic Credito Tasas
        /// </summary>
        /// <param name="TasaSolicitudCredito"></param>
        /// <returns></returns>
        public async Task<Response<TasaSolicitudCreditoDto>> ActualizaSolicCreditoTasas(TasaSolicitudCreditoDto TasaSolicitudCredito)
        {
            var Tasa = this._mapper.Map<TasaSolicitudCredito>(TasaSolicitudCredito);
            return new Response<TasaSolicitudCreditoDto> { Data = this._mapper.Map<TasaSolicitudCreditoDto>(await this._creditoRepository.ActualizaSolicCreditoTasas(Tasa)) };
        }

        /// <summary>
        /// Obtener Fuentes Recursos
        /// </summary>
        /// <returns></returns>
        public async Task<Response<IEnumerable<FuenteRecursosDto>>> ObtenerFuentesRecursos()
        {
            return new Response<IEnumerable<FuenteRecursosDto>> { Data = this._mapper.Map<IEnumerable<FuenteRecursosDto>>(await this._creditoRepository.ObtenerFuentesRecursos()) };
        }

        /// <summary>
        /// Mensaje
        /// </summary>
        /// <param name="codigoMensaje"></param>
        ///<author>Cristian Gonzalez</author>
        /// <date>10/06/2021</date>
        private async Task<MensajeDto> ObtenerMensaje(string codigoMensaje)
        {
            return this._mapper.Map<MensajeDto>(await this._messageRepository.ObtenerMensaje(codigoMensaje));
        }
        /// <summary>
        /// Generar Documento Cesion Leasing
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FileResult> GenerarCesionLeasing(Guid request)
        {
            var respuesta = await this._creditoRepository.ObtenerDatosSolicComite(request);
            BlobContainerClient container = new BlobContainerClient(this._options.Value.CadenaOne, "legalizacion-cartera");
            BlobClient blobBase = container.GetBlobClient("fcc24e2d-c829-4f2e-8957-2029b7f9d053.html");
            BlobClient blobCss = container.GetBlobClient(@"d813b70b-cdce-4144-9544-f6a37c26df94.css");

            BlobDownloadInfo downloadBase = await blobBase.DownloadAsync();
            BlobDownloadInfo downloadCss = await blobCss.DownloadAsync();

            var baseHtlm = new FileStreamResult(downloadBase.Content, downloadBase.ContentType);
            var baseCss = new FileStreamResult(downloadCss.Content, downloadCss.ContentType);

            await baseHtlm.FileStream.FlushAsync();
            await baseCss.FileStream.FlushAsync();
            PdfCreator pdf = new PdfCreator();
            var Resultado = await pdf.GenerarCesionLeasig(respuesta, baseHtlm, baseCss);
            return Resultado;
        }

        /// <summary>
        /// Obtener Desembolsos Solicitud
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<SolicitudDesembolsoDto>>> ObtenerDesembolsosSolicitud(SolicitudDesembolsoDto request)
        {
            var solicitud = this._mapper.Map<SolicitudDesembolso>(request);
            return new Response<IEnumerable<SolicitudDesembolsoDto>> { Data = this._mapper.Map<IEnumerable<SolicitudDesembolsoDto>>(await this._creditoRepository.ObtenerDesembolsosSolicitud(solicitud)) };
        }

        /// <summary>
        /// Crear Solic Credito Desembolsos
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<SolicitudCreditosDesembolsosDto>>> CrearSolicCreditoDesembolsos(IEnumerable<SolicitudCreditosDesembolsosDto> requests)
        {
            var lista = new List<SolicitudCreditosDesembolsosDto>();
            foreach (var request in requests)
            {
                request.idSolicitudDesembolso = Guid.NewGuid();
                var solicitud = this._mapper.Map<SolicitudCreditosDesembolsos>(request);
                lista.Add(this._mapper.Map<SolicitudCreditosDesembolsosDto>(await this._creditoRepository.CrearSolicCreditoDesembolsos(solicitud)));
            }

            return new Response<IEnumerable<SolicitudCreditosDesembolsosDto>> { Data = lista };
        }
        /// <summary>
        /// AplicarDesembolsoSolicitud
        /// </summary>
        /// <param name="desembolso"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<DesembolsoCreditoSolicitudDto>> AplicarDesembolsoSolicitud(DesembolsoCreditoSolicitudDto desembolso)
        {
            return new Response<DesembolsoCreditoSolicitudDto>
            {
                Data = this._mapper.Map<DesembolsoCreditoSolicitudDto>(
                    await this._creditoRepository.AplicarDesembolsoSolicitud(
                         this._mapper.Map<DesembolsoCreditoSolicitud>(desembolso)))

            };
        }

        /// <summary>
        /// AplicarDesembolsoSolicitud
        /// </summary>
        /// <param name="desembolso"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<Response<IEnumerable<ObtenerCausalDesistimientoDto>>> ObtenerCausalDesistimiento()
        {

            return new Response<IEnumerable<ObtenerCausalDesistimientoDto>>
            {
                Data = this._mapper.Map<IEnumerable<ObtenerCausalDesistimientoDto>>(
                    await this._creditoRepository.ObtenerCausalDesistimiento())

            };
        }

        /// <summary>
        /// Carga documentos de credito al blobstorage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>27/06/2021</date>
        public async Task<Response<string>> CargarDocumentos(IFormFile request)
        {
            var _request = request;
            FileInfo fi = new FileInfo(_request.FileName);
            BlobContainerClient container = new BlobContainerClient(_options.Value.CadenaOne, "credito");
            await container.CreateIfNotExistsAsync();
            var newName = Guid.NewGuid() + fi.Extension;
            BlobClient blob = container.GetBlobClient(newName);
            var result = await blob.UploadAsync(request.OpenReadStream());
            return new Response<string> { Data = newName };
        }

        /// <summary>
        /// Descarga documentos de credito al blobstorage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>27/06/2021</date>
        public async Task<FileResult> DescargarDocumentos(string request)
        {
            BlobContainerClient container = new BlobContainerClient(this._options.Value.CadenaOne, "credito");
            BlobClient blob = container.GetBlobClient(request);
            BlobDownloadInfo download = await blob.DownloadAsync();

            var descargado = new FileStreamResult(download.Content, download.ContentType);
            descargado.FileDownloadName = request;
            await descargado.FileStream.FlushAsync();
            return descargado;
        }

        /// <summary>
        /// Crear Solic Credito Financieros
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>27/06/2021</date>
        public async Task<Response<CreditoFinancieroDto>> CrearSolicCreditoFinancieros(CreditoFinancieroDto request)
        {
            var solicitud = this._mapper.Map<CreditoFinanciero>(request);
            return new Response<CreditoFinancieroDto> { Data = this._mapper.Map<CreditoFinancieroDto>(await this._creditoRepository.CrearSolicCreditoFinancieros(solicitud)) };
        }

        /// <summary>
        /// ObtenerDatosReparto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>27/06/2021</date>
        public async Task<Response<DatosRepartoDto>> ObtenerDatosReparto(Guid request)
        {
            var response = new DatosRepartoDto();
            response = this._mapper.Map<DatosRepartoDto>(await this._creditoRepository.ObtenerDatosReparto(request));
            if (response != null) response.IdSolicitud = request;
            return new Response<DatosRepartoDto> { Data = response };
        }

        /// <summary>
        /// DesistirDesembolsoSolicitud
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>27/06/2021</date>
        public async Task<Response<DesistimientoDesembolsoDto>> DesistirDesembolsoSolicitud(DesistimientoDesembolsoDto request)
        {
            var solicitud = this._mapper.Map<DesistimientoDesembolso>(request);
            return new Response<DesistimientoDesembolsoDto> { Data = this._mapper.Map<DesistimientoDesembolsoDto>(await this._creditoRepository.DesistirDesembolsoSolicitud(solicitud)) };
        }

        /// <summary>
        /// CargarDatosFinancieros
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>19/07/2021</date>
        public async Task<Response<DatosFinancierosDto>> CargarDatosFinancieros(DatosFinancierosDto request)
        {
            var SolicCreditoFinancieros = new CreditoFinancieroDto
            {
                IdSolicitudF = request.IdSof,
                IdSolicitudCredito = request.IdSolicitudCredito,
                ValorConceptoSalario = request.ValorSalario,
                Concepto1 = request.DescripcionOtroIng1,
                ValorConcepto1 = request.ValorOtrosIngresos1,
                Concepto2 = request.DescripcionOtroIng2,
                ValorConcepto2 = request.ValorOtrosIngresos2,
                Concepto3 = request.DescripcionOtroIng3,
                ValorConcepto3 = request.ValorOtrosIngresos3,
                Concepto4 = request.DescripcionOtroIng4,
                ValorConcepto4 = request.ValorOtrosIngresos4,
                Concepto5 = request.DescripcionOtroIng5,
                ValorConcepto5 = request.ValorOtrosIngresos5,
                Concepto6 = request.DescripcionOtroIng6,
                ValorConcepto6 = request.ValorOtrosIngresos6,
                ValorTotalIngresos = request.ValorTotalIngresos,
                ValorTotalEgresos = request.ValorTotalEgresos,
                DireccionVivienda = request.DireccionVivienda,
                MatriculaVivienda = request.MatriculaVivienda,
                ValorComercialVivienda = request.ValorComercialVivienda,
                MarcaVehiculo = request.MarcaVehiculo,
                PlacaVehiculo = request.PlacaVehiculo,
                ValorComercialVehiculo = request.ValorComercialVehiculo,
                CreadoPor = request.CreadoPor,
                FechaCreacion = request.FechaCreacion,
                ActualizadoPor = request.UsuarioActualiza,
                FechaActualiza = request.FechaActualiza
            };

            var SimulacionDatosFinancieros = new SimulacionDatosFinancierosDto
            {
                IdSimulacion = request.IdSimulacion,
                DescripcionSalario = request.DescripcionSalario,
                ValorSalario = request.ValorSalario,
                DescripcionOtroIngresos = request.DescripcionOtroIngresos,
                ValorOtrosIngresos = request.ValorOtrosIngresos,
                DescripcionOtroIng1 = request.DescripcionOtroIng1,
                ValorOtrosIngresos1 = request.ValorOtrosIngresos1,
                DescripcionOtroIng2 = request.DescripcionOtroIng2,
                ValorOtrosIngresos2 = request.ValorOtrosIngresos2,
                DescripcionOtroIng3 = request.DescripcionOtroIng3,
                ValorOtrosIngresos3 = request.ValorOtrosIngresos3,
                DescripcionOtroIng4 = request.DescripcionOtroIng4,
                ValorOtrosIngresos4 = request.ValorOtrosIngresos4,
                DescripcionOtroIng5 = request.DescripcionOtroIng5,
                ValorOtrosIngresos5 = request.ValorOtrosIngresos5,
                ValorTotalIngresos = request.ValorTotalIngresos,
                ValorTotalEgresos = request.ValorTotalEgresos,
                UsuarioActualiza = request.UsuarioActualiza,
                FechaActualiza = request.FechaActualiza
            };

            try
            {
                await this._validacionIdentidadBusinessLogic.CrearSimulacionDatosFinancieros(SimulacionDatosFinancieros);
                await this.CrearSolicCreditoFinancieros(SolicCreditoFinancieros);
                return new Response<DatosFinancierosDto> { Data = request };

            }
            catch (Exception ex)
            {
                return new Response<DatosFinancierosDto> { ReturnMessage = ex.ToString() };
            }
        }

        /// <summary>
        /// CargarDatosSolicCreditoTasasDesembolso
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>19/07/2021</date>
        public async Task<Response<DatosSolicCreditoDto>> CargarDatosSolicCreditoTasasDesembolso(DatosSolicCreditoDto request)
        {
            var response = new DatosSolicCreditoDto();
            response.SolicitudCreditosDesembolsos = (await this.CrearSolicCreditoDesembolsos(request.SolicitudCreditosDesembolsos)).Data;
            response.TasaSolicitudCreditoDto = (await this.ActualizaSolicCreditoTasas(request.TasaSolicitudCreditoDto)).Data;

            return new Response<DatosSolicCreditoDto> { Data = response };


        }

        /// <summary>
        /// ObtenerFuentesRecursosSolicitud
        /// </summary>
        /// <param name="IdSolicitud"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        public async Task<ActionResult<Response<IEnumerable<SolicitudCreditosDesembolsosDto>>>> ObtenerFuentesRecursosSolicitud(Guid request)
        {
            return new Response<IEnumerable<SolicitudCreditosDesembolsosDto>> { Data = this._mapper.Map<IEnumerable<SolicitudCreditosDesembolsosDto>>(await this._creditoRepository.ObtenerFuentesRecursosSolicitud(request)) };
        }

        /// <summary>
        /// GenerarFormatoReparto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>19/07/2021</date>
        public async Task<FileResult> GenerarFormatoReparto(Guid request)
        {
            var datos = await ObtenerDatosReparto(request);

            BlobContainerClient container = new BlobContainerClient(this._options.Value.CadenaOne, "legalizacion-cartera");
            BlobClient blobBase = container.GetBlobClient("29b93d1e-0191-4253-b9f7-2c698a21e055.html");
            BlobClient blobCss = container.GetBlobClient(@"40a472dc-fc82-4db9-ad68-befaabeac7c6.css");

            BlobDownloadInfo downloadBase = await blobBase.DownloadAsync();
            BlobDownloadInfo downloadCss = await blobCss.DownloadAsync();

            var baseHtlm = new FileStreamResult(downloadBase.Content, downloadBase.ContentType);
            var baseCss = new FileStreamResult(downloadCss.Content, downloadCss.ContentType);

            await baseHtlm.FileStream.FlushAsync();
            await baseCss.FileStream.FlushAsync();

            var pdf = new PdfCreator();
            var resultado = await pdf.GenerarReparto(datos.Data, baseHtlm, baseCss);
            return resultado;

        }

        /// <summary>
        /// Validar Documentos flujo
        /// </summary>
        /// <param name="validacionDocumentosDto"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<ValidacionDocumentosDto>>> ValidarDocumentosFlujo(ValidacionDocumentosDto validacionDocumentos)
        {
            var solicitud = this._mapper.Map<ValidacionDocumentos>(validacionDocumentos);
            return new Response<IEnumerable<ValidacionDocumentosDto>> { Data = this._mapper.Map<IEnumerable<ValidacionDocumentosDto>>(await this._creditoRepository.ValidarDocumentosFlujo(solicitud)) };

        }

        public async Task<FileResult> GenerarActaComite(int id)
        {
            var requestComite = new DatosComiteCreditoDto { CodigoComite = id };
            var comiteCredito = this.ObtenerComiteCredito(requestComite).Result.Data;

            var requestIntegrantes = new IntegrantePorComiteDto { idComite = id };
            var integrantes = this.ObtenerComiteCreditoIntegrante(requestIntegrantes).Result.Data;

            var requestTemas = new RequestTemaComiteCreditoDto { idComite = id };
            var temas = this.ObtenerComiteCreditoTemas(requestTemas).Result.Data;

            var requestSolicitudes = new SolicitudComiteDto { idComiteCredito = id };
            var solicitudes = this.ObtenerComiteCreditoSolicitud(requestSolicitudes).Result.Data;

            var datosSolicitudes = new List<DatosSolicitudComiteDto>();
            foreach (var solicitud in solicitudes)
            {
                var datos = this._mapper.Map<DatosSolicitudComiteDto>(this._creditoRepository.ObtenerDatosSolicComite((Guid)solicitud.idSolicitud).Result);
                datosSolicitudes.Add(datos);
            }

            var requestDocumento = new SolicitudActaComiteDto { DatosComite = comiteCredito, IntegrantesComite = integrantes, TemasComite = temas, Solicitudes = solicitudes, DatosSolicitud = datosSolicitudes };

            BlobContainerClient container = new BlobContainerClient(this._options.Value.CadenaOne, "legalizacion-cartera");
            BlobClient blobBase = container.GetBlobClient("a34c0f5f-4e98-4946-8734-b8c2d82ff353.html");
            BlobClient blobCss = container.GetBlobClient(@"8589af31-f2ed-4cea-8210-cdc3154d6fbf.css");

            BlobDownloadInfo downloadBase = await blobBase.DownloadAsync();
            BlobDownloadInfo downloadCss = await blobCss.DownloadAsync();

            var baseHtml = new FileStreamResult(downloadBase.Content, downloadBase.ContentType);
            var baseCss = new FileStreamResult(downloadCss.Content, downloadCss.ContentType);

            await baseHtml.FileStream.FlushAsync();
            await baseCss.FileStream.FlushAsync();

            PdfCreator pdf = new PdfCreator();


            var generado = await pdf.GenerarFichaComite(requestDocumento, baseHtml, baseCss);
            return generado;
        }

        public async Task<Response<ActualizacionSolicitudCreditoDesemFirmaDto>> ActualizaSolicCreditoDesembolso(ActualizacionSolicitudCreditoDesemFirmaDto request)
        {
            var solicitud = this._mapper.Map<ActualizacionSolicitudCreditoDesemFirma>(request);
            return new Response<ActualizacionSolicitudCreditoDesemFirmaDto> { Data = this._mapper.Map<ActualizacionSolicitudCreditoDesemFirmaDto>(await this._creditoRepository.ActualizaSolicCreditoDesembolso(solicitud)) };
        }

        public async Task<Response<ActualizacionSolicitudCreditoDesemFirmaDto>> ActualizaSolicCreditoFirmas(ActualizacionSolicitudCreditoDesemFirmaDto request)
        {
            var solicitud = this._mapper.Map<ActualizacionSolicitudCreditoDesemFirma>(request);
            return new Response<ActualizacionSolicitudCreditoDesemFirmaDto> { Data = this._mapper.Map<ActualizacionSolicitudCreditoDesemFirmaDto>(await this._creditoRepository.ActualizaSolicCreditoFirmas(solicitud)) };
        }

        private void streamToFile(Stream fileStream, string filePath)
        {
            using (FileStream writeStream = new FileStream(filePath,
                                            FileMode.Create,
                                            FileAccess.Write))
            {
                int length = 1024;
                Byte[] buffer = new Byte[length];
                int bytesRead = fileStream.Read(buffer, 0, length);
                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = fileStream.Read(buffer, 0, length);
                }
                fileStream.Close();
                writeStream.Close();
            }
        }

        public async Task<FileResult> ObtenerFichaRiesgo(RequestFichaRiesgo request)
        {
            var respuesta = await this._creditoRepository.ObtenerDatosSolicComite(request.IdSolicitud);
            var datosPersonales = await this._creditoRepository.ObtenerSimulacionPersonales(respuesta.SOB_NUMERO_DOCUMENTO.ToString());
            var simulacion = await this._creditoRepository.ConsultarSimulacionCliente(respuesta.SOB_NUMERO_DOCUMENTO.ToString());
            var solicitud = await this._creditoRepository.ConsultarSolicitudCredito(new ConsultaSolicitudCredito { SOC_ID = respuesta.SOC_ID, CLI_IDENTIFICACION = respuesta.SOB_NUMERO_DOCUMENTO.ToString(), SOC_ESTADO = "0" });
            RiesgoPdfCreator pdf = new RiesgoPdfCreator();
            if (respuesta != null)
            {
                try
                {
                    var blobCheck = await _blobStorageGenericRepository.DescargarArchivoStorage("riesgo", $"{request.IdSolicitud.ToString().ToUpper()}.pdf");
                    var blobMod = (int)(DateTime.Now - blobCheck.Details.LastModified).TotalDays;

                    if (blobMod >= 30)
                    {
                        await _blobStorageGenericRepository.EliminarArchivoStorage("riesgo", $"{request.IdSolicitud.ToString().ToUpper()}.pdf");
                        throw new Exception();
                    }
                    var file = new FileStreamResult(blobCheck.Content, "application/octet-stream")
                    {
                        FileDownloadName = $"{request.IdSolicitud.ToString().ToUpper()}.pdf"
                    };
                    await file.FileStream.FlushAsync();
                    return file;
                }
                catch
                {
                    #region Prepara template
                    //Descarga archivo base d eblob storage
                    var tempStream = await _blobStorageGenericRepository.DescargarArchivoStorage("riesgo", "552ddaf2-9cd8-4c34-b70b-f833a09a28c6.html");
                    var sr = new StreamReader(tempStream.Content);
                    var fileBase = await sr.ReadToEndAsync();

                    //descarga header de blob storage
                    tempStream = await _blobStorageGenericRepository.DescargarArchivoStorage("riesgo", "9dd8a639-dfca-4837-b040-699d186ba0b9.html");
                    sr = new StreamReader(tempStream.Content);
                    var header = await sr.ReadToEndAsync();

                    //descarga footer de blob storage
                    tempStream = await _blobStorageGenericRepository.DescargarArchivoStorage("riesgo", "82401d26-f129-4406-aa32-5c55aac7dade.html");
                    sr = new StreamReader(tempStream.Content);
                    var footer = await sr.ReadToEndAsync();

                    //descarga css de blob storage
                    tempStream = await _blobStorageGenericRepository.DescargarArchivoStorage("riesgo", "ccb522a9-2cb0-4c89-8363-b8b3959b0b5b.css");
                    sr = new StreamReader(tempStream.Content);
                    var css = await sr.ReadToEndAsync();
                    #endregion


                    var resultado = await pdf.GenerarFichaRiesgo(respuesta, simulacion, datosPersonales, solicitud, fileBase, header, footer, css);
                    var fileStreamResult = (FileStreamResult)resultado;
                    fileStreamResult.FileStream.Seek(0, SeekOrigin.Begin);
                    await _blobStorageGenericRepository.SubirArchivoStorage("riesgo", $"{request.IdSolicitud.ToString().ToUpper()}.pdf", fileStreamResult);
                    var blobCheck = await _blobStorageGenericRepository.DescargarArchivoStorage("riesgo", $"{request.IdSolicitud.ToString().ToUpper()}.pdf");
                    var returnFile = new FileStreamResult(blobCheck.Content, "application/octet-stream")
                    {
                        FileDownloadName = $"{request.IdSolicitud.ToString().ToUpper()}.pdf"
                    };
                    await returnFile.FileStream.FlushAsync();
                    return returnFile;
                }



            }
            else throw new ArgumentNullException(nameof(respuesta));
        }

        /// <summary>
        /// Obtiene los datos personale spara la simulacion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<SimulacionDatosPersonalesDto>> ObtenerSimulacionPersonales(string request)
        {
            try
            {
                var verificacion = int.Parse(request);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Cedula Invalida", ex);
            }

            var result = await this._creditoRepository.ObtenerSimulacionPersonales(request);
            return new Response<SimulacionDatosPersonalesDto> { Data = this._mapper.Map<SimulacionDatosPersonalesDto>(result) };
        }
        /// <summary>
        /// Obtiene la cuenta segun la cedula
        /// </summary>
        /// <param name="clienteIdentificacion"></param>
        /// <returns></returns>
        public async Task<Response<CuentaDto>> ObtenerCuentaById(string clienteIdentificacion)
        {
            var cuenta = await _iClientRequestProvider.ObtenerCuentaById(clienteIdentificacion);


            return cuenta;
        }

        /// <summary>
        /// Obtiene los datos personales financieros d eun usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<DatosFinancierosPersonalesDto>> ObtenerDatosFinancierosPersonales(string request)
        {
            return new Response<DatosFinancierosPersonalesDto> { Data = this._mapper.Map<DatosFinancierosPersonalesDto>(await this._creditoRepository.ObtenerDatosFinancierosPersonales(request)) };
        }

        /// <summary>
        /// Carga documentos en base 64 al blob storage
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<string>> CargaDocumentoSolicCreditoBase64(Base64FileDto request)
        {
            var _request = Convert.FromBase64String(request.File);

            Stream stream = new MemoryStream(_request);

            //FileInfo fi = new FileInfo(fs.Name);
            BlobContainerClient container = new BlobContainerClient(_options.Value.CadenaOne, "credito");
            await container.CreateIfNotExistsAsync();
            var newName = Guid.NewGuid() + ".pdf";
            BlobClient blob = container.GetBlobClient(newName);
            stream.Position = 0;
            var result = await blob.UploadAsync(stream);
            return new Response<string> { Data = newName };
        }

        /// <summary>
        /// Actualiza info personal vivienda
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Response<SimulacionDatosPersonalesDto>> ActualizarPersonalesVivienda(SimulacionDatosPersonalesDto request)
        {
            var peticion = this._mapper.Map<SimulacionDatosPersonales>(request);

            return new Response<SimulacionDatosPersonalesDto>() { Data = _mapper.Map<SimulacionDatosPersonalesDto>(await this._creditoRepository.ActualizarPersonalesVivienda(peticion)) };
        }

        /// <summary>
        /// Obtiene la dolicitud de credito
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<ActualizacionSolicitudCreditoDesemFirmaDto>> ObtenerSolicitudCredito(RequestSolicitudCreditoDto peticion)
        {
            var request = peticion.Indicador == 1 ? peticion.IdSolicitud : peticion.Documento;
            var indicador = peticion.Indicador;
            return new Response<ActualizacionSolicitudCreditoDesemFirmaDto>() { Data = _mapper.Map<ActualizacionSolicitudCreditoDesemFirmaDto>(await this._creditoRepository.ObtenerSolicitudCredito(request, indicador)) };
        }

        /// <summary>
        /// Obtiene la carta de instrucciones y el pagare
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<FileResult> ObtenerPagareCartaInstrucciones(Guid request)
        {
            var pagareBase = "810bc370-d71d-4a14-834d-927abca1b4b8.html";
            var cssBase = "f4c60f3d-834c-471f-872d-4547406f633b.css";
            var header = "44290a0c-6b18-49b4-a250-e9209d8fc6f0.html";
            var footer = "b0f2bdfb-cc86-4cd2-83fd-48e96e58d28f.html";

            PeticionCreditoBasicaDto peticion = new() { IND = 2, SOB_ID = null, SOC_ID = request };
            PeticionSolicitudCreditoProductoDto peticionCredito = new() { IND = 2, SOC_ID = request };
            RespuestaCreditoBasicaDto datosBasicos = (await this.ObtenerSolicCreditoBasica(peticion)).Data;
            RespuestaSolicitudCreditoProductoDto datosProducto = (await this.ObtenerSolicCreditoProducto(peticionCredito)).Data;
            var listCreditos = (await ObtenerTramiteSolicitud(new PeticionSolicitudObtenerTramiteDto() { Usuario = Guid.Parse("3e3ab8c4-2c45-417d-86f6-fed3d8ccc05f") })).Data;
            var producto = listCreditos.FirstOrDefault(x => x.ID_SOLICITUD == request);
            if (producto != default(RespuestaSolicitudObtenerTramiteDto) && producto.ID_TIPO_CREDITO == 1)
            {
                BlobContainerClient container = new BlobContainerClient(this._options.Value.CadenaOne, "legalizacion-cartera");
                BlobClient blobBase = container.GetBlobClient(pagareBase);
                BlobClient blobCss = container.GetBlobClient(cssBase);
                BlobClient blobHeader = container.GetBlobClient(header);
                BlobClient blobFooter = container.GetBlobClient(footer);
                BlobDownloadInfo downloadBase = await blobBase.DownloadAsync();
                BlobDownloadInfo downloadCss = await blobCss.DownloadAsync();
                BlobDownloadInfo downloadHeader = await blobHeader.DownloadAsync();
                BlobDownloadInfo downloadFooter = await blobFooter.DownloadAsync();

                var basePagare = new FileStreamResult(downloadBase.Content, downloadBase.ContentType);
                var baseCss = new FileStreamResult(downloadCss.Content, downloadCss.ContentType);
                var baseHeader = new FileStreamResult(downloadHeader.Content, downloadHeader.ContentType);
                var baseFooter = new FileStreamResult(downloadFooter.Content, downloadFooter.ContentType);

                await basePagare.FileStream.FlushAsync();
                await baseCss.FileStream.FlushAsync();
                await baseHeader.FileStream.FlushAsync();
                await baseFooter.FileStream.FlushAsync();
                PdfCreator pdf = new PdfCreator();



                return await pdf.GenerarPagareCartaInstrucciones(datosBasicos, datosProducto, basePagare, baseCss, baseHeader, baseFooter);
            }
            else { return null; }

        }

        public async Task<Response<IEnumerable<SolicitudCreditosDesembolsosDto>>> EliminarFuentesRecursosSolicitud(SolicitudCreditosDesembolsosDto request)
        {
            var solicitud = _mapper.Map<SolicitudCreditosDesembolsos>(request);
            return new Response<IEnumerable<SolicitudCreditosDesembolsosDto>>() { Data = _mapper.Map<IEnumerable<SolicitudCreditosDesembolsosDto>>(await this._creditoRepository.EliminarFuentesRecursosSolicitud(solicitud)) };
        }

        public async Task<Response<IEnumerable<EqivalenciaSimuladorDto>>> ObtenerEquivalenciasSimuladorCredito()
        {
            return new Response<IEnumerable<EqivalenciaSimuladorDto>>() { Data = _mapper.Map<IEnumerable<EqivalenciaSimuladorDto>>(await this._creditoRepository.ObtenerEquivalenciasSimuladorCredito()) };
        }

        public async Task<Response<SolicitudSimulacionDto>> CrearSolicitudSimulacionCredito(SolicitudSimulacionDto solicitudSimulacionDto)
        {
            return new Response<SolicitudSimulacionDto>() { Data = _mapper.Map<SolicitudSimulacionDto>(await this._creditoRepository.CrearSolicitudSimulacionCredito(_mapper.Map<SolicitudSimulacion>(solicitudSimulacionDto))) };
        }

        public async Task<Response<SimulacionDetalle>> CrearDetalleSimulacion(SimulacionDto simulacion)
        {
            var simulacionDetalle = new SimulacionDetalle()
            {
                SMD_ID=simulacion.IdDetalleSimulacion,
                SMC_ID=simulacion.IdSimulacionCliente,
                SMD_ABONO_EXTRA=simulacion.AbonoExtra,
                SMD_ABONO_MENSUAL=simulacion.AbonoMensual,
                SMD_CAPITAL=simulacion.Capital,
                SMD_CAPITAL_LEASING=simulacion.CapitalLeasing,
                SMD_COBRO_FONVIVIENDA=simulacion.CobroFonvivienda,
                SMD_CUOTA=simulacion.Cuota,
                SMD_CUOTA_LEASING=simulacion.CuotaLeasing,
                SMD_CUOTA_LEASING_SUBSIDIO=simulacion.CuotaLeasingSubsidio,
                SMD_CUOTA_REDUCCION=simulacion.CuotaReduccion,
                SMD_CUOTA_TOTAL=simulacion.TotalCuota,
                SMD_CUOTA_UNIDAD_PAGADORA=simulacion.CuotaUnidadPagadora,
                SMD_FECHA_CORTE=simulacion.FechaCorte,
                SMD_FECHA_PAGO=simulacion.FechaPago,
                SMD_INTERESES=simulacion.Intereses,
                SMD_INTERESES_REDUCCION=simulacion.InteresesReduccion,
                SMD_INTERES_LEASING=simulacion.InteresLeasing,
                SMD_INTERES_LEASING_SUBSIDIO=simulacion.Subsidio,
                SMD_INTERES_TRADICIONAL_SUBSIDIO=simulacion.InteresTradicionalSubsidio,
                SMD_SALDO=simulacion.Saldo,
                SMD_SALDO_LEASING=simulacion.SaldoLeasing,
                SMD_SEGURO_TERREMOTO=simulacion.SeguroHogar,
                SMD_SEGURO_VIDA=simulacion.SeguroVida,
                SMD_SEGURO_VIDA_LEASING=simulacion.SeguroVidaLeasing

            };
            return new Response<SimulacionDetalle>() { Data =await this._creditoRepository.CrearDetalleSimulacion(simulacionDetalle) };
        }

        public async Task<Response<SMCSimulacionClienteDto>> CrearSimulacionClienteSMC(SMCSimulacionClienteDto sMCSimulacionClienteDto)
        {
            var request = _mapper.Map<SMCSimulacionCliente>(sMCSimulacionClienteDto);
            return new Response<SMCSimulacionClienteDto>() { Data = _mapper.Map<SMCSimulacionClienteDto>(await this._creditoRepository.CrearSimulacionClienteSMC(request)) };

        }

        public async Task<Response<SolicitudSimulacionDto>> CrearPreAprobado(SolicitudSimulacionDto request)
        {
            var _request = _mapper.Map<SolicitudSimulacion>(request);
            return new Response<SolicitudSimulacionDto>() { Data = _mapper.Map<SolicitudSimulacionDto>(await this._creditoRepository.CrearPreAprobado(_request)) };

        }

        public async Task<Response<FormularioCreditoBasicaDto>> FormularioCreditoBasica(Guid idSolicitudCredito)
        {
           
            IEnumerable<TipoIdentificacionDto> tiposIdentificacion = this._mapper.Map<IEnumerable<TipoIdentificacionDto>>(await this._catalogsRepository.ObtenerTiposIdentificacion());
            IEnumerable<DepartamentoDto> departamentos = this._mapper.Map<IEnumerable<DepartamentoDto>>(await this._catalogsRepository.ObtenerDepartamentos());
            IEnumerable<FuerzasDto> fuerzas = this._mapper.Map<IEnumerable<FuerzasDto>>(await this._catalogsRepository.ObtenerFuerzas());
            IEnumerable<CategoriaDto> categorias = this._mapper.Map<IEnumerable<CategoriaDto>>(await this._catalogsRepository.ObtenerCategorias());
            IEnumerable<SexoDto> sexoTypes = this._mapper.Map<IEnumerable<SexoDto>>(await this._catalogsRepository.ObtenerTipoDeSexo());
            IEnumerable<EstadoCivilDto> estadoCivilTypes = this._mapper.Map<IEnumerable<EstadoCivilDto>>(await this._catalogsRepository.ObtenerEstadosCiviles());
            IEnumerable<NivelAcademicoCatalogoDto> nivelesAcademicos = this._mapper.Map<IEnumerable<NivelAcademicoCatalogoDto>>(await this._catalogsRepository.ObtenerNivelEducativo());
            IEnumerable<ProfesionDto> profesiones = this._mapper.Map<IEnumerable<ProfesionDto>>(await this._catalogsRepository.ObtenerProfesiones());
            PeticionCreditoBasica pet=new PeticionCreditoBasica();
            pet.SOC_ID = idSolicitudCredito;
            pet.IND = 2;
            RespuestaCreditoBasicaDto RespuestaCreditoBasica  = this._mapper.Map<RespuestaCreditoBasicaDto>(await this._creditoRepository.ObtenerSolicCreditoBasica(pet));
            FormularioCreditoBasicaDto credito = new FormularioCreditoBasicaDto();
            credito.TiposIdentificacion = (List<TipoIdentificacionDto>) tiposIdentificacion;
            credito.Departamentos = (List<DepartamentoDto>)departamentos;
            credito.Fuerzas = (List<FuerzasDto>)fuerzas;
            credito.Categorias= (List<CategoriaDto>)categorias;
            credito.Sexos = (List<SexoDto>)sexoTypes;
            credito.EstadosCiviles = (List<EstadoCivilDto>)estadoCivilTypes;
            credito.NivelesAcademicos = (List<NivelAcademicoCatalogoDto>)nivelesAcademicos;
            credito.Profeciones = (List<ProfesionDto>)profesiones;
            credito.CreditoBasica = RespuestaCreditoBasica;

            return new Response<FormularioCreditoBasicaDto>() { Data = credito };

        }

        public async Task<Response<SocSolicitudInfobasicaDto>> CrearSolicCreditoBasicos(SocSolicitudInfobasicaDto infoBasica)
        {
            SocSolicitudInfobasica request = _mapper.Map<SocSolicitudInfobasica>(infoBasica);
            SocSolicitudInfobasicaDto Respuesta = this._mapper.Map<SocSolicitudInfobasicaDto>(await this._creditoRepository.CrearSolicCreditoBasicos(request));
            return new Response<SocSolicitudInfobasicaDto>() { Data = Respuesta };
    
        }

        public async Task<Response<IEnumerable<TasaHogarCiudadDto>>> ObtenerTasasHogarCiudad()
        {
            var Respuesta = this._mapper.Map<IEnumerable<TasaHogarCiudadDto>>(await this._creditoRepository.ObtenerTasasHogarCiudad());
            return new Response<IEnumerable<TasaHogarCiudadDto>>() { Data = Respuesta };
        }

        public async Task<Response<FormularioCreditoConyugueDto>> FormularioCreditoConyugue(Guid idSolicitudCredito)
        {
            FormularioCreditoConyugueDto form = new FormularioCreditoConyugueDto();

            IEnumerable<TipoIdentificacionDto> tiposIdentificacion = this._mapper.Map<IEnumerable<TipoIdentificacionDto>>(await this._catalogsRepository.ObtenerTiposIdentificacion());
            IEnumerable<DepartamentoDto> departamentos = this._mapper.Map<IEnumerable<DepartamentoDto>>(await this._catalogsRepository.ObtenerDepartamentos());

            PeticionCreditoBasica pet = new PeticionCreditoBasica();
            pet.SOY_ID = Guid.NewGuid();
            pet.SOC_ID = idSolicitudCredito;
            pet.IND = 2;

            InformacionConyugueDto SolicitudInfoConyugue = this._mapper.Map<InformacionConyugueDto>(await this._creditoRepository.ObtenerSolicCreditoConyugue(pet));
           
            form.Departamentos = (List<DepartamentoDto>)departamentos;
            form.TiposIdentificacion= (List<TipoIdentificacionDto>)tiposIdentificacion;
            form.InformacionConyugue = SolicitudInfoConyugue;

            return new Response<FormularioCreditoConyugueDto>() { Data = form };


        }

        public async Task<Response<InformacionConyugueDto>> CrearSolicCreditoConyugue(InformacionConyugueDto infoConyugue)
        {

            InformacionConyugue InfoConyugue = this._mapper.Map<InformacionConyugue>(infoConyugue);
            InformacionConyugueDto SolicitudInfoConyugue = this._mapper.Map<InformacionConyugueDto>(await this._creditoRepository.CrearSolicCreditoConyugue(InfoConyugue));
            return new Response<InformacionConyugueDto>() { Data = SolicitudInfoConyugue  };
            
        }
    }
}
