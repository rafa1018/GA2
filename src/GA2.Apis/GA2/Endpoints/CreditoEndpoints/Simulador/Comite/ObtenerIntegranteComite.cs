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

namespace GA2.Endpoints.CreditoEndpoints.Simulador.Comite
{
    /// <summary>
    /// Endpoint Obtener integrantes comite
    /// </summary>
    [Authorize]
    public class ObtenerIntegranteComite : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<IntegranteComiteDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerIntegranteComite(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Aprueba Datos Comite Credito
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerIntegranteComite")]
        [ProducesResponseType(typeof(IEnumerable<IntegranteComiteDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Integrante Comite",
            Description = "Obtener Integrante Comite",
            OperationId = "credito.ObtenerIntegranteComite",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<IntegranteComiteDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerIntegranteComite();
        }
    }
}


