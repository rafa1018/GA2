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

    //[Authorize]
    /// <summary>
    /// CierreMensualEndPoint
    /// </summary>
    public class CierreMensualEndPoint : BaseAsyncEndpoint
        .WithRequest<ParametrosCierreMensualDto>
        .WithResponse<Response<bool>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICierreMensualBusinessLogic _cierreMensualBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cierreMensualBusinessLogic"></param>
        public CierreMensualEndPoint(ICierreMensualBusinessLogic cierreMensualBusinessLogic)
        {
            _cierreMensualBusinessLogic = cierreMensualBusinessLogic;
        }


        [HttpPost("api/CierreMensual")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ClienteDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Generar Remuneracion de Intereses",
            Description = "Generar Remuneracion de Intereses",
            OperationId = "CierreMensual.CierreMensual",
            Tags = new[] { "CierreMensualEndpoint" })]


        public override async Task<ActionResult<Response<bool>>> HandleAsync(ParametrosCierreMensualDto request, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
