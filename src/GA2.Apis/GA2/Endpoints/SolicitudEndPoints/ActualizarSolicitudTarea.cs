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
    /// <author>Erwin Pantoja España</author>
    /// <date>20/10/2021</date>
    [Authorize]
    public class ActualizarSolicitudTarea :
         BaseAsyncEndpoint.WithRequest<CrearSolicitudTareaDto>
        .WithResponse<Response<bool>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Erwin Pantoja</author>
        /// <date>20/10/2021</date>
        public ActualizarSolicitudTarea(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="crearSolicitudTareaDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/solicitud/ActualizarSolicitudTarea")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Solicitud de una tarea nueva",
           Description = "Actualizar Solicitud de de una tarea nueva",
           OperationId = "Solicitud.ActualizarSolicitudTarea",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<bool>>> HandleAsync(CrearSolicitudTareaDto crearSolicitudTareaDto, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.ActualizarSolicitudTarea(crearSolicitudTareaDto);
        }

    }

}
