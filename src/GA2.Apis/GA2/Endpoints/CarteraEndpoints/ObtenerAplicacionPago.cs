using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ObtenerAplicacionPago:BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<IEnumerable<AplicacionPagoDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerAplicacionPago(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/cartera/ObtenerAplicacionPago")]
        [ProducesResponseType(typeof(Response<IEnumerable<TasaSimuladorDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener Pagos aplicados",
           Description = "Obtener Pagos aplicado",
           OperationId = "cartera.ObtenerAplicacionPago",
           Tags = new[] { "CarteraEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<AplicacionPagoDto>>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await _carteraBusinessLogic.ObtenerAplicacionPago(request);
        }
    }
}
