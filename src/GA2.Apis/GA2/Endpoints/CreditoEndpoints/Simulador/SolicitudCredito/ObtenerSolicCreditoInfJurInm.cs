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
    /// Obtiene solicitud credito informacion juridica inmueble
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class ObtenerSolicCreditoInfJurInm : BaseAsyncEndpoint.WithRequest<RequestSolicCreditoInfJurInmDto>.WithResponse<Response<IEnumerable<SolicCreditoInfJurInmDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerSolicCreditoInfJurInm(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene solicitud credito informacion juridica inmueble
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerSolicCreditoInfJurInm")]
        [ProducesResponseType(typeof(Response<IEnumerable<SolicCreditoInfJurInmDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Solicitud Credito Informacion Tecnica Inmueble",
            Description = "Obtiene Solicitud Credito Informacion Tecnica Inmueble",
            OperationId = "credito.ObtenerSolicCreditoInfJurInm",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<SolicCreditoInfJurInmDto>>>> HandleAsync(RequestSolicCreditoInfJurInmDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerSolicCreditoInfJurInm(request);
        }
    }
}
