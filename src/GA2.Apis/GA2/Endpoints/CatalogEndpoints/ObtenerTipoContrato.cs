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
    /// Obtener Tipo Contrato
    /// </summary>
    [Authorize]
    public class ObtenerTipoContrato : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TipoContratoDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogosBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogosBusinessLogic"></param>
        public ObtenerTipoContrato(ICatalogosBusinessLogic catalogosBusinessLogic)
        {
            _catalogosBusinessLogic = catalogosBusinessLogic;
        }

        // <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpGet("api/catalogos/ObtenerTipoContrato")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoContratoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Tipo Contrato",
            Description = "Obtener Tipo Contrato",
            OperationId = "catalogos.ObtenerTipoContrato",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TipoContratoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _catalogosBusinessLogic.ObtenerTipoContrato();
        }
    }
}
