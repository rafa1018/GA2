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

namespace GA2.Apis.GA2.Endpoints.CatalogEndpoints
{
    [Authorize]
    public class ActualizarDocumentoTipo:BaseAsyncEndpoint.WithRequest<TipoIdentificacionDto>.WithResponse<Response<TipoIdentificacionDto>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public ActualizarDocumentoTipo(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        [HttpPatch("api/catalogos/ActualizarDocumentoTipo")]
        [ProducesResponseType(typeof(Response<TipoIdentificacionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualizar Tipo de Documento",
            Description = "Actualizar Tipo de Documento",
            OperationId = "catalogos.ActualizarDocumentoTipo",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<TipoIdentificacionDto>>> HandleAsync(TipoIdentificacionDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.ActualizarDocumentoTipo(request);
        }
    }
}
