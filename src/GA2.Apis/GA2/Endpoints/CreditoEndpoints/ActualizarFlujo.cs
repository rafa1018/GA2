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

namespace GA2.Apis.Identity
{
    /// <summary>
	/// Endpoint para Actualizar Flujo
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>11/05/2021</date>
    [Authorize]
    public class ActualizarFlujo :
         BaseAsyncEndpoint.WithRequest<FlujoDto>
        .WithResponse<Response<FlujoDto>>
    {

        private readonly ICreditoBusinessLogic _flujoBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Actualizar Flujo
        /// </summary>
        /// <param name="flujoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ActualizarFlujo(ICreditoBusinessLogic flujoBusinessLogic)
        {
            _flujoBusinessLogic = flujoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name = "request"></param >
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/credito/actualizarflujo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FlujoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Flujo",
           Description = "Actualizar Flujo",
           OperationId = "Credito.actualizarflujo",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<FlujoDto>>> HandleAsync(FlujoDto request, CancellationToken cancellationToken = default)
        {
            return await this._flujoBusinessLogic.ActualizarFlujo(request);
        }
    }
}

