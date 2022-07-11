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
    /// Endpoint para Eliminar Color Grilla Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class EliminarColorGrillaPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<ColorGrillaDto>>
    {

        private readonly ICreditoBusinessLogic _colorgrillaBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Color Grilla Por Id
        /// </summary>
        /// <param name="colorgrillaBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public EliminarColorGrillaPorId(ICreditoBusinessLogic colorgrillaBusinessLogic)
        {
            _colorgrillaBusinessLogic = colorgrillaBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/credito/eliminarcolorGrilla")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ColorGrillaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Eliminar ColorGrilla",
           Description = "Eliminar ColorGrilla",
           OperationId = "Credito.eliminarcolorGrilla",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ColorGrillaDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._colorgrillaBusinessLogic.EliminarColorGrillaPorid(request);
        }
    }
}

