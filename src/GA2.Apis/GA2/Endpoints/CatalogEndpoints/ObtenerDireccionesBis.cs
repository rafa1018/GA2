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
    /// End catalogo direcciones abecedario
    /// </summary>
    [Authorize]
    public class ObtenerDireccionesBis : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<BisDto>>>
    {

        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// logica catalogos
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public ObtenerDireccionesBis(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// Obtener direcciones tipos
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/obtenerdireccionesbis")]
        [ProducesResponseType(typeof(Response<IEnumerable<BisDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.obtenerdireccionesbis",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<BisDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerDireccionesBis();
        }
    }
}
