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
	/// Endpoint para Obtener Valor Catalogos
	/// </summary>
	/// <author>Erwin Pantoja España</author>
    [Authorize]
    public class ObtenerValoresCatalogosPorIdCatalogo : BaseAsyncEndpoint
        .WithRequest<int>
        .WithResponse<Response<IEnumerable<CatalogoValorDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Valor Catalogos
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerValoresCatalogosPorIdCatalogo(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene valor catalogos
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="idCatalogo"></param>
        /// <returns></returns>
        [HttpGet("api/Catalogos/ObtenerValoresCatalogosPorIdCatalogo")]
        [ProducesResponseType(typeof(Response<IEnumerable<CatalogoValorDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene valor catalogo",
            Description = "Obtiene valor catalogo",
            OperationId = "catalogos.ObtenerValoresCatalogosPorIdCatalogo",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<CatalogoValorDto>>>> HandleAsync(int idCatalogo, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerValoresCatalogosPorIdCatalogo(idCatalogo);
        }
    }
}
