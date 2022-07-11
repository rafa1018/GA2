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
    /// Endpoint para Obtener Actividad Flujo
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerActividadFlujo : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<ActividadFlujoDto>>>
    {
        private readonly ICreditoBusinessLogic _actividadflujoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Actividad Flujo
        /// </summary>
        /// <param name="actividadflujoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerActividadFlujo(ICreditoBusinessLogic actividadflujoBusinessLogic)
        {
            _actividadflujoBusinessLogic = actividadflujoBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obteneractividadflujo")]
        [ProducesResponseType(typeof(Response<IEnumerable<ActividadFlujoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene ActividadFlujo",
            Description = "Obtiene ActividadFlujo",
            OperationId = "credito.obteneractividadflujo",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ActividadFlujoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._actividadflujoBusinessLogic.ObtenerActividadFlujo();
        }

    }
}
