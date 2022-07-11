using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para consultar las solicitudes de cesantías realizadas
    /// </summary>
    /// <author>Hanson Restrepo</author>
    // [Authorize]
    public class ConsultarSolicitudCesantias :
        BaseAsyncEndpoint.WithRequest<PeticionConsultarSolicitudCesantiasDto>
        .WithResponse<Response<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor Endpoint
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        public ConsultarSolicitudCesantias(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }

        /// <summary>
        /// Endpoint para consultar las solicitudes de cesantías realizadas
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/solicitud/ConsultarSolicitudCesantias")]
        //[Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Consulta solicitudes de cesantías",
            Description = "Consulta solicitudes de cesantías",
            OperationId = "Solicitud.ConsultarSolicitudCesantias",
            Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<RespuestaConsultarSolicitudCesantiasDto>>>> HandleAsync(PeticionConsultarSolicitudCesantiasDto request, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.ConsultarSolicitudCesantias(request);
        }
    }
}
