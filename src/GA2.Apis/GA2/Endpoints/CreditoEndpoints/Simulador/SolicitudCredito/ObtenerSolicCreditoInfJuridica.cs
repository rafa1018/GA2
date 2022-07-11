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

namespace GA2.Endpoints.CreditoEndpoints.Simulador.SolicitudCredito
{
    /// <summary>
    /// Obtiene solicitud credito informacion juridica
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class ObtenerSolicCreditoInfJuridica : BaseAsyncEndpoint.WithRequest<RequestSolicCreditoInfJuridicaDto>.WithResponse<Response<SolicCreditoInfJuridicaDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerSolicCreditoInfJuridica(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene solicitud credito informacion juridica
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerSolicCreditoInfJuridica")]
        [ProducesResponseType(typeof(Response<SolicCreditoInfJuridicaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Solicitud Credito Informacion Juridica",
            Description = "Obtiene Solicitud Credito Informacion Juridica",
            OperationId = "credito.ObtenerSolicCreditoInfJuridica",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SolicCreditoInfJuridicaDto>>> HandleAsync(RequestSolicCreditoInfJuridicaDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerSolicCreditoInfJuridica(request);
        }
    }
}
