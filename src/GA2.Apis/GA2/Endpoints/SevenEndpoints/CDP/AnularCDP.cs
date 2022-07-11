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

namespace GA2.Apis.GA2.Endpoints.SevenEndpoints.CDP
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class AnularCDP:BaseAsyncEndpoint.WithRequest<AnularCDPRequestDto>.WithResponse<Response<object>>
    {
        private readonly ISevenBusinesslogic _sevenBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sevenBusinessLogic"></param>
        public AnularCDP(ISevenBusinesslogic sevenBusinessLogic)
        {
            _sevenBusinessLogic = sevenBusinessLogic;
        }

        /// <summary>
        /// Crear Cdp
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/credito/anularCDP")]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Anular CDP",
            Description = "Anular CDP",
            OperationId = "Seven.AnularCDP",
            Tags = new[] { "Seven" })]
        public async override Task<ActionResult<Response<object>>> HandleAsync(AnularCDPRequestDto request, CancellationToken cancellationToken = default)
        {
            return await this._sevenBusinessLogic.AnularCDP(request);
        }
    }
}
