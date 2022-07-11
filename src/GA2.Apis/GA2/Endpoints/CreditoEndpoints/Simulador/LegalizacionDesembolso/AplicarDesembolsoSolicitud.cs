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

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// Endpoint para aplicar Desembolso
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>22/06/2021</date>
    [Authorize]
    public class AplicarDesembolsoSolicitud :
         BaseAsyncEndpoint.WithRequest<DesembolsoCreditoSolicitudDto>
        .WithResponse<Response<DesembolsoCreditoSolicitudDto>>
    {

        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint aplicar desembolso
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>22/06/2021</date>
        public AplicarDesembolsoSolicitud(ICreditoBusinessLogic creditoBusinessLogic)
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
        [HttpPost("api/credito/AplicarDesembolsoCreditoSolicitud")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<DesembolsoCreditoSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "aplicar Desembolso Credito Solicitud",
           Description = " aplicar Desembolso Credito Solicitud",
           OperationId = "credito.AplicarDesembolsoCreditoSolicitud",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<DesembolsoCreditoSolicitudDto>>> HandleAsync(DesembolsoCreditoSolicitudDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.AplicarDesembolsoSolicitud(request);
        }
    }
}

