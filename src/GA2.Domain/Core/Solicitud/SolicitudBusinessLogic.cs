using System;
using AutoMapper;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using GA2.Transversals.Commons.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs.Models;
using GA2.Domain.Entities.Bpm;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Logica
    /// <author>Erwin Pantoja España</author>
    /// <date>20/10/2021</date>
    /// </summary>
    /// 
    public class SolicitudBusinessLogic : ISolicitudBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly ISolicitudRepository _solicitudRepository;
        private readonly IClientRequestProvider _iClientRequestProvider;
        private readonly ITareaRepository _itareaRepository;
        private readonly IOptions<BlobStorageOptions> _options;
        private readonly IBlobStorageGenericRepository _blobStorageGenericRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="solicitudRepository"></param>
        public SolicitudBusinessLogic(
            IMapper mapper,
            ISolicitudRepository solicitudRepository,
            IClientRequestProvider iClientRequestProvider,
            ITareaRepository itareaRepository,
            IBlobStorageGenericRepository blobStorageGenericRepository,
            IOptions<BlobStorageOptions> options
            )
        {
            _mapper = mapper;
            _solicitudRepository = solicitudRepository;
            _iClientRequestProvider = iClientRequestProvider;
            _itareaRepository = itareaRepository;
            _blobStorageGenericRepository = blobStorageGenericRepository;
            _options = options;
        }


        /// <summary>
        /// Metodo logica de negocio para insertar una solicitud
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <param name="crearSolicitudDto"></param>
        /// <returns>Response<ObtenerTramiteSolicitudDto></returns>
        public async Task<Response<ObtenerTramiteSolicitudDto>> CrearSolicitud(CrearSolicitudDto crearSolicitudDto)
        {
            CrearSolicitud parametrosSolicitud = this._mapper.Map<CrearSolicitud>(crearSolicitudDto);

            IEnumerable<Tarea> tareas = await _itareaRepository.ObtenerTareasPorProcesoId(crearSolicitudDto.procesoId);
            parametrosSolicitud.TRA_ID = tareas.Where(x => x.TRA_ORDEN == 1).FirstOrDefault().TRA_ID;

            IEnumerable<Entities.Bpm.EstadoTareaSolicitud> listEstadoTareaSol = await _itareaRepository.ObtenerEstadoSolicitudTarea();
            IEnumerable<Entities.Bpm.EstadoSolicitud> listEstadoSol = await _itareaRepository.ObtenerEstadoSolicitud();

            parametrosSolicitud.SOL_ESTADO_SOLICITUD = listEstadoSol.Where(x => x.CVL_DESCRIPCION == "En Tramite").FirstOrDefault().CVL_ID;  //SolicitudConstants.EstadoInicialSolicitud;
            parametrosSolicitud.STL_ESTADO_SOLICITUD = listEstadoTareaSol.Where(x => x.CVL_DESCRIPCION == "Pendiente").FirstOrDefault().CVL_ID;  //SolicitudConstants.EstadoInicialTareaSolicitud;

            Response<ObtenerTramiteSolicitudDto> respuesta =
                new Response<ObtenerTramiteSolicitudDto>
                {
                    Data = this._mapper.Map<ObtenerTramiteSolicitudDto>(await
                    this._solicitudRepository.CrearSolicitud(parametrosSolicitud))
                };
            

            Response<ClienteDto> clienteDto = new Response<ClienteDto>();
            clienteDto = await _iClientRequestProvider.ObtenerClienteInformacion(crearSolicitudDto.clienteId);
            clienteDto = await _iClientRequestProvider.ObtenerClientePorTipoIdentificationYNumero(clienteDto.Data.IdTipoIdentificacion, clienteDto.Data.Identificacion);

            respuesta.Data.nombresCliente = $"{clienteDto.Data.PrimerNombre} {clienteDto.Data.SegundoNombre}";
            respuesta.Data.apellidosCliente = $"{clienteDto.Data.PrimerApellido} {clienteDto.Data.SegundoApellido}";
            respuesta.Data.identificacionCliente = $"{clienteDto.Data.Identificacion}";
            respuesta.Data.tipoIdentificacion = clienteDto.Data.IdTipoIdentificacion;



            decimal sumatoriaTotal, sumatoriaAhorro, sumatoriaCesantia;
            sumatoriaTotal = sumatoriaAhorro = sumatoriaCesantia = 0;
            string concepto = "";

            foreach (var item in clienteDto.Data.Saldos)
            {
                concepto = item.Concepto;
                if (concepto.Contains("Ahorro"))
                {
                    sumatoriaAhorro += item.Valor;
                }
                if (concepto.Contains("Cesantias"))
                {
                    sumatoriaCesantia += item.Valor;
                }
                sumatoriaTotal += item.Valor;
            }

            respuesta.Data.valorCesantia = sumatoriaCesantia;
            respuesta.Data.valorAhorro = sumatoriaAhorro;
            respuesta.Data.valorTotal = sumatoriaTotal;
            respuesta.Data.SaldosE = clienteDto.Data.Saldos;

            return respuesta;
        }

        public async Task<Response<ObtenerTramiteSolicitudDto>> ConsultarExisteSolicitud(ConsultarSolicitudDto consultarSolicitudDto)
        {

            Response<ClienteCesantiasDto> clienteDto = new Response<ClienteCesantiasDto>();
            clienteDto = await _iClientRequestProvider.ObtenerInformacionClientePorDocumentoYTipo(consultarSolicitudDto.tipoIdentificacion, consultarSolicitudDto.identificacion, 0);



            Response<ObtenerTramiteSolicitudDto> respuesta = new Response<ObtenerTramiteSolicitudDto>();

            if (clienteDto.Data == null)
            {
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "El afiliado no existe en BUA";
                return respuesta;
            }

            Response<ClienteDto> clienteSaldostDto = new Response<ClienteDto>();
            clienteSaldostDto = await _iClientRequestProvider.ObtenerClientePorTipoIdentificationYNumero(consultarSolicitudDto.tipoIdentificacion, consultarSolicitudDto.identificacion);

            IEnumerable<Entities.Bpm.EstadoSolicitud> listEstadoSol = await _itareaRepository.ObtenerEstadoSolicitud();
            IEnumerable<Entities.Bpm.EstadoTareaSolicitud> listEstadoTareaSol = await _itareaRepository.ObtenerEstadoSolicitudTarea();

            ConsultarSolicitud consultarSolicitud = new ConsultarSolicitud();

            consultarSolicitud.CLI_ID = clienteDto.Data.IdCliente;
            consultarSolicitud.TPS_SUB_ID = consultarSolicitudDto.tipoSubModalidadId;
            consultarSolicitud.SOL_ESTADO_ANULADO = listEstadoSol.Where(x => x.CVL_DESCRIPCION == "Anulada").FirstOrDefault().CVL_ID;  //SolicitudConstants.EstadoAnuladaSolicitud;

            respuesta =
                new Response<ObtenerTramiteSolicitudDto>
                {
                    Data = this._mapper.Map<ObtenerTramiteSolicitudDto>(await
                    this._solicitudRepository.ConsultarExisteSolicitud(consultarSolicitud))
                };

            decimal sumatoriaTotal, sumatoriaAhorro, sumatoriaCesantia;
            sumatoriaTotal = sumatoriaAhorro = sumatoriaCesantia = 0;
            string concepto = "";

            foreach (var item in clienteSaldostDto.Data.Saldos)
            {
                concepto = item.Concepto;
                if (concepto.Contains("Ahorro"))
                {
                    sumatoriaAhorro += item.Valor;
                }
                if (concepto.Contains("Cesantias"))
                {
                    sumatoriaCesantia += item.Valor;
                }
                sumatoriaTotal += item.Valor;
            }

            if (respuesta.Data != null)
            {




                respuesta.Data.nombresCliente = $"{clienteDto.Data.PrimerNombre} {clienteDto.Data.SegundoNombre}";
                respuesta.Data.apellidosCliente = $"{clienteDto.Data.PrimerApellido} {clienteDto.Data.SegundoApellido}";
                respuesta.Data.identificacionCliente = $"{clienteDto.Data.Identificacion}";
                respuesta.Data.clienteId = clienteDto.Data.IdCliente;
                respuesta.Data.tipoIdentificacion = clienteDto.Data.IdTipoIdentificacion;
                respuesta.Data.telefonoCliente = clienteDto.Data.TelefonoResidencia;
                respuesta.Data.correoCliente = clienteDto.Data.CorreoPersonal;
                respuesta.Data.celularCliente = clienteDto.Data.NumeroCelular;
                respuesta.Data.direccionCliente = clienteDto.Data.Direccion;
                respuesta.IsSuccess = false;
                respuesta.Data.valorCesantia = sumatoriaCesantia;
                respuesta.Data.valorAhorro = sumatoriaAhorro;
                respuesta.Data.valorTotal = sumatoriaTotal;
                respuesta.Data.SaldosE = clienteSaldostDto.Data.Saldos;

                respuesta.ReturnMessage = $"Ya existe una solicitud en tramite para " +
                    $"{clienteDto.Data.PrimerNombre.ToLower()} {clienteDto.Data.SegundoNombre.ToLower()} " +
                    $"{clienteDto.Data.PrimerApellido.ToLower()} {clienteDto.Data.SegundoApellido.ToLower()}";

                int estadoInicial = listEstadoTareaSol.Where(x => x.CVL_DESCRIPCION == "Pendiente").FirstOrDefault().CVL_ID;
                int estadoTramite = listEstadoTareaSol.Where(x => x.CVL_DESCRIPCION == "En Tramite").FirstOrDefault().CVL_ID;


                if (respuesta.Data.solicitudTareaEstadoId == estadoInicial ||
                   respuesta.Data.solicitudTareaEstadoId == estadoTramite)
                {



                    respuesta.Data.solicitudMatriculaDto = (from s in await _solicitudRepository.ConsultarSolicitudMatricula(respuesta.Data.solicitudId)
                                                            select new MatriculaRespuestaDto
                                                            {
                                                                ciudadId = s.DPC_ID_FK,
                                                                direccion = s.MAI_DIRECCION,
                                                                esPrincipal = s.MAI_PRINCIPAL,
                                                                numeroMatricula = s.MAI_NUMERO_MATRICULA,
                                                                id = s.MAI_ID,
                                                                ciudad = new LlaveValorDto
                                                                {
                                                                    id = s.DPC_ID_FK,
                                                                    descripcion = s.DPC_NOMBRE
                                                                },
                                                                departamento = new LlaveValorDto
                                                                {
                                                                    id = (int)s.DPD_ID,
                                                                    descripcion = s.DPD_NOMBRE
                                                                },
                                                                bloqueo = s.MAI_BLOQUEO
                                                            }).ToList();


                    List<RespuestaPropietario> respuestaPropietario = (from s in await _solicitudRepository.ConsultarSolicitudPropietario(respuesta.Data.solicitudId) select s).ToList();

                    respuesta.Data.solicitudPropietarioDto = (from s in respuestaPropietario
                                                              group s by new { s.PRP_ID, s.PRP_NUMERO_IDENTIFICACION, s.PRP_NOMBRE_RAZON_SOCIAL, s.TID_ID_FK, s.TID_DESCRIPCION } into g
                                                              select new PropietarioRespuestaDto
                                                              {
                                                                  numeroIdentificacion = g.Key.PRP_NUMERO_IDENTIFICACION,
                                                                  razonSocial = g.Key.PRP_NOMBRE_RAZON_SOCIAL,
                                                                  tipoIdentificacion = new LlaveValorDto
                                                                  {
                                                                      id = g.Key.TID_ID_FK,
                                                                      descripcion = g.Key.TID_DESCRIPCION
                                                                  },
                                                                  matricula = (from mp in respuestaPropietario
                                                                               where mp.PRP_ID == g.Key.PRP_ID
                                                                               select new MatriculaPropietarioDto
                                                                               {
                                                                                   id = mp.MAI_ID,
                                                                                   numeroMatricula = mp.MAI_NUMERO_MATRICULA,
                                                                                   estado = mp.MAI_PRINCIPAL ? "Principal" : "Relacionado"
                                                                               }).ToList()
                                                              }).ToList();


                    respuesta.Data.solicitudTerceroVendedorDto = (from s in await _solicitudRepository.ConsultarTerceroVendedor(respuesta.Data.solicitudId, SolicitudConstants.TipoTerceroVendedorId)
                                                                  select new TerceroVendedorRespuestaDto
                                                                  {
                                                                      ciudad = s.DPC_ID,
                                                                      ciudadObj = new LlaveValorDto
                                                                      {
                                                                          id = s.DPC_ID,
                                                                          descripcion = s.DPC_NOMBRE
                                                                      },
                                                                      id = s.TER_ID,
                                                                      correo = s.TER_CORREO_ELECTRONICO,
                                                                      departamentoVendedor = new LlaveValorDto
                                                                      {
                                                                          id = s.DPD_ID,
                                                                          descripcion = s.DPD_NOMBRE
                                                                      },
                                                                      direccion = s.TER_DIRECCION,
                                                                      numDoc = s.TER_NUMERO_DOCUMENTO,
                                                                      razonsocial = s.TER_NOMBRE_RAZON_SOCIAL,
                                                                      telefono = s.TER_TELEFONO,
                                                                      tipoDoc = s.TID_ID_FK,
                                                                      tipoDocObj = new LlaveValorDto
                                                                      {
                                                                          id = s.TID_ID_FK,
                                                                          descripcion = s.TID_DESCRIPCION
                                                                      }
                                                                  }).ToList();


                    respuesta.Data.solicitudTerceroBeneficiarioDto = (from s in await _solicitudRepository.ConsultarTerceroBeneficiario(respuesta.Data.solicitudId, SolicitudConstants.TipoTerceroBeneficiarioId)
                                                                      select new TerceroBeneficiarioRespuestaDto
                                                                      {
                                                                          id = s.TER_ID,
                                                                          numDoc = s.TER_NUMERO_DOCUMENTO,
                                                                          razonsocial = s.TER_NOMBRE_RAZON_SOCIAL,
                                                                          tipoDoc = s.TID_ID_FK,
                                                                          tipoDocObj = new LlaveValorDto
                                                                          {
                                                                              id = s.TID_ID_FK,
                                                                              descripcion = s.TID_DESCRIPCION
                                                                          },
                                                                          entidad = s.ENT_ID,
                                                                          entidadObj = new LlaveValortextoDto
                                                                          {
                                                                              id = s.ENT_ID,
                                                                              descripcion = s.ENT_NOMBRE_RAZON_SOCIAL
                                                                          },
                                                                          numeroCuenta = s.TER_NUMERO_CUENTA,
                                                                          tipoCuenta = s.CVL_ID,
                                                                          tipoCuentaObj = new LlaveValorDto
                                                                          {
                                                                              id = s.CVL_ID,
                                                                              descripcion = s.CVL_DESCRIPCION
                                                                          },
                                                                          valorRetirarDos = s.TER_VALOR_RETIRAR
                                                                      }).ToList();


                    respuesta.Data.solicitudTerceroApoderadoDto = (from s in await _solicitudRepository.ConsultarTerceroApoderado(respuesta.Data.solicitudId, SolicitudConstants.TipoTerceroApoderadoId)
                                                                   select new TerceroApoderadoRespuestaDto
                                                                   {
                                                                       id = s.TER_ID,
                                                                       tipoDoc = s.TID_ID_FK,
                                                                       tipoDocObj = new LlaveValorDto
                                                                       {
                                                                           id = s.TID_ID_FK,
                                                                           descripcion = s.TID_DESCRIPCION
                                                                       },
                                                                       numDoc = s.TER_NUMERO_DOCUMENTO,
                                                                       razonsocial = s.TER_NOMBRE_RAZON_SOCIAL,
                                                                       parentesco = s.CVL_ID,
                                                                       parentescoObj = new LlaveValorDto
                                                                       {
                                                                           id = s.CVL_ID,
                                                                           descripcion = s.CVL_DESCRIPCION
                                                                       },
                                                                       esAutorizado = s.TER_ESAUTORIZADO
                                                                   }).ToList();


                    RespuestaTerceroEntidadEducativa entidadEducativa = await _solicitudRepository.ConsultarTerceroEntidadEducativa(respuesta.Data.solicitudId, SolicitudConstants.TipoTerceroEntidadEducativa);

                    if (entidadEducativa != null)
                    {
                        respuesta.Data.solicitudTerceroEntidadEducativaDto = new TerceroEntidadEducativaRespuestaDto
                        {
                            fechalimite = entidadEducativa.TER_FECHA_LIMITE_PAGO,
                            idNivel = entidadEducativa.PRN_ID,
                            reciboPago = entidadEducativa.TER_NUM_RECIBO_PAGO,
                            idEntidad = entidadEducativa.PGN_ID,
                            razonSocial = $"{entidadEducativa.ENE_ID_FK}_{entidadEducativa.TER_NUMERO_DOCUMENTO}_{entidadEducativa.TER_NOMBRE_RAZON_SOCIAL}"
                        };
                    }


                    respuesta.Data.solicitudTerceroBeneficiarioEstudioDto = (from s in await _solicitudRepository.ConsultarTerceroBeneficiarioEstudio(respuesta.Data.solicitudId, SolicitudConstants.TipoTerceroBeneficiarioEstudioId)
                                                                             select new SolicitudTerceroBeneficiarioEstudioDto
                                                                             {
                                                                                 tipoDocEstudioObj = new LlaveValorStringDto
                                                                                 {
                                                                                     id = s.TID_ID_FK,
                                                                                     descripcion = s.TID_DESCRIPCION
                                                                                 },
                                                                                 numDocEstudio = s.TER_NUMERO_DOCUMENTO,
                                                                                 parentescoEstudio = s.TER_PARENTESCO,
                                                                                 razonsocialEstudio = s.TER_NOMBRE_RAZON_SOCIAL,
                                                                                 tipoDocEstudio = s.TID_ID_FK,
                                                                                 parentescoEstudioObj = new LlaveValorStringDto
                                                                                 {
                                                                                     id = s.TER_PARENTESCO,
                                                                                     descripcion = s.CVL_DESCRIPCION
                                                                                 }
                                                                             }).ToList();


                    RespuestaTerceroEntidadSeguroEducativo entidadSeguroEducativo = await _solicitudRepository.ConsultarTerceroEntidadSeguroEducativo(respuesta.Data.solicitudId, SolicitudConstants.TipoTerceroEntidadSeguroEducativoId);

                    if (entidadSeguroEducativo != null)
                    {
                        respuesta.Data.solicitudTerceroEntidadSeguroEducativoDto = new SolicitudTerceroEntidadSeguroEducativoDto
                        {
                            numDoc = entidadSeguroEducativo.ESE_NUMERO_IDENTIFICACION,
                            razonSocialAseguradora = entidadSeguroEducativo.ESE_NOMBRE_RAZON_SOCIAL,
                            tipoDocId = entidadSeguroEducativo.TID_ID_FK,
                            entidadSeguroEducativoId = entidadSeguroEducativo.ESE_ID,
                            numeroPoliza = entidadSeguroEducativo.TER_NUM_POLIZA
                        };
                    }


                    RespuestaTerceroTenedorAcciones tenedorAcciones = await _solicitudRepository.ConsultarTerceroTenedorAcciones(respuesta.Data.solicitudId, SolicitudConstants.TipoTerceroTenedorAccionesId);

                    if (tenedorAcciones != null)
                    {
                        respuesta.Data.solicitudTerceroTenedorAccionesDto = new SolicitudTerceroTenedorAccionesDto
                        {
                            TipoDoc = tenedorAcciones.TID_ID_FK,
                            NumDoc = tenedorAcciones.TER_NUMERO_DOCUMENTO,
                            Razonsocial = tenedorAcciones.TER_NOMBRE_RAZON_SOCIAL,
                            Direccion = tenedorAcciones.TER_DIRECCION,
                            Ciudad = tenedorAcciones.DPC_ID,
                            Correo = tenedorAcciones.TER_CORREO_ELECTRONICO,
                            Telefono = tenedorAcciones.TER_TELEFONO,
                            Emisor = tenedorAcciones.TER_EMISOR_NOMBRE_RAZON_SOCIAL,
                            Departamento = tenedorAcciones.DPD_ID
                        };
                    }

                }
            }
            else
            {
                respuesta.Data = new ObtenerTramiteSolicitudDto
                {
                    clienteId = clienteDto.Data.IdCliente,
                    tipoIdentificacion = clienteDto.Data.IdTipoIdentificacion,

                    valorCesantia = sumatoriaCesantia,
                    valorAhorro = sumatoriaAhorro,
                    valorTotal = sumatoriaTotal,
                    SaldosE = clienteSaldostDto.Data.Saldos
                };
            }

            int idEstado = listEstadoSol.Where(x => x.CVL_DESCRIPCION == "En Tramite").FirstOrDefault().CVL_ID;


            if (respuesta.Data.solicitudTareaEstadoId == idEstado) //SolicitudConstants.EstadoTramiteTareaSolicitud
            {
                respuesta.Data.solicitudEncontrada = true;
            }

            return respuesta;

        }

        public async Task<Response<TerceroApoderadoRespuestaDto>> ConsultarExistePersona(string numeroDocumento)
        {
            Response<TerceroApoderadoRespuestaDto> respuesta = new Response<TerceroApoderadoRespuestaDto>();
            RespuestaTerceroApoderado respuestaTerceroApoderado = new RespuestaTerceroApoderado();

            respuestaTerceroApoderado = await _solicitudRepository.
                ConsultarTerceroRazonSocial(numeroDocumento);

            if (respuestaTerceroApoderado == null)
            {
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "El tercero no existe";
                respuesta.Data = null;

                return respuesta;
            }

            respuesta.IsSuccess = true;
            respuesta.Data = new TerceroApoderadoRespuestaDto()
            {
                numDoc = respuestaTerceroApoderado.TER_NUMERO_DOCUMENTO,
                razonsocial = respuestaTerceroApoderado.TER_NOMBRE_RAZON_SOCIAL,
                tipoDocObj = new LlaveValorDto
                {
                    id = respuestaTerceroApoderado.TID_ID_FK,
                    descripcion = respuestaTerceroApoderado.TID_DESCRIPCION
                }
            };

            return respuesta;
        }

        // Consultar propietarios entre solicitudes para integridad de datos, provisional mientras se fusiona tabla props con terceros.
        public async Task<Response<TerceroApoderadoRespuestaDto>> ConsultarExistePropProv(string numeroIdentificacion)
        {
            Response<TerceroApoderadoRespuestaDto> respuesta = new Response<TerceroApoderadoRespuestaDto>();
            SolicitudPropietario solicitudPropietario = new SolicitudPropietario();

            solicitudPropietario = await _solicitudRepository.
               ConsultarPropietarioIntegridad(numeroIdentificacion);

            if (solicitudPropietario == null)
            {
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = "El propietario no existe";
                respuesta.Data = null;

                return respuesta;
            }

            respuesta.IsSuccess = true;
            respuesta.Data = new TerceroApoderadoRespuestaDto()
            {
                numDoc = solicitudPropietario.PRP_NUMERO_IDENTIFICACION,
                razonsocial = solicitudPropietario.PRP_NOMBRE_RAZON_SOCIAL,
                tipoDocObj = new LlaveValorDto
                {
                    id = solicitudPropietario.TID_ID_FK,
                    descripcion = solicitudPropietario.TID_DESCRIPCION
                }
            };

            return respuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="crearSolicitudCompraViviendaDto"></param>
        /// <returns></returns>
        public async Task<Response<bool>> CrearSolicitudTarea(CrearSolicitudTareaDto crearSolicitudTareaDto)
        {
            Response<bool> respuesta = new Response<bool>();

            respuesta.Data = false;
            respuesta.IsSuccess = false;
            string mensajeValidacionMatricula = ValidarMatriculas(crearSolicitudTareaDto.SolicitudMatriculaDto);

            if (mensajeValidacionMatricula != "")
            {
                respuesta.Data = false;
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = mensajeValidacionMatricula;
                return respuesta;
            }

            string mensajeValidacionPropietario = ValidarPropietario(crearSolicitudTareaDto.SolicitudPropietarioDto, crearSolicitudTareaDto.SolicitudMatriculaDto);

            if (mensajeValidacionPropietario != "")
            {
                respuesta.Data = false;
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = mensajeValidacionPropietario;
                return respuesta;
            }

            respuesta = await InsertarSolicitudTarea(crearSolicitudTareaDto);

            IEnumerable<Entities.Bpm.EstadoTareaSolicitud> listEstadoTareaSol = await _itareaRepository.ObtenerEstadoSolicitudTarea();

            if (respuesta.Data)
            {
                ActualizarSolicitudTarea actualizarSolicitudTarea = new ActualizarSolicitudTarea()
                {
                    SLT_ID = crearSolicitudTareaDto.solicitudTareaId,
                    SLT_ESTADO_SOLICITUD = listEstadoTareaSol.Where(x => x.CVL_DESCRIPCION == "En Tramite").FirstOrDefault().CVL_ID //SolicitudConstants.EstadoTramiteTareaSolicitud
                };

                await _solicitudRepository.ActualizarSolicitudTarea(actualizarSolicitudTarea);

                ActualizarSolicitud actualizarSolicitud = new ActualizarSolicitud()
                {
                    SOL_ID = crearSolicitudTareaDto.SolicitudId,
                    SOL_VALOR_A_RETIRAR = crearSolicitudTareaDto.valorRetirar
                };

                await _solicitudRepository.ActualizarSolicitud(actualizarSolicitud);
            }
            else
            {
                await EliminarTareasSolicitud(crearSolicitudTareaDto);
            }

            return respuesta;
        }

        public async Task<Response<ObtenerTramiteSolicitudDto>> AprobarSolicitudTarea(AprobarSolicitudTareaDto aprobarSolicitudTareaDto)
        {
            Response<ClienteCesantiasDto> clienteDto = new Response<ClienteCesantiasDto>();
            clienteDto = await _iClientRequestProvider.ObtenerInformacionClientePorDocumentoYTipo(0, "", aprobarSolicitudTareaDto.clienteId);


            Response<ObtenerTramiteSolicitudDto> respuesta = new Response<ObtenerTramiteSolicitudDto>();
            respuesta.Data = null;
            respuesta.IsSuccess = false;

            var clienteId = aprobarSolicitudTareaDto.clienteId;

            IEnumerable<Entities.Bpm.EstadoTareaSolicitud> listEstadoTareaSol = await _itareaRepository.ObtenerEstadoSolicitudTarea();
            IEnumerable<Entities.Bpm.EstadoSolicitud> listEstadoSol = await _itareaRepository.ObtenerEstadoSolicitud();


            AprobarSolicitudTarea actualizarSolicitudTarea = new AprobarSolicitudTarea()
            {
                SLT_ID = aprobarSolicitudTareaDto.solicitudTareaId,
                SLT_ESTADO_SOLICITUD = listEstadoTareaSol.Where(x => x.CVL_DESCRIPCION == "Aprobada").FirstOrDefault().CVL_ID, // SolicitudConstants.EstadoAprobadaTareaSolicitud,
                SLT_ESTADO_SOLICITUD_NUEVO = listEstadoTareaSol.Where(x => x.CVL_DESCRIPCION == "Pendiente").FirstOrDefault().CVL_ID // SolicitudConstants.EstadoInicialTareaSolicitud
            };

            respuesta.Data = this._mapper.Map<ObtenerTramiteSolicitudDto>(await
                    this._solicitudRepository.AprobarSolicitudTarea(actualizarSolicitudTarea));
            respuesta.IsSuccess = true;

            respuesta.Data.nombresCliente = $"{clienteDto.Data.PrimerNombre} {clienteDto.Data.SegundoNombre}";
            respuesta.Data.apellidosCliente = $"{clienteDto.Data.PrimerApellido} {clienteDto.Data.SegundoApellido}";
            respuesta.Data.identificacionCliente = $"{clienteDto.Data.Identificacion}";
            respuesta.Data.clienteId = clienteDto.Data.IdCliente;
            respuesta.Data.tipoIdentificacion = clienteDto.Data.IdTipoIdentificacion;
            respuesta.Data.telefonoCliente = clienteDto.Data.TelefonoResidencia;
            respuesta.Data.correoCliente = clienteDto.Data.CorreoPersonal;
            respuesta.Data.celularCliente = clienteDto.Data.NumeroCelular;
            respuesta.Data.direccionCliente = clienteDto.Data.Direccion;

            return respuesta;
        }

        public async Task<Response<bool>> RechazarSolicitudTarea(RechazarSolicitudTareaDto rechazarSolicitudTareaDto)
        {
            Response<bool> respuesta = new Response<bool>();
            respuesta.Data = false;
            respuesta.IsSuccess = false;

            IEnumerable<Entities.Bpm.EstadoTareaSolicitud> listEstadoTareaSol = await _itareaRepository.ObtenerEstadoSolicitudTarea();
            IEnumerable<Entities.Bpm.EstadoSolicitud> listEstadoSol = await _itareaRepository.ObtenerEstadoSolicitud();

            RechazarSolicitudTarea actualizarSolicitudTarea = new RechazarSolicitudTarea()
            {
                SLT_ID = rechazarSolicitudTareaDto.solicitudTareaId,
                SLT_ESTADO_SOLICITUD = listEstadoTareaSol.Where(x => x.CVL_DESCRIPCION == "Rechazada").FirstOrDefault().CVL_ID,   //SolicitudConstants.EstadoRechazadaTareaSolicitud,
                SLT_ESTADO_SOLICITUD_NUEVO = listEstadoTareaSol.Where(x => x.CVL_DESCRIPCION == "Pendiente").FirstOrDefault().CVL_ID,//SolicitudConstants.EstadoInicialTareaSolicitud,
                SOL_ESTADO_SOLICITUD = listEstadoSol.Where(x => x.CVL_DESCRIPCION == "Anulada").FirstOrDefault().CVL_ID  //SolicitudConstants.EstadoAnuladaSolicitud
            };

            respuesta.Data = await _solicitudRepository.RechazarSolicitudTarea(actualizarSolicitudTarea);
            respuesta.IsSuccess = true;

            return respuesta;
        }

        public async Task<Response<bool>> ActualizarSolicitudTarea(CrearSolicitudTareaDto actualizarSolicitudTareaDto)
        {
            Response<bool> respuesta = new Response<bool>();

            respuesta.Data = false;
            respuesta.IsSuccess = false;
            string mensajeValidacionMatricula = ValidarMatriculas(actualizarSolicitudTareaDto.SolicitudMatriculaDto);

            if (mensajeValidacionMatricula != "")
            {
                respuesta.Data = false;
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = mensajeValidacionMatricula;
                return respuesta;
            }

            string mensajeValidacionPropietario = ValidarPropietario(actualizarSolicitudTareaDto.SolicitudPropietarioDto, actualizarSolicitudTareaDto.SolicitudMatriculaDto);

            if (mensajeValidacionPropietario != "")
            {
                respuesta.Data = false;
                respuesta.IsSuccess = false;
                respuesta.ReturnMessage = mensajeValidacionPropietario;
                return respuesta;
            }

            ///Eliminar registros
            await EliminarTareasSolicitud(actualizarSolicitudTareaDto);

            respuesta = await InsertarSolicitudTarea(actualizarSolicitudTareaDto);

            if (respuesta.Data)
            {
                ActualizarSolicitud actualizarSolicitud = new ActualizarSolicitud()
                {
                    SOL_ID = actualizarSolicitudTareaDto.SolicitudId,
                    SOL_VALOR_A_RETIRAR = actualizarSolicitudTareaDto.valorRetirar
                };

                await _solicitudRepository.ActualizarSolicitud(actualizarSolicitud);
            }


            return respuesta;
        }

        public async Task<Response<IEnumerable<DocumentosPorSubModalidadDto>>> ConsultarDocumentosPorSubModalidad(ConsultaDocumentoSubModalidadTarea consultaDocumentoSubModalidadTarea)
        {
            IEnumerable<DocumentosPorSubModalidadDto> documentos = this._mapper.Map<IEnumerable<DocumentosPorSubModalidadDto>>(await this._solicitudRepository.ConsultarDocumentosPorSubModalidad(consultaDocumentoSubModalidadTarea.idSubModalidad, consultaDocumentoSubModalidadTarea.idSolicitudtarea));
            return new Response<IEnumerable<DocumentosPorSubModalidadDto>> { Data = documentos, IsSuccess = true, ReturnMessage = "" };
        }

        /// <summary>
        /// Carga los documentos para la solicitud de cesantías
        /// </summary>
        /// <author>Hanson Restrepo</author>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Response<bool>> CargarDocumentosSolicitud(List<CargarDocumentosSolicitudDto> cargarDocumentosSolicitudDto, Guid IdSolicitud)
        {
            foreach (var x in cargarDocumentosSolicitudDto)
            {
                foreach (var y in x.archivosCargados)
                {
                    FileStreamResult fileStreamResult = new FileStreamResult(y.OpenReadStream(), y.ContentType);

                    FileInfo fi = new FileInfo(y.FileName);
                    if (fi.Extension == ".pdf" || fi.Extension == ".PDF")
                    {
                        var newName = Path.GetRandomFileName() + fi.Extension.ToLower();
                        var result = await _blobStorageGenericRepository.SubirArchivoBlobStorage("cesantias", newName.ToString(), fileStreamResult);

                        InsertarArchivo insertarArchivo = new InsertarArchivo();
                        insertarArchivo.AST_NOMBRE_ARCHIVO = fi.Name;
                        insertarArchivo.AST_RUTA_STORAGE = newName;
                        insertarArchivo.AST_EXTENSION = fi.Extension;
                        insertarArchivo.SOL_ID_FK = IdSolicitud;
                        insertarArchivo.PAM_ID_FK = x.archivoParametrizadoId;
                        insertarArchivo.AST_CREATEDOPOR = new Guid();

                        await _solicitudRepository.InsertarArchivoPorSolicitudTarea(insertarArchivo);
                    }
                    else { return new Response<bool> { Data = false, IsSuccess = false, ReturnMessage = "Algunos documentos no fueron almacenados. Solo puede cargar documentos PDF" }; }

                }
            }
            return new Response<bool> { Data = true, IsSuccess = true, ReturnMessage = "Documentos almacenados correctamente" };
        }

        public async Task<Response<IEnumerable<ConsultarArchivoPorSolicitudDto>>> ConsultarArchivoPorSolicitud(Guid IdSolicitud)
        {
            IEnumerable<ConsultarArchivoPorSolicitudDto> archivo = this._mapper.Map<IEnumerable<ConsultarArchivoPorSolicitudDto>>(await this._solicitudRepository.ConsultarArchivoPorSolicitud(IdSolicitud));
            return new Response<IEnumerable<ConsultarArchivoPorSolicitudDto>> { Data = archivo, IsSuccess = true, ReturnMessage = "" };
        }

        public async Task<Response<bool>> EliminarArchivoPorSolicitud(EliminarArchivoPorSolicitudDto eliminarArchivoPorSolicitudDto)
        {
            Response<bool> respuesta = new Response<bool>();
            respuesta.Data = false;
            respuesta.IsSuccess = false;

            //elimina del blobstorage
            var result = await _blobStorageGenericRepository.EliminarArchivoStorage("cesantias", eliminarArchivoPorSolicitudDto.rutaStorage);

            //elimina de la bd
            EliminarArchivoPorSolicitud eliminarArchivo = new EliminarArchivoPorSolicitud()
            {
                AST_ID = eliminarArchivoPorSolicitudDto.idArchivo,
                AST_RUTA_STORAGE = eliminarArchivoPorSolicitudDto.rutaStorage
            };

            respuesta.Data = await _solicitudRepository.EliminarArchivoPorSolicitud(eliminarArchivo);
            respuesta.IsSuccess = true;

            return respuesta;
        }

        public async Task<FileResult> DescargarArchivoPorSolicitud(string rutaStorage)
        {
            /*
            var blobCheck = await _blobStorageGenericRepository.DescargarArchivoStorage("cesantias", rutaStorage);
            var descargado = new FileStreamResult(blobCheck.Content, blobCheck.ContentType);
            descargado.FileDownloadName = rutaStorage;
            await descargado.FileStream.FlushAsync();
            respuesta.Data = descargado;
            */

            BlobContainerClient container = new BlobContainerClient(this._options.Value.CadenaOne, "cesantias");
            BlobClient blob = container.GetBlobClient(rutaStorage);
            BlobDownloadInfo download = await blob.DownloadAsync();

            var descargado = new FileStreamResult(download.Content, download.ContentType);
            descargado.FileDownloadName = rutaStorage;
            await descargado.FileStream.FlushAsync();

            return descargado;
        }

        /// <summary>
        /// Insertar una inconsistencia
        /// </summary>
        /// <param name="insertarInconsistenciaSolicitud"></param>
        /// <returns></returns>
        public async Task<Response<InconsistenciaSolicitudDto>> InsertarInconsistenciaSolicitud(InconsistenciaSolicitudDto insertarInconsistenciaSolicitud)
        {
            return new Response<InconsistenciaSolicitudDto>
            {
                Data = this._mapper.Map<InconsistenciaSolicitudDto>(
                    await this._solicitudRepository.InsertarInconsistenciaSolicitud(
                         this._mapper.Map<InconsistenciaSolicitud>(insertarInconsistenciaSolicitud)))
            };
        }

        /// <summary>
        /// Insertar una inconsistencia
        /// </summary>
        /// <param name="actualizarInconsistenciaSolicitud"></param>
        /// <returns></returns>
        public async Task<Response<InconsistenciaSolicitudDto>> ActualizarInconsistenciaSolicitud(InconsistenciaSolicitudDto actualizarInconsistenciaSolicitud)
        {
            return new Response<InconsistenciaSolicitudDto>
            {
                Data = this._mapper.Map<InconsistenciaSolicitudDto>(
                    await this._solicitudRepository.ActualizarInconsistenciaSolicitud(
                         this._mapper.Map<InconsistenciaSolicitud>(actualizarInconsistenciaSolicitud)))
            };
        }

        public async Task<Response<IEnumerable<InconsistenciaSolicitudDto>>> ConsultarInconsistenciaSolicitud(Guid IdSolicitud)
        {
            IEnumerable<InconsistenciaSolicitudDto> archivo = this._mapper.Map<IEnumerable<InconsistenciaSolicitudDto>>(await this._solicitudRepository.ConsultarInconsistenciaSolicitud(IdSolicitud));
            return new Response<IEnumerable<InconsistenciaSolicitudDto>> { Data = archivo, IsSuccess = true, ReturnMessage = "" };
        }

        /// <summary>
        /// Metodo logica de negocio para obtener las solicitudes de cesantías
        /// </summary>
        /// <author>Hanson Restrepo</author>
        /// <param name = "solicitud" ></ param >
        /// < returns >Response<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>></ returns >
        public async Task<Response<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>>> ConsultarSolicitudCesantias(PeticionConsultarSolicitudCesantiasDto solicitud)
        {
            IEnumerable<RespuestaConsultarSolicitudCesantiasDto> dataResult;
            var consultaSolicitud = this._mapper.Map<PeticionConsultarSolicitudCesantias>(solicitud);
            IEnumerable<RespuestaConsultarSolicitudCesantiasDto> result = this._mapper.Map<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>>(await this._solicitudRepository.ConsultarSolicitudCesantias(consultaSolicitud));

            var listIdCliente = "";

            // SI HAY IDENTIFICACIONES
            if (solicitud.Identificacion != "")
            {
                dataResult = await AsignarNombreEIdentificacion(solicitud.Identificacion, result);
            }
            // SI TRAE TODOS LOS PROCESOS
            else
            {
                if (result.Count() == 0)
                {
                    return new Response<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>> { Data = null, IsSuccess = true, ReturnMessage = "" };
                }

                result.ToList().ForEach(x =>
                {
                    listIdCliente += x.IdCliente + ",";
                });
                listIdCliente = listIdCliente.Remove(listIdCliente.Length - 1);

                dataResult = await AsignarNombreEIdentificacionProcesos(listIdCliente, result);
            }

            return new Response<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>> { Data = dataResult, IsSuccess = true, ReturnMessage = "" };
        }


        private async Task<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>> AsignarNombreEIdentificacion(string identificacion, IEnumerable<RespuestaConsultarSolicitudCesantiasDto> result)
        {
            Response<ClienteCedulaDto> clienteDto = new Response<ClienteCedulaDto>();
            clienteDto = await _iClientRequestProvider.ObtenerClientesByNumeroIdentificacion(identificacion);

            if (clienteDto.Data != null)
            {
                result = result.Where(x => x.IdCliente == clienteDto.Data.IdCliente);

                foreach (var item in result)
                {
                    item.CedulaCliente = clienteDto.Data.Identificacion;
                    item.NombreCliente = $"{clienteDto.Data.PrimerNombre} {clienteDto.Data.SegundoNombre} {clienteDto.Data.PrimerApellido} {clienteDto.Data.SegundoApellido}";
                }
            }
            else
            {
                result = (IEnumerable<RespuestaConsultarSolicitudCesantiasDto>)clienteDto.Data;
            }

            return result;
        }

        private async Task<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>> AsignarNombreEIdentificacionProcesos(string cadenaIds, IEnumerable<RespuestaConsultarSolicitudCesantiasDto> result)
        {
            Response<IEnumerable<ClienteDto>> clienteDto = new Response<IEnumerable<ClienteDto>>();
            clienteDto = await _iClientRequestProvider.ObtenerClientesById(cadenaIds);

            var joined = result.Join(clienteDto.Data,
            resultKey => resultKey.IdCliente,
            clienteKey => clienteKey.IdCliente,
            (resultKey, clienteKey) => new RespuestaConsultarSolicitudCesantiasDto
            {
                NumeroSolicitud = resultKey.NumeroSolicitud,
                ProcesoDescripcion = resultKey.ProcesoDescripcion,
                CedulaCliente = clienteKey.Identificacion,
                NombreCliente = clienteKey.PrimerNombre+" "+clienteKey.SegundoNombre+" "+clienteKey.PrimerApellido+" "+clienteKey.SegundoApellido,
                FechaSolicitud = resultKey.FechaSolicitud,
                ValorRetirar = resultKey.ValorRetirar,
                TareaNombre = resultKey.TareaNombre,
                EstadoSolicitud = resultKey.EstadoSolicitud,
                IdCliente = resultKey.IdCliente
            });

            return joined;
        }



        #region Metodos de negocio

        private async Task<Response<bool>> EliminarTareasSolicitud(CrearSolicitudTareaDto eliminarSolicitudTareaDto)
        {

            Response<bool> respuesta = new Response<bool>();

            respuesta.Data = false;
            respuesta.IsSuccess = false;

            await _solicitudRepository.EliminarTerceroSolicitud(eliminarSolicitudTareaDto.SolicitudId);
            await _solicitudRepository.EliminarMatriculaPropietarioSolicitud(eliminarSolicitudTareaDto.SolicitudId);
            await _solicitudRepository.EliminarPropietarioSolicitud(eliminarSolicitudTareaDto.SolicitudId);
            await _solicitudRepository.EliminarMatriculaInmobiliaria(eliminarSolicitudTareaDto.SolicitudId);

            respuesta.Data = true;
            respuesta.IsSuccess = true;

            return respuesta;
        }

        private async Task<Response<bool>> InsertarSolicitudTarea(CrearSolicitudTareaDto crearSolicitudCompraViviendaDto)
        {
            Response<bool> respuesta = new Response<bool>();

            SolicitudMatricula matriculaInsertada = new SolicitudMatricula();

            List<SolicitudMatricula> solicitudMatricula = this._mapper.Map<List<SolicitudMatricula>>(crearSolicitudCompraViviendaDto.SolicitudMatriculaDto);

            foreach (SolicitudMatricula item in solicitudMatricula)
            {
                item.MAI_FECHA_REGISTRO = System.DateTime.Now;
                item.CREATEDO_POR = crearSolicitudCompraViviendaDto.CreadoPor;
                item.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
                matriculaInsertada = await this._solicitudRepository.InsertarSolicitudMatricula(item);
                item.MAI_ID = matriculaInsertada.MAI_ID;

            }

            SolicitudPropietario propietarioInsertado = new SolicitudPropietario();

            foreach (SolicitudPropietarioDto item in crearSolicitudCompraViviendaDto.SolicitudPropietarioDto)
            {
                SolicitudPropietario datoInsertar = new SolicitudPropietario
                {
                    SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId,
                    CREATEDO_POR = crearSolicitudCompraViviendaDto.CreadoPor,
                    PRP_NOMBRE_RAZON_SOCIAL = item.RazonSocial,
                    PRP_NUMERO_IDENTIFICACION = item.NumeroIdentificacion,
                    TID_ID_FK = item.TipoIdentificacion.Id
                };

                propietarioInsertado = await _solicitudRepository.InsertarSolicitudPropietario(datoInsertar);

                List<SolicitudPropietarioMatricula> matriculaPropietario = (from p in item.Matricula
                                                                            join m in solicitudMatricula on p.NumeroMatricula equals m.MAI_NUMERO_MATRICULA
                                                                            select new SolicitudPropietarioMatricula
                                                                            {
                                                                                PRP_ID = propietarioInsertado.PRP_ID,
                                                                                MAI_ID = m.MAI_ID,
                                                                                PMA_CREATEDOPOR = crearSolicitudCompraViviendaDto.CreadoPor
                                                                            }).ToList();

                foreach (SolicitudPropietarioMatricula insert in matriculaPropietario)
                {
                    await _solicitudRepository.InsertarSolicitudPropietarioMatricula(insert);
                }
            }

            //aqui guardas tercero apoderado
            foreach (SolicitudTerceroApoderadoDto item in crearSolicitudCompraViviendaDto.SolicitudTerceroApoderadoDto)
            {
                SolicitudTerceroApoderado solicitudTerceroApoderado = this._mapper.Map<SolicitudTerceroApoderado>(item);
                solicitudTerceroApoderado.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
                solicitudTerceroApoderado.CREATEDO_POR = crearSolicitudCompraViviendaDto.CreadoPor;
                solicitudTerceroApoderado.TER_TIPO_TERCERO_FK = SolicitudConstants.TipoTerceroApoderadoId;
                await _solicitudRepository.InsertarSolicitudTerceroApoderado(solicitudTerceroApoderado);
            }

            //aqui guardas tercero beneficiario
            foreach (SolicitudTerceroBeneficiarioDto item in crearSolicitudCompraViviendaDto.SolicitudTerceroBeneficiarioDto)
            {
                SolicitudTerceroBeneficiario solicitudTerceroBeneficiario = this._mapper.Map<SolicitudTerceroBeneficiario>(item);
                solicitudTerceroBeneficiario.TER_TIPO_TERCERO_FK = SolicitudConstants.TipoTerceroBeneficiarioId;
                solicitudTerceroBeneficiario.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
                solicitudTerceroBeneficiario.CREATEDO_POR = crearSolicitudCompraViviendaDto.CreadoPor;
                await _solicitudRepository.InsertarSolicitudTerceroBeneficiario(solicitudTerceroBeneficiario);
            }

            //aqui guardas tercero vendedor
            foreach (SolicitudTerceroVendedorDto item in crearSolicitudCompraViviendaDto.SolicitudTerceroVendedorDto)
            {
                SolicitudTerceroVendedor solicitudTerceroVendedor = this._mapper.Map<SolicitudTerceroVendedor>(item);
                solicitudTerceroVendedor.TER_TIPO_TERCERO_FK = SolicitudConstants.TipoTerceroVendedorId;
                solicitudTerceroVendedor.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
                solicitudTerceroVendedor.CREATEDO_POR = crearSolicitudCompraViviendaDto.CreadoPor;
                await _solicitudRepository.InsertarSolicitudTerceroVendedor(solicitudTerceroVendedor);
            }

            //aqui guardas tercero constructor
            if (crearSolicitudCompraViviendaDto.SolicitudTerceroConstructorDto != null)
            {
                SolicitudTerceroConstructor solicitudTerceroConstructor = this._mapper.Map<SolicitudTerceroConstructor>(crearSolicitudCompraViviendaDto.SolicitudTerceroConstructorDto);
                solicitudTerceroConstructor.TER_TIPO_TERCERO_FK = SolicitudConstants.TipoTerceroConstructorId;
                solicitudTerceroConstructor.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
                solicitudTerceroConstructor.CREATEDO_POR = crearSolicitudCompraViviendaDto.CreadoPor;
                await _solicitudRepository.InsertarSolicitudTerceroConstructor(solicitudTerceroConstructor);
            }

            //aqui guardas tercero autorizado
            if (crearSolicitudCompraViviendaDto.SolicitudTerceroAutorizadoDto != null)
            {
                SolicitudTerceroAutorizado solicitudTerceroAutorizado = this._mapper.Map<SolicitudTerceroAutorizado>(crearSolicitudCompraViviendaDto.SolicitudTerceroAutorizadoDto);
                solicitudTerceroAutorizado.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
                solicitudTerceroAutorizado.CREATEDO_POR = crearSolicitudCompraViviendaDto.CreadoPor;
                await _solicitudRepository.InsertarSolicitudTerceroAutorizado(solicitudTerceroAutorizado);
            }

            //aqui guardas tercero entidad educativa
            if (crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadEducativaDto != null)
            {
                SolicitudTerceroEntidadEducativa solicitudTerceroEntidadEducativa = new SolicitudTerceroEntidadEducativa();
                solicitudTerceroEntidadEducativa.ENE_ID = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadEducativaDto.IdEntidad;
                solicitudTerceroEntidadEducativa.ENE_NIT = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadEducativaDto.Nit;
                solicitudTerceroEntidadEducativa.ENE_NOMBRE_RAZON_SOCIAL = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadEducativaDto.RazonSocial;
                solicitudTerceroEntidadEducativa.PRN_ID_FK = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadEducativaDto.IdNivel;
                solicitudTerceroEntidadEducativa.TER_NUM_RECIBO_PAGO = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadEducativaDto.ReciboPago;
                solicitudTerceroEntidadEducativa.TER_FECHA_LIMITE_PAGO = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadEducativaDto.Fechalimite;
                solicitudTerceroEntidadEducativa.ENE_CREATEDOPOR = crearSolicitudCompraViviendaDto.CreadoPor;
                solicitudTerceroEntidadEducativa.TER_TIPO_TERCERO_FK = SolicitudConstants.TipoTerceroEntidadEducativa;
                solicitudTerceroEntidadEducativa.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
                solicitudTerceroEntidadEducativa.TID_ID_FK = SolicitudConstants.TipoIdentificacionNit;

                await _solicitudRepository.InsertarSolicitudTerceroEntidadEducativa(solicitudTerceroEntidadEducativa);
            }

            //aqui guardas tercero beneficiario de estudio
            foreach (SolicitudTerceroBeneficiarioEstudioDto item in crearSolicitudCompraViviendaDto.SolicitudTerceroBeneficiarioEstudioDto)
            {
                SolicitudTerceroBeneficiarioEstudio solicitudTerceroBeneficiarioEstudio = new SolicitudTerceroBeneficiarioEstudio();
                solicitudTerceroBeneficiarioEstudio.TER_NUMERO_DOCUMENTO = item.numDocEstudio;
                solicitudTerceroBeneficiarioEstudio.TER_NOMBRE_RAZON_SOCIAL = item.razonsocialEstudio;
                solicitudTerceroBeneficiarioEstudio.TER_PARENTESCO = item.parentescoEstudio;
                solicitudTerceroBeneficiarioEstudio.CREATEDOPOR = crearSolicitudCompraViviendaDto.CreadoPor;
                solicitudTerceroBeneficiarioEstudio.TER_TIPO_TERCERO_FK = SolicitudConstants.TipoTerceroBeneficiarioEstudioId;
                solicitudTerceroBeneficiarioEstudio.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
                solicitudTerceroBeneficiarioEstudio.TID_ID_FK = item.tipoDocEstudio;

                await _solicitudRepository.InsertarSolicitudTerceroBeneficiarioEstudio(solicitudTerceroBeneficiarioEstudio);
            }

            //aqui guardas tercero beneficiario estudio entidad educativa
            //foreach (SolicitudTerceroBeneficiarioEstudioEntidadEducativaDto item in crearSolicitudCompraViviendaDto.SolicitudTerceroBeneficiarioEstudioEntidadEducativaDto)
            //{
            //    SolicitudTerceroBeneficiarioEstudioEntidadEducativa solicitudTerceroBeneficiarioEstudioEntidadEducativa = new SolicitudTerceroBeneficiarioEstudioEntidadEducativa();
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.TER_NUMERO_DOCUMENTO = item.NumDocEstudio;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.TER_NOMBRE_RAZON_SOCIAL = item.RazonsocialEstudio;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.TER_PARENTESCO = item.ParentescoEstudio;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.TER_TIPO_TERCERO_FK = SolicitudConstants.TipoTerceroBeneficiarioEstudioEntidadEducativaId;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.TID_ID_FK = item.TipoDocEstudio;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.ENE_ID = item.IdEntidad;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.ENE_NIT = item.Nit;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.ENE_NOMBRE_RAZON_SOCIAL = item.RazonSocial;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.PRN_ID_FK = item.IdNivel;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.TER_NUM_RECIBO_PAGO = item.ReciboPago;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.SOL_VALOR_A_RETIRAR = crearSolicitudCompraViviendaDto.valorRetirar;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.TER_FECHA_LIMITE_PAGO = item.Fechalimite;
            //    solicitudTerceroBeneficiarioEstudioEntidadEducativa.ENE_CREATEDOPOR = crearSolicitudCompraViviendaDto.CreadoPor;

            //    await _solicitudRepository.InsertarSolicitudTerceroBeneficiarioEstudioEntidadEducativa(solicitudTerceroBeneficiarioEstudioEntidadEducativa);
            //}

            //aqui guardas tercero entidad seguro educativo
            if (crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadSeguroEducativoDto != null)
            {
                SolicitudTerceroEntidadSeguroEducativo solicitudTerceroEntidadSeguroEducativo = new SolicitudTerceroEntidadSeguroEducativo();
                solicitudTerceroEntidadSeguroEducativo.TER_NUMERO_DOCUMENTO = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadSeguroEducativoDto.numDoc;
                solicitudTerceroEntidadSeguroEducativo.TER_NOMBRE_RAZON_SOCIAL = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadSeguroEducativoDto.razonSocialAseguradora;
                solicitudTerceroEntidadSeguroEducativo.TER_CREATEDOPOR = crearSolicitudCompraViviendaDto.CreadoPor;
                solicitudTerceroEntidadSeguroEducativo.TER_TIPO_TERCERO_FK = SolicitudConstants.TipoTerceroEntidadSeguroEducativoId;
                solicitudTerceroEntidadSeguroEducativo.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
                solicitudTerceroEntidadSeguroEducativo.TID_ID_FK = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadSeguroEducativoDto.tipoDocId;
                solicitudTerceroEntidadSeguroEducativo.ESE_ID_FK = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadSeguroEducativoDto.entidadSeguroEducativoId;
                solicitudTerceroEntidadSeguroEducativo.TER_NUM_POLIZA = crearSolicitudCompraViviendaDto.SolicitudTerceroEntidadSeguroEducativoDto.numeroPoliza;

                await _solicitudRepository.InsertarSolicitudTerceroEntidadSeguroEducativo(solicitudTerceroEntidadSeguroEducativo);
            }

            //aqui guardas tercero tenedor de acciones
            if (crearSolicitudCompraViviendaDto.SolicitudTerceroTenedorAccionesDto != null)
            {
                SolicitudTerceroTenedorAcciones solicitudTerceroTenedorAcciones = new SolicitudTerceroTenedorAcciones();
                solicitudTerceroTenedorAcciones.TER_TIPO_TERCERO_FK = SolicitudConstants.TipoTerceroTenedorAccionesId;
                solicitudTerceroTenedorAcciones.SOL_ID_FK = crearSolicitudCompraViviendaDto.SolicitudId;
                solicitudTerceroTenedorAcciones.TER_CREATEDOPOR = crearSolicitudCompraViviendaDto.CreadoPor;
                solicitudTerceroTenedorAcciones.TID_ID_FK = crearSolicitudCompraViviendaDto.SolicitudTerceroTenedorAccionesDto.TipoDoc;
                solicitudTerceroTenedorAcciones.TER_NUMERO_DOCUMENTO = crearSolicitudCompraViviendaDto.SolicitudTerceroTenedorAccionesDto.NumDoc;
                solicitudTerceroTenedorAcciones.TER_NOMBRE_RAZON_SOCIAL = crearSolicitudCompraViviendaDto.SolicitudTerceroTenedorAccionesDto.Razonsocial;
                solicitudTerceroTenedorAcciones.TER_DIRECCION = crearSolicitudCompraViviendaDto.SolicitudTerceroTenedorAccionesDto.Direccion;
                solicitudTerceroTenedorAcciones.TER_CORREO_ELECTRONICO = crearSolicitudCompraViviendaDto.SolicitudTerceroTenedorAccionesDto.Correo;
                solicitudTerceroTenedorAcciones.TER_TELEFONO = crearSolicitudCompraViviendaDto.SolicitudTerceroTenedorAccionesDto.Telefono;
                solicitudTerceroTenedorAcciones.TER_EMISOR_NOMBRE_RAZON_SOCIAL = crearSolicitudCompraViviendaDto.SolicitudTerceroTenedorAccionesDto.Emisor;
                solicitudTerceroTenedorAcciones.DPC_ID_FK = crearSolicitudCompraViviendaDto.SolicitudTerceroTenedorAccionesDto.Ciudad;

                await _solicitudRepository.InsertarSolicitudTerceroTenedorAcciones(solicitudTerceroTenedorAcciones);
            }


            respuesta.Data = true;
            respuesta.IsSuccess = true;

            return respuesta;

        }

        #endregion

        #region Metodos privados
        private string ValidarMatriculas(List<SolicitudMatriculaDto> listaMatricula)
        {
            var resultadoGroupBy = from l in listaMatricula
                                   group l.NumeroMatricula by l.NumeroMatricula into g
                                   select new { NumeroMatricula = g.Key, total = g.Count() };

            var encontroDuplicados = resultadoGroupBy.Where(x => x.total > 1).FirstOrDefault();

            if (encontroDuplicados != null)
            {
                return "Existen matrículas duplicadas";
            }

            var resultadoGroupByEsPrincipal = from l in listaMatricula
                                              group l.EsPrincipal by l.EsPrincipal into g
                                              select new { EsPrincipal = g.Key, total = g.Count() };

            var encontroDuplicadosEsPrincipal = resultadoGroupByEsPrincipal.Where(x => x.total > 1 && x.EsPrincipal == true).FirstOrDefault();

            // validar que solo exista una matricula principal
            if (encontroDuplicadosEsPrincipal != null)
            {
                return "Existe mas de una matrícula principal";
            }

            var resultadoGroupByUnaPrincipal = from l in listaMatricula
                                               group l.EsPrincipal by l.EsPrincipal into g
                                               select new { EsPrincipal = g.Key, total = g.Count() };

            var encontroDuplicadosUnaPrincipal = resultadoGroupByUnaPrincipal.Where(x => x.EsPrincipal == true).FirstOrDefault();

            // validar que solo exista una matricula principal
            if (encontroDuplicadosUnaPrincipal == null && listaMatricula.Count > 0)
            {
                return "Al menos una matrícula debe de ser principal";
            }


            return "";
        }


        private string ValidarPropietario(List<SolicitudPropietarioDto> listaPropietario, List<SolicitudMatriculaDto> listaMatricula)
        {
            string mensaje = "";
            listaPropietario.ForEach(x =>
            {
                var resultadoGroupBy = from l in x.Matricula
                                       group l by new { l.NumeroMatricula } into g
                                       select new { NumeroIdentificacion = g.Key, total = g.Count() };

                var encontroDuplicados = resultadoGroupBy.Where(x => x.total > 1).FirstOrDefault();

                if (encontroDuplicados != null)
                {
                    mensaje = "Existe un propietario asociado mas de una vez a una misma matrícula";
                    return;
                }
            });

            if (mensaje != "")
            {
                return mensaje;
            }

            if (listaPropietario.Count > 0)
            {
                listaMatricula.ForEach(ma =>
                {
                    var total = listaPropietario.SelectMany(x => x.Matricula).Where(x => x.NumeroMatricula == ma.NumeroMatricula).Count();
                    if (total == 0)
                    {
                        mensaje = "Existen matrículas sin propietario asignado";
                        return;
                    }
                });
            }

            if (mensaje != "")
            {
                return mensaje;
            }


            return "";
        }
        #endregion
    }
}
