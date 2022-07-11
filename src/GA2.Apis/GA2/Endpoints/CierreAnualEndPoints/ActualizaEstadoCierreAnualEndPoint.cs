using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CierreAnualEndPoints
{
    public class ActualizaEstadoCierreAnualEndPoint : BaseAsyncEndpoint.WithRequest<ActualizaCierreAnualDto>.WithResponse<Response<ProgramacionCierreAnualDto>>
    {

        private readonly ICierreAnualBusinessLogic _cierreAnualBusinessLogic;

        public ActualizaEstadoCierreAnualEndPoint(ICierreAnualBusinessLogic cierreAnualBusinessLogic)
        {
            _cierreAnualBusinessLogic = cierreAnualBusinessLogic;
        }



        /// <summary>
        /// ActualizaEstadoCierreAnual
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/ActualizaEstadoCierreAnual")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProgramacionCierreAnualDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Actualiza el estado del proceso de cierre Anual",
            Description = "Actualiza el estado del proceso de cierre Anual",
            OperationId = "CierreAnualEndpoint.ActualizaEstadoCierreAnual",
            Tags = new[] { "CierreAnualEndpoint" })]
        public override async Task<ActionResult<Response<ProgramacionCierreAnualDto>>> HandleAsync(ActualizaCierreAnualDto request, CancellationToken cancellationToken = default)
        {
            return await this._cierreAnualBusinessLogic.ActualizaEstadoCierreAnual(request);
        }
    }
}
