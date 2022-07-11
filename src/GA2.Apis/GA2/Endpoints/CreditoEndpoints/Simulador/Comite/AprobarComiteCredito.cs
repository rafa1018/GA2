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
    /// Endpoint Aprobar datos de comite credito
    /// </summary>
    [Authorize]
    public class AprobarComiteCredito : BaseAsyncEndpoint.WithRequest<DatosComiteCreditoDto>.WithResponse<Response<DatosComiteCreditoDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public AprobarComiteCredito(ICreditoBusinessLogic creditoBusinessLogic)
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
        [HttpPost("api/credito/aprobarComiteCredito")]
        [ProducesResponseType(typeof(Response<DatosComiteCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Aprueba Datos Comite Credito",
            Description = "Aprueba Datos Comite Credito",
            OperationId = "credito.AprobarComiteCredito",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<DatosComiteCreditoDto>>> HandleAsync(DatosComiteCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.AprobarComiteCredito(request);
        }
    }
}


