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
    /// Endpoint para Insert Estado
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>17/05/2021</date>
    [Authorize]
    public class CrearEstado : BaseAsyncEndpoint.WithRequest<EstadoDto>.WithResponse<Response<EstadoDto>>
    {
        private readonly IEstadoBusinessLogic _stateBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Insert Estado
        /// </summary>
        /// <param name="stateBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public CrearEstado(IEstadoBusinessLogic stateBusinessLogic)
        {
            _stateBusinessLogic = stateBusinessLogic;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/estado/CrearEstado")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<EstadoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene estado",
            Description = "Agrega estado",
            OperationId = "estado.insert",
            Tags = new[] { "StateEndPoint" })]
        public async override Task<ActionResult<Response<EstadoDto>>> HandleAsync(EstadoDto request, CancellationToken cancellationToken = default)
        {
            return await _stateBusinessLogic.CrearEstado(request);
        }
    }
}