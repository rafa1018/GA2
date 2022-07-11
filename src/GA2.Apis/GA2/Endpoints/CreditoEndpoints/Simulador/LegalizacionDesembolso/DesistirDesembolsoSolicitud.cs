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
    /// Desistir Desembolso Solicitud
    /// </summary>
    [Authorize]
    public class DesistirDesembolsoSolicitud:BaseAsyncEndpoint.WithRequest<DesistimientoDesembolsoDto>.WithResponse<Response<DesistimientoDesembolsoDto>>
    {

        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public DesistirDesembolsoSolicitud(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Desistir Desembolso Solicitud
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/credito/desistirDesembolsoSolicitud")]
        [ProducesResponseType(typeof(Response<DesistimientoDesembolsoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Desistir Desembolso Solicitud",
            Description = "Desistir Desembolso Solicitud",
            OperationId = "credito.DesistirDesembolsoSolicitud",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<DesistimientoDesembolsoDto>>> HandleAsync(DesistimientoDesembolsoDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.DesistirDesembolsoSolicitud(request);
        }
    }
}
