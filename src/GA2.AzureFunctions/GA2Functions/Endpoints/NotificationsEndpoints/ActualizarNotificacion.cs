using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using GA2.Application.Main;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.NotificationsEndpoints
{
    public class ActualizarNotificacion
    {
        private readonly INotificacionBusinessLogic _notificationBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationBusinessLogic"></param>
        public ActualizarNotificacion(INotificacionBusinessLogic notificationBusinessLogic)
        {
            _notificationBusinessLogic = notificationBusinessLogic;
        }

        /// <summary>
        /// Endpoint ActualizarBloqueo
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("ActualizarNotificacion")]
        public async Task<Response<NotificacionDto>> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route = "notificacion/actualizarnotificacion")] HttpRequest req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("NotificationEndpoints - ActualizarNotificacion");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var notificacion = JsonConvert.DeserializeObject<NotificacionDto>(body);

            await Task.CompletedTask;
            return null;
           // return await _notificationBusinessLogic.Act(notificacion);
        }
    }
}
