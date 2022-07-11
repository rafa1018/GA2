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
    /// Actualiza Solicitud Credito Seguro
    /// </summary>
    [Authorize]
    public class ActualizaSolicCreditoSeguro : BaseAsyncEndpoint.WithRequest<DatosActualizaSolicCreditoSeguroDto>.WithResponse<Response<ConsultaSolicitudCreditoDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ActualizaSolicCreditoSeguro(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Actualiza solicitud credito en campo de seguro
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/actualizaSolicCreditoSeguro")]
        [ProducesResponseType(typeof(Response<ConsultaSolicitudCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation("Actualiza Solicitud Credito Seguro",
            Description = "Actualiza Solicitud Credito Seguro",
            OperationId = "credito.ActualizaSolicCreditoSeguro",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ConsultaSolicitudCreditoDto>>> HandleAsync(DatosActualizaSolicCreditoSeguroDto request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.ActualizaSolicCreditoSeguro(request);
        }
    }
}
