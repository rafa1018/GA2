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
	/// Endpoint para actualizar Get Estado
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>17/05/2021</date>
    [Authorize]
    public class ObtenerEstado : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<EstadoDto>>>
    {
        private readonly IEstadoBusinessLogic _stateBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Get Estado
        /// </summary>
        /// <param name="stateBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerEstado(IEstadoBusinessLogic stateBusinessLogic)
        {
            _stateBusinessLogic = stateBusinessLogic;
        }


        /// <summary>
        /// Obtiene all estados
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/estado/ObtenerEstado")]
        [ProducesResponseType(typeof(Response<IEnumerable<EstadoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene estado",
            Description = "Obtiene estado",
            OperationId = "estado.get",
            Tags = new[] { "StateEndPoint" })]
        public async override Task<ActionResult<Response<IEnumerable<EstadoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._stateBusinessLogic.ObtenerEstado();
        }
    }
}
