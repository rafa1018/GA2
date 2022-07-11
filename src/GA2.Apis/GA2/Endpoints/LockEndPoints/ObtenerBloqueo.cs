using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ObtenerBloqueo : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<BloqueoDto>>>
    {
        private readonly IBloqueoBusinessLogic _lockBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lockBusinessLogic"></param>
        public ObtenerBloqueo(IBloqueoBusinessLogic lockBusinessLogic)
        {
            _lockBusinessLogic = lockBusinessLogic;
        }


        /// <summary>
        /// Obtiene all Bloqueos
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/bloqueo/ObtenerBloqueo")]
        [ProducesResponseType(typeof(Response<IEnumerable<BloqueoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Bloqueo",
            Description = "Obtiene Bloqueo",
            OperationId = "Bloqueo.get",
            Tags = new[] { "lockEndPoint" })]
        public async override Task<ActionResult<Response<IEnumerable<BloqueoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._lockBusinessLogic.ObtenerBloqueoAsync();
        }
    }
}
