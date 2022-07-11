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
    ///<summary>
    /// Endpoint para Obtener Consecutivo
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerConsecutivo : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<ConsecutivoDto>>>
    {
        private readonly ICreditoBusinessLogic _consecutivoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Consecutivo
        /// </summary>
        /// <param name="consecutivoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerConsecutivo(ICreditoBusinessLogic consecutivoBusinessLogic)
        {
            _consecutivoBusinessLogic = consecutivoBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerconsecutivo")]
        [ProducesResponseType(typeof(Response<IEnumerable<ConsecutivoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Consecutivo",
            Description = "Obtiene Consecutivo",
            OperationId = "credito.obtenerconsecutivo",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ConsecutivoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._consecutivoBusinessLogic.ObtenerConsecutivo();
        }

    }
}
