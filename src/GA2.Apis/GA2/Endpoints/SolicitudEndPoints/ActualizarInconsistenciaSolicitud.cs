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
    /// Endpoint para Actualizar una inconsistencia de solicitud
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>02/06/2022</date>
    // [Authorize]
    public class ActualizarInconsistenciaSolicitud :
         BaseAsyncEndpoint.WithRequest<InconsistenciaSolicitudDto>
        .WithResponse<Response<InconsistenciaSolicitudDto>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint para Actualizar una inconsistencia de solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>02/06/2022</date>
        public ActualizarInconsistenciaSolicitud(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }



        /// <summary>
        /// EndPoint para Actualizar una inconsistencia de solicitud
        /// </summary>
        /// <param name="actualizarInconsistenciaSolicitud"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/solicitud/ActualizarInconsistenciaSolicitud")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<InconsistenciaSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Inconsistencia",
           Description = "Actualizar Inconsistencia",
           OperationId = "Solicitud.ActualizarInconsistenciaSolicitud",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<InconsistenciaSolicitudDto>>> HandleAsync(InconsistenciaSolicitudDto actualizarInconsistenciaSolicitud, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.ActualizarInconsistenciaSolicitud(actualizarInconsistenciaSolicitud);
        }
    }
}
