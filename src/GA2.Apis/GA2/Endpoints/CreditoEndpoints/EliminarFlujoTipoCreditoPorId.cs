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
    /// Endpoint para Eliminar Flujo Tipo Credito Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class EliminarFlujoTipoCreditoPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<FlujoTipoCreditoDto>>
    {

        private readonly ICreditoBusinessLogic _flujotipocreditoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Flujo Tipo Credito Por Id
        /// </summary>
        /// <param name="flujotipocreditoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public EliminarFlujoTipoCreditoPorId(ICreditoBusinessLogic flujotipocreditoBusinessLogic)
        {
            _flujotipocreditoBusinessLogic = flujotipocreditoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/credito/eliminarflujotipocredito")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FlujoTipoCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Eliminar FlujoTipoCredito",
           Description = "Eliminar FlujoTipoCredito",
           OperationId = "credito.eliminarflujotipocredito",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<FlujoTipoCreditoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._flujotipocreditoBusinessLogic.EliminarFlujoTipoCreditoPorid(request);
        }
    }
}

