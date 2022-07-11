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
    public class ActualizarCategoria : BaseAsyncEndpoint.WithRequest<CategoriaDto>.WithResponse<Response<CategoriaDto>>
    {
        private readonly ICatalogosBusinessLogic _catalogosBusinessLogic;

        public ActualizarCategoria(ICatalogosBusinessLogic catalogosBusinessLogic)
        {
            _catalogosBusinessLogic = catalogosBusinessLogic;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("api/Catalogos/ActualizarCategoria")]
        [ProducesResponseType(typeof(Response<CategoriaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualiza Categoria",
            Description = "Actualiza Categoria",
            OperationId = "catalogos.ActualizarCategoria",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<CategoriaDto>>> HandleAsync(CategoriaDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogosBusinessLogic.ActualizarCategoria(request);
        }
    }

}
