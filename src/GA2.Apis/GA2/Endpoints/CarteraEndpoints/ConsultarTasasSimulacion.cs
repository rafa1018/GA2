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
    public class ConsultarTasasSimulacion : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TasaSimuladorDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;


        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>

        public ConsultarTasasSimulacion(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpGet("api/credito/ConsultarTasasSimulacion")]
        [ProducesResponseType(typeof(Response<IEnumerable<TasaSimuladorDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Consultar tasas simulacion",
            Description = "Consulta los paramatros de las tasas",
            OperationId = "credito.ConsultarTasas",
            Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TasaSimuladorDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ObtenerTasasSimulador(); 

        }
    }
}
