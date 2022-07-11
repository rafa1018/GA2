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
    /// CierreAnualEndPoint
    /// </summary>
    public class CierreAnualEndPoint : BaseAsyncEndpoint
        .WithRequest<ParametrosCierreAnualDto>
        .WithResponse<Response<bool>>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly ICierreAnualBusinessLogic _cierreAnualBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cierreAnualBusinessLogic"></param>
        public CierreAnualEndPoint(ICierreAnualBusinessLogic cierreAnualBusinessLogic)
        {
            _cierreAnualBusinessLogic = cierreAnualBusinessLogic;
        }


        [HttpPost("api/CierreAnual")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ClienteDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Generar Remuneracion de Intereses",
            Description = "Generar Remuneracion de Intereses",
            OperationId = "CierreAnual.CierreAnual",
            Tags = new[] { "CierreAnualEndpoint" })]


        public override async Task<ActionResult<Response<bool>>> HandleAsync(ParametrosCierreAnualDto request, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}
