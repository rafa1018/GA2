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
    /// Endpoint para Obtener Tipo Actividad
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerTipoActividad : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TipoActividadDto>>>
    {
        private readonly ICreditoBusinessLogic _tipoactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Tipo Actividad
        /// </summary>
        /// <param name="tipoactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerTipoActividad(ICreditoBusinessLogic tipoactividadBusinessLogic)
        {
            _tipoactividadBusinessLogic = tipoactividadBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenertipoactividad")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoActividadDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene TipoActividad",
            Description = "Obtiene TipoActividad",
            OperationId = "credito.obtenertipoactividad",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TipoActividadDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._tipoactividadBusinessLogic.ObtenerTipoActividad();
        }

    }
}
