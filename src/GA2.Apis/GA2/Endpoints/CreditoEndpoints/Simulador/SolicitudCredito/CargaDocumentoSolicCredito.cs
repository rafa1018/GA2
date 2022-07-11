using Ardalis.ApiEndpoints;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Endpoints.CreditoEndpoints.Simulador.SolicitudCredito
{
    /// <summary>
    /// Endpoint carga documento solicitud credito
    /// </summary>
    [Authorize]
    public class CargaDocumentoSolicCredito : BaseAsyncEndpoint.WithRequest<IFormFile>.WithResponse<Response<string>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CargaDocumentoSolicCredito(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Carga Archivo al blob storage para solicitud credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/cargaDocumentoSolicCredito")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation("Carga Archivo al blob storage para solicitud creditoCrear Documento Solicitud Credito",
            Description = "Carga Archivo al blob storage para solicitud credito",
            OperationId = "credito.CargaDocumentoSolicCredito",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<string>>> HandleAsync(IFormFile request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.CargaDocumentoSolicCredito(request);
        }
    }
}
