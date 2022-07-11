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
    /// Endpoint para actualizar parametrizacion liquidacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    [Authorize]
    public class CrearLiquidacion : BaseAsyncEndpoint.WithRequest<ParametrizacionLiquidacionDto>.WithResponse<Response<ParametrizacionLiquidacionDto>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        public CrearLiquidacion(IParametrizacionBusinessLogic parametrizationBusinessLogic)
        {
            _parametrizationBusinessLogic = parametrizationBusinessLogic;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/parametrizacion/CrearLiquidacion")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ParametrizacionLiquidacionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene parametrizacion liquidacion",
            Description = "Obtiene parametrizacion liquidacion",
            OperationId = "parametrizacion.updateCrearLiquidacion",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<ParametrizacionLiquidacionDto>>> HandleAsync(ParametrizacionLiquidacionDto request, CancellationToken cancellationToken = default)
        {
            return await _parametrizationBusinessLogic.CrearLiquidacion(request);
        }
    }
}