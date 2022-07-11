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

namespace GA2.Endpoints.Credito.Simulador
{
    /// <summary>
    /// Envia Subsanacion Actividad Tramite
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class EnviaSubsancionActividadTramite :
        BaseAsyncEndpoint
        .WithRequest<ActividadTramiteSolicitudDto>
        .WithResponse<Response<ActualizaActividadTramiteDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public EnviaSubsancionActividadTramite(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Envia Subsanacion Actividad Tramite
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPut("api/credito/enviaSubsancionActividadTramite")]
        [ProducesResponseType(typeof(Response<ActividadTramiteSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualiza Subsanar de la actividad del tramite del flujo",
            Description = "Actualiza Subsanar de la actividad del tramite del flujo",
            OperationId = "credito.EnviaSubsancionActividadTramite",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ActualizaActividadTramiteDto>>> HandleAsync(ActividadTramiteSolicitudDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.EnviaSubsancionActividadTramite(request);
        }
    }
}
