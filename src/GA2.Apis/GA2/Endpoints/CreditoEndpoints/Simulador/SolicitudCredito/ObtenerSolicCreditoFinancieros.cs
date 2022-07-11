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

namespace GA2.Endpoints.CreditoEndpoints.Simulador
{
    /// <summary>
    /// Obtiene solicitud credito financiero
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class ObtenerSolicCreditoFinancieros : BaseAsyncEndpoint.WithRequest<PeticionCreditoFinancieroDto>.WithResponse<Response<RespuestaCreditoFinancieroDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerSolicCreditoFinancieros(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene solicitud credito financiero
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerSolicCreditoFinancieros")]
        [ProducesResponseType(typeof(Response<RespuestaCreditoFinancieroDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Solicitud Credito Financieros",
            Description = "Obtiene Solicitud Credito Financieros",
            OperationId = "credito.ObtenerSolicCreditoFinancieros",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<RespuestaCreditoFinancieroDto>>> HandleAsync(PeticionCreditoFinancieroDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerSolicCreditoFinancieros(request);
        }
    }
}
