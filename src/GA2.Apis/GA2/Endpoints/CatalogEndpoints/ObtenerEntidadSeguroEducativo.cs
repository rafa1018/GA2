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
	/// Endpoint para Obtener Entidades de ahorro programado o seguro educativo
	/// </summary>
	/// <author>Hanson Restrepo</author>
	/// <date>10/02/2022</date>
    [Authorize]
    public class ObtenerEntidadSeguroEducativo : BaseAsyncEndpoint
        .WithoutRequest.WithResponse<Response<IEnumerable<EntidadSeguroEducativoDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Entidades de ahorro programado o seguro educativo
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>10/02/2022</date>
        public ObtenerEntidadSeguroEducativo(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// Obtiene todas las Entidades de ahorro programado o seguro educativo
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerEntidadSeguroEducativo")]
        [ProducesResponseType(typeof(Response<IEnumerable<EntidadSeguroEducativoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene entidad de ahorro programado o seguro educativo",
            Description = "Obtiene entidad de ahorro programado o seguro educativo",
            OperationId = "catalogos.ObtenerEntidadSeguroEducativo",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<EntidadSeguroEducativoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerEntidadSeguroEducativo();
        }
    }
}
