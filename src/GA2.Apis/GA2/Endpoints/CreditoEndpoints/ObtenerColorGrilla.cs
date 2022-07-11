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
    /// Endpoint para Obtener Color Grilla
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerColorGrilla : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<ColorGrillaDto>>>
    {
        private readonly ICreditoBusinessLogic _colorgrillaBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Color Grilla
        /// </summary>
        /// <param name="colorgrillaBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerColorGrilla(ICreditoBusinessLogic colorgrillaBusinessLogic)
        {
            _colorgrillaBusinessLogic = colorgrillaBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenercolorgrilla")]
        [ProducesResponseType(typeof(Response<IEnumerable<ColorGrillaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene ColorGrilla",
            Description = "Obtiene ColorGrilla",
            OperationId = "credito.obtenercolorgrilla",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ColorGrillaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._colorgrillaBusinessLogic.ObtenerColorGrilla();
        }

    }
}
