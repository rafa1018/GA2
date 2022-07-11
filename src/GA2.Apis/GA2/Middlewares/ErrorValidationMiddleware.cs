using GA2.Domain.Core;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Middlewares
{
    /// <summary>
    /// Middleware que registra los errores de la aplicación
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>19/02/2021</date>
    public class ErrorValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogErrorBusinessLogic _logErrorBL;

        /// <summary>
        /// ErrorValidation Constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logErrorBL"></param>
        public ErrorValidationMiddleware(RequestDelegate next, ILogErrorBusinessLogic logErrorBL)
        {
            _next = next;
            _logErrorBL = logErrorBL;
        }

        /// <summary>
        /// Invoke ErrorValidation
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var trace = exception.StackTrace;
                
                await GetResult(exception, context);
            }
        }

        /// <summary>
        /// Obtienen result de la excepcion
        /// </summary>
        /// <param name="exception">Excepcion</param>
        /// <param name="context">Contexto aplicado</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>24/02/2021</date>
        /// <returns>void</returns>
        private async Task GetResult(Exception exception, HttpContext context)
        {
            switch (exception.GetType().Name)
            {
                case "CustomBadRequestException":
                    await OnBadRequestException(context, (CustomBadRequestException)exception);
                    break;

                case "CustomConflictException":
                    await OnCustomConflictException(context, (CustomConflictException)exception);
                    break;

                case "CustomNotFoundException":
                    await OnCustomNotFoundException(context, (CustomNotFoundException)exception);
                    break;

                default:
                    await GetResult(context, exception, HttpStatusCode.Conflict);
                    break;
            }
        }

        /// <summary>
        /// Obtienen result de la excepcion
        /// </summary>
        /// <param name="exception">Excepcion</param>
        /// <param name="context">Contexto aplicado</param>
        /// <param name="code">Http status code</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>24/02/2021</date>
        /// <returns>void</returns>
        private async Task GetResult(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var route = context.GetRouteData();
            string ControllerName = context.Request.Path.ToString();
            string ActionName = context.Request.Method.ToString();
            if (route != null)
            {
                try
                {
                    ControllerName = (string)route.Values["controller"];
                    ActionName = (string)route.Values["action"];
                }
                catch (Exception)
                {
                    //Todo Log this
                }
            }
            context.Response.Clear();
            context.Response.StatusCode = (int)code;
            context.Response.ContentType = @"application/json";
            var error = CreateErrorResponse(exception, context, ControllerName, ActionName);
            var logError = await CreateLogError(error);
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(logError, settings));
        }

        /// <summary>
        /// Create el error producido en la aplicacion
        /// </summary>
        /// <param name="exception">Excepcion producida</param>
        /// <param name="context">Contexto aplicado</param>
        /// <param name="ControllerName">Controlador</param>
        /// <param name="ActionName">Metodo de controlador</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>24/02/2021</date>
        /// <returns>Errror Response</returns>
        private ERRORRESPONSE CreateErrorResponse(Exception exception, HttpContext context, string ControllerName, string ActionName)
        {
            return new ERRORRESPONSE()
            {
                MESSAGE = GetMessage(exception),
                CLIENTID = GetClientId(context),
                CONTROLLERNAME = ControllerName,
                ACTIONNAME = ActionName,
                STACKTRACE = GetMessageException(exception),
                ERRORCODE = GetCodeException(exception),
                REQUESTIP = GetRemoteIPAdress(context)
            };
        }

        /// <summary>
        /// Registra el error en base de datos
        /// </summary>
        /// <param name="errorResponse">Error devuelto</param>
        /// <auhtor>Oscar Julian Rojas Garces</auhtor>
        /// <date>24/02/2021</date>
        /// <returns>ErrorResponse</returns>
        private async Task<Response<ERRORRESPONSE>> CreateLogError(ERRORRESPONSE errorResponse)
        {
            return await _logErrorBL.CreateLogError(errorResponse);
        }

        /// <summary>
        /// Error en methodo no escontrado
        /// </summary>
        /// <param name="context">Contexto aplicado</param>
        /// <param name="exception">Exception</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>24/02/2021</date>
        /// <returns></returns>
        private async Task OnCustomNotFoundException(HttpContext context, CustomNotFoundException exception)
        {
            await GetResult(context, exception, HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Excepcion de conflicto 
        /// </summary>
        /// <param name="context">Contexto aplicado</param>
        /// <param name="exception">Excepcion producida</param>
        /// <returns></returns>
        private async Task OnCustomConflictException(HttpContext context, CustomConflictException exception)
        {
            await GetResult(context, exception, HttpStatusCode.Conflict);
        }

        /// <summary>
        /// Error en mala petición
        /// </summary>
        /// <param name="context">Contexto aplicado</param>
        /// <param name="exception">Exception</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>22/02/2021</date>
        /// <returns>Void</returns>
        private async Task OnBadRequestException(HttpContext context, CustomBadRequestException exception)
        {
            await GetResult(context, exception, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Metodo que devuelve el mensaje de excepcion
        /// </summary>
        /// <param name="exception">Excepcion producida</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>24/02/2021</date>
        /// <returns>Mensaje de excepcion</returns>
        private static string GetMessage(Exception exception)
        {
            try
            {
                return exception.Message;
            }
            catch (Exception)
            {
                return "Not-Message-Defined";
            }
        }

        /// <summary>
        /// Obtiene el cliente de los claims
        /// </summary>
        /// <param name="context">Contexto aplicado</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>24/02/2021</date>
        /// <returns>Identificador de usuario</returns>
        private static Guid GetClientId(HttpContext context)
        {
            try
            {
                var userId = context.User?.Claims?.Where(c => c.Type == "USR_ID").FirstOrDefault() ??
                    context.User?.Claims?.Where(c => c.Type == "IdCliente").FirstOrDefault() ??
                    context.User?.Claims?.Where(c => c.Type == "ApplicationIdentity").FirstOrDefault();
                return Guid.Parse(userId?.Value);
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// Obtener la direccion ip de excepcion
        /// </summary>
        /// <param name="context">Contexto aplicado</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/02/2021</date>
        /// <returns>Ip remota</returns>
        private static string GetRemoteIPAdress(HttpContext context)
        {
            try
            {
                return context.Connection?.RemoteIpAddress?.ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Codigo de la excepcion
        /// </summary>
        /// <param name="exception">Excepcion producida</param>
        /// <auhtor>Oscar Julian Rojas Garces</auhtor>
        /// <date>24/02/2021</date>
        /// <returns>Codigo excepcion</returns>
        private static int GetCodeException(Exception exception)
        {
            try
            {
                ModelBaseException ex = (ModelBaseException)exception;
                return ex.ApplicationMessage.Code;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// Obtiene el mensaje de la excepcion 
        /// </summary>
        /// <param name="exception">Excepcion</param>
        /// <param name="Message">Mensaje de excepcion</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>24/02/2021</date>
        /// <returns>Mensaje producido</returns>
        private string GetMessageException(Exception exception, string Message = "")
        {
            if (String.IsNullOrEmpty(Message))
            {
                Message = " Exception:" + exception.Message + ". ";
            }
            else
            {
                Message += exception.Message + ". ";
            }

            if (exception.InnerException != null)
            {
                Message += ". Inner Exception=" + exception.InnerException.Message
                            + ". StackTrace=" + exception.StackTrace;
                Message = GetMessageException(exception.InnerException, Message);
            }
            else
            {
                return Message + ". StackTrace=" + exception.StackTrace;
            }
            return Message;
        }
    }
}
