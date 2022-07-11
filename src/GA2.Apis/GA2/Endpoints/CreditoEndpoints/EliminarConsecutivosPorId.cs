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
    /// Endpoint para Eliminar Consecutivos Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class EliminarConsecutivosPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<ConsecutivoDto>>
    {

        private readonly ICreditoBusinessLogic _consecutivoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Consecutivos Por Id
        /// </summary>
        /// <param name="consecutivoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public EliminarConsecutivosPorId(ICreditoBusinessLogic consecutivoBusinessLogic)
        {
            _consecutivoBusinessLogic = consecutivoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/credito/eliminarconsecutivo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ConsecutivoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Eliminar Consecutivo",
           Description = "Eliminar Consecutivo",
           OperationId = "Credito.eliminarconsecutivo",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ConsecutivoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._consecutivoBusinessLogic.EliminarConsecutivoPorid(request);
        }
    }
}

