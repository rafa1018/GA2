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


namespace GA2.Apis.GA2.Endpoints.SolicitudEndPoints
{
    /// <summary>
    /// Endpoint para consultar una solicitud
    /// </summary>
    /// <author>Erwin Pantoja España</author>
    [Authorize]
    public class ConsultarExisteSolicitud :
         BaseAsyncEndpoint.WithRequest<ConsultarSolicitudDto>
        .WithResponse<Response<ObtenerTramiteSolicitudDto>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Erwin Pantoja</author>
        /// <date>20/10/2021</date>
        public ConsultarExisteSolicitud(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }



        /// <summary>
        /// EndPoint para crear una solicitud
        /// </summary>
        /// <param name="consultarSolicitudDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/solicitud/ConsultarExisteSolicitud")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ObtenerTramiteSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Consultar existe Solicitud",
           Description = "Consultar existe Solicitud",
           OperationId = "Solicitud.ConsultarExisteSolicitud",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<ObtenerTramiteSolicitudDto>>> HandleAsync(ConsultarSolicitudDto consultarSolicitudDto, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.ConsultarExisteSolicitud(consultarSolicitudDto);
        }
    }
}
