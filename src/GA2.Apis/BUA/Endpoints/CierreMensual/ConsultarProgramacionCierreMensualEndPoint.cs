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
    /// Programar Cierre Mensual
    /// </summary>

    public class ConsultarProgramacionCierreMensualEndPoint : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<Response<IEnumerable<ProgramacionCierreMensualDto>>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICierreMensualBusinessLogicBua _cierreMensualBusinessLogic;

        /// <summary>
        /// ConsultarProgramacionCierreMensualEndPoint Construct
        /// </summary>
        /// <param name="cierreMensualBusinessLogic"></param>
        public ConsultarProgramacionCierreMensualEndPoint(ICierreMensualBusinessLogicBua cierreMensualBusinessLogic)
        {
            _cierreMensualBusinessLogic = cierreMensualBusinessLogic;
        }


        /// <summary>
        /// ProgramarCierreMensual
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        [HttpGet("api/ConsultarProgramacionCierreMensual")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProgramacionCierreMensualDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Consultar Programacion Cierre Mensual",
            Description = "Consultar Programacion Cierre Mensual",
            OperationId = "CierreMensualEndpoint.ConsultarProgramacionCierreMensual",
            Tags = new[] { "CierreMensualEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<ProgramacionCierreMensualDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._cierreMensualBusinessLogic.ConsultarProgramacionCierreMensual();
        }
    }
}
