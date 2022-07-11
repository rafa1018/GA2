using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Endpoints.CreditoEndpoints.Simulador.Comite
{
    /// <summary>
    /// Endpoint Crear integrantes comite
    /// </summary>
    [Authorize]
    public class CrearComiteCreditoIntegrante : BaseAsyncEndpoint.WithRequest<ComiteIntegranteDto>.WithResponse<Response<ComiteIntegranteDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CrearComiteCreditoIntegrante(ICreditoBusinessLogic creditoBusinessLogic)
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
        [HttpPost("api/credito/crearComiteCreditoIntegrante")]
        [ProducesResponseType(typeof(Response<ComiteIntegranteDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Integrante Comite",
            Description = "Crear Integrante Comite",
            OperationId = "credito.CrearComiteCreditoIntegrante",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ComiteIntegranteDto>>> HandleAsync(ComiteIntegranteDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.CrearComiteCreditoIntegrante(request);
        }
    }
}


