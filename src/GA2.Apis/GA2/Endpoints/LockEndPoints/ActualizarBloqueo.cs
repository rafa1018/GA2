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
    /// Endpoint para actualizar el Bloqueo
    /// </summary>
    [Authorize]
    public class ActualizarBloqueo : BaseAsyncEndpoint.WithRequest<BloqueoDto>.WithResponse<Response<BloqueoDto>>
    {
        private readonly IBloqueoBusinessLogic _lockBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lockBusinessLogic"></param>
        public ActualizarBloqueo(IBloqueoBusinessLogic lockBusinessLogic)
        {
            _lockBusinessLogic = lockBusinessLogic;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/bloqueo/ActualizarBloqueo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<BloqueoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Bloqueo",
            Description = "Actualiza Bloqueo",
            OperationId = "Bloqueo.update",
            Tags = new[] { "lockEndPoint" })]
        public async override Task<ActionResult<Response<BloqueoDto>>> HandleAsync(BloqueoDto request, CancellationToken cancellationToken = default)
        {
            return await _lockBusinessLogic.ActualizarBloqueo(request);
        }
    }
}