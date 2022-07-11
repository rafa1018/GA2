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

namespace GA2.Endpoints
{
    /// <summary>
    /// ObtenerGradosPorFuerzaCategoria
    /// </summary>
    [Authorize]
    public class ObtenerGradosPorFuerzaCategoria : BaseAsyncEndpoint
        .WithRequest<GradoDto>.WithResponse<Response<IEnumerable<GradoDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        public ObtenerGradosPorFuerzaCategoria(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">Grado</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/Catalogos/obtenergradosPorFuerzaCategoria")]
        [ProducesResponseType(typeof(Response<IEnumerable<GradoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.obtenergradosPorFuerzaCategoria",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<GradoDto>>>> HandleAsync(GradoDto request,  CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerGradosPorFuerzaCategoria(request);
        }
    }
}
