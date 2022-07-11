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

namespace GA2.Apis.GA2.Endpoints.Prospeccion
{
    [Authorize]
    public class CrearSolicitudCredito:BaseAsyncEndpoint.WithRequest<SolicitudCreditoDto>.WithResponse<Response<SolicitudCreditoDto>>
    {
        private readonly IProspeccionBusinessLogic _prospeccionBusinessLogic;
        public CrearSolicitudCredito(IProspeccionBusinessLogic prospeccionBusinessLogic)
        {
            _prospeccionBusinessLogic = prospeccionBusinessLogic;
        }

        /// <summary>
        ///  Crea Preaprovado
        /// </summary>
        /// <param name = "request" > Peticion usuario</param>
        /// <param name = "cancellationToken" > cancelacion si se desea</param>
        [HttpPost("api/prospeccion/CrearSolicitudCredito")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<SolicitudCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear simulacion Credito",
           Description = "Crea simulacion credito",
           OperationId = "prospeccion.CrearSolicitudCredito",
           Tags = new[] { "ProspeccionEndpoint" })]

        public override async Task<ActionResult<Response<SolicitudCreditoDto>>> HandleAsync(SolicitudCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await _prospeccionBusinessLogic.CrearSolicitudCredito(request);
        }
    }
}
