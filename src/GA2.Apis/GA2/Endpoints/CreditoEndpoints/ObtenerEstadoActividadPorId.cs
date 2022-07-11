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
    /// Endpoint para Obtener Estado Actividad Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerEstadoActividadPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<EstadoActividadDto>>
    {

        private readonly ICreditoBusinessLogic _estadoactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Estado Actividad Por Id
        /// </summary>
        /// <param name="estadoactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerEstadoActividadPorId(ICreditoBusinessLogic estadoactividadBusinessLogic)
        {
            _estadoactividadBusinessLogic = estadoactividadBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerestadoactividadporid")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<EstadoActividadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener EstadoActividadporid",
           Description = "Obtener Estado Actividad por id",
           OperationId = "credito.obtenerestadoactividadporid",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<EstadoActividadDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._estadoactividadBusinessLogic.ObtenerEstadoActividadPorId(request);
        }
    }
}

