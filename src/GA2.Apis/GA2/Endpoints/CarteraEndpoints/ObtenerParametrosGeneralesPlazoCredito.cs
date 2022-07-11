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
    public class ObtenerParametrosGeneralesPlazoCredito : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerParametrosGeneralesPlazoCredito(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }


        [HttpGet("api/cartera/obtenerParametrosGeneralesPlazoCredito")]
        [ProducesResponseType(typeof(Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener parametros generales de los plazos de los creditos",
           Description = "Obtener parametros generales de los plazos de los creditos",
           OperationId = "cartera.obtenerParametrosGeneralesPlazoCredito",
           Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ParamGeneralesExcepcionPlazoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _carteraBusinessLogic.ObtenerParametrosGeneralesPlazoCredito();
        }
    }
}
