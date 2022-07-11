using AutoMapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Repositories;
using GA2.Transversals.Commons;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    public class GestorTransUnionBusinessLogic : IGestorTransUnionBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly ITransUnionRepository _transUnionRepository;

        public GestorTransUnionBusinessLogic(IMapper mapper, ITransUnionRepository transUnionRepository)
        {
            _mapper = mapper;
            _transUnionRepository = transUnionRepository;
        }

        public async Task<Response<VLL_VALIDACION_LOG_OTPDto>> CrearLogOTP(VLL_VALIDACION_LOG_OTPDto datosLog)
        {
            var registroLog = this._mapper.Map<VLL_VALIDACION_LOG_OTP>(datosLog);
            return new Response<VLL_VALIDACION_LOG_OTPDto> { Data = this._mapper.Map<VLL_VALIDACION_LOG_OTPDto>(await this._transUnionRepository.CrearLogOTP(registroLog)) };

        }

        //public async Task<Response<Guid>> CrearValidacion(VLI_VALIDACION_IDENTIDADDto valida)
        //{
        //    var actualiza = this._mapper.Map<VLI_VALIDACION_IDENTIDAD>(valida);

        //    return new Response<Guid> { Data = this._mapper.Map<Guid>(await this._transUnionRepository.CrearValidacion(actualiza)) };
        //}

        //public async Task<Response<int>> ActualizarOtpValidacion(VLI_VALIDACION_IDENTIDADDto valida)
        //{
        //    var actualiza = this._mapper.Map<VLI_VALIDACION_IDENTIDAD>(valida);

        //    return new Response<int> { Data = this._mapper.Map<int>(await this._transUnionRepository.ActualizarOtpValidacion(actualiza)) };
        //}


        public async Task<Response<SolicitudCreditoProductoDto>> CrearLogTu(SolicitudCreditoProductoDto datosLog)
        {
            var registroLog = this._mapper.Map<SolicitudCreditoProductoGral>(datosLog);

            return new Response<SolicitudCreditoProductoDto> { Data = this._mapper.Map<SolicitudCreditoProductoDto>(await this._transUnionRepository.CrearLogTu(registroLog)) };
        }

        public async Task<Response<SolicitudCreditoProductoDto>> RegistroLogTU(SolicitudCreditoProductoDto datosLog)
        {
            var registroLog = this._mapper.Map<SolicitudCreditoProductoGral>(datosLog);
            return new Response<SolicitudCreditoProductoDto> { Data = this._mapper.Map<SolicitudCreditoProductoDto>(await this._transUnionRepository.RegistroLogTU(registroLog)) };
        }






















        //public async Task<Response<Guid>> CrearValidacion(VLI_VALIDACION_IDENTIDADDto valida)
        //{
        //    var actualiza = this._mapper.Map<VLI_VALIDACION_IDENTIDAD>(valida);

        //    return new Response<Guid> { Data = this._mapper.Map<Guid>(await this._transUnionRepository.CrearValidacion(actualiza)) };
        //}

        //public async Task<Response<int>> ActualizarOtpValidacion(VLI_VALIDACION_IDENTIDADDto valida)
        //{
        //    var actualiza = this._mapper.Map<VLI_VALIDACION_IDENTIDAD>(valida);

        //    return new Response<int> { Data = this._mapper.Map<int>(await this._transUnionRepository.ActualizarOtpValidacion(actualiza)) };
        //}


        //        public Guid CrearSolicitud(SLS_SOLICITUD_SIMULACION solicitud, SDP_SIMULACION_DATOS_PERSONALES datos, ref string Error)
        //        {
        //            try
        //            {
        //                var objeto = new
        //                {
        //                    SLS_ID = solicitud.SLS_ID,
        //                    SDP_ID = datos.SDP_ID,
        //                    TCR_ID = solicitud.TCR_ID,
        //                    SLS_FECHA_SOLICITUD = solicitud.SLS_FECHA_SOLICITUD,
        //                    FRZ_ID = datos.FRZ_ID,
        //                    CTG_ID = datos.CTG_ID,
        //                    GRD_ID = datos.GRD_ID,
        //                    SDP_NUMERO_DOCUMENTO = datos.SDP_NUMERO_DOCUMENTO,
        //                    SDP_NOMBRES_APELLIDOS = datos.SDP_NOMBRES_APELLIDOS,
        //                    SDP_EDAD = datos.SDP_EDAD,
        //                    SDP_FECHA_AFILIACION = datos.SDP_FECHA_AFILIACION,
        //                    DPD_ID = datos.DPD_ID,
        //                    DPC_ID = datos.DPC_ID,
        //                    SDP_DIRECCION = datos.SDP_DIRECCION,
        //                    SDP_TELEFONO_FIJO = datos.SDP_TELEFONO_FIJO,
        //                    SDP_TELEFONO_CELULAR = datos.SDP_TELEFONO_CELULAR,
        //                    SDP_E_MAIL = datos.SDP_E_MAIL,
        //                    SDP_CUOTAS = datos.SDP_CUOTAS,
        //                    SDP_REGIMEN = datos.SDP_REGIMEN,
        //                    SDP_VALOR_INMUEBLE = datos.SDP_VALOR_INMUEBLE,
        //                    TVV_ID = datos.TVV_ID,
        //                    DPD_ID_INMUEBLE = datos.DPD_ID_INMUEBLE,
        //                    DPC_ID_INMUEBLE = datos.DPC_ID_INMUEBLE,
        //                    SLS_USUARIO_ACTUALIZA = Guid.NewGuid(),
        //                    SLS_FECHA_ACTUALIZA = DateTime.Now
        //                };
        //                Actualizacion actualiza = new Actualizacion();
        //                var retorno = actualiza.EjecutarQuery<SDP_SIMULACION_DATOS_PERSONALES>("CrearSolicitudSimulacion", objeto, CommandType.StoredProcedure, ref Error);
        //                return retorno.FirstOrDefault().SLS_ID;
        //            }
        //            catch (Exception ex)
        //            {
        //                Error = "Error Creando la Solicitud. " + ex.Message.ToString();
        //                return Guid.NewGuid();
        //            }
        //        }
        //        public Guid CrearDatosFinancierosSolicitud(SDF_SIMULACION_DATOS_FINANCIEROS datos, ref string Error)
        //        {
        //            try
        //            {
        //                var objeto = new
        //                {
        //                    SDF_ID = datos.SDF_ID,
        //                    SLS_ID = datos.SLS_ID,
        //                    SDF_VALOR_SALARIO = datos.SDF_VALOR_SALARIO,
        //                    SDF_VALOR_OTROS_INGRESOS = datos.SDF_VALOR_OTROS_INGRESOS,
        //                    SDF_VALOR_OTROS_INGRESOS1 = datos.SDF_VALOR_OTROS_INGRESOS1,
        //                    SDF_VALOR_OTROS_INGRESOS2 = datos.SDF_VALOR_OTROS_INGRESOS2,
        //                    SDF_VALOR_OTROS_INGRESOS3 = datos.SDF_VALOR_OTROS_INGRESOS3,
        //                    SDF_VALOR_OTROS_INGRESOS4 = datos.SDF_VALOR_OTROS_INGRESOS4,
        //                    SDF_DESCRIPCION_SALARIO = datos.SDF_DESCRIPCION_SALARIO,
        //                    SDF_DESCRIPCION_OTRO_INGRESOS = datos.SDF_DESCRIPCION_OTRO_INGRESOS,
        //                    SDF_DESCRIPCION_OTRO_ING1 = datos.SDF_DESCRIPCION_OTRO_ING1,
        //                    SDF_DESCRIPCION_OTRO_ING2 = datos.SDF_DESCRIPCION_OTRO_ING2,
        //                    SDF_DESCRIPCION_OTRO_ING3 = datos.SDF_DESCRIPCION_OTRO_ING3,
        //                    SDF_DESCRIPCION_OTRO_ING4 = datos.SDF_DESCRIPCION_OTRO_ING4,
        //                    SDF_VALOR_TOTAL_INGRESOS = datos.SDF_VALOR_TOTAL_INGRESOS,
        //                    SDF_VALOR_TOTAL_EGRESOS = datos.SDF_VALOR_TOTAL_EGRESOS,
        //                    SDF_USUARIO_ACTUALIZA = Guid.NewGuid(),
        //                    SDF_FECHA_ACTUALIZA = DateTime.Now
        //                };
        //                Actualizacion actualiza = new Actualizacion();
        //                var retorno = actualiza.EjecutarQuery<SDF_SIMULACION_DATOS_FINANCIEROS>("CrearSimulacionFinan", objeto, CommandType.StoredProcedure, ref Error);
        //                return retorno.FirstOrDefault().SLS_ID;
        //            }
        //            catch (Exception ex)
        //            {
        //                Error = "Error Creando Datos Financieros de la Solicitud. " + ex.Message.ToString();
        //                return Guid.NewGuid();
        //            }
        //        }
        //        
        //        
        //        public Guid CrearSolicitudCredito(SOC_SOLICITUD_CREDITO solicitud, SOP_SOLICITUD_PRODUCTO producto, ref string Error)
        //        {
        //            try
        //            {
        //                var objeto = new
        //                {
        //                    SOC_ID = solicitud.SOC_ID,
        //                    SOC_FECHA_SOLICITUD = solicitud.SOC_FECHA_SOLICITUD,
        //                    SOC_NUMERO_SOLICITUD = 0,
        //                    TCR_ID = solicitud.TCR_ID,
        //                    DPD_ID = solicitud.DPD_ID,
        //                    DPC_ID = solicitud.DPC_ID,
        //                    SLS_ID = solicitud.SLS_ID,
        //                    TID_ID = solicitud.TID_ID,
        //                    CLI_IDENTIFICACION = solicitud.CLI_IDENTIFICACION,
        //                    SOC_DECLARACION_ORIGEN_FONDOS = solicitud.SOC_DECLARACION_ORIGEN_FONDOS,
        //                    SOC_AUTORIZA_USO_DATOS = solicitud.SOC_AUTORIZA_USO_DATOS,
        //                    SOC_AUTORIZA_CONSULTA_CENTRALES = solicitud.SOC_AUTORIZA_CONSULTA_CENTRALES,
        //                    SOC_DECLARACION_ASEGURABILIDAD = solicitud.SOC_DECLARACION_ASEGURABILIDAD,
        //                    SOC_ESTADO = solicitud.SOC_ESTADO,
        //                    SOC_CREADO_POR = solicitud.SOC_CREADO_POR,
        //                    SOC_FECHA_CREACION = solicitud.SOC_FECHA_CREACION,
        //                    SOP_ID = producto.SOP_ID,
        //                    SOP_ESTADO_INMUEBLE = producto.SOP_ESTADO_INMUEBLE,
        //                    SOP_TIPO_INMUEBLE = producto.SOP_TIPO_INMUEBLE,
        //                    SOP_TIENE_GARAJE = producto.SOP_TIENE_GARAJE,
        //                    SOP_TIENE_DEPOSITO = producto.SOP_TIENE_DEPOSITO,
        //                    SOP_CONJUNTO_CERRADO = producto.SOP_CONJUNTO_CERRADO,
        //                    TVV_ID = producto.TVV_ID,
        //                    SOP_AÑOS_CONSTRUCCION = producto.SOP_AÑOS_CONSTRUCCION,
        //                    SOP_MATRICULA_INMOBILIARIA1 = producto.SOP_MATRICULA_INMOBILIARIA1,
        //                    SOP_MATRICULA_INMOBILIARIA2 = producto.SOP_MATRICULA_INMOBILIARIA2,
        //                    SOP_MATRICULA_INMOBILIARIA3 = producto.SOP_MATRICULA_INMOBILIARIA3,
        //                    SOP_VALOR_INMUEBLE = producto.SOP_VALOR_INMUEBLE,
        //                    SOP_DIRECCION_INMUEBLE = producto.SOP_DIRECCION_INMUEBLE,
        //                    DPD_ID_INMUEBLE = producto.DPD_ID,
        //                    DPC_ID_INMUEBLE = producto.DPC_ID,
        //                    SOP_VALOR_CREDITO = producto.SOP_VALOR_CREDITO,
        //                    SOP_PORC_FINANCIACION = producto.SOP_PORC_FINANCIACION,
        //                    SOP_PLAZO_FINANCIACION = producto.SOP_PLAZO_FINANCIACION,
        //                    TID_ID_CONS = producto.TID_ID,
        //                    SOP_NUMERO_DOCUMENTO_CONSTRUCTOR = producto.SOP_NUMERO_DOCUMENTO_CONSTRUCTOR,
        //                    SOP_NOMBRE_CONSTRUCTOR = producto.SOP_NOMBRE_CONSTRUCTOR,
        //                    SOP_FECHA_ENTREGA_INMUEBLE = producto.SOP_FECHA_ENTREGA_INMUEBLE,
        //                    SOP_NOMBRE_FIDUCIA = producto.SOP_NOMBRE_FIDUCIA,
        //                    SOP_NOMBRE_PROYECTO = producto.SOP_NOMBRE_PROYECTO
        //                };
        //                Actualizacion actualiza = new Actualizacion();
        //                var retorno = actualiza.EjecutarQuery<SOC_SOLICITUD_CREDITO>("CrearSolicitudCredito", objeto, CommandType.StoredProcedure, ref Error);
        //                return retorno.FirstOrDefault().SOC_ID;
        //            }
        //            catch (Exception ex)
        //            {
        //                Error = "Error Creando Datos de la Solicitud. " + ex.Message.ToString();
        //                return Guid.NewGuid();
        //            }
        //        }
        //        public Guid CrearSolicCreditoBasicos(SOB_SOLICITUD_INF_BASICA basica, ref string Error)
        //        {
        //            try
        //            {
        //                var objeto = new
        //                {
        //                    SOB_ID = basica.SOB_ID,
        //                    SOC_ID = basica.SOC_ID,
        //                    TID_ID = basica.TID_ID,
        //                    SOB_NUMERO_DOCUMENTO = basica.SOB_NUMERO_DOCUMENTO,
        //                    SOB_FECHA_EXPEDICION = basica.SOB_FECHA_EXPEDICION,
        //                    DPD_ID_EXP = basica.DPD_ID_EXP,
        //                    DPC_ID_EXP = basica.DPC_ID_EXP,
        //                    SOB_PRIMER_APELLIDO = basica.SOB_PRIMER_APELLIDO,
        //                    SOB_SEGUNDO_APELLIDO = basica.SOB_SEGUNDO_APELLIDO,
        //                    SOB_PRIMER_NOMBRE = basica.SOB_PRIMER_NOMBRE,
        //                    SOB_SEGUNDO_NOMBRE = basica.SOB_SEGUNDO_NOMBRE,
        //                    SOB_FECHA_NACIMIENTO = basica.SOB_FECHA_NACIMIENTO,
        //                    DPD_ID_NACIMIENTO = basica.DPD_ID_NACIMIENTO,
        //                    DPC_ID_NACIMIENTO = basica.DPC_ID_NACIMIENTO,
        //                    SOB_SEXO = basica.SOB_SEXO,
        //                    SOB_ESTADO_CIVIL = basica.SOB_ESTADO_CIVIL,
        //                    SOB_NIVEL_EDUCACION = basica.SOB_NIVEL_EDUCACION,
        //                    FRZ_ID = basica.FRZ_ID,
        //                    CTG_ID = basica.CTG_ID,
        //                    GRD_ID = basica.GRD_ID,
        //                    DPD_ID_RESIDENCIA = basica.DPD_ID_RESIDENCIA,
        //                    DPC_ID_RESIDENCIA = basica.DPC_ID_RESIDENCIA,
        //                    SOB_DIRECCION_RESIDENCIA = basica.SOB_DIRECCION_RESIDENCIA,
        //                    SOB_CORREO_PERSONAL = basica.SOB_CORREO_PERSONAL,
        //                    SOB_TELEFONO_RESIDENCIA = basica.SOB_TELEFONO_RESIDENCIA,
        //                    SOB_CELULAR = basica.SOB_CELULAR,
        //                    DPD_ID_OFICINA = basica.DPD_ID_OFICINA,
        //                    DPC_ID_OFICINA = basica.DPC_ID_OFICINA,
        //                    SOB_DIRECCION_OFICINA = basica.SOB_DIRECCION_OFICINA,
        //                    SOB_CORREO_INSTITUCIONAL = basica.SOB_CORREO_INSTITUCIONAL,
        //                    SOB_TELEFONO_OFICINA = basica.SOB_TELEFONO_OFICINA,
        //                    ACC_ID = basica.ACC_ID,
        //                    PRF_ID = basica.PRF_ID,
        //                    SOB_CREADO_POR = basica.SOB_CREADO_POR,
        //                    SOB_FECHA_CREACION = basica.SOB_FECHA_CREACION
        //                };
        //                Actualizacion actualiza = new Actualizacion();
        //                var retorno = actualiza.EjecutarQuery<SOB_SOLICITUD_INF_BASICA>("CrearSolicCreditoBasicos", objeto, CommandType.StoredProcedure, ref Error);
        //                return retorno.FirstOrDefault().SOC_ID;
        //            }
        //            catch (Exception ex)
        //            {
        //                Error = "Error Creando Datos de la Solicitud. " + ex.Message.ToString();
        //                return Guid.NewGuid();
        //            }
        //        }
        //        public Guid CrearSolicCreditoInformacion(SOY_SOLICITUD_INF_CONYUGUE conyugue, SOP_SOLICITUD_PRODUCTO producto, ref string Error)
        //        {
        //            try
        //            {
        //                var objeto = new
        //                {
        //                    SOY_ID = conyugue.SOY_ID,
        //                    SOC_ID = conyugue.SOC_ID,
        //                    TID_ID = conyugue.TID_ID,
        //                    SOY_NUMERO_DOCUMENTO = conyugue.SOY_NUMERO_DOCUMENTO,
        //                    SOY_FECHA_EXPEDICION = conyugue.SOY_FECHA_EXPEDICION,
        //                    DPD_ID_EXP = conyugue.DPD_ID_EXP,
        //                    DPC_ID_EXP = conyugue.DPC_ID_EXP,
        //                    SOY_PRIMER_APELLIDO = conyugue.SOY_PRIMER_APELLIDO,
        //                    SOY_SEGUNDO_APELLIDO = conyugue.SOY_SEGUNDO_APELLIDO,
        //                    SOY_PRIMER_NOMBRE = conyugue.SOY_PRIMER_NOMBRE,
        //                    SOY_SEGUNDO_NOMBRE = conyugue.SOY_SEGUNDO_NOMBRE,
        //                    SOY_FECHA_NACIMIENTO = conyugue.SOY_FECHA_NACIMIENTO,
        //                    DPD_ID_NACIMIENTO = conyugue.DPD_ID_NACIMIENTO,
        //                    DPC_ID_NACIMIENTO = conyugue.DPC_ID_NACIMIENTO,
        //                    SOY_CELULAR = conyugue.SOY_CELULAR,
        //                    SOY_CORREO_PERSONAL = conyugue.SOY_CORREO_PERSONAL,
        //                    SOY_ACTIVIDAD_LABORAL = conyugue.SOY_ACTIVIDAD_LABORAL,
        //                    SOY_OTRO_ACTIVIDAD = conyugue.SOY_OTRO_ACTIVIDAD,
        //                    SOY_EMPRESA_LABORA = conyugue.SOY_EMPRESA_LABORA,
        //                    SOY_CREADO_POR = conyugue.SOY_CREADO_POR,
        //                    SOY_FECHA_CREACION = conyugue.SOY_FECHA_CREACION
        //                };
        //                Actualizacion actualiza = new Actualizacion();
        //                var retorno = actualiza.EjecutarQuery<SOY_SOLICITUD_INF_CONYUGUE>("CrearSolicCreditoConyugue", objeto, CommandType.StoredProcedure, ref Error);
        //                if (Error == "")
        //                {
        //                    if (producto.TID_ID_VENDEDOR != 0)
        //                    {
        //                        var objeto1 = new
        //                        {
        //                            SOP_ID = producto.SOP_ID,
        //                            SOC_ID = producto.SOC_ID,
        //                            TID_ID_VENDEDOR = producto.TID_ID_VENDEDOR,
        //                            SOP_NUMERO_DOCUMENTO_VENDEDOR = producto.SOP_NUMERO_DOCUMENTO_VENDEDOR,
        //                            SOP_NOMBRE_VENDEDOR = producto.SOP_NOMBRE_VENDEDOR,
        //                            SOP_DIRECCION_VENDEDOR = producto.SOP_DIRECCION_VENDEDOR,
        //                            DPD_ID_VENDEDOR = producto.DPD_ID_VENDEDOR,
        //                            DPC_ID_VENDEDOR = producto.DPC_ID_VENDEDOR,
        //                            SOP_CORREO_VENDEDOR = producto.SOP_CORREO_VENDEDOR,
        //                            SOP_TELEFONO_VENDEDOR = producto.SOP_TELEFONO_VENDEDOR,
        //                            SOP_ACTUALIZADO_POR = producto.SOP_ACTUALIZADO_POR,
        //                            SOP_FECHA_ACTUALIZA = producto.SOP_FECHA_ACTUALIZA
        //                        };
        //                        var retorno1 = actualiza.EjecutarQuery<SOP_SOLICITUD_PRODUCTO>("ActualizaSolicCreditoProducto", objeto1, CommandType.StoredProcedure, ref Error);
        //                    }
        //                }
        //                return retorno.FirstOrDefault().SOC_ID;
        //            }
        //            catch (Exception ex)
        //            {
        //                Error = "Error Creando Datos de la Solicitud. " + ex.Message.ToString();
        //                return Guid.NewGuid();
        //            }
        //        }
        //        public Guid CrearSolicCreditoFinanciera(SOF_SOLICITUD_INF_FINANCIERA financiero, SOB_SOLICITUD_INF_BASICA basica, ref string Error)
        //        {
        //            try
        //            {
        //                var objeto = new
        //                {
        //                    SOF_ID = financiero.SOF_ID,
        //                    SOC_ID = financiero.SOC_ID,
        //                    SOF_CONCEPTO_SALARIO = financiero.SOF_CONCEPTO_SALARIO,
        //                    SOF_VALOR_CONCEPTO_SALARIO = financiero.SOF_VALOR_CONCEPTO_SALARIO,
        //                    SOF_CONCEPTO_1 = financiero.SOF_CONCEPTO_1,
        //                    SOF_VALOR_CONCEPTO_1 = financiero.SOF_VALOR_CONCEPTO_1,
        //                    SOF_CONCEPTO_2 = financiero.SOF_CONCEPTO_2,
        //                    SOF_VALOR_CONCEPTO_2 = financiero.SOF_VALOR_CONCEPTO_2,
        //                    SOF_CONCEPTO_3 = financiero.SOF_CONCEPTO_3,
        //                    SOF_VALOR_CONCEPTO_3 = financiero.SOF_VALOR_CONCEPTO_3,
        //                    SOF_CONCEPTO_4 = financiero.SOF_CONCEPTO_4,
        //                    SOF_VALOR_CONCEPTO_4 = financiero.SOF_VALOR_CONCEPTO_4,
        //                    SOF_CONCEPTO_5 = financiero.SOF_CONCEPTO_5,
        //                    SOF_VALOR_CONCEPTO_5 = financiero.SOF_VALOR_CONCEPTO_5,
        //                    SOF_CONCEPTO_6 = financiero.SOF_CONCEPTO_6,
        //                    SOF_VALOR_CONCEPTO_6 = financiero.SOF_VALOR_CONCEPTO_6,
        //                    SOF_VALOR_TOTAL_INGRESOS = financiero.SOF_VALOR_TOTAL_INGRESOS,
        //                    SOF_VALOR_TOTAL_EGRESOS = financiero.SOF_VALOR_TOTAL_EGRESOS,
        //                    SOF_CREADO_POR = financiero.SOF_CREADO_POR,
        //                    SOF_FECHA_CREACION = financiero.SOF_FECHA_CREACION
        //                };
        //                Actualizacion actualiza = new Actualizacion();
        //                var retorno = actualiza.EjecutarQuery<SOF_SOLICITUD_INF_FINANCIERA>("CrearSolicCreditoFinancieros", objeto, CommandType.StoredProcedure, ref Error);
        //                if (Error == "")
        //                {
        //                    var objeto1 = new
        //                    {
        //                        SOB_ID = basica.SOB_ID,
        //                        SOC_ID = basica.SOC_ID,
        //                        SOB_TIENE_TRANSACCION_ME = basica.SOB_TIENE_TRANSACCION_ME,
        //                        SOB_TIPO_TRANSACCION_ME = basica.SOB_TIPO_TRANSACCION_ME,
        //                        SOB_TIPO_PRODUCTO_ME = basica.SOB_TIPO_PRODUCTO_ME,
        //                        SOB_BANCO_TRANSACCION_ME = basica.SOB_BANCO_TRANSACCION_ME,
        //                        SOB_NUMERO_PRODUCTO_ME = basica.SOB_NUMERO_PRODUCTO_ME,
        //                        SOB_SALDO_PROMEDIO_CUENTAS_ME = basica.SOB_SALDO_PROMEDIO_CUENTAS_ME,
        //                        DPP_ID_ME = basica.DPP_ID_ME,
        //                        DPD_ID_ME = basica.DPD_ID_ME,
        //                        SOB_ACTUALIZADO_POR = basica.SOB_ACTUALIZADO_POR,
        //                        SOB_FECHA_ACTUALIZA = basica.SOB_FECHA_ACTUALIZA
        //                    };
        //                    var retorno1 = actualiza.EjecutarQuery<SOP_SOLICITUD_PRODUCTO>("ActualizaSolicCreditoBasica", objeto1, CommandType.StoredProcedure, ref Error);
        //                }
        //                return retorno.FirstOrDefault().SOC_ID;
        //            }
        //            catch (Exception ex)
        //            {
        //                Error = "Error Creando Datos de la Solicitud. " + ex.Message.ToString();
        //                return Guid.NewGuid();
        //            }
        //        }
        //        public Guid CrearSolicCreditoReferencias(SOF_SOLICITUD_INF_FINANCIERA financiero, List<SOR_SOLICITUD_INF_REFERENCIAS> referencias, ref string Error)
        //        {
        //            try
        //            {
        //                Actualizacion actualiza = new Actualizacion();
        //                Guid idRetorno = financiero.SOC_ID;
        //                if (financiero.SOF_DIRECCION_VIVIENDA != null || financiero.SOF_MARCA_VEHICULO != null)
        //                {
        //                    var objeto = new
        //                    {
        //                        SOF_ID = financiero.SOF_ID,
        //                        SOC_ID = financiero.SOC_ID,
        //                        SOF_DIRECCION_VIVIENDA = financiero.SOF_DIRECCION_VIVIENDA,
        //                        SOF_MATRICULA_VIVIENDA = financiero.SOF_MATRICULA_VIVIENDA,
        //                        SOF_VALOR_COMERCIAL_VIVIENDA = financiero.SOF_VALOR_COMERCIAL_VIVIENDA,
        //                        SOF_MARCA_VEHICULO = financiero.SOF_MARCA_VEHICULO,
        //                        SOF_PLACA_VEHICULO = financiero.SOF_PLACA_VEHICULO,
        //                        SOF_VALOR_COMERCIAL_VEHICULO = financiero.SOF_VALOR_COMERCIAL_VEHICULO,
        //                        SOF_ACTUALIZADO_POR = financiero.SOF_ACTUALIZADO_POR,
        //                        SOF_FECHA_ACTUALIZA = financiero.SOF_FECHA_ACTUALIZA
        //                    };
        //                    var retorno = actualiza.EjecutarQuery<SOF_SOLICITUD_INF_FINANCIERA>("ActualizaSolicCreditoFinancieros", objeto, CommandType.StoredProcedure, ref Error);
        //                    idRetorno = retorno.FirstOrDefault().SOC_ID;
        //                }
        //                if (Error == "")
        //                {
        //                    foreach (SOR_SOLICITUD_INF_REFERENCIAS refer in referencias)
        //                    {
        //                        var objeto1 = new
        //                        {
        //                            SOR_ID = refer.SOR_ID,
        //                            SOC_ID = refer.SOC_ID,
        //                            SOR_TIPO_REFERENCIA = refer.SOR_TIPO_REFERENCIA,
        //                            SOR_PRIMER_APELLIDO = refer.SOR_PRIMER_APELLIDO,
        //                            SOR_SEGUNDO_APELLIDO = refer.SOR_SEGUNDO_APELLIDO,
        //                            SOR_NOMBRES = refer.SOR_NOMBRES,
        //                            SOR_PARENTESCO = refer.SOR_PARENTESCO,
        //                            SOR_RELACION = refer.SOR_RELACION,
        //                            SOR_DIRECCION = refer.SOR_DIRECCION,
        //                            DPD_ID = refer.DPD_ID,
        //                            DPC_ID = refer.DPC_ID,
        //                            SOR_TELEFONO = refer.SOR_TELEFONO,
        //                            SOR_CELULAR = refer.SOR_CELULAR,
        //                            SOR_CREADO_POR = refer.SOR_CREADO_POR,
        //                            SOR_FECHA_CREACION = refer.SOR_FECHA_CREACION
        //                        };
        //                        var retorno1 = actualiza.EjecutarQuery<SOP_SOLICITUD_PRODUCTO>("CrearSolicCreditoRefererncias", objeto1, CommandType.StoredProcedure, ref Error);
        //                    }
        //                }
        //                return idRetorno;
        //            }
        //            catch (Exception ex)
        //            {
        //                Error = "Error Creando Datos de la Solicitud. " + ex.Message.ToString();
        //                return Guid.NewGuid();
        //            }
        //        }
        //        public string CrearEnvioAlerta(ENA_ENVIO_ALERTAS envioAlerta)
        //        {
        //            try
        //            {
        //                string Error = "";
        //                /// Obtengo el Texto de la Alerta
        //                GestorConsultas consulta = new GestorConsultas();
        //                var alerta = consulta.ObtenerAlertaAutomatica(ref Error);
        //                if (Error == "")
        //                {
        //                    var objeto = new
        //                    {
        //                        ENA_ID = envioAlerta.ENA_ID,
        //                        ENA_DESTINATARIO = envioAlerta.ENA_DESTINATARIO,
        //                        ENA_ASUNTO = envioAlerta.ENA_ASUNTO,
        //                        ENA_TEXTO = alerta.FirstOrDefault().ALA_MENSAJE.Replace("&1&", envioAlerta.NOMBRE_CLIENTE),
        //                        ENA_RUTA_ADJUNTO = envioAlerta.ENA_RUTA_ADJUNTO,
        //                        ENA_ENVIADO = envioAlerta.ENA_ENVIADO,
        //                        ENA_CREADO_POR = envioAlerta.ENA_CREADO_POR,
        //                        ENA_FECHA_CREACION = envioAlerta.ENA_FECHA_CREACION,
        //                    };
        //                    Actualizacion actualiza = new Actualizacion();
        //                    var retorno = actualiza.EjecutarQuery<ENA_ENVIO_ALERTAS>("CrearEnvioAlerta", objeto, CommandType.StoredProcedure, ref Error);
        //                    if (Error == "")
        //                        return "";
        //                    else
        //                        return Error;
        //                }
        //                else
        //                    return Error;
        //            }
        //            catch (Exception ex)
        //            {
        //                return "Error actualizando Envio Alerta. " + ex.Message.ToString();
        //            }
        //        }
        //        public List<SLS_SOLICITUD_SIMULACION> GenerarPreaprobado(SLS_SOLICITUD_SIMULACION simula, ref string Error)
        //        {
        //            try
        //            {
        //                var objeto = new
        //                {
        //                    SLS_ID = simula.SLS_ID,
        //                    TCR_ID = simula.TCR_ID,
        //                    SLS_USUARIO_ACTUALIZA = simula.SLS_USUARIO_ACTUALIZA,
        //                    SLS_FECHA_ACTUALIZA = simula.SLS_FECHA_ACTUALIZA
        //                };
        //                Actualizacion actualiza = new Actualizacion();
        //                var retorno = actualiza.EjecutarQuery<SLS_SOLICITUD_SIMULACION>("CrearPreAprobado", objeto, CommandType.StoredProcedure, ref Error);
        //                return retorno;
        //            }
        //            catch (Exception ex)
        //            {
        //                Error = "Error Generando Preaprobado la Simulacion. " + ex.Message.ToString();
        //                return null;
        //            }
        //        }
        //        public List<SOC_SOLICITUD_CREDITO> GenerarSolicitudCredito(SOC_SOLICITUD_CREDITO solic, List<string> lFiles, ref string Error)
        //        {
        //            try
        //            {
        //                var objeto = new
        //                {
        //                    SOC_ID = solic.SOC_ID,
        //                    SOC_DECLARACION_ORIGEN_FONDOS = solic.SOC_DECLARACION_ORIGEN_FONDOS,
        //                    SOC_AUTORIZA_USO_DATOS = solic.SOC_AUTORIZA_USO_DATOS,
        //                    SOC_AUTORIZA_CONSULTA_CENTRALES = solic.SOC_AUTORIZA_CONSULTA_CENTRALES,
        //                    SOC_DECLARACION_ASEGURABILIDAD = solic.SOC_DECLARACION_ASEGURABILIDAD,
        //                    SOC_CONVENIO_ASEGURADORA = solic.SOC_CONVENIO_ASEGURADORA,
        //                    ASE_ID = solic.ASE_ID,
        //                    SOC_ESTADO = solic.SOC_ESTADO,
        //                    SOC_FECHA_ACTUALIZA = solic.SOC_FECHA_ACTUALIZA,
        //                    SOC_ACTUALIZADO_POR = solic.SOC_ACTUALIZADO_POR
        //                };
        //                Actualizacion actualiza = new Actualizacion();
        //                var retorno = actualiza.EjecutarQuery<SOC_SOLICITUD_CREDITO>("CrearNoSolicitudCredito", objeto, CommandType.StoredProcedure, ref Error);
        //                if (Error == "")
        //                {
        //                    foreach (string doc in lFiles)
        //                    {
        //                        var dat = doc.Split('_');
        //                        var tipo = dat[2].Split('.');
        //                        var objeto1 = new
        //                        {
        //                            DCS_ID = Guid.NewGuid(),
        //                            SOC_ID = solic.SOC_ID,
        //                            TDC_ID = tipo[0].Trim(),
        //                            DCS_CODIGO_BARRAS = "0",
        //                            DCS_FECHA_DOCUMENTO = DateTime.Now.Date,
        //                            DCS_NUMERO_FOLIOS = 0,
        //                            DCS_TAMAÑO = 0,
        //                            DCS_RUTA_IMAGEN = doc,
        //                            DCS_ESTADO = 1,
        //                            DCS_CREADO_POR = Guid.NewGuid(),
        //                            DCS_FECHA_CREACION = DateTime.Now
        //                        };
        //                        var retorno1 = actualiza.EjecutarQuery<SOP_SOLICITUD_PRODUCTO>("CrearDocumentoSolicCredito", objeto1, CommandType.StoredProcedure, ref Error);
        //                    }
        //                }
        //                return retorno;
        //            }
        //            catch (Exception ex)
        //            {
        //                Error = "Error Generando Numero Solicitud Credito. " + ex.Message.ToString();
        //                return null;
        //            }
        //        }
    }
}
