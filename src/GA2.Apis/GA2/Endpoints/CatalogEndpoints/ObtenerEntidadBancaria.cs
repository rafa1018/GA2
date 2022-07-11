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
	/// Endpoint para Obtener Tipos de cuenta
	/// </summary>
	/// <author>Hanson Restrepo</author>
	/// <date>30/11/2021</date>
    [Authorize]
    public class ObtenerEntidadBancaria : BaseAsyncEndpoint
        .WithoutRequest.WithResponse<Response<IEnumerable<EntidadBancariaDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Tipos de cuenta
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>30/11/2021</date>
        public ObtenerEntidadBancaria(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// Obtiene todas las entidades bancarias
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerEntidadBancaria")]
        [ProducesResponseType(typeof(Response<IEnumerable<EntidadBancariaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene entidad bancaria",
            Description = "Obtiene entidad bancaria",
            OperationId = "catalogos.ObtenerEntidadBancaria",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<EntidadBancariaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerEntidadBancaria();
        }
    }
}
