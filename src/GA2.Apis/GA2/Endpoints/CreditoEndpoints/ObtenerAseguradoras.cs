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
    /// Endpoint para Obtener Aseguradoras
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerAseguradoras : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<AseguradorasDto>>>
    {
        private readonly ICreditoBusinessLogic _aseguradorasBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Aseguradoras
        /// </summary>
        /// <param name="aseguradorasBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerAseguradoras(ICreditoBusinessLogic aseguradorasBusinessLogic)
        {
            _aseguradorasBusinessLogic = aseguradorasBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obteneraseguradoras")]
        [ProducesResponseType(typeof(Response<IEnumerable<AseguradorasDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Aseguradoras",
            Description = "Obtiene Aseguradoras",
            OperationId = "credito.obteneraseguradoras",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<AseguradorasDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._aseguradorasBusinessLogic.ObtenerAseguradoras();
        }

    }
}
