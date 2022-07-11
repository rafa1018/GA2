using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para traer el Notificacion
    /// <date>17/05/2021</date>
    /// </summary>
    [Authorize]
    public class ObtenerNotificaciones : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<NotificacionDto>>>
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
        /// Obtiene all Notificaciones
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/notificacion/obtenerNotificaciones")]
        [ProducesResponseType(typeof(Response<IEnumerable<NotificacionDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Notificacion",
            Description = "Obtiene Notificacion",
            OperationId = "Notificacion.get",
            Tags = new[] { "NotificationEndPoint" })]
        public async override Task<ActionResult<Response<IEnumerable<NotificacionDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var userId = User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value;
            return await this._notificationBusinessLogic.ObtenerNotificacionAsync(Guid.Parse(userId));
        }
    }
}
