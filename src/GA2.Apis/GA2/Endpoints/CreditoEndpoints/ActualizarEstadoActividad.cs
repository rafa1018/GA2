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
	/// Endpoint para actualizar Estado Actividad
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>11/05/2021</date>
    [Authorize]
    public class ActualizarEstadoActividad :
         BaseAsyncEndpoint.WithRequest<EstadoActividadDto>
        .WithResponse<Response<EstadoActividadDto>>
    {

        private readonly ICreditoBusinessLogic _estadoactividadBusinessLogic;

        /// <summary>
        /// Constructor de actualizar Estado Actividad
        /// </summary>
        /// <param name="estadoactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ActualizarEstadoActividad(ICreditoBusinessLogic estadoactividadBusinessLogic)
        {
            _estadoactividadBusinessLogic = estadoactividadBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name = "request"></param >
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/credito/actualizarestadoactividad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<EstadoActividadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar EstadoActividad",
           Description = "Actualizar EstadoActividad",
           OperationId = "Credito.actualizarestadoactividad",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<EstadoActividadDto>>> HandleAsync(EstadoActividadDto request, CancellationToken cancellationToken = default)
        {
            return await this._estadoactividadBusinessLogic.ActualizarEstadoActividad(request);
        }
    }
}

