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

namespace GA2.Endpoints.CreditoEndpoints.Simulador.Comite
{
    /// <summary>
    /// Endpoint Obtiene Solicitud Comite Credito
    /// </summary>
    [Authorize]
    public class ObtenerComiteCreditoSolicitud : BaseAsyncEndpoint.WithRequest<SolicitudComiteDto>.WithResponse<Response<IEnumerable<SolicitudComiteDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerComiteCreditoSolicitud(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene Solicitud Comite Credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerComiteCreditoSolicitud")]
        [ProducesResponseType(typeof(Response<IEnumerable<SolicitudComiteDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Solicitud Comite Credito",
            Description = "Obtiene Solicitud Comite Credito",
            OperationId = "credito.ObtenerComiteCreditoSolicitud",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<SolicitudComiteDto>>>> HandleAsync(SolicitudComiteDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerComiteCreditoSolicitud(request);
        }
    }
}


