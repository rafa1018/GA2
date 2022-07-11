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
	/// Endpoint para actualizar Color Grilla
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>11/05/2021</date>
    [Authorize]
    public class ActualizarColorGrilla :
         BaseAsyncEndpoint.WithRequest<ColorGrillaDto>
        .WithResponse<Response<ColorGrillaDto>>
    {

        private readonly ICreditoBusinessLogic _colorGrillaBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint actualizar Color Grilla
        /// </summary>
        /// <param name="colorGrillaBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ActualizarColorGrilla(ICreditoBusinessLogic colorGrillaBusinessLogic)
        {
            _colorGrillaBusinessLogic = colorGrillaBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name = "request"></param >
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/credito/actualizarcolorgrilla")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ColorGrillaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar ColorGrilla",
           Description = "Actualizar ColorGrilla",
           OperationId = "Credito.actualizarcolorgrilla",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ColorGrillaDto>>> HandleAsync(ColorGrillaDto request, CancellationToken cancellationToken = default)
        {
            return await this._colorGrillaBusinessLogic.ActualizarColorGrilla(request);
        }
    }
}

