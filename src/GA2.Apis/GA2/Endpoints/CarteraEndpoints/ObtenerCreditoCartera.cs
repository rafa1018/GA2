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
    /// Endpoint para obtener un credito desde cartera
    /// </summary>
    /// <author>Sergio Ortega</author>
    /// <date>19/09/2021</date>
    [Authorize]
    public class ObtenerCreditoCartera : BaseAsyncEndpoint.WithRequest<int>.WithResponse<Response<InformacionCreditoDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerCreditoCartera(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerCreditoCartera")]
        [ProducesResponseType(typeof(Response<InformacionCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene el credito de cartera",
           Description = "Obtiene credito cartera",
           OperationId = "credito.ObtenerCreditoCartera",
           Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<InformacionCreditoDto>>> HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ObtenerCreditoCartera(request);
        }
    }
}
