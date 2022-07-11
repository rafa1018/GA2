using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
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
    public class CargaDocumentoSolicCreditoBase64 : BaseAsyncEndpoint.WithRequest<Base64FileDto>.WithResponse<Response<string>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CargaDocumentoSolicCreditoBase64(ICreditoBusinessLogic creditoBusinessLogic)
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
        [HttpPost("api/credito/cargaDocumentoSolicCreditoBase64")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation("Carga Archivo al blob storage para solicitud creditoCrear Documento Solicitud Credito",
            Description = "Carga Archivo al blob storage para solicitud credito",
            OperationId = "credito.CargaDocumentoSolicCreditoBase64",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<string>>> HandleAsync(Base64FileDto request, CancellationToken cancellationToken = default)
        {
            
            return await _creditoBusinessLogic.CargaDocumentoSolicCreditoBase64(request);
        }
    }
}
