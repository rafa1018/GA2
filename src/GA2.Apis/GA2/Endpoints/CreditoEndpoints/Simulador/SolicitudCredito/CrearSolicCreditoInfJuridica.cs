using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using GA2.Transversals.Commons.CustomBaseEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Endpoints.CreditoEndpoints.Simulador.SolicitudCredito
{
    /// <summary>
    /// Crear solicitud Credito informacion Juridica
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class CrearSolicCreditoInfJuridica : BaseAsyncEndpoint.WithRequest<SolicCreditoInfJuridicaDto>.WithResponse<Response<SolicCreditoInfJuridicaDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CrearSolicCreditoInfJuridica(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Crea Solicitud Credito Informacion Juridica
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearSolicCreditoInfJuridica")]
        [ProducesResponseType(typeof(Response<SolicCreditoInfJuridicaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Solicitud Credito Informacion Juridica",
            Description = "Crear Solicitud Credito Informacion Juridica",
            OperationId = "credito.CrearSolicCreditoInfJuridica",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SolicCreditoInfJuridicaDto>>> HandleAsync(SolicCreditoInfJuridicaDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.CrearSolicCreditoInfJuridica(request);
        }
    }
}
