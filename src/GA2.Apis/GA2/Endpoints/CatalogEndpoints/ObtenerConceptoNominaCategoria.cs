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
    /// ObtenerConceptoNominaCategoria
    /// </summary>
    [Authorize]
    public class ObtenerConceptoNominaCategoria : BaseAsyncEndpoint
        .WithRequest<ConceptoNominaDto>.WithResponse<Response<IEnumerable<ConceptoNominaDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        public ObtenerConceptoNominaCategoria(ICatalogosBusinessLogic catalogsBusinessLogic)
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
        [HttpPost("api/Catalogos/obtenerConceptoNominaCategoria")]
        [ProducesResponseType(typeof(Response<IEnumerable<ConceptoNominaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.obtenerconceptoNominaCategoria",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ConceptoNominaDto>>>> HandleAsync(ConceptoNominaDto request, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerConceptoNominaCat(request);
        }
    }
}
