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
    /// Endpoint para Obtener Estado Solicitud
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerEstadoSolicitud : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<EstadoSolicitudDto>>>
    {
        private readonly ICreditoBusinessLogic _estadosolicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Estado Solicitud
        /// </summary>
        /// <param name="estadosolicitudBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerEstadoSolicitud(ICreditoBusinessLogic estadosolicitudBusinessLogic)
        {
            _estadosolicitudBusinessLogic = estadosolicitudBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerestadosolicitud")]
        [ProducesResponseType(typeof(Response<IEnumerable<EstadoSolicitudDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene EstadoSolicitud",
            Description = "Obtiene EstadoSolicitud",
            OperationId = "credito.obtenerestadosolicitud",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<EstadoSolicitudDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._estadosolicitudBusinessLogic.ObtenerEstadoSolicitud();
        }

    }
}
