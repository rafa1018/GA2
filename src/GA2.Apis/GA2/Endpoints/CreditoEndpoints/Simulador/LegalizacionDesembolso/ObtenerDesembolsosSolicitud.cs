using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// Obtener Solicitud Desembolsos 
    /// </summary>
    [Authorize]
    public class ObtenerDesembolsosSolicitud : BaseAsyncEndpoint.WithRequest<SolicitudDesembolsoDto>.WithResponse<Response<IEnumerable<SolicitudDesembolsoDto>>>
    {

        private readonly ICreditoBusinessLogic _creditoBusinessLogic;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerDesembolsosSolicitud(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Aprueba actividad tramite
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerDesembolsosSolicitud")]
        [ProducesResponseType(typeof(Response<IEnumerable<SolicitudDesembolsoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Desembolsos Solicitud",
            Description = "Obtener Desembolsos Solicitud",
            OperationId = "credito.ObtenerDesembolsosSolicitud",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<SolicitudDesembolsoDto>>>> HandleAsync(SolicitudDesembolsoDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerDesembolsosSolicitud(request);
        }
    }
}
