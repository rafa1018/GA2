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

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ActualizarLiquidacionGeneral:BaseAsyncEndpoint.WithRequest<DatosLiquidacionDto>.WithResponse<Response<DatosLiquidacionDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ActualizarLiquidacionGeneral(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/cartera/ActualizarLiquidacionGeneral")]
        [ProducesResponseType(typeof(Response<DatosLiquidacionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualizar Liquidacion General",
            Description = "Actualizar Liquidacion General",
            OperationId = "credito.ActualizarLiquidacionGeneral",
            Tags = new[] { "CarteraEndpoint" })]
        public override async Task<ActionResult<Response<DatosLiquidacionDto>>> HandleAsync(DatosLiquidacionDto request, CancellationToken cancellationToken = default)
        {
            return await _carteraBusinessLogic.ActualizarLiquidacionGeneral(request);
        }
    }
}
