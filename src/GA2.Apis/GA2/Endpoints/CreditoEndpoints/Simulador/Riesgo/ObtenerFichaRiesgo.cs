using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Custom = GA2.Transversals.Commons.CustomBaseEndpoints;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.Riesgo
{
    /// <summary>
    /// 
    /// </summary>
    public class ObtenerFichaRiesgo:Custom.BaseAsyncEndpoint.WithRequest<RequestFichaRiesgo>.WithResponseCustoms<FileResult>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerFichaRiesgo(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerFichaRiesgo")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "ObtenerFichaRiesgo",
            Description = "ObtenerFichaRiesgo",
            OperationId = "credito.ObtenerFichaRiesgo",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<FileResult> HandleAsync(RequestFichaRiesgo request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerFichaRiesgo(request);
        }
    }
}
