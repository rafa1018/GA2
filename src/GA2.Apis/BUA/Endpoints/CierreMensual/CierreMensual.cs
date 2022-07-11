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
    /// <summary>
    /// CierreMensual
    /// </summary>
    public class CierreMensual : BaseAsyncEndpoint.WithRequest<ProgramacionCierreMensualDto>
        .WithResponse<Response<RespuestaCierreMensualDto>>
    {
        /// <summary>
        /// ICierreMensualBusinessLogicBua
        /// </summary>
        private readonly ICierreMensualBusinessLogicBua _cierreMensualBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cierreMensualBusinessLogic"></param>
        public CierreMensual(ICierreMensualBusinessLogicBua cierreMensualBusinessLogic)
        {
            _cierreMensualBusinessLogic = cierreMensualBusinessLogic;
        }


        /// <summary>
        /// CierreMensual
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/CierreMensual")]
        [ProducesResponseType(typeof(Response<RespuestaCierreMensualDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Generar Remuneracion de Intereses",
            Description = "Generar Remuneracion de Intereses",
            OperationId = "CierreMensual.CierreMensual",
            Tags = new[] { "CierreMensual" })]

        public override async Task<ActionResult<Response<RespuestaCierreMensualDto>>> HandleAsync(ProgramacionCierreMensualDto request, CancellationToken cancellationToken = default)
        {
            return await _cierreMensualBusinessLogic.CierreMensual(request);
        }

    }
}
