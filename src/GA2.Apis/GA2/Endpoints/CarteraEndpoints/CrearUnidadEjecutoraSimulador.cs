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

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class CrearUnidadEjecutoraSimulador : BaseAsyncEndpoint.WithRequest<UnidadesEjecutorasDto>.WithResponse<Response<UnidadesEjecutorasDto>>

    {

        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public CrearUnidadEjecutoraSimulador(ICarteraBusinessLogic carteraBusinessLogic)
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
        [HttpPost("api/credito/CrearUnidadEjecutoraSimulador")]
        [ProducesResponseType(typeof(Response<ParametrosTasaActorDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear unidad ejecutora simulacion",
            Description = "Crea unidad ejecutora  de la simulacion",
            OperationId = "credito.CrearUnidadEjecutora",
            Tags = new[] { "CarteraEndpoint" })]



        public async override Task<ActionResult<Response<UnidadesEjecutorasDto>>> HandleAsync(UnidadesEjecutorasDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.CrearUnidadEjecutoraSimulador(request);
        }
    }
}
