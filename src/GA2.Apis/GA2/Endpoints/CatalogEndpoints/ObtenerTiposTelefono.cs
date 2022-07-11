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

namespace GA2.Endpoints.CatalogEndpoints
{
    /// <summary>
    /// Obtener tipos de correo
    /// </summary>
    [Authorize]
    public class ObtenerTiposTelefonos : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<TipoTelefonoDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public ObtenerTiposTelefonos(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene todos los tipos de correo
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/obtenerTiposTelefonos")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoTelefonoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ObtenerTiposTelefonos",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TipoTelefonoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerTiposTelefono();
        }
    }
}
