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
    /// Endpoint para obtener documentos Act Solicitud
    /// <author>Nicolas Florez Sarrazola</author>
    /// </summary>
    [Authorize]
    public class ObtenerDocumentosActSolicitud : BaseAsyncEndpoint.WithRequest<DocumentosActSolicitudDto>.WithResponse<Response<IEnumerable<DocumentosActRespuestaDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerDocumentosActSolicitud(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Metodo que obtiene los documentos
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerDocumentosActSolicitud")]
        [ProducesResponseType(typeof(Response<IEnumerable<DocumentosActRespuestaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Documentos Act",
            Description = "Obtiene Documentos Act",
            OperationId = "credito.ObtenerDocumentosActSolicitud",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<DocumentosActRespuestaDto>>>> HandleAsync(DocumentosActSolicitudDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerDocumentosActSolicitud(request);
        }
    }
}
