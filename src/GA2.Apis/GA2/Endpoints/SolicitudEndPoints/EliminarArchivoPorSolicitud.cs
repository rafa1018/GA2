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
    /// Endpoint para Eliminar archivos de solicitud Por Id
    /// </summary>
    /// <author>Hanson Restrepo</author>
    /// <date>07/03/2022</date>
    [Authorize]
    public class EliminarArchivoPorSolicitud :
         BaseAsyncEndpoint.WithRequest<EliminarArchivoPorSolicitudDto>
        .WithResponse<Response<bool>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Archivo de Solicitud Por Id
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>08/03/2022</date>
        public EliminarArchivoPorSolicitud(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }


        /// <param name="eliminarArchivoPorSolicitudDto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/solicitud/EliminarArchivoPorSolicitud")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation(
               Summary = "Eliminar Archivos de Solicitud por Id",
               Description = "Eliminar Archivos de Solicitud por Id",
               OperationId = "Solicitud.EliminarArchivoPorSolicitud",
               Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<bool>>> HandleAsync(EliminarArchivoPorSolicitudDto eliminarArchivoPorSolicitudDto, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.EliminarArchivoPorSolicitud(eliminarArchivoPorSolicitudDto);
        }
    }
}

