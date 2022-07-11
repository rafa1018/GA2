using Ardalis.ApiEndpoints;
using GA2.Domain.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Commons = GA2.Transversals.Commons.CustomBaseEndpoints;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// Endpoint que genera documento para cesion de leasing
    /// </summary>
    [Authorize]
    public class GenerarCesionLeasing : Commons.BaseAsyncEndpoint.WithRequest<Guid>.WithResponseCustoms<FileResult>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public GenerarCesionLeasing(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Envia Subsanacion Actividad Tramite
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/credito/generarCesionLeasing")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Genera Cesion Leasing",
            Description = "Generar Cesion Leasing",
            OperationId = "credito.GenerarCesionLeasing",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<FileResult> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.GenerarCesionLeasing(request);
        }
    }
}
