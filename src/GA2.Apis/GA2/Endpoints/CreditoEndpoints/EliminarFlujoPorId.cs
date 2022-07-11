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
    /// Endpoint para Eliminar Flujo Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class EliminarFlujoPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<FlujoDto>>
    {

        private readonly ICreditoBusinessLogic _flujoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Flujo Por Id
        /// </summary>
        /// <param name="flujoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public EliminarFlujoPorId(ICreditoBusinessLogic flujoBusinessLogic)
        {
            _flujoBusinessLogic = flujoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/credito/eliminarflujo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FlujoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Eliminar Flujo",
           Description = "Eliminar Flujo",
           OperationId = "credito.eliminarflujo",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<FlujoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._flujoBusinessLogic.EliminarFlujoPorid(request);
        }
    }
}

