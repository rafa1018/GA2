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
    /// Endpoint para Crear ColorGrilla
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearColorGrilla :
         BaseAsyncEndpoint.WithRequest<ColorGrillaDto>
        .WithResponse<Response<ColorGrillaDto>>
    {

        private readonly ICreditoBusinessLogic _colorgrillaBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Color Grilla
        /// </summary>
        /// <param name="colorgrillaBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearColorGrilla(ICreditoBusinessLogic colorgrillaBusinessLogic)
        {
            _colorgrillaBusinessLogic = colorgrillaBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearcolorgrilla")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ColorGrillaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear ColorGrilla",
           Description = "Crear ColorGrilla",
           OperationId = "Credito.crearcolorgrilla",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ColorGrillaDto>>> HandleAsync(ColorGrillaDto request, CancellationToken cancellationToken = default)
        {
            return await this._colorgrillaBusinessLogic.CrearColorGrilla(request);
        }
    }
}

