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

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// Endpoint para obtener las unidades ejecutoras
    /// </summary>
    /// <author>Sergio Ortega</author>
    /// <date>11/01/2022</date>
    [Authorize]
    public class ConsultarUnidadEjecutora : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<UnidadesEjecutorasDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ConsultarUnidadEjecutora(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpGet("api/cartera/consultarUnidadEjecutora")]
        [ProducesResponseType(typeof(Response<IEnumerable<UnidadesEjecutorasDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene los registros de unidad ejecutora",
            Description = "Obtiene los registros de unidad ejecutora",
            OperationId = "cartera.ConsultarUnidadEjecutora",
            Tags = new[] { "CarteraEndpoint" })]

        public async override Task<ActionResult<Response<IEnumerable<UnidadesEjecutorasDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ConsultarUnidadEjecutora();
        }
    }
}
