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
    /// Actualiza Solicitud Credito Recomendacion
    /// </summary>
    [Authorize]
    public class ActualizaSolicCreditoRecomendacion : BaseAsyncEndpoint.WithRequest<SolicCreditoRecomendacionDto>.WithResponse<Response<SolicCreditoRecomendacionDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ActualizaSolicCreditoRecomendacion(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Actualiza Solicitud Credito Recomendacion
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/actualizaSolicCreditoRecomendacion")]
        [ProducesResponseType(typeof(Response<SolicCreditoRecomendacionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation("Actualiza Solicitud Credito Recomendacion",
            Description = "Actualiza Solicitud Credito Recomendacion",
            OperationId = "credito.ActualizaSolicCreditoRecomendacion",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SolicCreditoRecomendacionDto>>> HandleAsync(SolicCreditoRecomendacionDto request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.ActualizarSolicCreditoRecomendacion(request);
        }
    }
}
