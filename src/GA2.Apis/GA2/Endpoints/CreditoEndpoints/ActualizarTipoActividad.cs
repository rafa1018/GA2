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
	/// Endpoint para Actualizar Tipo Actividad
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>11/05/2021</date>
    [Authorize]
    public class ActualizarTipoActividad :
         BaseAsyncEndpoint.WithRequest<TipoActividadDto>
        .WithResponse<Response<TipoActividadDto>>
    {

        private readonly ICreditoBusinessLogic _tipoactividadBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Alerta
        /// </summary>
        /// <param name="tipoactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ActualizarTipoActividad(ICreditoBusinessLogic tipoactividadBusinessLogic)
        {
            _tipoactividadBusinessLogic = tipoactividadBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name = "request"></param >
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/credito/actualizartipoactividad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TipoActividadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar TipoActividad",
           Description = "Actualizar TipoActividad",
           OperationId = "Credito.actualizartipoactividad",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<TipoActividadDto>>> HandleAsync(TipoActividadDto request, CancellationToken cancellationToken = default)
        {
            return await this._tipoactividadBusinessLogic.ActualizarTipoActividad(request);
        }
    }
}

