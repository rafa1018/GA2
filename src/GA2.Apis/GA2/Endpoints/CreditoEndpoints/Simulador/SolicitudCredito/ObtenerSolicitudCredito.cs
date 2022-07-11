using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.SolicitudCredito
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    public class ObtenerSolicitudCredito : BaseAsyncEndpoint.WithRequest<RequestSolicitudCreditoDto>.WithResponse<Response<ActualizacionSolicitudCreditoDesemFirmaDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerSolicitudCredito(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene solicitud Credito 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpGet("api/credito/obtenerSolicitudCredito")]
        [ProducesResponseType(typeof(Response<ActualizacionSolicitudCreditoDesemFirmaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Solicitud Credito ",
            Description = "Obtiene Solicitud Credito ",
            OperationId = "credito.ObtenerSolicCredito",
            Tags = new[] { "CreditoEndpoint" })]

        public async override Task<ActionResult<Response<ActualizacionSolicitudCreditoDesemFirmaDto>>> HandleAsync([FromQuery]RequestSolicitudCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerSolicitudCredito(request);
        }
    }
}
