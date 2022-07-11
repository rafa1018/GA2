using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// Actualiza Solic Credito Firmas
    /// </summary>
    [Authorize]
    public class ActualizaSolicCreditoFirmas:BaseAsyncEndpoint.WithRequest<ActualizacionSolicitudCreditoDesemFirmaDto>.WithResponse<Response<ActualizacionSolicitudCreditoDesemFirmaDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ActualizaSolicCreditoFirmas(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// actualizaSolicCreditoFirmas
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/actualizaSolicCreditoFirmas")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ActualizacionSolicitudCreditoDesemFirmaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualiza Solic Credito Firmas",
           Description = "Actualiza Solic Credito Firmas",
           OperationId = "credito.ActualizaSolicCreditoFirmas",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ActualizacionSolicitudCreditoDesemFirmaDto>>> HandleAsync(ActualizacionSolicitudCreditoDesemFirmaDto request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.ActualizaSolicCreditoFirmas(request);
        }
    }
}
