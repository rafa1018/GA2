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

namespace GA2.Endpoints.CreditoEndpoints.Simulador.Comite
{
    /// <summary>
    /// Endpoint Crea Solicitud Comite Credito
    /// </summary>
    [Authorize]
    public class CrearComiteCreditoSolicitud : BaseAsyncEndpoint.WithRequest<SolicitudComiteCreacionDto>.WithResponse<Response<SolicitudComiteCreacionDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CrearComiteCreditoSolicitud(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Crear Solicitud Comite Credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearComiteCreditoSolicitud")]
        [ProducesResponseType(typeof(Response<SolicitudComiteCreacionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crea Solicitud Comite Credito",
            Description = "Crea Solicitud Comite Credito",
            OperationId = "credito.CrearComiteCreditoSolicitud",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SolicitudComiteCreacionDto>>> HandleAsync(SolicitudComiteCreacionDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.CrearComiteCreditoSolicitud(request);
        }
    }
}


