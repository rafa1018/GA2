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
    /// Programar Cierre Anual
    /// </summary>

    public class ProgramarCierreAnualEndPoint : BaseAsyncEndpoint
        .WithRequest<ParametrosCierreAnualDto>
        .WithResponse<Response<ProgramacionCierreAnualDto>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICierreAnualBusinessLogic _cierreAnualBusinessLogic;

        /// <summary>
        /// ProgramarCierreAnualEndPoint Construct
        /// </summary>
        /// <param name="cierreAnualBusinessLogic"></param>
        public ProgramarCierreAnualEndPoint(ICierreAnualBusinessLogic cierreAnualBusinessLogic)
        {
            _cierreAnualBusinessLogic = cierreAnualBusinessLogic;
        }


        /// <summary>
        /// ProgramarCierreAnual
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        [HttpPost("api/ProgramarCierreAnual")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProgramacionCierreAnualDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Programar Cierre Anual",
            Description = "Programar Cierre Anual",
            OperationId = "CierreAnual.ProgramarCierreAnual",
            Tags = new[] { "CierreAnualEndpoint" })]
        public override async Task<ActionResult<Response<ProgramacionCierreAnualDto>>> HandleAsync(ParametrosCierreAnualDto request, CancellationToken cancellationToken = default)
        {
            return await this._cierreAnualBusinessLogic.ProgramarCierreAnual(request);
        }
    }
}
