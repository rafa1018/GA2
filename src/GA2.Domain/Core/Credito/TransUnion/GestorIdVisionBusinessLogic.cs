using GA2.Application.Dto;
using GA2.Application.Main.TU;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class GestorIdVisionBusinessLogic : IGestorIdVisionBusinessLogic

    {
        private readonly IGestorTransUnionBusinessLogic _gestorActualizacionBusinessLogic;
        private readonly IOptions<IdVisionOptions> _options;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gestorActualizacionBusinessLogic"></param>
        public GestorIdVisionBusinessLogic(IGestorTransUnionBusinessLogic gestorActualizacionBusinessLogic, IOptions<IdVisionOptions> options)
        {
            _gestorActualizacionBusinessLogic = gestorActualizacionBusinessLogic;
            _options = options;

        }

        public GestorIdVisionBusinessLogic()
        {
        }

        /// <summary>
        /// Validación de Identidad con ID_VISION - TransUnion
        /// </summary>
        /// <param name="requestTU"></param>
        /// <returns></returns>
        //public async Task<Response<ResponseTUDto>> validarCliente(RequestTUDto requestTU)
        public async Task<ResponseTu> validarCliente(RequestTuDto requestTU)
        {
            ResponseTu responseTu = new ResponseTu
            {
                idAplication = "0",
                codigoError = 0,
                detalleError = "",
                codigoRechazo = 1,
                tipoRechazo = "NA",
                detalleRechazo = "NA"
            };
            try
            {
                ValidacionesTU tu = new ValidacionesTU();

                DCRequest dcr = new DCRequest();
                dcr.Authentication = new Authentication() { UserId = requestTU.usrId, Password = requestTU.pasword, Type = "OnDemand" };
                dcr.RequestInfo = new RequestInfo() { SolutionSetId = requestTU.solucionId, ExecuteLatestVersion = "true", ExecutionMode = "NewWithContext" };

                Applicant ap = new Applicant();
                ap.IdNumber = requestTU.IdNumber;
                ap.IdType = requestTU.IdType;
                ap.RecentPhoneNumber = requestTU.RecentPhoneNumber;
                ap.LastName = requestTU.LastName;
                ap.IdExpeditionDate = requestTU.IdExpeditionDate;
                dcr.Fields = new Fields { Field = new List<Field>() { new Field { Key = "PrimaryApplicant", Text = ap.Serialize<Applicant>() } } };

                //Guarda consumo de TransUnion
                var respuesta = tu.ConsumirTU(dcr, out string request, out string response);

                if (respuesta.Status.ToString() == "Success" && (respuesta.Authentication.Status.ToString() == "Success" || respuesta.Authentication.Status.ToString() == "FirstTimeLogIn"))
                {
                    var appData = respuesta.ContextData.Field.Where(x => x.Key.Contains("ApplicationData"));
                    if (appData.Count<Field>() > 0)
                    {
                        ApplicationData vcrReason = Serialization.DeserializeRC(appData.FirstOrDefault().Text);
                        if (vcrReason != null)
                        {
                            var vcr = vcrReason.IDVReasonsCode;
                            if (vcr != null)
                            {
                                responseTu.codigoRechazo = int.Parse(vcr.Reason.Code);
                                responseTu.tipoRechazo = vcr.Reason.Type;
                                responseTu.detalleRechazo = vcr.Reason.Description;
                            }
                            else
                            {
                                var velo = vcrReason.VelocityCheckReasons;
                                if (velo != null)
                                {
                                    responseTu.codigoRechazo = int.Parse(velo.Reason.Code);
                                    responseTu.tipoRechazo = velo.Reason.Type;
                                    responseTu.detalleRechazo = velo.Reason.Description;
                                }
                            }
                            if (responseTu.codigoRechazo == 101)
                            {
                                responseTu.codigoRechazo = 1;
                                responseTu.detalleError = "Usuario Bloqueado por Seguridad";
                            }
                            else
                            {
                                if (vcrReason.IDVReasonsCode != null)
                                {
                                    if (vcrReason.IDVReasonsCode.Reason.Code == "105")
                                    {
                                        responseTu.codigoError = 1;
                                        responseTu.detalleError = "Verificación de identidad fallida";
                                    }
                                    else
                                    {
                                        if (vcrReason.IDVReasonsCode.Reason.Code == "103")
                                        {
                                            responseTu.codigoError = 1;
                                            responseTu.detalleError = "Verificación de identidad fallida";
                                        }
                                        else
                                        {
                                            if (vcrReason.IDVReasonsCode.Reason.Code == "104")
                                            {
                                                responseTu.codigoError = 1;
                                                responseTu.detalleError = "Verificación de identidad fallida";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    responseTu.codigoError = 1;
                                    responseTu.detalleError = "Problemas en la Conexión con TransUnion.!";
                                }
                            }
                        }
                        else
                        {
                            responseTu.codigoError = 1;
                            responseTu.detalleError = "Problemas en la Conexión con TransUnion.!";
                        }
                    }
                    else
                    {
                        var preguntas = respuesta.ContextData.Field.Where(x => x.Key.Contains("ExamData")).FirstOrDefault();
                        if (preguntas != null)
                        {
                            var dataPreguntas = Serialization.DeserializeED(preguntas.Text);
                        }
                        else
                        {
                            var hasErrors = respuesta.ContextData.Field.Where(x => x.Key.Contains("HasError"));
                            if (hasErrors.FirstOrDefault().Text == "False")
                            {
                                responseTu.codigoRechazo = 0;
                                responseTu.detalleRechazo = "";
                                responseTu.idAplication = respuesta.ResponseInfo.ApplicationId;
                            }
                        }
                    }
                }
                else
                {
                    responseTu.codigoError = 1;
                    responseTu.detalleError = "Problemas en la Conexión con TransUnion.!";
                }

                /// Registro el Log del LLamado a los Servicios TU
                SolicitudCreditoProductoDto logTu = new SolicitudCreditoProductoDto
                {
                    VLT_ID = Guid.NewGuid(),
                    VLI_ID = Guid.Parse(requestTU.IdValidation),
                    VLT_SERVICIO = "ValidacionIdentidad",
                    VLT_PASO_TRANSACCION = "ID_VISION",
                    VLT_XML_SOLICITUD = request,
                    VLT_XML_RESPUESTA = response,
                    VLT_ID_APICACION = respuesta.ResponseInfo.ApplicationId,
                    VLT_CODIGO_RESPUESTA = responseTu.codigoRechazo.ToString(),
                    VLT_TIPO_RESPUESTA = responseTu.tipoRechazo,
                    VLT_DESCRIPCION_RESPUESTA = responseTu.detalleRechazo,

                };
                var resapLog = await _gestorActualizacionBusinessLogic.CrearLogTu(logTu);
            }
            catch (Exception ex)
            {
                responseTu.codigoError = 1;
                responseTu.detalleError = "Error en la Conexión con TransUnion. " + ex.Message.ToString();
            }
            return responseTu;
            //return new Response<ResponseTUDto> { Data = responseTu };
        }


        /// <summary>
        /// Envio del Código OTP al Celular del Cliente
        /// </summary>
        /// <param name="requestTU"></param>
        /// <returns></returns>
        //public async Task<Response<ResponseTUDto>> envioCodigoOTP(RequestTUDto requestTU)
        public async Task<ResponseTu> EnvioCodigoOTP(RequestTuDto requestTU)
        {
            var options = _options.Value;

            requestTU.solucionId = options.solucionId;
            requestTU.usrId = options.usuarioIDVision;
            requestTU.pasword = options.claveIDVision;

            ResponseTu responseTu = new ResponseTu
            {
                idAplication = "0",
                codigoError = 0,
                detalleError = "",
                codigoRechazo = 0,
                tipoRechazo = "NA",
                detalleRechazo = "NA"
            };
            try
            {
                ValidacionesTU tu = new ValidacionesTU();

                DCRequest dcrOTP = new DCRequest();
                dcrOTP.Authentication = new Authentication() { UserId = requestTU.usrId, Password = requestTU.pasword, Type = "OnDemand" };
                dcrOTP.RequestInfo = new RequestInfo() { ApplicationId = requestTU.idAplication, QueueName = "PhoneSelection", ExecutionMode = "Send" };

                dcrOTP.Fields = new Fields
                {
                    Field = new List<Field>()
                {
                    new Field { Key = "PhoneType", Text = "Mobile" },
                    new Field { Key = "SelectedPhoneNumber", Text = requestTU.RecentPhoneNumber },
                    new Field { Key = "ValidationMethod", Text = "SMS" }
                }
                };
                var respuestaOTP = tu.ConsumirTU(dcrOTP, out string requestOTP, out string responseOTP);

                if (respuestaOTP.Status == "Success" && respuestaOTP.Authentication.Status == "Success")
                {
                    var appData = respuestaOTP.ContextData.Field.Where(x => x.Key.Contains("ApplicationData"));

                    var OTPCodes = respuestaOTP.ContextData.Field.Where(x => x.Key.Contains("OTPCode"));
                    var delays = respuestaOTP.ContextData.Field.Where(x => x.Key.Contains("Delay"));
                    var errorRpta = respuestaOTP.ContextData.Field.Where(x => x.Key.Contains("ReturnMensagge"));

                    responseTu.codigoRechazo = 0;
                    responseTu.codigoOtp = OTPCodes.FirstOrDefault().Text;
                    responseTu.delayOtp = delays.FirstOrDefault().Text;

                    /// Registro el Log del Envio del Codigo OTP
                    VLL_VALIDACION_LOG_OTPDto logOTP = new VLL_VALIDACION_LOG_OTPDto
                    {
                        VLL_ID = Guid.NewGuid(),
                        VLI_ID = Guid.Parse(requestTU.IdValidation),
                        VLL_CODIGO_OTP = responseTu.codigoOtp,
                        VLL_ID_APICACION = respuestaOTP.ResponseInfo.ApplicationId,
                        VLL_ESTADO_VALIDACION = "Respuesta Envio: ",
                        VLL_FECHA_ACTUALIZA = DateTime.Now

                    };


                    var resapLogOTP = await _gestorActualizacionBusinessLogic.CrearLogOTP(logOTP);
                }
                else
                {
                    responseTu.codigoRechazo = 1;
                    responseTu.detalleRechazo = "Problemas en la Conexión con TransUnion.!";
                }
                /// Registro el Log del LLamado a los Servicios TU
                SolicitudCreditoProductoDto logTu = new SolicitudCreditoProductoDto
                {
                    VLT_ID = Guid.NewGuid(),
                    VLI_ID = Guid.Parse(requestTU.IdValidation),
                    VLT_SERVICIO = "ReEnvioCodigoOTP",
                    VLT_PASO_TRANSACCION = "ID_VISION",
                    VLT_XML_SOLICITUD = requestOTP,
                    VLT_XML_RESPUESTA = responseOTP,
                    VLT_ID_APICACION = respuestaOTP.ResponseInfo.ApplicationId,
                    VLT_CODIGO_RESPUESTA = responseTu.codigoRechazo.ToString(),
                    VLT_TIPO_RESPUESTA = responseTu.tipoRechazo,
                    VLT_DESCRIPCION_RESPUESTA = responseTu.detalleRechazo

                };


                var resapLog = await _gestorActualizacionBusinessLogic.RegistroLogTU(logTu);
            }
            catch (Exception ex)
            {
                responseTu.codigoRechazo = 1;
                responseTu.detalleRechazo = "Error en la Conexión con TransUnion. " + ex.Message.ToString();
            }
            return responseTu;
            //return new Response<ResponseTUDto> { Data = responseTu };
        }

        /// <summary>
        /// Reenvio del Código OTP al Celular del Cliente
        /// </summary>
        /// <param name="requestTU"></param>
        /// <returns></returns>
        public async Task<ResponseTu> reEnvioCodigoOTP(RequestTuDto requestTU)
        {
            ResponseTu responseTu = new ResponseTu
            {
                idAplication = "0",
                codigoError = 0,
                detalleError = "",
                codigoRechazo = 0,
                tipoRechazo = "NA",
                detalleRechazo = "NA"
            };
            try
            {
                ValidacionesTU tu = new ValidacionesTU();

                DCRequest dcrROTP = new DCRequest();
                dcrROTP.Authentication = new Authentication() { UserId = requestTU.usrId, Password = requestTU.pasword, Type = "OnDemand" };
                dcrROTP.RequestInfo = new RequestInfo() { ApplicationId = requestTU.idAplication, QueueName = "PinVerification_OTPInput", ExecutionMode = "Send" };

                dcrROTP.Fields = new Fields
                {
                    Field = new List<Field>()
                {
                    new Field { Key = "Action", Text = "ResendOTP" }
                }
                };

                var respuestaOTP = tu.ConsumirTU(dcrROTP, out string requestOTP, out string responseOTP);

                if (respuestaOTP.Status == "Success" && respuestaOTP.Authentication.Status == "Success")
                {
                    responseTu.codigoError = 0;
                    responseTu.codigoRechazo = 0;
                    responseTu.tipoRechazo = "";
                    responseTu.detalleRechazo = "";
                }
                else
                {
                    responseTu.codigoError = 1;
                    responseTu.detalleError = "Problemas en la Conexión con TransUnion.!";
                }
                /// Registro el Log del LLamado a los Servicios TU
                SolicitudCreditoProductoDto logTu = new SolicitudCreditoProductoDto
                {
                    VLT_ID = Guid.NewGuid(),
                    VLI_ID = Guid.Parse(requestTU.IdValidation),
                    VLT_SERVICIO = "ReEnvioCodigoOTP",
                    VLT_PASO_TRANSACCION = "ID_VISION",
                    VLT_XML_SOLICITUD = requestOTP,
                    VLT_XML_RESPUESTA = responseOTP,
                    VLT_ID_APICACION = respuestaOTP.ResponseInfo.ApplicationId,
                    VLT_CODIGO_RESPUESTA = responseTu.codigoRechazo.ToString(),
                    VLT_TIPO_RESPUESTA = responseTu.tipoRechazo,
                    VLT_DESCRIPCION_RESPUESTA = responseTu.detalleRechazo,

                };
                var resapLog = await _gestorActualizacionBusinessLogic.RegistroLogTU(logTu);
            }
            catch (Exception ex)
            {
                responseTu.codigoError = 1;
                responseTu.detalleError = "Error en la Conexión con TransUnion. " + ex.Message.ToString();
            }
            return responseTu;
        }

        /// <summary>
        /// Devolver la transaccion para re envio del codigo OTP
        /// </summary>
        /// <param name="requestTU"></param>
        /// <returns></returns>
        public async Task<ResponseTu> validacionCodigoOTPAsync(RequestTuDto requestTU)
        {
            ResponseTu responseTu = new ResponseTu
            {
                idAplication = "0",
                codigoError = 0,
                detalleError = "",
                codigoRechazo = 0,
                tipoRechazo = "NA",
                detalleRechazo = "NA"
            };
            try
            {
                ValidacionesTU tu = new ValidacionesTU();

                DCRequest dcrVOTP = new DCRequest();
                dcrVOTP.Authentication = new Authentication() { UserId = requestTU.usrId, Password = requestTU.pasword, Type = "OnDemand" };
                dcrVOTP.RequestInfo = new RequestInfo() { ApplicationId = requestTU.idAplication, QueueName = "PinVerification_OTPInput", ExecutionMode = "Send" };

                dcrVOTP.Fields = new Fields
                {
                    Field = new List<Field>()
                {
                    new Field { Key = "PinNumber", Text = requestTU.codeOTP },
                    new Field { Key = "Action", Text = "Continue" }
                }
                };

                var respuestaOTP = tu.ConsumirTU(dcrVOTP, out string requestOTP, out string responseOTP);

                if (respuestaOTP.Status == "Success" && respuestaOTP.Authentication.Status == "Success")
                {
                    var appData = respuestaOTP.ContextData.Field.Where(x => x.Key.Contains("ApplicationData"));
                    if (appData.Count<Field>() > 0)
                    {
                        ApplicationData vcrReason = Serialization.DeserializeRC(appData.FirstOrDefault().Text);
                        var OTPReasons = vcrReason.OTPReasons.Reason;

                        responseTu.codigoRechazo = Convert.ToInt32(OTPReasons.Code);
                        responseTu.tipoRechazo = OTPReasons.Type;
                        responseTu.detalleRechazo = OTPReasons.Description;
                        if (OTPReasons.Code == "302")
                        {
                            responseTu.codigoError = 1;
                            responseTu.detalleError = "Validacion fallida debio a código OTP incorrecto.";
                        }
                        if (OTPReasons.Code == "300")
                        {
                            responseTu.codigoError = 0;
                            responseTu.detalleError = "Validacion exitosa de código OTP.";
                        }
                        /// Registro el Log del Envio del Codigo OTP
                        VLL_VALIDACION_LOG_OTPDto logOTP = new VLL_VALIDACION_LOG_OTPDto
                        {
                            VLL_ID = Guid.NewGuid(),
                            VLI_ID = Guid.Parse(requestTU.IdValidation),
                            VLL_CODIGO_OTP = responseTu.codigoOtp,
                            VLL_ID_APICACION = respuestaOTP.ResponseInfo.ApplicationId,
                            VLL_ESTADO_VALIDACION = "Respuesta Envio: ",
                            VLL_FECHA_ACTUALIZA = DateTime.Now

                        };

                        var resapLogOTP = await _gestorActualizacionBusinessLogic.CrearLogOTP(logOTP);
                    }
                }
                else
                {
                    responseTu.codigoError = 1;
                    responseTu.detalleError = "Problemas en la Conexión con TransUnion.!";
                }
                /// Registro el Log del LLamado a los Servicios TU
                SolicitudCreditoProductoDto logTu = new SolicitudCreditoProductoDto
                {
                    VLT_ID = Guid.NewGuid(),
                    VLI_ID = Guid.Parse(requestTU.IdValidation),
                    VLT_SERVICIO = "ReEnvioCodigoOTP",
                    VLT_PASO_TRANSACCION = "ID_VISION",
                    VLT_XML_SOLICITUD = requestOTP,
                    VLT_XML_RESPUESTA = responseOTP,
                    VLT_ID_APICACION = respuestaOTP.ResponseInfo.ApplicationId,
                    VLT_CODIGO_RESPUESTA = responseTu.codigoRechazo.ToString(),
                    VLT_TIPO_RESPUESTA = responseTu.tipoRechazo,
                    VLT_DESCRIPCION_RESPUESTA = responseTu.detalleRechazo

                };
                var resapLog = await _gestorActualizacionBusinessLogic.RegistroLogTU(logTu);
            }
            catch (Exception ex)
            {
                responseTu.codigoError = 1;
                responseTu.detalleError = "Error en la Conexión con TransUnion. " + ex.Message.ToString();
            }
            return responseTu;
        }

        /// <summary>
        /// Obtención del Score del Cliente con AQM-GO - TransUnion
        /// </summary>
        /// <param name="requestTU"></param>
        /// <returns></returns>
        public async Task<Response<ResponseTu>> obtenerScoreCliente(RequestTuDto requestTU)
        {
            ResponseTu responseTu = new ResponseTu
            {
                idAplication = "0",
                codigoRechazo = 0,
                detalleRechazo = "OK"
            };
            try
            {
                ValidacionesTU tu = new ValidacionesTU();
                DCRequest dcAQM = new DCRequest();
                dcAQM.Authentication = new Authentication() { UserId = requestTU.usrId, Password = requestTU.pasword, Type = "OnDemand" };
                dcAQM.RequestInfo = new RequestInfo() { SolutionSetId = requestTU.solucionId, ExecuteLatestVersion = "true", ExecutionMode = "NewWithContext" };

                Applicant apAQM = new Applicant();
                apAQM.IdNumber = requestTU.IdNumber;
                apAQM.IdType = requestTU.IdType;
                apAQM.RecentPhoneNumber = requestTU.RecentPhoneNumber;
                apAQM.LastName = requestTU.LastName;
                apAQM.IdExpeditionDate = requestTU.IdExpeditionDate;
                apAQM.Occupation = requestTU.ocupacion;
                apAQM.MonthlyIncome = requestTU.sueldo;
                dcAQM.Fields = new Fields { Field = new List<Field>() { new Field { Key = "PrimaryApplicant", Text = apAQM.Serialize<Applicant>() }, new Field { Key = "ApplicationData", Text = (new ApplicationData { Product = "CONSUMO" }).Serialize<ApplicationData>() } } };
                var respuestaAQM = tu.ConsumirTUAqm(dcAQM, out string requestAqm, out string responseAqm);

                var applicantsR =(respuestaAQM.ContextData.Field.Where(x => x.Key.Equals("Applicants")));
                var appData = respuestaAQM.ContextData.Field.Where(x => x.Key.Contains("ApplicationData"));
                var desicion = respuestaAQM.ContextData.Field.Where(x => x.Key.Contains("Decision"));
                if (appData.Count<Field>() > 0)
                {
                    ApplicationData applicationData = Serialization.DeserializeRC(appData.FirstOrDefault().Text);
                    if (applicationData != null)
                    {
                        if (applicationData.DecisionHomologada == "VIABLE" || applicationData.DecisionHomologada == "PENDIENTE")
                        {
                            if (applicantsR != null)
                            {
                                Applicants ar = Serialization.DeserializeApps(applicantsR.FirstOrDefault().Text);
                                responseTu.capacidadEndeudamiento = decimal.Parse(ar.Applicant.CapacidadEndeudamiento);
                                responseTu.porcentajeEndeudamiento = decimal.Parse(ar.Applicant.PorcEndFinal);
                                responseTu.score = ar.Applicant.Score;
                                responseTu.decision = applicationData.DecisionHomologada;
                                responseTu.idAplication = respuestaAQM.ResponseInfo.ApplicationId;
                            }
                            else
                            {
                                responseTu.codigoRechazo = 0;
                                responseTu.tipoRechazo = "Politicas";
                                responseTu.detalleRechazo = "Cliente No VIABLE";
                                responseTu.decision = applicationData.DecisionHomologada;
                                responseTu.idAplication = respuestaAQM.ResponseInfo.ApplicationId;
                            }
                        }
                        else
                        {
                            responseTu.idAplication = respuestaAQM.ResponseInfo.ApplicationId;
                            responseTu.codigoRechazo = 0;
                            responseTu.tipoRechazo = "Politicas";
                            responseTu.detalleRechazo = "Cliente No VIABLE";
                            responseTu.decision = applicationData.DecisionHomologada;
                        }
                    }
                    else
                    {
                        responseTu.codigoRechazo = 1;
                        responseTu.detalleRechazo = "Error en la Conexión con Buro. ";
                        responseTu.idAplication = respuestaAQM.ResponseInfo.ApplicationId;

                    }
                }
                else
                {
                    responseTu.codigoRechazo = 1;
                    responseTu.detalleRechazo = "Error en la Conexión con Buro. ";
                }
                SolicitudCreditoProductoDto logTu = new SolicitudCreditoProductoDto
                {
                    VLT_ID = Guid.NewGuid(),
                    VLI_ID = Guid.Parse(requestTU.IdValidation),
                    VLT_SERVICIO = "Consulta Score Pn",
                    VLT_PASO_TRANSACCION = "AQM-GO",
                    VLT_XML_SOLICITUD = requestAqm,
                    VLT_XML_RESPUESTA = responseAqm,
                    VLT_ID_APICACION = respuestaAQM.ResponseInfo.ApplicationId,
                    VLT_CODIGO_RESPUESTA = responseTu.codigoRechazo.ToString(),
                    VLT_TIPO_RESPUESTA = responseTu.tipoRechazo,
                    VLT_DESCRIPCION_RESPUESTA = responseTu.detalleRechazo

                };
                //var resapLog = await _gestorActualizacionBusinessLogic.RegistroLogTU(logTu);
            }
            catch (Exception ex)
            {
                responseTu.detalleRechazo = "Error en la Conexión con TransUnion. " + ex.Message.ToString(); ;
            }
            return new Response<ResponseTu> { Data = responseTu };
        }
        /// <summary>
        /// Obtención del Historial Comercial del Cliente con AQM-GO - TransUnion
        /// </summary>
        /// <param name="requestTU"></param>
        /// <returns></returns>
        public async Task<Response<ResponseTu>> obtenerHistorialCliente(RequestTuDto requestTU)
        {
            ResponseTu responseTu = new ResponseTu
            {
                idAplication = "0",
                codigoRechazo = 0,
                detalleRechazo = "OK"
            };
            try
            {
                ValidacionesTU tu = new ValidacionesTU();
                DCRequest dcAQM = new DCRequest();
                dcAQM.Authentication = new Authentication() { UserId = requestTU.usrId, Password = requestTU.pasword, Type = "OnDemand" };
                dcAQM.RequestInfo = new RequestInfo() { ApplicationId = requestTU.idAplication, QueueName = "DocVerify", ExecutionMode = "Send" };

                Applicant apAQM = new Applicant();
                apAQM.IdNumber = requestTU.IdNumber;
                apAQM.IdType = requestTU.IdType;
                apAQM.RecentPhoneNumber = requestTU.RecentPhoneNumber;
                apAQM.LastName = requestTU.LastName;
                apAQM.IdExpeditionDate = requestTU.IdExpeditionDate;
                apAQM.Occupation = requestTU.ocupacion;
                apAQM.MonthlyIncome = requestTU.sueldo;
                dcAQM.Fields = new Fields { Field = new List<Field>() { new Field { Key = "GenerateReport", Text = "Y" } } };
                var respuestaAQM = tu.ConsumirTUAqm(dcAQM, out string requestAqm, out string responseAqm);

                var applicantsR = respuestaAQM.ContextData.Field.Where(x => x.Key.Equals("Applicants"));
                if (applicantsR.Count<Field>() > 0)
                {
                    Applicants ar = Serialization.DeserializeApps(applicantsR.FirstOrDefault().Text);
                    if (ar != null)
                    {
                        var JsonHistoria = System.Text.Json.JsonSerializer.Serialize(ar.Applicant.DSOnlineBureauCOLData);
                        responseTu.historialCredito = JsonHistoria;
                    }
                    else
                    {
                        responseTu.detalleRechazo = "Error en la Conexión con TransUnion AQM. ";
                    }
                }

                SolicitudCreditoProductoDto logTu = new SolicitudCreditoProductoDto
                {
                    VLT_ID = Guid.NewGuid(),
                    VLI_ID = Guid.Parse(requestTU.IdValidation),
                    VLT_SERVICIO = "Consulta Historial Pn",
                    VLT_PASO_TRANSACCION = "AQM-GO",
                    VLT_XML_SOLICITUD = requestAqm,
                    VLT_XML_RESPUESTA = responseAqm,
                    VLT_ID_APICACION = respuestaAQM.ResponseInfo.ApplicationId,
                    VLT_CODIGO_RESPUESTA = responseTu.codigoRechazo.ToString(),
                    VLT_TIPO_RESPUESTA = responseTu.tipoRechazo,
                    VLT_DESCRIPCION_RESPUESTA = responseTu.detalleRechazo

                };
                //var resapLog = await this._gestorActualizacionBusinessLogic.RegistroLogTU(logTu);
            }
            catch (Exception ex)
            {
                responseTu.detalleRechazo = "Error en la Conexión con TransUnion. " + ex.Message.ToString(); ;
            }
            return new Response<ResponseTu> { Data = responseTu };
        }
    }
}
