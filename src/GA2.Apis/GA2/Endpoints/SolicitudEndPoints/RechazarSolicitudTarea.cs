using System;
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
    /// Endpoint para Crear una solicitud
    /// </summary>
    /// <author>Hanson Restrepo</author>
    /// <date>31/12/2021</date>
    [Authorize]
    public class RechazarSolicitudTarea :
         BaseAsyncEndpoint.WithRequest<RechazarSolicitudTareaDto>
        .WithResponse<Response<bool>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Rechazar solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>20/10/2021</date>
        public RechazarSolicitudTarea(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rechazarSolicitudTareaDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/solicitud/RechazarSolicitudTarea")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Rechazar Solicitud de una tarea",
           Description = "Rechazar Solicitud de una tarea",
           OperationId = "Solicitud.RechazarSolicitudTarea",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<bool>>> HandleAsync(RechazarSolicitudTareaDto rechazarSolicitudTareaDto, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.RechazarSolicitudTarea(rechazarSolicitudTareaDto);
        }

    }

}