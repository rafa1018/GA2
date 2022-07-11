using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CatalogEndpoints
{
    public class ObtenerConceptoNomina :BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<ConceptoNominaDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogos;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogos"></param>
        public ObtenerConceptoNomina (ICatalogosBusinessLogic catalogos)
        {
            _catalogos = catalogos;
        }

        /// <summary>
        /// obtener Abono Unico
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/ObtenerConceptoNomina")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<ConceptoNominaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Obtener conceptos nomina",
            Description = "Obtener conceptos nomina",
            OperationId = "catalogos.ObtenerCategoriasNomina",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ConceptoNominaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogos.ObtenerConceptoNomina();
        }
    }
}
