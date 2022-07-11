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

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// Endpoint para Obtener Causal Desistimiento
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>22/06/2021</date>
    [Authorize]
    public class ObtenerCausalDesistimiento :

        BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<ObtenerCausalDesistimientoDto>>>
    {

        private readonly ICreditoBusinessLogic _causaldesistimientoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint para Obtener Causal Desistimiento
        /// </summary>
        /// <param name="causaldesistimientoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>22/06/2021</date>
        public ObtenerCausalDesistimiento(ICreditoBusinessLogic causaldesistimientoBusinessLogic)
        {
            _causaldesistimientoBusinessLogic = causaldesistimientoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpGet("api/credito/ObtenerCausalDesistimiento")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<ObtenerCausalDesistimientoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener Causal Desistimiento",
           Description = "Obtener Causal Desistimiento",
           OperationId = "credito.ObtenerCausalDesistimiento",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ObtenerCausalDesistimientoDto>>>> HandleAsync( CancellationToken cancellationToken = default)
        {
            return await this._causaldesistimientoBusinessLogic.ObtenerCausalDesistimiento();
        }
    }
}
