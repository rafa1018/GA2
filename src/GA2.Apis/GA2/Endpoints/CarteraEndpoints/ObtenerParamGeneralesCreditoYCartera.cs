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
    /// Endpoint para obtener los parametros generales de credito y cartera
    /// </summary>
    /// <author>Sergio Ortega</author>
    /// <date>13/01/2022</date>
    [Authorize]
    public class ObtenerParamGeneralesCreditoYCartera : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<ParamGeneralesCreditoYCarteraDto>>

    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerParamGeneralesCreditoYCartera(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpGet("api/cartera/obtenerParamGeneralesCreditoYCartera")]
        [ProducesResponseType(typeof(Response<ParamGeneralesCreditoYCarteraDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene parametros generales de credito y cartera",
            Description = "Obtiene parametros generales de credito y cartera",
            OperationId = "cartera.obtenerParamGeneralesCreditoYCartera",
            Tags = new[] { "CarteraEndpoint" })]

        public async override Task<ActionResult<Response<ParamGeneralesCreditoYCarteraDto>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ObtenerParamGeneralesCreditoYCartera();
        }
    }
}
