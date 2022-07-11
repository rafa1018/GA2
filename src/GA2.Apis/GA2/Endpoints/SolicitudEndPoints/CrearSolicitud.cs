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

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary> 
    /// Endpoint para Crear una solicitud
    /// </summary>
    /// <author>Erwin Pantoja España</author>
    /// <date>20/10/2021</date>
    [Authorize]
    public class CrearSolicitud :
         BaseAsyncEndpoint.WithRequest<CrearSolicitudDto>
        .WithResponse<Response<ObtenerTramiteSolicitudDto>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Erwin Pantoja</author>
        /// <date>20/10/2021</date>
        public CrearSolicitud(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }



        /// <summary>
        /// EndPoint para crear una solicitud
        /// </summary>
        /// <param name="crearSolicitudDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/solicitud/crearsolicitud")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ObtenerTramiteSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear Solicitud",
           Description = "Crear Solicitud",
           OperationId = "Solicitud.crearsolicitud",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<ObtenerTramiteSolicitudDto>>> HandleAsync(CrearSolicitudDto crearSolicitudDto, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.CrearSolicitud(crearSolicitudDto);
        }
    }
}
