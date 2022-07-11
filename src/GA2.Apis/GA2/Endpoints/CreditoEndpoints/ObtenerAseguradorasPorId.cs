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
    /// Endpoint para Obtener Aseguradoras Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerAseguradorasPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<AseguradorasDto>>
    {

        private readonly ICreditoBusinessLogic _aseguradorasBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Aseguradoras Por Id
        /// </summary>
        /// <param name="aseguradorasBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerAseguradorasPorId(ICreditoBusinessLogic aseguradorasBusinessLogic)
        {
            _aseguradorasBusinessLogic = aseguradorasBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obteneraseguradorasporid")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<AseguradorasDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener Aseguradora por id",
           Description = "Obtener aseguradora por Id",
           OperationId = "Obtener.obteneraseguradorasporid",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<AseguradorasDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._aseguradorasBusinessLogic.ObtenerAseguradorasPorId(request);
        }
    }
}

