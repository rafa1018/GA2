using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.BUA.Endpoints
{

    //[Authorize]
    /// <summary>
    /// Programar Cierre Anual
    /// </summary>

    public class ConsultarProgramacionCierreAnualEndPoint : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<Response<IEnumerable<ProgramacionCierreAnualDto>>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICierreAnualBusinessLogicBua _cierreAnualBusinessLogic;

        /// <summary>
        /// ConsultarProgramacionCierreAnualEndPoint Construct
        /// </summary>
        /// <param name="cierreAnualBusinessLogic"></param>
        public ConsultarProgramacionCierreAnualEndPoint(ICierreAnualBusinessLogicBua cierreAnualBusinessLogic)
        {
            _cierreAnualBusinessLogic = cierreAnualBusinessLogic;
        }


        /// <summary>
        /// ProgramarCierreAnual
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        [HttpGet("api/ConsultarProgramacionCierreAnual")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProgramacionCierreAnualDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Consultar Programacion Cierre Anual",
            Description = "Consultar Programacion Cierre Anual",
            OperationId = "CierreAnualEndpoint.ConsultarProgramacionCierreAnual",
            Tags = new[] { "CierreAnualEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<ProgramacionCierreAnualDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._cierreAnualBusinessLogic.ConsultarProgramacionCierreAnual();
        }
    }
}
