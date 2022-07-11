using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CatalogEndpoints
{
    public class ObtenerTipoAfiliacion : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TipoAfiliacionDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogos;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogos"></param>
        public ObtenerTipoAfiliacion(ICatalogosBusinessLogic catalogos)
        {
            _catalogos = catalogos;
        }

        /// <summary>
        /// obtener Abono Unico
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/obtenerTiposAfiliacion")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoAfiliacionDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Obtener Tipos Afiliacion",
            Description = "Obtener Tipos Afiliacion",
            OperationId = "catalogos.obtenerTiposAfiliacion",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TipoAfiliacionDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogos.ObtenerTiposAfiliacion();
        }
    }
}
