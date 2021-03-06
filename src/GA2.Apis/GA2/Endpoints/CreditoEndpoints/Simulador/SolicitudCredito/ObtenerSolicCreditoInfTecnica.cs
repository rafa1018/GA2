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
    /// 
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class ObtenerSolicCreditoInfTecnica : BaseAsyncEndpoint.WithRequest<RequestSolicCreditoInfTecnicaDto>.WithResponse<Response<SolicCreditoInfTecnicaDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerSolicCreditoInfTecnica(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerSolicCreditoInfTecnica")]
        [ProducesResponseType(typeof(Response<SolicCreditoInfTecnicaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Solicitud Credito Informacion Tecnica",
            Description = "Obtener Solicitud Credito Informacion Tecnica",
            OperationId = "credito.ObtenerSolicCreditoInfTecnica",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SolicCreditoInfTecnicaDto>>> HandleAsync(RequestSolicCreditoInfTecnicaDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerSolicCreditoInfTecnica(request);
        }
    }
}
