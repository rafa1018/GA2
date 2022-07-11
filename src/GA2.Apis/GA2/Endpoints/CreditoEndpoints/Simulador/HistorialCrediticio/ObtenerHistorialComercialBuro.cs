using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
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

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.HistorialCrediticio
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ObtenerHistorialComercialBuro: Commons.BaseAsyncEndpoint.WithRequest<RequestTuDto>.WithResponseCustoms<FileResult>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerHistorialComercialBuro(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene Historial Comercial Buro
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerHistorialComercialBuro")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Historial Comercial Buro",
            Description = "Obtiene Historial Comercial Buro",
            OperationId = "credito.ObtenerHistorialComercialBuro",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<FileResult> HandleAsync(RequestTuDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerHistorialComercialBuro(request);
        }
    }
}
