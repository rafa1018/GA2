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
    public class CrearCategoria:BaseAsyncEndpoint.WithRequest<CategoriaDto>.WithResponse<Response<CategoriaDto>>
    {
        private readonly ICatalogosBusinessLogic _catalogosBusinessLogic;

        public CrearCategoria(ICatalogosBusinessLogic catalogosBusinessLogic)
        {
            _catalogosBusinessLogic = catalogosBusinessLogic;
        }

        [HttpPost("api/Catalogos/CrearCategoria")]
        [ProducesResponseType(typeof(Response<CategoriaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Categoria",
            Description = "Crear Categoria",
            OperationId = "catalogos.CrearCategoria",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<CategoriaDto>>> HandleAsync(CategoriaDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogosBusinessLogic.CrearCategoria(request);
        }
    }
}
