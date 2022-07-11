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

namespace GA2.Apis.GA2.EndPoints
{
    /// <summary>
	/// Endpoint para actualizar Alertas Automaticas
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerUnidadesEjecutorasCronograma :
         BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<CronogramaDto>>>
    {

        private readonly ICronogramaNovedadesBusinessLogic _cronogramaBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Alerta
        /// </summary>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerUnidadesEjecutorasCronograma(ICronogramaNovedadesBusinessLogic cronogramaNovedadesBusinessLogic)
        {
            _cronogramaBusinessLogic = cronogramaNovedadesBusinessLogic;
        }


        /// <summary>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpGet("api/cronograma/obtenerunidadesejecutorascronograma")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<CronogramaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener unidades ejecutoras cronograma",
           Description = "Obtener unidades ejecutoras cronograma",
           OperationId = "Cronograma.obtenerunidadesejecutorascronograma",
           Tags = new[] { "CronogramaEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<CronogramaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._cronogramaBusinessLogic.ObtenerUnidadesEjecutorasCronograma();
        }
    }
}

