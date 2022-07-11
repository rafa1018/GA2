using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using GA2.Application.Main;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.NotificationsEndpoints
{
    public class CrearNotificacion
    {
        private readonly INotificacionBusinessLogic _notificationBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationBusinessLogic"></param>
        public CrearNotificacion(INotificacionBusinessLogic notificationBusinessLogic)
        {
            _notificationBusinessLogic = notificationBusinessLogic;
        }

        /// <summary>
        /// Endpoint ActualizarBloqueo
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("CrearNotificacion")]
        public async Task<ActionResult> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route = "notificacion/crearnotificacion")] HttpRequest req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("NotificationsEndpoinst - CrearNotificacion");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var notificacion = JsonConvert.DeserializeObject<NotificacionDto>(body);

            await _notificationBusinessLogic.CrearNotificacionClienteId(notificacion);
            return new OkResult();
        }
    }
}
