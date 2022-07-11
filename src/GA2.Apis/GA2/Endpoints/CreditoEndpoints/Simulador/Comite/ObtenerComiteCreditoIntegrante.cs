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
    public class ObtenerComiteCreditoIntegrante : BaseAsyncEndpoint.WithRequest<IntegrantePorComiteDto>.WithResponse<Response<IEnumerable<IntegrantePorComiteDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerComiteCreditoIntegrante(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Aprueba Datos Comite Credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerComiteCreditoIntegrante")]
        [ProducesResponseType(typeof(IEnumerable<IntegrantePorComiteDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Integrantes Comité Segun Comité",
            Description = "Obtener Integrantes Comité Segun Comité",
            OperationId = "credito.ObtenerComiteCreditoIntegrante",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<IntegrantePorComiteDto>>>> HandleAsync(IntegrantePorComiteDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerComiteCreditoIntegrante(request);
        }
    }
}


