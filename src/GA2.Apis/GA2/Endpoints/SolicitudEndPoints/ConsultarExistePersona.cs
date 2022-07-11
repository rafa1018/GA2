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
    /// Endpoint para consultar si existe un tercero
    /// </summary>
    /// <author>Hanson Restrepo</author>
    // [Authorize]
    public class ConsultarExistePersona :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<TerceroApoderadoRespuestaDto>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint agregar tercero
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>25/04/2022</date>
        public ConsultarExistePersona(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }



        /// <summary>
        /// EndPoint para agregar un tercero a una sección
        /// </summary>
        /// <param name="numeroDocumento"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/solicitud/ConsultarExistePersona")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TerceroApoderadoRespuestaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Consultar existe Persona",
           Description = "Consultar existe Persona",
           OperationId = "Solicitud.ConsultarExistePersona",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<TerceroApoderadoRespuestaDto>>> HandleAsync(string numeroDocumento, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.ConsultarExistePersona(numeroDocumento);
        }
    }
}
