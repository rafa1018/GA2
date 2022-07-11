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
    /// Endpoint para Crear Flujo TipoCredito
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearFlujoTipoCredito :
         BaseAsyncEndpoint.WithRequest<FlujoTipoCreditoDto>
        .WithResponse<Response<FlujoTipoCreditoDto>>
    {

        private readonly ICreditoBusinessLogic _flujotipoCreditoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Flujo TipoCredito
        /// </summary>
        /// <param name="flujotipoCreditoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearFlujoTipoCredito(ICreditoBusinessLogic flujotipoCreditoBusinessLogic)
        {
            _flujotipoCreditoBusinessLogic = flujotipoCreditoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearflujotipocredito")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FlujoTipoCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear FlujoTipoCredito",
           Description = "Crear FlujoTipoCredito",
           OperationId = "Credito.crearflujotipocredito",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<FlujoTipoCreditoDto>>> HandleAsync(FlujoTipoCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await this._flujotipoCreditoBusinessLogic.CrearFlujoTipoCredito(request);
        }
    }
}

