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

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// Endpoint para Crear Flujo
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearFlujo :
         BaseAsyncEndpoint.WithRequest<FlujoDto>
        .WithResponse<Response<FlujoDto>>
    {

        private readonly ICreditoBusinessLogic _flujoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Flujo
        /// </summary>
        /// <param name="flujoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearFlujo(ICreditoBusinessLogic flujoBusinessLogic)
        {
            _flujoBusinessLogic = flujoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearflujo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FlujoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear Flujo",
           Description = "Crear Flujo",
           OperationId = "Credito.crearflujo",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<FlujoDto>>> HandleAsync(FlujoDto request, CancellationToken cancellationToken = default)
        {
            return await this._flujoBusinessLogic.CrearFlujo(request);
        }
    }
}

