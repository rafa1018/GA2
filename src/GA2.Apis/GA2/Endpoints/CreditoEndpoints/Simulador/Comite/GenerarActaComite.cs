using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Commons = GA2.Transversals.Commons.CustomBaseEndpoints;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.Comite
{
    /// <summary>
    /// Generar actas de comite
    /// </summary>
    //[Authorize]
    public class GenerarActaComite:Commons.BaseAsyncEndpoint.WithRequest<int>.WithResponseCustoms<FileResult>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public GenerarActaComite(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Aprueba Datos Comite Credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/credito/generarActaComite")]
        [ProducesResponseType(typeof(Response<FileResult>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Generar Acta Comite",
            Description = "Generar Acta Comite",
            OperationId = "credito.GenerarActaComite",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<FileResult> HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.GenerarActaComite(request);
        }
    }
}
