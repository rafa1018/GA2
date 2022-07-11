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
    /// Programar Cierre Mensual
    /// </summary>

    public class ProgramarCierreMensualEndPoint : BaseAsyncEndpoint
        .WithRequest<ParametrosCierreMensualDto>
        .WithResponse<Response<ProgramacionCierreMensualDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICierreMensualBusinessLogic _cierreMensualBusinessLogic;

        /// <summary>
        /// ProgramarCierreMensualEndPoint Construct
        /// </summary>
        /// <param name="cierreMensualBusinessLogic"></param>
        public ProgramarCierreMensualEndPoint(ICierreMensualBusinessLogic cierreMensualBusinessLogic)
        {
            _cierreMensualBusinessLogic = cierreMensualBusinessLogic;
        }


        /// <summary>
        /// ProgramarCierreMensual
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        [HttpPost("api/ProgramarCierreMensual")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProgramacionCierreMensualDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Programar Cierre Mensual",
            Description = "Programar Cierre Mensual",
            OperationId = "CierreMensual.ProgramarCierreMensual",
            Tags = new[] { "CierreMensualEndpoint" })]
        public override async Task<ActionResult<Response<ProgramacionCierreMensualDto>>> HandleAsync(ParametrosCierreMensualDto request, CancellationToken cancellationToken = default)
        {
            return await this._cierreMensualBusinessLogic.ProgramarCierreMensual(request);
        }
    }
}
