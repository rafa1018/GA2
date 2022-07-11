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
    /// Obtener Estratos
    /// </summary>
    [Authorize]
    public class ObtenerEstrato : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<EstratoDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogosBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogosBusinessLogic"></param>
        public ObtenerEstrato(ICatalogosBusinessLogic catalogosBusinessLogic)
        {
            _catalogosBusinessLogic = catalogosBusinessLogic;
        }

        // <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpGet("api/catalogos/ObtenerEstrato")]
        [ProducesResponseType(typeof(Response<IEnumerable<EstratoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Estratos",
            Description = "Obtener Estratos",
            OperationId = "catalogos.ObtenerEstrato",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<EstratoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _catalogosBusinessLogic.ObtenerEstrato();
        }
    }
}
