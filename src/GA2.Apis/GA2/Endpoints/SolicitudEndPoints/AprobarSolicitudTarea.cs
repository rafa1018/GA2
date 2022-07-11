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
    /// <date>29/12/2021</date>
    [Authorize]
    public class AprobarSolicitudTarea :
         BaseAsyncEndpoint.WithRequest<AprobarSolicitudTareaDto>
        .WithResponse<Response<ObtenerTramiteSolicitudDto>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Aprobar solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>20/10/2021</date>
        public AprobarSolicitudTarea(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aprobarSolicitudTareaDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/solicitud/AprobarSolicitudTarea")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ObtenerTramiteSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Aprobar Solicitud de una tarea",
           Description = "Aprobar Solicitud de una tarea",
           OperationId = "Solicitud.AprobarSolicitudTarea",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<ObtenerTramiteSolicitudDto>>> HandleAsync(AprobarSolicitudTareaDto aprobarSolicitudTareaDto, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.AprobarSolicitudTarea(aprobarSolicitudTareaDto);
        }

    }

}
