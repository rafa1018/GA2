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
    /// Crea tipo de documento
    /// </summary>
    [Authorize]
    public class CrearDocumentoTipo:BaseAsyncEndpoint.WithRequest<TipoIdentificacionDto>.WithResponse<Response<TipoIdentificacionDto>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public CrearDocumentoTipo(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/catalogos/CrearDocumentoTipo")]
        [ProducesResponseType(typeof(Response<TipoIdentificacionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Tipo de Documento",
            Description = "Crear Tipo de Documento",
            OperationId = "catalogos.CrearDocumentoTipo",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<TipoIdentificacionDto>>> HandleAsync(TipoIdentificacionDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.CrearDocumentoTipo(request);
        }
    }
}
