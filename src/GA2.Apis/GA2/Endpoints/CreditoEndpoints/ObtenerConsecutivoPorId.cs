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
    /// Endpoint para Obtener Consecutivo Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerConsecutivoPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<ConsecutivoDto>>
    {

        private readonly ICreditoBusinessLogic _consecutivoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Consecutivo Por Id
        /// </summary>
        /// <param name="consecutivoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerConsecutivoPorId(ICreditoBusinessLogic consecutivoBusinessLogic)
        {
            _consecutivoBusinessLogic = consecutivoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerconsecutivoporid")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ConsecutivoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obetner Consecutivoporid",
           Description = "Obtener Consecutivo por id ",
           OperationId = "credito.obtenerconsecutivoporid",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ConsecutivoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._consecutivoBusinessLogic.ObtenerConsecutivoPorId(request);
        }
    }
}

