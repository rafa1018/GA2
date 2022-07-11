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

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// Endpoint para Obtener Flujo Tipo Credito Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerFlujoTipoCreditoPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<FlujoTipoCreditoDto>>
    {

        private readonly ICreditoBusinessLogic _flujotipoCreditoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Flujo Tipo Credito Por Id
        /// </summary>
        /// <param name="flujotipoCreditoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerFlujoTipoCreditoPorId(ICreditoBusinessLogic flujotipoCreditoBusinessLogic)
        {
            _flujotipoCreditoBusinessLogic = flujotipoCreditoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerflujotipocreditoporid")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FlujoTipoCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener FlujoTipoCreditoporid",
           Description = "Obtener Flujo Tipo Credito por id",
           OperationId = "credito.obtenerflujotipocreditoporid",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<FlujoTipoCreditoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._flujotipoCreditoBusinessLogic.ObtenerFlujoTipoCreditoPorId(request);
        }
    }
}

