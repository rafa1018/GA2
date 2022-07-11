using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para Obtener los estados de la cartera
    /// </summary>
    /// <author>Sergio Ortega</author>
    /// <date>28/09/2021</date>

    [Authorize]
    public class ObtenerEstadoCartera : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<EstadoCarteraDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogosBusinessLogic;

        /// <summary>
        /// Constructor del endpoint
        /// </summary>
        /// <param name="catalogosBusinessLogic"></param>
        public ObtenerEstadoCartera(ICatalogosBusinessLogic catalogosBusinessLogic)
        {
            _catalogosBusinessLogic = catalogosBusinessLogic;
        }

        /// <summary>
        /// Obtiene los estados del usuario en cartera
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/obtenerEstadoCartera")]
        [ProducesResponseType(typeof(Response<IEnumerable<EstadoCarteraDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ObtenerEstadoCartera",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<EstadoCarteraDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogosBusinessLogic.ObtenerEstadoCartera();
        }

    }
}
