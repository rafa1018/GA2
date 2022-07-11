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
    /// Endpoint para obtener parametrizacion liquidacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    [Authorize]
    public class ObtenerLiquidacion : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<ParametrizacionLiquidacionDto>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Get Liquidacion
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerLiquidacion(IParametrizacionBusinessLogic parametrizationBusinessLogic)
        {
            _parametrizationBusinessLogic = parametrizationBusinessLogic;
        }
        /// <summary>
        /// Obtener parametrizacion de tasas
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/parametrizacion/ObtenerLiquidacion")]
        [ProducesResponseType(typeof(Response<ParametrizacionLiquidacionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene parametrizacion liquidacion",
            Description = "Obtiene parametrizacion liquidacion",
            OperationId = "parametrizacion.getLiquidacion",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<ParametrizacionLiquidacionDto>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _parametrizationBusinessLogic.ObtenerLiquidacion();
        }
    }
}
