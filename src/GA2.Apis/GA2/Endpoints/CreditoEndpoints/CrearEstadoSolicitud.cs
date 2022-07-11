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
    /// Endpoint para Crear Estado Solicitud
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearEstadoSolicitud :
         BaseAsyncEndpoint.WithRequest<EstadoSolicitudDto>
        .WithResponse<Response<EstadoSolicitudDto>>
    {

        private readonly ICreditoBusinessLogic _estadosolicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Estado Solicitud
        /// </summary>
        /// <param name="estadosolicitudBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearEstadoSolicitud(ICreditoBusinessLogic estadosolicitudBusinessLogic)
        {
            _estadosolicitudBusinessLogic = estadosolicitudBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearestadosolicitud")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<EstadoSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear EstadoSolicitud",
           Description = "Crear EstadoSolicitud",
           OperationId = "Credito.crearestadosolicitud",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<EstadoSolicitudDto>>> HandleAsync(EstadoSolicitudDto request, CancellationToken cancellationToken = default)
        {
            return await this._estadosolicitudBusinessLogic.CrearEstadoSolicitud(request);
        }
    }
}

