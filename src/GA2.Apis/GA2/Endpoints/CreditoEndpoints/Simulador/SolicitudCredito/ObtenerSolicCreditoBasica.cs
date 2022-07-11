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

namespace GA2.Endpoints.CreditoEndpoints.Simulador
{
    /// <summary>
    /// Obtiene solicitud  credito basica
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class ObtenerSolicCreditoBasica : BaseAsyncEndpoint.WithRequest<PeticionCreditoBasicaDto>.WithResponse<Response<RespuestaCreditoBasicaDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerSolicCreditoBasica(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        ///  Obtiene solicitud  credito basica
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerSolicCreditoBasica")]
        [ProducesResponseType(typeof(Response<RespuestaCreditoBasicaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Solicitud Credito Basica",
            Description = "Obtiene Solicitud Credito Basica",
            OperationId = "credito.ObtenerSolicCreditoBasica",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<RespuestaCreditoBasicaDto>>> HandleAsync(PeticionCreditoBasicaDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerSolicCreditoBasica(request);
        }
    }
}
