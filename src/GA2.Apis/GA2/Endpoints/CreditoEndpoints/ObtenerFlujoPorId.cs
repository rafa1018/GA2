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
    /// Endpoint para Obtener Flujo Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerFlujoPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<FlujoDto>>
    {

        private readonly ICreditoBusinessLogic _flujoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Flujo Por Id
        /// </summary>
        /// <param name="flujoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerFlujoPorId(ICreditoBusinessLogic flujoBusinessLogic)
        {
            _flujoBusinessLogic = flujoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerfLujoporid")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FlujoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener Flujo por id",
           Description = "Obtener Flujo por id ",
           OperationId = "credito.obtenerfLujoporid",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<FlujoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._flujoBusinessLogic.ObtenerFlujoPorId(request);
        }
    }
}

