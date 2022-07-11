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
    /// Obtener Tipo Vivienda Propia
    /// </summary>
    [Authorize]
    public class ObtenerTipoViviendaPropia : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TipoViviendaPropiaDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogosBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogosBusinessLogic"></param>
        public ObtenerTipoViviendaPropia(ICatalogosBusinessLogic catalogosBusinessLogic)
        {
            _catalogosBusinessLogic = catalogosBusinessLogic;
        }

        // <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpGet("api/catalogos/ObtenerTipoViviendaPropia")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoViviendaPropiaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Tipo Vivienda Propia",
            Description = "Obtener Tipo Vivienda Propia",
            OperationId = "catalogos.ObtenerTipoViviendaPropia",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TipoViviendaPropiaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _catalogosBusinessLogic.ObtenerTipoViviendaPropia();
        }
    }
}
