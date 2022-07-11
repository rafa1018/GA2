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
	/// Endpoint para Obtener Todas las tareas
	/// </summary>
	/// <author>Hanson Restrepo</author>
	/// <date>26/10/2021</date>
    ///[Authorize]
    public class ObtenerTareas : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<TareaDto>>>
    {
        private readonly ITareaBusinessLogic _tareaBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Tareas
        /// </summary>
        /// <param name="tareaBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>26/10/2021</date>
        public ObtenerTareas(ITareaBusinessLogic tareaBusinessLogic)
        {
            _tareaBusinessLogic = tareaBusinessLogic;
        }

        /// <summary>
        /// Endpoint para obtener todas las tareas
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Bpm/ObtenerTareas")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<TareaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene todas las tareas",
            Description = "Método para obtener todas las tareas ",
            OperationId = "Bpm.ObtenerTareas",
            Tags = new[] { "BpmEndpoints" })]
        public async override Task<ActionResult<Response<IEnumerable<TareaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._tareaBusinessLogic.ObtenerTareas();
        }
    }
}
