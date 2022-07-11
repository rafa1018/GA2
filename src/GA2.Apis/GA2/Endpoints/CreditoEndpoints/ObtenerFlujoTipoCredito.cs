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

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para Obtener Flujo Tipo Credito
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerFlujoTipoCredito : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<FlujoTipoCreditoDto>>>
    {
        private readonly ICreditoBusinessLogic _flujotipoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Flujo Tipo Credito
        /// </summary>
        /// <param name="flujotipoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerFlujoTipoCredito(ICreditoBusinessLogic flujotipoBusinessLogic)
        {
            _flujotipoBusinessLogic = flujotipoBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerflujotipocredito")]
        [ProducesResponseType(typeof(Response<IEnumerable<FlujoTipoCreditoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene FlujoTipoCredito",
            Description = "Obtiene FlujoTipoCredito",
            OperationId = "credito.obtenerflujotipocredito",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<FlujoTipoCreditoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._flujotipoBusinessLogic.ObtenerFlujoTipoCredito();
        }

    }
}
