using GA2.Domain.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Commons = GA2.Transversals.Commons.CustomBaseEndpoints;

namespace GA2.Endpoints.CreditoEndpoints.Simulador
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    public class PruebaGenerarPDFPreAprobado : Commons.BaseAsyncEndpoint.WithRequest<string>.WithResponseCustoms<FileResult>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public PruebaGenerarPDFPreAprobado(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene Datos Solicitud Comite
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/pruebaGenerarPDFPreAprobado")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Generar PDF PreAprobado",
            Description = "Generar PDF PreAprobado",
            OperationId = "credito.GenerarPDFPreAprobado",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<FileResult> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.GenerarPDFPreAprobado(request);
        }
    }
}
