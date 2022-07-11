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
	/// <author>Erwin Pantoja España</author>
	/// <date>22/09/2021</date>
    [Authorize]
    public class ObtenerTipoCuenta : BaseAsyncEndpoint
        .WithoutRequest.WithResponse<Response<IEnumerable<TipoCuentaDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Tipos de cuenta
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Erwin Pantoja</author>
        /// <date>22/09/2021</date>
        public ObtenerTipoCuenta(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// Obtiene todas los tipos de cuenta
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerTipoCuenta")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoCuentaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene tipos de cuenta",
            Description = "Obtiene tipos de cuenta",
            OperationId = "catalogos.ObtenerTipoCuenta",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<TipoCuentaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerTipoCuenta();
        }
    }
}
