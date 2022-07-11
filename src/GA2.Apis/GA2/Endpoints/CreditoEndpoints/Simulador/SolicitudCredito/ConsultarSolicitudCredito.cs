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
    /// Endpoint consultar solicitudes de credito
    /// </summary>
    [Authorize]
    public class ConsultarSolicitudCredito : BaseAsyncEndpoint.WithRequest<ConsultaSolicitudCreditoDto>.WithResponse<Response<ConsultaSolicitudCreditoDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ConsultarSolicitudCredito(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Consulta solicitudes de credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/consultarSolicitudCredito")]
        [ProducesResponseType(typeof(Response<ConsultaSolicitudCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation("Consultar Solicitud Credito",
            Description = "Consultar Solicitud Credito",
            OperationId = "credito.ConsultarSolicitudCredito",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ConsultaSolicitudCreditoDto>>> HandleAsync(ConsultaSolicitudCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.ConsultarSolicitudCredito(request);
        }
    }
}
