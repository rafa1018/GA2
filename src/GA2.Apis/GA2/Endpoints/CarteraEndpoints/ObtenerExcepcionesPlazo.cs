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
    public class ObtenerExcepcionesPlazo : BaseAsyncEndpoint.WithRequest<ParamGeneralesExcepcionPlazoDto>.WithResponse<Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        public ObtenerExcepcionesPlazo(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/cartera/obtenerExcepcionesPlazo")]
        [ProducesResponseType(typeof(Response<ParamGeneralesExcepcionPlazoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene excepciones plazos",
            Description = "Obtiene excepciones plazos",
            OperationId = "cartera.obtenerExcepcionesPlazo",
            Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>>> HandleAsync(ParamGeneralesExcepcionPlazoDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ObtenerExcepcionesPlazo(request);
        }
    }
    }
