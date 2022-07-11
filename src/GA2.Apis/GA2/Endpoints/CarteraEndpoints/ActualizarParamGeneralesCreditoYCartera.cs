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

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ActualizarParamGeneralesCreditoYCartera : BaseAsyncEndpoint.WithRequest<ParamGeneralesCreditoYCarteraDto>.WithResponse<Response<ParamGeneralesCreditoYCarteraDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ActualizarParamGeneralesCreditoYCartera(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/actualizarParamGeneralesCreditoYCartera")]
        [ProducesResponseType(typeof(Response<ParamGeneralesCreditoYCarteraDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualizar parametros generales de credito y cartera en la simulacion",
            Description = "Actualizar parametros generales de credito y cartera en la simulacion",
            OperationId = "credito.ActualizarParamGeneralesCreditoYCartera",
            Tags = new[] { "CarteraEndpoint" })]

        public async override Task<ActionResult<Response<ParamGeneralesCreditoYCarteraDto>>> HandleAsync(ParamGeneralesCreditoYCarteraDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ActualizarParamGeneralesCreditoYCartera(request);
        }
    }
}
