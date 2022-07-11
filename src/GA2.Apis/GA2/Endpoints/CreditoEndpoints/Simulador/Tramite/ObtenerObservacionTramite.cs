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

namespace GA2.Endpoints.CreditoEndpoints.Simulador.Tramite
{
    /// <summary>
    /// Obtiene observacion tramite
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class ObtenerObservacionTramite : BaseAsyncEndpoint.WithRequest<PeticionObtenerObservacionTramiteDto>.WithResponse<Response<IEnumerable<RespuestaObservacionTramiteDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerObservacionTramite(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene observacion tramite
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerObservacionTramite")]
        [ProducesResponseType(typeof(Response<IEnumerable<RespuestaObservacionTramiteDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Observacion Tramite",
            Description = "Obtiene Observacion Tramite",
            OperationId = "credito.ObtenerObservacionTramite",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<RespuestaObservacionTramiteDto>>>> HandleAsync(PeticionObtenerObservacionTramiteDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerObservacionTramite(request);
        }
    }
}
