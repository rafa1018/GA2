using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para actualizar el Notificacion
    /// <date>17/05/2021</date>
    /// </summary>
    [Authorize]
    public class CrearNotificacion : BaseAsyncEndpoint.WithRequest<NotificacionDto>.WithoutResponse
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
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/notificacion/crearnotificacion")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<NotificacionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Agrega Notificacion",
            Description = "Agrega Notificacion",
            OperationId = "Notificacion.insert",
            Tags = new[] { "NotificationEndPoint" })]
        public async override Task<ActionResult> HandleAsync(NotificacionDto request, CancellationToken cancellationToken = default)
        {
            await _notificationBusinessLogic.CrearNotificacionClienteId(request);
            return Ok();
        }
    }
}