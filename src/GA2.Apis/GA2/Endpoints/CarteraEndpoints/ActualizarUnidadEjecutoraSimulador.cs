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
    /// 
    /// </summary>
    [Authorize]
    public class ActualizarUnidadEjecutoraSimulador : BaseAsyncEndpoint.WithRequest<UnidadesEjecutorasDto>.WithResponse<Response<UnidadesEjecutorasDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ActualizarUnidadEjecutoraSimulador(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/ActualizarUnidadEjecutoraSimulador")]
        [ProducesResponseType(typeof(Response<IEnumerable<ParametrosTasaActorDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualizar parametros de las unidades ejecutoras de la simulacion",
            Description = "Actualizar parametros de las unidades ejecutoras de la simulacion",
            OperationId = "credito.ActualizarUnidadEjecutoraSimulador",
            Tags = new[] { "CarteraEndpoint" })]

        public  async override Task<ActionResult<Response<UnidadesEjecutorasDto>>> HandleAsync(UnidadesEjecutorasDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ActualizarUnidadEjecutoraSimulador(request);
        }
    }
}
