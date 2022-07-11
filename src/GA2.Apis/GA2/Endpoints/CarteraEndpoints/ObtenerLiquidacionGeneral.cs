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

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    [Authorize]
    public class ObtenerLiquidacionGeneral:BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<DatosLiquidacionDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerLiquidacionGeneral(ICarteraBusinessLogic carteraBusinessLogic)
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
        [HttpGet("api/cartera/ObtenerLiquidacionGeneral")]
        [ProducesResponseType(typeof(Response<IEnumerable<DatosLiquidacionDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Liquidacion General",
            Description = "Obtener Liquidacion General",
            OperationId = "credito.ObtenerLiquidacionGeneral",
            Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<DatosLiquidacionDto>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _carteraBusinessLogic.ObtenerLiquidacionGeneral();
        }
    }
}
