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
    /// 
    /// </summary>
    [Authorize]
    public class CrearSolicCreditoDesembolsos : BaseAsyncEndpoint.WithRequest<IEnumerable<SolicitudCreditosDesembolsosDto>>.WithResponse<Response<IEnumerable<SolicitudCreditosDesembolsosDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CrearSolicCreditoDesembolsos(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Aprueba actividad tramite
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearSolicCreditoDesembolsos")]
        [ProducesResponseType(typeof(Response<IEnumerable<SolicitudCreditosDesembolsosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Solic Credito Desembolsos",
            Description = "Crear Solic Credito Desembolsos",
            OperationId = "credito.CrearSolicCreditoDesembolsos",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<SolicitudCreditosDesembolsosDto>>>> HandleAsync(IEnumerable<SolicitudCreditosDesembolsosDto> request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.CrearSolicCreditoDesembolsos(request);
        }
    }
}
