using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities.Credito.Simulador;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Globalization;
using GA2.Application.Main;
using System.Collections.Generic;

namespace GA2.Domain.Core
{
    // <summary>
    /// Implementacion Interface Validacion de Identidad
    /// </summary>
    public class ValidacionIdentidadBusinessLogic : IValidacionIdentidadBusinessLogic
    {
        private readonly IValidacionIdentidadRepository _validaRepository;
        private readonly IMapper _mapper;
        private readonly IGestorIdVisionBusinessLogic _gestorIdVision;
        private string _usuarioIDVision;
        private string _claveIDVision;
        private string _solucionId;
        private string _usuarioAqm;
        private string _claveAqm;
        private string _solucionIdAqm;
        private readonly IOptions<IdVisionOptions> _IdVisionoptions;
        private readonly IOptions<AqmOptions> _AQMoptions;
        private readonly IClientRequestProvider _requestPovider;
        private readonly ICatalogosRepository _catalogosRepository;

        public ValidacionIdentidadBusinessLogic(IValidacionIdentidadRepository validaRepository, IMapper mapper, IGestorIdVisionBusinessLogic gestorIdVision, IOptions<IdVisionOptions> idVisionoptions, IOptions<AqmOptions> aQMoptions, IClientRequestProvider requestPovider, ICatalogosRepository catalogosRepository)
        {
            _validaRepository = validaRepository;
            _mapper = mapper;
            _gestorIdVision = gestorIdVision;
            _IdVisionoptions = idVisionoptions;
            _AQMoptions = aQMoptions;
            _requestPovider = requestPovider;
            _catalogosRepository = catalogosRepository;
            _usuarioIDVision = _IdVisionoptions.Value.usuarioIDVision;
            _claveIDVision = _IdVisionoptions.Value.claveIDVision;
            _solucionId = _IdVisionoptions.Value.solucionId;
            _usuarioAqm = _AQMoptions.Value.usuarioAqm;
            _claveAqm = _AQMoptions.Value.claveAqm;
            _solucionIdAqm = _AQMoptions.Value.solucionIdAqm;
        }



        /// <summary>
        /// Metodo para la creacion y validacion de Identidad, Obtener datos personales y envia codigo OTP
        /// Recibe como parametro un objeto de la clase ValidacionIdentidadDto
        /// /// <param name="validaDto"></param>
        /// </summary>
        public async Task<Response<ValidacionIdentidadDto>> CreateValidacionIdentidad(ValidacionIdentidadDto validaDto)
        {
            var validacion = this._mapper.Map<ValidacionIdentidad>(validaDto);
            string apellido = "";
            var modeloIdentidad = await this._validaRepository.CreateValidacionIdentidad(validacion);
            var datosPersonales = await ObtenerDatosPersonalesAsync(modeloIdentidad.VLI_NUMERO_DOCUMENTO);
            if (datosPersonales == null)
                apellido = "NA";
            else
                apellido = datosPersonales.NombresApellidos.ToString().Split(' ')[2].Trim();

            RequestTuDto request = new RequestTuDto
            {
                usrId = _usuarioIDVision,
                pasword = _claveIDVision,
                solucionId = _solucionId,
                LastName = apellido,
                IdExpeditionDate = modeloIdentidad.VLI_FECHA_EXPEDICION.ToString("dd/MM/yyyy"),
                IdNumber = modeloIdentidad.VLI_NUMERO_DOCUMENTO,
                IdType = modeloIdentidad.TID_ID,
                RecentPhoneNumber = modeloIdentidad.VLI_NUMERO_CELULAR,
                IdValidation = modeloIdentidad.VLI_ID.ToString()
            };

            var valdiacionIdentidadDto = this._mapper.Map<ValidacionIdentidadDto>(modeloIdentidad);
            var respuesta = await _gestorIdVision.validarCliente(request);

            #region Codigo Original
            if (respuesta.codigoRechazo == 0)
            {
                request.idAplication = valdiacionIdentidadDto.Id.ToString();

                var respuestaOTP = await _gestorIdVision.EnvioCodigoOTP(request);
                if (respuestaOTP.codigoError == 0)
                {
                    valdiacionIdentidadDto.IdPantalla = 1; //Cambio de Pantalla 
                    valdiacionIdentidadDto.Delay = respuestaOTP.delayOtp.Trim();
                    valdiacionIdentidadDto.CodigoOtp = respuestaOTP.codigoOtp.Trim();
                }
                else
                {
                    //Rechazo Otp
                    valdiacionIdentidadDto.idError = 1;
                    valdiacionIdentidadDto.DescripcionError = respuesta.detalleRechazo.Trim();
                    valdiacionIdentidadDto.IdPantalla = 0; //Cambio de Pantalla - Error
                }
            }
            else
            {
                //Codigo Prueba -- Temporal
                var digits = 4;
                var otp = string.Empty;
                var rGuid = Guid.NewGuid().ToString().ToArray();
                while (otp.Length < digits - 1)
                {
                    foreach (var value in rGuid)
                    {
                        int result = 0;
                        if (int.TryParse(value.ToString(), out result))
                        {
                            otp += value;
                        }
                        if (otp.Length == digits)
                            break;
                    }
                }
                valdiacionIdentidadDto.IdPantalla = 1; //Cambio de Pantalla 
                valdiacionIdentidadDto.Delay = "05:00";
                valdiacionIdentidadDto.CodigoOtp = otp;
                valdiacionIdentidadDto.IdAplicacion = valdiacionIdentidadDto.Id.ToString();

                ////Codigo Original
                //valdiacionIdentidadDto.idError = 1;
                //valdiacionIdentidadDto.DescripcionError = respuesta.detalleError;
                //valdiacionIdentidadDto.IdPantalla = 0; //Cambio de Pantalla - Error
            }
            #endregion

            return new Response<ValidacionIdentidadDto> { Data = valdiacionIdentidadDto };
        }


        /// <summary>
        /// Metodo para la actualizacion de datos codigo OTP
        /// Recibe como parametro objeto de la clase ValidacionIdentidadDto// Copia_Pruebas
        /// /// <param name="validaDto"></param>
        /// </summary>
        public async Task<Response<ValidacionIdentidadDto>> ActualizarValidacionOTP(ValidacionIdentidadDto validaDto)
        {
            RequestTuDto request = new RequestTuDto
            {
                usrId = _usuarioIDVision,
                pasword = _claveIDVision,
                solucionId = _solucionId,
                RecentPhoneNumber = validaDto.NumeroCelular,
                IdValidation = validaDto.Id.ToString(),
                idAplication = validaDto.IdAplicacion,
                codeOTP = validaDto.CodigoOtp
            };

            var responseTU = await _gestorIdVision.validacionCodigoOTPAsync(request);
            if (responseTU.codigoError == 1)
            {
                if (validaDto.CodigoOtp == validaDto.CodigoOtpIngresado)
                {
                    responseTU.codigoError = 0;
                }
                else
                {
                    validaDto.idError = 1;
                    validaDto.DescripcionError = "Codigo otp no valido intente de nuevo";
                    validaDto.IdPantalla = 0;
                }
            }

            if (responseTU.codigoError == 0)
            {
                var identidad = this._mapper.Map<ValidacionIdentidad>(validaDto);

                identidad.VLI_ID = Guid.Parse(validaDto.Id.ToString());
                identidad.VLI_FECHA_VALIDA_OTP = DateTime.Now;
                identidad.VLI_FECHA_VALIDA_IDEN = DateTime.Now;
                identidad.VLI_CODIGO_OTP = validaDto.CodigoOtp;
                identidad.VLI_PASO_VALIDACION = 0;

                var ActValidacion = _validaRepository.ActualizarValidacionOTP(identidad);
                var PreaProbado = _validaRepository.ConsultarPreAprobado(identidad.VLI_NUMERO_DOCUMENTO);
                var Solicitud = _validaRepository.ConsultarSolicitudCredito(identidad.VLI_NUMERO_DOCUMENTO);

                await Task.WhenAll(ActValidacion, PreaProbado, Solicitud);

                if (!ActValidacion.IsFaulted)
                {
                    if (PreaProbado.Result.Count <= 0 && Solicitud.Result.Count <= 0)
                    {
                        validaDto.idError = 0;
                        validaDto.IdPantalla = 2; //FormularioSolicitud.aspx
                    }
                    else
                    {
                        if (Solicitud.Result.Count <= 0)
                        {
                            validaDto.IdSolicitud = Guid.Parse(PreaProbado.Result.FirstOrDefault().SLS_ID.ToString());
                            validaDto.TcrId = PreaProbado.Result.FirstOrDefault().TCR_ID;
                            validaDto.NumeroPreaprobado = PreaProbado.Result.FirstOrDefault().SLS_NUMERO_PREAPROBADO;
                            validaDto.RutaPdfResumen = PreaProbado.Result.FirstOrDefault().SLS_RUTA_PDF_RESUMEN.ToString();
                            validaDto.ValorPrestamo = PreaProbado.Result.FirstOrDefault().VALOR_PRESTAMO.ToString();
                            validaDto.ValorVivienda = PreaProbado.Result.FirstOrDefault().VALOR_VIVIENDA.ToString();
                            validaDto.TipoVivienda = PreaProbado.Result.FirstOrDefault().TIPO_VIVIENDA.ToString();
                            validaDto.ViviendaVis = PreaProbado.Result.FirstOrDefault().VIVIENDA_VIS.ToString();

                            validaDto.idError = 0;
                            validaDto.IdPantalla = 3; //FormularioCredito.aspx
                        }
                        else
                        {
                            validaDto.SocId = Guid.Parse(Solicitud.Result.FirstOrDefault().SOC_ID.ToString());
                            validaDto.idError = 0;
                            validaDto.IdPantalla = 4; //FormularioCliente.aspx
                        }
                    }
                }
                else
                {
                    validaDto.idError = 1;
                    validaDto.DescripcionError = "No se realizo la actualizacion de datos codigo OTP";
                    validaDto.IdPantalla = 1; //Error no actualizoValidacionOTP
                }
            }
            return new Response<ValidacionIdentidadDto> { Data = validaDto };
        }


        /// <summary>
        /// Metodo para Reenviar codigo OTP
        /// /// <param name="validaDto"></param>
        /// </summary>
        public async Task<Response<ValidacionIdentidadDto>> ReenvioCodigoOtp(ValidacionIdentidadDto validaDto)
        {
            RequestTuDto request = new RequestTuDto
            {
                usrId = _usuarioIDVision,
                pasword = _claveIDVision,
                solucionId = _solucionId,
                RecentPhoneNumber = validaDto.NumeroCelular,
                IdValidation = validaDto.Id.ToString(),
                idAplication = validaDto.IdAplicacion,
            };

            var respuestaOTP = await _gestorIdVision.reEnvioCodigoOTP(request);
            if (respuestaOTP.codigoError == 0)
            {
                var respuestaOTP1 = await _gestorIdVision.EnvioCodigoOTP(request);
                validaDto.Delay = respuestaOTP1.delayOtp.Trim();
            }
            else
            {
                validaDto.idError = 1;
                validaDto.DescripcionError = respuestaOTP.detalleError;
            }

            return new Response<ValidacionIdentidadDto> { Data = validaDto };
        }


        /// <summary>
        /// Metodo para la obtencion de datos Personales del Usuario Mediante número de cedula. El metodo se reutiliza en el metodo local
        /// CreateValidacionIdentidad y tambien se llama desde el EndPoint Obtener datos personales
        /// Recibe como parametro un string
        /// /// <param name="numeroDocumento"></param>
        /// </summary>
        public async Task<SimulacionDatosPersonalesDto> ObtenerDatosPersonalesAsync(string numeroDocumento)
        {
            return this._mapper.Map<SimulacionDatosPersonalesDto>(await this._validaRepository.ObtenerDatosPersonalesAsync(numeroDocumento));
        }


        /// <summary>
        /// Metodo para la obtencion de datos financieros del Usuario Mediante número de cedula.
        /// Recibe como parametro un string
        /// /// <param name="numeroDocumento"></param>
        /// </summary>
        public async Task<SimulacionDatosFinancierosDto> ObtenerDatosFinancierosAsync(string numeroDocumento)
        {
            return this._mapper.Map<SimulacionDatosFinancierosDto>(await this._validaRepository.ObtenerDatosFinancierosAsync(numeroDocumento));
        }

        /// <summary>
        /// Metodo para seleccionar tipo de Credito - Credito Hipotecario, Leasing Habitacional
        /// Recibe como parametro un int
        /// /// <param name="tipoCredito"></param>
        /// </summary>
        public async Task<Response<ValidacionIdentidadDto>> SeleccionarTipoCredito(ValidacionIdentidadDto tipoCredito)
        {
            if (tipoCredito.TcrId == 1)
            {
                //Ingreso pantalla Credito Hipotecario
                tipoCredito.IdPantalla = 1;
            }
            else if (tipoCredito.TcrId == 2)
            {
                //Ingreso pantalla Leasing Habitacional
                tipoCredito.IdPantalla = 1;
            }
            await Task.CompletedTask;
            return new Response<ValidacionIdentidadDto> { Data = tipoCredito };
        }

        /// <summary>
        /// Metodo para crear una solicitud de simulación y sus datos personales
        /// Recibe como parametro un objeto de la clase SimulacionDatosPersonalesDto
        /// /// <param name="datosPersonales"></param>
        /// </summary>
        public async Task<Response<SimulacionDatosPersonalesDto>> CrearSimulacionDatosPersonales(SimulacionDatosPersonalesDto datosPersonales)
        {
            
            SimulacionDatosPersonalesDto objResponse = null;

            if (datosPersonales.IdSimulacion == null || datosPersonales.IdSimulacion== Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                datosPersonales.IdSimulacion = Guid.NewGuid(); 
            }
            if (datosPersonales.Id == null || datosPersonales.Id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                datosPersonales.Id = Guid.NewGuid(); 
            }
            SimulacionDatosPersonalesDto datosFromDb = new();
            try
            {
                datosFromDb = await ObtenerDatosPersonalesAsync(datosPersonales.NumeroDocumento);
                if (datosFromDb == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                var datosFromBua = (await _requestPovider.ObtenerClientePorTipoIdentificationYNumero(1, datosPersonales.NumeroDocumento)).Data;
                var tipoAfiliacion = await _catalogosRepository.ObtenerTiposAfiliacion();
                var fuerzas = await _catalogosRepository.ObtenerFuerzas();
                var categorias = await _catalogosRepository.ObtenerCategorias();
                var grados = await _catalogosRepository.ObtenerGrados();
                var ciudades = await _catalogosRepository.ObtenerCiudades();
                var departamentos = await _catalogosRepository.ObtenerDepartamentos();
                var tiposVivienda = await _catalogosRepository.ObtenerTipoVivienda();
                var unidadesEjecutoras= await _catalogosRepository.ObtenerUnidadesEjecutoras();
                var age = DateTime.Now.Year - datosFromBua.FechaNacimiento.Year;
                var cuotasAportadas = 0;
                if (datosFromBua.Cuentas.Count() > 0) {
                    foreach (var cuenta in datosFromBua.Cuentas)
                    {
                        cuotasAportadas += cuenta.Cuotas;
                    }
                }
                datosFromDb = new SimulacionDatosPersonalesDto
                {
                    Id = datosPersonales.Id,
                    IdSimulacion = datosPersonales.IdSimulacion,
                    FrzId = datosFromBua.IdFuerza,
                    CrgId = datosFromBua.IdCategoria,
                    GrdId = datosFromBua.IdGrado,
                    NumeroDocumento = datosFromBua.Identificacion,
                    NombresApellidos = $"{datosFromBua.PrimerNombre} {datosFromBua.SegundoNombre} {datosFromBua.PrimerApellido} {datosFromBua.SegundoApellido}".Replace("  "," "),
                    Edad = datosFromBua.FechaNacimiento > DateTime.Now.AddYears(-age) ? age-- : age,
                    FechaAfiliacion = datosFromBua.FechaAlta,
                    DpcId = datosFromBua.IdCiudadResidencia,
                    DpdId = datosFromBua.IdDepartamentoResidencia,
                    Direccion = datosFromBua.Direccion,
                    TelefonoCelular = datosFromBua.Telefono,
                    TelefonoFijo = datosFromBua.Telefono,
                    EMail = datosFromBua.Correo,
                    Cuotas = cuotasAportadas,
                    Regimen = datosFromBua.Regimen.ToString(),
                    ValorInmueble = 0,
                    TvvId = 0,
                    TipoAfiliado = tipoAfiliacion.FirstOrDefault(a => a.TPF_ID == datosFromBua.IdTipoActor).TPF_DESCRIPCION,
                    UsuarioActualiza = Guid.NewGuid(),
                    FechaActualiza = DateTime.Now,
                    TipoAfiliadoId=datosFromBua.IdTipoActor,
                    Fuerza=fuerzas.FirstOrDefault(f=>f.FRZ_ID==datosFromBua.IdFuerza).FRZ_DESCRIPCION,
                    CiudadResidencia=ciudades.FirstOrDefault(c=>c.DPC_ID==datosFromBua.IdCiudadResidencia).DPC_NOMBRE,
                    DepartamentoResidencia=departamentos.FirstOrDefault(d=>d.DPD_ID==datosFromBua.IdDepartamentoResidencia).DPD_NOMBRE,
                    Categoria=categorias.FirstOrDefault(c=>c.CTG_ID==datosFromBua.IdCategoria).CTG_DESCRIPCION,
                    Grado=grados.FirstOrDefault(g=>g.GRD_ID==datosFromBua.IdGrado).GRD_DESCRIPCION,
                    UnidadEjecutora=unidadesEjecutoras.FirstOrDefault(uej=>uej.UEJ_ID==datosFromBua.IdUnidadEjecutora).UEJ_NOMBRE,
                    UejId=datosFromBua.IdUnidadEjecutora,

                };
                datosPersonales = datosFromDb;
            }
            try
            {
                objResponse = _mapper.Map<SimulacionDatosPersonalesDto>(await this._validaRepository.CrearSimulacionDP(this._mapper.Map<SimulacionDatosPersonales>(datosPersonales)));

                return new Response<SimulacionDatosPersonalesDto>
                {
                    Data = objResponse
                };
            }
            catch (Exception ex)
            {
                objResponse = new SimulacionDatosPersonalesDto
                {
                };
            }

            return new Response<SimulacionDatosPersonalesDto>
            {
                Data = objResponse
            };
        }

        /// <summary>
        /// Metodo para crear los datos financieros de la simulacion
        /// Recibe como parametro un objeto de la clase SimulacionDatosFinancierosDto
        /// /// <param name="datosPersonales"></param>
        /// </summary>
        public async Task<Response<SimulacionDatosFinancierosDto>> CrearSimulacionDatosFinancieros(SimulacionDatosFinancierosDto datosFinancieros)
        {
            SimulacionDatosFinancieros simulacionDatosFinancierosDto=new();

            if (datosFinancieros.IdSimulacion == default(Guid))
            {
                datosFinancieros.IdSimulacion = Guid.NewGuid();
            }
            if (datosFinancieros.Id == default(Guid))
            {
                datosFinancieros.Id = Guid.NewGuid(); ;
            }
            try
            {
                simulacionDatosFinancierosDto = await this._validaRepository.CrearSimulacionDF(this._mapper.Map<SimulacionDatosFinancieros>(datosFinancieros));

                return new Response<SimulacionDatosFinancierosDto>
                {
                    Data = this._mapper.Map<SimulacionDatosFinancierosDto>(simulacionDatosFinancierosDto)
                };
            }
            catch (Exception ex)
            {
                return new Response<SimulacionDatosFinancierosDto>
                {
                    ReturnMessage = "Error al cargar datos financieros"
                };
            }

            
        }
        /// <summary>
        /// Metodo para la obtencion deparametros del Simulador.
        /// </summary>
        public async Task<Response<ParametrosSimuladorDto>> ObtenerParametrosSimuladorAsync()
        {
            var parametros = this._mapper.Map<ParametrosSimuladorDto>(await this._validaRepository.ObtenerParametrosSimulador());
            return new Response<ParametrosSimuladorDto> { Data = parametros };
        }
        /// <summary>
        /// Validacion del Score del Cliente en el Buro
        /// </summary>
        /// <param name="validaDto"></param>
        /// <returns></returns>
        public async Task<Response<ValidacionIdentidadDto>> ValidacionScoreCliente(ValidacionIdentidadDto validaDto)
        {
            var validacion = this._mapper.Map<ValidacionIdentidad>(validaDto);
            string apellido = "";
            decimal valorMaximoCuota = 0;
            bool paso = true;
            decimal valorCuotaLey = 0;
            string decision = "N/D";
            decimal porcentajeEndeudamiento = 0;
            decimal porcentajeEndeudamientoCuota = 0;
            decimal capacidadEndeudamientoBuro = 0;
            decimal scoreBuro = 0;
            var datosPersonales = await ObtenerDatosPersonalesAsync(validacion.VLI_NUMERO_DOCUMENTO);
            if (datosPersonales == null)
                apellido = "NA";
            else
                apellido = datosPersonales.NombresApellidos.ToString().Split(' ')[2].Trim();
            var datosFinan = await ObtenerDatosFinancierosAsync(validacion.VLI_NUMERO_DOCUMENTO);
            var parametros = await ObtenerParametrosSimuladorAsync();

            RequestTuDto request = new RequestTuDto
            {
                usrId = _usuarioAqm,
                pasword = _claveAqm,
                solucionId = _solucionIdAqm,
                LastName = apellido,
                IdExpeditionDate = validacion.VLI_FECHA_EXPEDICION.ToString("dd/MM/yyyy"),
                IdNumber = validacion.VLI_NUMERO_DOCUMENTO,
                IdType = validacion.TID_ID,
                RecentPhoneNumber = validacion.VLI_NUMERO_CELULAR,
                IdValidation = validacion.VLI_ID.ToString(),
                ocupacion = "EMPLEADO",
                sueldo = datosFinan.ValorTotalIngresos.ToString()
            };
            var respuesta = await _gestorIdVision.obtenerScoreCliente(request);
            if (respuesta.Data.codigoRechazo == 0)
            {
                decision = respuesta.Data.decision;
                if (respuesta.Data.decision == "VIABLE" || respuesta.Data.decision == "PENDIENTE")
                {
                    scoreBuro = Convert.ToInt32(respuesta.Data.score);
                    if (scoreBuro > parametros.Data.ScoreMinimo)
                    {
                        porcentajeEndeudamiento = respuesta.Data.porcentajeEndeudamiento;
                        capacidadEndeudamientoBuro = respuesta.Data.capacidadEndeudamiento;
                        valorCuotaLey = (Convert.ToDecimal(datosFinan.ValorTotalIngresos) * (parametros.Data.PorcLeyVivienda / 100));
                        porcentajeEndeudamientoCuota = Math.Round((valorCuotaLey - Convert.ToDecimal(datosFinan.ValorTotalEgresos) + capacidadEndeudamientoBuro * 100) / Convert.ToDecimal(datosFinan.ValorTotalIngresos), 2);
                        if (capacidadEndeudamientoBuro < valorCuotaLey - Convert.ToDecimal(datosFinan.ValorTotalIngresos))
                        {
                            paso = false;
                            valorMaximoCuota = capacidadEndeudamientoBuro;
                        }
                        else
                            valorMaximoCuota = valorCuotaLey - Convert.ToDecimal(datosFinan.ValorTotalEgresos);
                        if (!paso)
                        {
                            validaDto.DescripcionError = "La cuota maxima que se puede aprobar es " + valorMaximoCuota.ToString("###,###,###,###,##0");
                            validaDto.idError = 1;
                        }
                    }
                    else
                    {
                        validaDto.DescripcionError = "Lamentamos informarle que su solicitud ha sido rechazada por políticas internas";
                        validaDto.idError = 1;
                    }
                }
                else
                {
                    validaDto.DescripcionError = "Lamentamos informarle que su solicitud ha sido rechazada por políticas internas";
                    validaDto.idError = 1;
                }
            }
            else
            {
                validaDto.DescripcionError = respuesta.Data.detalleRechazo + " " + respuesta.Data.detalleError;
                validaDto.idError = 1;
            }
            /// Creo el Registro
            ConsultaBuroCliente consultaBuroCliente = new ConsultaBuroCliente
            {
                CBC_ID = Guid.NewGuid(),
                CBC_FECHA_CONSULTA = DateTime.Now,
                CLI_IDENTIFICACION = validaDto.NumeroDocumento,
                CBC_DECISION_BURO = decision,
                CBC_SCORE = scoreBuro.ToString(),
                CBC_CAPACIDAD_ENDEUDAMIENTO = capacidadEndeudamientoBuro,
                CBC_NIVEL_ENDEUDAMIENTO = Math.Round(porcentajeEndeudamiento, 2),
                CBC_NIVEL_ENDEUDAMIENTO_CUOTA = porcentajeEndeudamientoCuota,
                CBC_HISTORIAL_CREDITO = "",
                CBC_HUELLA_CONSULTA = "",
                CBC_CREADO_POR = Guid.NewGuid(),
                CBC_FECHA_CREACION = DateTime.Now
            };
            var consilta = await this._validaRepository.CrearConsultaBuro(consultaBuroCliente);
            return new Response<ValidacionIdentidadDto> { Data = validaDto };
        }

        #region "Validar"
        public async Task<Response<ValidacionIdentidadDto>> GetByIdValidacionIdentidad(Guid id)
        {
            return new Response<ValidacionIdentidadDto> { Data = this._mapper.Map<ValidacionIdentidadDto>(await this._validaRepository.GetByIdSolicitudSimulacion(id)) };
        }
        public async Task<Response<ValidacionIdentidadDto>> GetByDocumentoValidacionIdentidad(string numeroDocumento)
        {
            return new Response<ValidacionIdentidadDto> { Data = this._mapper.Map<ValidacionIdentidadDto>(await this._validaRepository.GetByDocumentoSolicitudSimulacion(numeroDocumento)) };
        }

        public Task<Response<string>> ObtenerOtpCliente(string request)
        {
            var digits = 4;
            var otp = string.Empty;
            var rGuid = Guid.NewGuid().ToString().ToArray();
            while (otp.Length < digits - 1)
            {
                foreach (var value in rGuid)
                {
                    int result = 0;
                    if (int.TryParse(value.ToString(), out result))
                    {
                        otp += value;
                    }
                    if (otp.Length == digits)
                        break;
                }
            }


            return Task.FromResult(new Response<string> { Data = otp });
        }


        #endregion
    }
}


/// <summary>
/// Actualizacion de datos codigo OTP
/// Recibe como parametro un objeto de la clase ValidacionIdentidadDto // Codigo Original
/// /// <param name="validaDto"></param>
/// </summary>
//public async Task<Response<ValidacionIdentidadDto>> ActualizarValidacionOTP(ValidacionIdentidadDto validaDto)
//{
//    RequestTu request = new RequestTu
//    {
//        usrId = _usuarioIDVision,
//        pasword = _claveIDVision,
//        solucionId = _solucionId,
//        RecentPhoneNumber = validaDto.NumeroCelular,
//        IdValidation = validaDto.Id.ToString(),
//        idAplication = validaDto.IdAplicacion,
//        codeOTP = validaDto.CodigoOtp
//    };

//    var responseTU = await _gestorIdVision.validacionCodigoOTPAsync(request);
//    if (responseTU.codigoError == 1)
//    {
//        validaDto.idError = 1;
//        validaDto.DescripcionError = responseTU.detalleRechazo.Trim();
//        validaDto.IdPantalla = 0;
//    }
//    else
//    {
//        var identidad = this._mapper.Map<ValidacionIdentidad>(validaDto);

//        identidad.VLI_ID = Guid.Parse(validaDto.Id.ToString());
//        identidad.VLI_FECHA_VALIDA_OTP = DateTime.Now;
//        identidad.VLI_FECHA_VALIDA_IDEN = DateTime.Now;
//        identidad.VLI_CODIGO_OTP = validaDto.CodigoOtp;
//        identidad.VLI_PASO_VALIDACION = 0;

//        var ActValidacion = _validaRepository.ActualizarValidacionOTP(identidad);
//        var PreaProbado = _validaRepository.ConsultarPreAprobado(identidad.VLI_NUMERO_DOCUMENTO);
//        var Solicitud = _validaRepository.ConsultarSolicitudCredito(identidad.VLI_NUMERO_DOCUMENTO);

//        await Task.WhenAll(ActValidacion, PreaProbado, Solicitud);

//        if (ActValidacion.Result == 1)
//        {
//            if (PreaProbado.Result.Count <= 0 && Solicitud.Result.Count <= 0)
//            {
//                validaDto.idError = 0;
//                validaDto.IdPantalla = 2; //FormularioSolicitud.aspx
//            }
//            else
//            {
//                if (Solicitud.Result.Count <= 0)
//                {
//                    validaDto.IdSolicitud = Guid.Parse(PreaProbado.Result.FirstOrDefault().SLS_ID.ToString());
//                    validaDto.TcrId = PreaProbado.Result.FirstOrDefault().TCR_ID;
//                    validaDto.NumeroPreaprobado = PreaProbado.Result.FirstOrDefault().SLS_NUMERO_PREAPROBADO;
//                    validaDto.RutaPdfResumen = PreaProbado.Result.FirstOrDefault().SLS_RUTA_PDF_RESUMEN.ToString();

//                    validaDto.idError = 0;
//                    validaDto.IdPantalla = 3; //FormularioCredito.aspx
//                }
//                else
//                {
//                    validaDto.SocId = Guid.Parse(Solicitud.Result.FirstOrDefault().SOC_ID.ToString());
//                    validaDto.idError = 0;
//                    validaDto.IdPantalla = 4; //FormularioCliente.aspx
//                }
//            }
//        }
//        else
//        {
//            validaDto.idError = 1;
//            validaDto.DescripcionError = "No se realizo la actualizacion de datos codigo OTP";
//            validaDto.IdPantalla = 1; //Error no actualizoValidacionOTP
//        }
//    }
//    return new Response<ValidacionIdentidadDto> { Data = validaDto };
//}

///// <summary>