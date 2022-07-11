using GA2.Domain.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;
using Commons = GA2.Transversals.Commons.CustomBaseEndpoints;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// 
    /// </summary>
    public class GenerarFormatoReparto: Commons.BaseAsyncEndpoint.WithRequest<Guid>.WithResponseCustoms<FileResult>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public GenerarFormatoReparto(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Generar Formato Reparto
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/generarFormatoReparto")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Genera Formato Reparto",
            Description = "Generar Formato Reparto",
            OperationId = "credito.GenerarFormatoReparto",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<FileResult> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.GenerarFormatoReparto(request);
        }
    }
}
