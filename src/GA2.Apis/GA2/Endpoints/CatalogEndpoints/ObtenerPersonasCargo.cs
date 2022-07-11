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
    /// Obtener Personas a Cargo
    /// </summary>
    [Authorize]
    public class ObtenerPersonasCargo:BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<PersonasCargoDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogosBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogosBusinessLogic"></param>
        public ObtenerPersonasCargo(ICatalogosBusinessLogic catalogosBusinessLogic)
        {
            _catalogosBusinessLogic = catalogosBusinessLogic;
        }

        // <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpGet("api/catalogos/ObtenerPersonasCargo")]
        [ProducesResponseType(typeof(Response<IEnumerable<PersonasCargoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Personas a Cargo",
            Description = "Obtener Personas a cargo",
            OperationId = "catalogos.ObtenerPersonasCargo",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<PersonasCargoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _catalogosBusinessLogic.ObtenerPersonasCargo();
        }
    }
}
