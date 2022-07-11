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
    public class EliminarUnidadEjecutoraSimulador : BaseAsyncEndpoint.WithRequest<UnidadesEjecutorasDto>.WithResponse<Response<UnidadesEjecutorasDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public EliminarUnidadEjecutoraSimulador(ICarteraBusinessLogic carteraBusinessLogic)
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
        [HttpPost("api/credito/EliminarUnidadEjecutoraSimulacion")]
        [ProducesResponseType(typeof(Response<IEnumerable<UnidadesEjecutorasDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Eliminar unidad ejecutora simulacion",
            Description = "Elimina un registro o unidad ejecutora de la simulacion",
            OperationId = "credito.EliminarUnidadEjecutora",
            Tags = new[] { "CarteraEndpoint" })]

        public async override Task<ActionResult<Response<UnidadesEjecutorasDto>>> HandleAsync(UnidadesEjecutorasDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.EliminarUnidadEjecutoraSimulador(request);
        }
    }
}
