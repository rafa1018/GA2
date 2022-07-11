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
    /// Actualizacion Solicitud Desembolso
    /// </summary>
    [Authorize]
    public class ActualizaSolicCreditoDesembolso:BaseAsyncEndpoint.WithRequest<ActualizacionSolicitudCreditoDesemFirmaDto>.WithResponse<Response<ActualizacionSolicitudCreditoDesemFirmaDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ActualizaSolicCreditoDesembolso(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }


        /// <summary>
        /// actualiza SolicCredito Desembolso
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/actualizaSolicCreditoDesembolso")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ActualizacionSolicitudCreditoDesemFirmaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualiza Solic Credito Desembolso",
           Description = "Actualiza Solic Credito Desembolso",
           OperationId = "credito.ActualizaSolicCreditoDesembolso",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ActualizacionSolicitudCreditoDesemFirmaDto>>> HandleAsync(ActualizacionSolicitudCreditoDesemFirmaDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ActualizaSolicCreditoDesembolso(request);
        }
    }
}
