using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.BUA.Endpoints
{
    /// <summary>
    /// CierreAnual
    /// </summary>
    public class CierreAnual : BaseAsyncEndpoint.WithRequest<ProgramacionCierreAnualDto>
        .WithResponse<Response<RespuestaCierreAnualDto>>
    {
        /// <summary>
        /// ICierreAnualBusinessLogicBua
        /// </summary>
        private readonly ICierreAnualBusinessLogicBua _CierreAnualBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CierreAnualBusinessLogic"></param>
        public CierreAnual(ICierreAnualBusinessLogicBua CierreAnualBusinessLogic)
        {
            _CierreAnualBusinessLogic = CierreAnualBusinessLogic;
        }


        /// <summary>
        /// CierreAnual
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/CierreAnual")]
        [ProducesResponseType(typeof(Response<RespuestaCierreAnualDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Generar Remuneracion de Intereses",
            Description = "Generar Remuneracion de Intereses",
            OperationId = "CierreAnual.CierreAnual",
            Tags = new[] { "CierreAnual" })]

        public override async Task<ActionResult<Response<RespuestaCierreAnualDto>>> HandleAsync(ProgramacionCierreAnualDto request, CancellationToken cancellationToken = default)
        {
            return await _CierreAnualBusinessLogic.CierreAnual(request);
        }

    }
}
