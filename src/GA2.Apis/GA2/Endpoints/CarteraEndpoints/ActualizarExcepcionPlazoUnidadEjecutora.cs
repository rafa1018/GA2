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
    public class ActualizarExcepcionPlazoUnidadEjecutora : BaseAsyncEndpoint.WithRequest<ParamGeneralesExcepcionPlazoDto>.WithResponse<Response<ParamGeneralesExcepcionPlazoDto>>
    {

        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        public ActualizarExcepcionPlazoUnidadEjecutora(ICarteraBusinessLogic carteraBusinessLogic)
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
        [HttpPost("api/cartera/actualizarExcepcionPlazoUnidadEjecutora")]
        [ProducesResponseType(typeof(Response<ParamGeneralesExcepcionPlazoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualizar excepcion plazos por unidad ejecutora",
            Description = "Actualizar excepciones de plazos por unidad ejecutora",
            OperationId = "cartera.ActualizarExcepcionPlazoUnidadEjecutora",
            Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<ParamGeneralesExcepcionPlazoDto>>> HandleAsync(ParamGeneralesExcepcionPlazoDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ActualizarExcepcionPlazoUnidadEjecutora(request);
        }
    }
}
