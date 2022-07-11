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

namespace GA2.Apis.GA2.Endpoints.CatalogEndpoints
{
    /// <summary>
    /// Obtiene los tipos de documento activos
    /// </summary>
    [Authorize]
    public class ObtenerDocumentoTipo:BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TipoIdentificacionDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public ObtenerDocumentoTipo(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpGet("api/catalogos/ObtenerDocumentoTipo")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoIdentificacionDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Tipo de Documento",
            Description = "Obtener Tipo de Documento",
            OperationId = "catalogos.ObtenerCatalogos",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<TipoIdentificacionDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.ObtenerDocumentoTipo();
        }
    }
}
