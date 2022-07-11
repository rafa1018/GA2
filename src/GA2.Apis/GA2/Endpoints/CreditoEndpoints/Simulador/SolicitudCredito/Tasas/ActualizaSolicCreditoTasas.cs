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

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.SolicitudCredito.Tasas
{
    /// <summary>
    /// Endpoint que actualiza la tasa en la solicitud de credito
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <Date>02/07/2021</Date>
    [Authorize]
    public class ActualizaSolicCreditoTasas : BaseAsyncEndpoint.WithRequest<TasaSolicitudCreditoDto>.WithResponse<Response<TasaSolicitudCreditoDto>>
    {

        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ActualizaSolicCreditoTasas(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Actualiza Solic Credito Tasas
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/actualizaSolicCreditoTasas")]
        [ProducesResponseType(typeof(Response<TasaSolicitudCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation("Actualiza Solic Credito Tasas",
            Description = "Actualiza Solic Credito Tasas",
            OperationId = "credito.ActualizaSolicCreditoTasas",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<TasaSolicitudCreditoDto>>> HandleAsync(TasaSolicitudCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.ActualizaSolicCreditoTasas(request);
        }
    }
}
