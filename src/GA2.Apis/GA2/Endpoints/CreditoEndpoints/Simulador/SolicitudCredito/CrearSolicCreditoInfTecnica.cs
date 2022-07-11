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
    /// Crea solicitud credito informacion tecnica
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class CrearSolicCreditoInfTecnica : BaseAsyncEndpoint.WithRequest<SolicCreditoInfTecnicaDto>.WithResponse<Response<SolicCreditoInfTecnicaDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CrearSolicCreditoInfTecnica(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Crea solicitud credito informacion tecnica
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearSolicCreditoInfTecnica")]
        [ProducesResponseType(typeof(Response<SolicCreditoInfTecnicaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Solicitud Credito Informacion Tecnica",
            Description = "Crear Solicitud Credito Informacion Tecnica",
            OperationId = "credito.CrearSolicCreditoInfTecnica",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SolicCreditoInfTecnicaDto>>> HandleAsync(SolicCreditoInfTecnicaDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.CrearSolicCreditoInfTecnica(request);
        }
    }
}