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
    public class ObtenerExcepSeguroPorMunicipio : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<ParamGeneralesSegurosDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerExcepSeguroPorMunicipio(ICarteraBusinessLogic carteraBusinessLogic)
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
        [HttpGet("api/cartera/obtenerExcepSeguroPorMunicipio")]
        [ProducesResponseType(typeof(Response<ParamGeneralesExcepcionPlazoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene excepciones seguro por municipio",
            Description = "Obtiene excepciones seguro por municipio",
            OperationId = "cartera.ObtenerExcepSeguroPorMunicipio",
            Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ParamGeneralesSegurosDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ObtenerExcepSeguroPorMunicipio();
        }
    }
}
