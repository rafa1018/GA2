using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para consultar las inconsistencias de una solicitud
    /// </summary>
    /// <author>Hanson Restrepo</author>
    // [Authorize]
    public class ConsultarInconsistenciaSolicitud :
         BaseAsyncEndpoint.WithRequest<Guid>
        .WithResponse<Response<IEnumerable<InconsistenciaSolicitudDto>>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint consultar las inconsistencias de una solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>07/063/2022</date>
        public ConsultarInconsistenciaSolicitud(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }

        /// <summary>
        /// Consulta las inconsistencias de una solicitud
        /// </summary>
        /// <param name="IdSolicitud"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/solicitud/ConsultarInconsistenciaSolicitud")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ObtenerTramiteSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Consultar Inconsistencia por solicitud",
           Description = "Consultar Inconsistencia por solicitud",
           OperationId = "Solicitud.ConsultarInconsistenciaSolicitud",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<InconsistenciaSolicitudDto>>>> HandleAsync(Guid IdSolicitud, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.ConsultarInconsistenciaSolicitud(IdSolicitud);
        }
    }
}
