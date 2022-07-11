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

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para Obtener Flujo
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerFlujo : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<FlujoDto>>>
    {
        private readonly ICreditoBusinessLogic _flujoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Flujo
        /// </summary>
        /// <param name="flujoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerFlujo(ICreditoBusinessLogic flujoBusinessLogic)
        {
            _flujoBusinessLogic = flujoBusinessLogic;
        }


        /// <summary>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerflujo")]
        [ProducesResponseType(typeof(Response<IEnumerable<FlujoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Flujo",
            Description = "Obtiene Flujo",
            OperationId = "credito.obtenerflujo",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<FlujoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._flujoBusinessLogic.ObtenerFlujo();
        }

    }
}
