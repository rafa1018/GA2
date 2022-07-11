using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using GA2.Application.Main;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.NotificationsEndpoints
{
    public class ObtenerNotificaciones
    {
        private readonly INotificacionBusinessLogic _notificationBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificationBusinessLogic"></param>
        public ObtenerNotificaciones(INotificacionBusinessLogic notificationBusinessLogic)
        {
            _notificationBusinessLogic = notificationBusinessLogic;
        }


        /// <summary>
        /// Endpoint ActualizarBloqueo
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("ObtenerNotificacion")]
        public async Task<Response<IEnumerable<NotificacionDto>>> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route = "notificacion/obtenerNotificaciones")] HttpRequest req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("NotificationsEndpoinst - ObtenerNotificacion");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var userId = req.HttpContext.User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value;
            return await this._notificationBusinessLogic.ObtenerNotificacionAsync(Guid.Parse(userId));

        }
    }
}
