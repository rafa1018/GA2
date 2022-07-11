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
    /// Endpoint para obtener parametrizacion legal alivio
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    [Authorize]
    public class ObtenerLegalAlivio : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<ParametrizacionLegalAlivioDto>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Get Legal Alivio
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerLegalAlivio(IParametrizacionBusinessLogic parametrizationBusinessLogic)
        {
            _parametrizationBusinessLogic = parametrizationBusinessLogic;
        }
        /// <summary>
        /// Obtener parametrizacion de Alivios
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/parametrizacion/ObtenerLegalAlivio")]
        [ProducesResponseType(typeof(Response<ParametrizacionLegalAlivioDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene parametrizacion legal Alivio",
            Description = "Obtiene parametrizacion legal Alivio",
            OperationId = "parametrizacion.getLegalAlivio",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<ParametrizacionLegalAlivioDto>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _parametrizationBusinessLogic.ObtenerLegalAlivio();
        }
    }
}
