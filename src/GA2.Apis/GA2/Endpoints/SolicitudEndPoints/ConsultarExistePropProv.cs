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
    /// Endpoint para consultar si existe un propietario
    /// </summary>
    /// <author>Hanson Restrepo</author>
    // [Authorize]
    public class ConsultarExistePropProv :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<TerceroApoderadoRespuestaDto>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint agregar propietario
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>05/05/2022</date>
        public ConsultarExistePropProv(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }



        /// <summary>
        /// EndPoint para agregar un propietario a una sección
        /// </summary>
        /// <param name="numeroIdentificacion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/solicitud/ConsultarExistePropProv")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TerceroApoderadoRespuestaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Consultar existe Propietario",
           Description = "Consultar existe Propietario",
           OperationId = "Solicitud.ConsultarExistePropProv",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<TerceroApoderadoRespuestaDto>>> HandleAsync(string numeroIdentificacion, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.ConsultarExistePropProv(numeroIdentificacion);
        }
    }
}
