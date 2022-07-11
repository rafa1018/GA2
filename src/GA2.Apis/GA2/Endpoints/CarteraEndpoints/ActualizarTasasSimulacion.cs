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
    public class ActualizarTasasSimulacion : BaseAsyncEndpoint.WithRequest<TasaSimuladorDto>.WithResponse<Response<TasaSimuladorDto>>
    {
     
        
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;


        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ActualizarTasasSimulacion(ICarteraBusinessLogic carteraBusinessLogic)
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
        [HttpPost("api/cartera/ActualizarTasasSimulacion")]
        [ProducesResponseType(typeof(Response<IEnumerable<TasaSimuladorDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualizar tasas simulacion",
            Description = "Actualizar los paramatros de las tasas",
            OperationId = "credito.ActualizarTasas",
            Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<TasaSimuladorDto>>> HandleAsync(TasaSimuladorDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ActualizarTasasSimulacion(request);
        }
    }
}
