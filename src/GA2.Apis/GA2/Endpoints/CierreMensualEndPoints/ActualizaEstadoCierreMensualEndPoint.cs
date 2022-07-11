using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CierreMensualEndPoints
{
    public class ActualizaEstadoCierreMensualEndPoint : BaseAsyncEndpoint.WithRequest<ActualizaCierreMensualDto>.WithResponse<Response<ProgramacionCierreMensualDto>>
    {

        private readonly ICierreMensualBusinessLogic _cierreMensualBusinessLogic;

        public ActualizaEstadoCierreMensualEndPoint(ICierreMensualBusinessLogic cierreMensualBusinessLogic)
        {
            _cierreMensualBusinessLogic = cierreMensualBusinessLogic;
        }



        /// <summary>
        /// ActualizaEstadoCierreMensual
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/ActualizaEstadoCierreMensual")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProgramacionCierreMensualDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Actualiza el estado del proceso de cierre mensual",
            Description = "Actualiza el estado del proceso de cierre mensual",
            OperationId = "CierreMensualEndpoint.ActualizaEstadoCierreMensual",
            Tags = new[] { "CierreMensualEndpoint" })]
        public override async Task<ActionResult<Response<ProgramacionCierreMensualDto>>> HandleAsync(ActualizaCierreMensualDto request, CancellationToken cancellationToken = default)
        {
            return await this._cierreMensualBusinessLogic.ActualizaEstadoCierreMensual(request);
        }
    }
}
