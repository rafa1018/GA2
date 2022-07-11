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
    /// Endpoint para Crear una inconsistencia de solicitud
    /// </summary>
    /// <author>Hanson Restrepo</author>
    /// <date>31/05/2022</date>
    // [Authorize]
    public class InsertarInconsistenciaSolicitud :
         BaseAsyncEndpoint.WithRequest<InconsistenciaSolicitudDto>
        .WithResponse<Response<InconsistenciaSolicitudDto>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint para Crear una inconsistencia de solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>31/05/2022</date>
        public InsertarInconsistenciaSolicitud(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }



        /// <summary>
        /// EndPoint para crear una inconsistencia de solicitud
        /// </summary>
        /// <param name="insertarInconsistenciaSolicitud"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/solicitud/InsertarInconsistenciaSolicitud")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<InconsistenciaSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Insertar Inconsistencia",
           Description = "Insertar Inconsistencia",
           OperationId = "Solicitud.InsertarInconsistenciaSolicitud",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<InconsistenciaSolicitudDto>>> HandleAsync(InconsistenciaSolicitudDto insertarInconsistenciaSolicitud, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.InsertarInconsistenciaSolicitud(insertarInconsistenciaSolicitud);
        }
    }
}
