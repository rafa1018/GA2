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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// Endpoint para aplicar pago cartera
    /// </summary>
    /// <author>Sergio Ortega</author>
    /// <date>19/09/2021</date>
    [Authorize]
    public class AplicarPago:BaseAsyncEndpoint.WithRequest<PagoAplicarDto>.WithResponse<Response<AplicacionPagoDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public AplicarPago(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/aplicarPago")]
        [ProducesResponseType(typeof(Response<AplicacionPagoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Aplicar Pago",
           Description = "Aplicar Pago",
           OperationId = "credito.AplicarPago",
           Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<AplicacionPagoDto>>> HandleAsync(PagoAplicarDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.AplicarPago(request);
        }
    }
}
