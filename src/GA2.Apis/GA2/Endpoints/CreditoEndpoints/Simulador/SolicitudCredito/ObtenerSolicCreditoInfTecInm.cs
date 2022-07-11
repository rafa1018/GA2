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

namespace GA2.Endpoints.CreditoEndpoints.Simulador.SolicitudCredito
{
    /// <summary>
    /// Obtiene solicitud credito informacion tecnica inmueble
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class ObtenerSolicCreditoInfTecInm : BaseAsyncEndpoint.WithRequest<RequestSolicCreditoInfTecInmDto>.WithResponse<Response<IEnumerable<SolicCreditoInfTecInmDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerSolicCreditoInfTecInm(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene solicitud credito informacion tecnica inmueble
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerSolicCreditoInfTecInm")]
        [ProducesResponseType(typeof(Response<IEnumerable<SolicCreditoInfTecInmDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Solicitud Credito Informacion Tecnica Inmueble",
            Description = "Obtiene Solicitud Credito Informacion Tecnica Inmueble",
            OperationId = "credito.ObtenerSolicCreditoInfTecInm",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<SolicCreditoInfTecInmDto>>>> HandleAsync(RequestSolicCreditoInfTecInmDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerSolicCreditoInfTecInm(request);
        }
    }
}
