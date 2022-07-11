using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// Endpoint para obtener las unidades ejecutoras segun el id enviado
    /// </summary>
    /// <author>Sergio Ortega</author>
    /// <date>11/01/2022</date>
    [Authorize]
    public class ObtenerUnidadesEjecutorasPorId : BaseAsyncEndpoint.WithRequest<UnidadesEjecutorasDto>.WithResponse<Response<IEnumerable<UnidadesEjecutorasDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerUnidadesEjecutorasPorId(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/cartera/obtenerUnidadesEjecutorasPorId")]
        [ProducesResponseType(typeof(Response<IEnumerable<UnidadesEjecutorasDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener Unidades Ejecutoras",
           Description = "Obtener Unidades Ejecutoras",
           OperationId = "cartera.ObtenerUnidadesEjecutorasPorId",
           Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<UnidadesEjecutorasDto>>>> HandleAsync(UnidadesEjecutorasDto request, CancellationToken cancellationToken = default)
        {
            return await _carteraBusinessLogic.ObtenerUnidadesEjecutorasPorId(request);
        }
    }
}
