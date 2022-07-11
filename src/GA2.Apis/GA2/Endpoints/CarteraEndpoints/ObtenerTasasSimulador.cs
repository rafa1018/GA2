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
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ObtenerTasasSimulador : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TasaSimuladorDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerTasasSimulador(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/cartera/obtenerTasasSimulador")]
        [ProducesResponseType(typeof(Response<IEnumerable<TasaSimuladorDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener Tasas Simulador",
           Description = "Obtener Tasas Simulador",
           OperationId = "cartera.ObtenerTasasSimulador",
           Tags = new[] { "CarteraEndpoint" })]
        
        public override async Task<ActionResult<Response<IEnumerable<TasaSimuladorDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _carteraBusinessLogic.ObtenerTasasSimulador();
        }
    }
}
