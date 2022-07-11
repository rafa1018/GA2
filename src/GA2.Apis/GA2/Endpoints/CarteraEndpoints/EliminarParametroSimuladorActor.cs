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
    public class EliminarParametroSimuladorActor : BaseAsyncEndpoint.WithRequest<ParametrosTasaActorDto>.WithResponse<Response<ParametrosTasaActorDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public EliminarParametroSimuladorActor(ICarteraBusinessLogic carteraBusinessLogic)
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
        [HttpPost("api/credito/EliminarActorSimulacion")]
        [ProducesResponseType(typeof(Response<IEnumerable<TasaSimuladorDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Eliminar actor simulacion",
            Description = "Elimina un parametro o actor de la simulacion",
            OperationId = "credito.EliminarActor",
            Tags = new[] { "CarteraEndpoint" })]

        public async override Task<ActionResult<Response<ParametrosTasaActorDto>>> HandleAsync(ParametrosTasaActorDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.EliminarParametroSimuladorActor(request);

        }
    }
}
