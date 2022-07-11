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


namespace GA2.Apis.GA2.Endpoints.SolicitudEndPoints
{
    /// <summary>
    /// Endpoint para consultar los archivos de una solicitud
    /// </summary>
    /// <author>Hanson Restrepo</author>
    [Authorize]
    public class ConsultarArchivoPorSolicitud :
         BaseAsyncEndpoint.WithRequest<Guid>
        .WithResponse<Response<IEnumerable<ConsultarArchivoPorSolicitudDto>>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint consultar archivo por solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>07/03/2022</date>
        public ConsultarArchivoPorSolicitud(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }

        /// <summary>
        /// Consulta Archivo al blob storage para solicitud de cesantías
        /// </summary>
        /// <param name="IdSolicitud"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/solicitud/ConsultarArchivoPorSolicitud")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ObtenerTramiteSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Consultar archivos por solicitud",
           Description = "Consultar archivos por solicitud",
           OperationId = "Solicitud.ConsultarArchivoPorSolicitud",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ConsultarArchivoPorSolicitudDto>>>> HandleAsync(Guid IdSolicitud, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.ConsultarArchivoPorSolicitud(IdSolicitud);
        }
    }
}
