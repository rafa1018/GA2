using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Endpoints.Credito.Simulador
{
    /// <summary>
    /// Endpoint para obtener el flujo de los documentos
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class ObtenerDocumentosFlujo : BaseAsyncEndpoint.WithRequest<PeticionFlujoDocumentosDto>.WithResponse<Response<IEnumerable<RespuestaFlujoDocumentosDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerDocumentosFlujo(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene Documentos Flujo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerDocumentosFlujo")]
        [ProducesResponseType(typeof(Response<IEnumerable<RespuestaFlujoDocumentosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene el flujo de los documentos",
            Description = "Obtiene el flujo de los documentos",
            OperationId = "credito.ObtenerDocumentosFlujo",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<RespuestaFlujoDocumentosDto>>>> HandleAsync(PeticionFlujoDocumentosDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerDocumentosFlujo(request);
        }
    }
}
