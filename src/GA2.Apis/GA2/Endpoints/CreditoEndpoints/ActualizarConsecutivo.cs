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
    /// Endpoint para Actualizar Consecutivo
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ActualizarConsecutivos :
         BaseAsyncEndpoint.WithRequest<ConsecutivoDto>
        .WithResponse<Response<ConsecutivoDto>>
    {

        private readonly ICreditoBusinessLogic _consecutivoBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Actualizar Consecutivo
        /// </summary>
        /// <param name="consecutivoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ActualizarConsecutivos(ICreditoBusinessLogic consecutivoBusinessLogic)
        {
            _consecutivoBusinessLogic = consecutivoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/credito/actualizarconsecutivo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ConsecutivoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Consecutivo",
           Description = "Actualizar Consecutivo",
           OperationId = "Credito.actualizarconsecutivo",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ConsecutivoDto>>> HandleAsync(ConsecutivoDto request, CancellationToken cancellationToken = default)
        {
            return await this._consecutivoBusinessLogic.ActualizarConsecutivo(request);
        }
    }
}

