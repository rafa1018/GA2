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

namespace GA2.Apis.GA2.Endpoints.AuditoriaEndPoints
{
    public class ObtenerlogAuditoria : BaseAsyncEndpoint.WithRequest<ConsultaAuditoriaDto>.WithResponse<Response<listaAuditorias>>
    {
        private readonly IAuditoriaBusinessLogic _auditoriaBusinessLogic;

        public ObtenerlogAuditoria(IAuditoriaBusinessLogic auditoriaBusinessLogic)
        {
            _auditoriaBusinessLogic = auditoriaBusinessLogic;
        }


        /// <summary>
        /// Actualizar Juzgado
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/ObtenerlogAuditoria")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<listaAuditorias>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Lista el log de auditoria",
            Description = "Lista el log de auditoria",
            OperationId = "Auditoria.ObtenerlogAuditoria",
            Tags = new[] { "AuditoriaEndPoints" })]
        public override async Task<ActionResult<Response<listaAuditorias>>> HandleAsync(ConsultaAuditoriaDto request, CancellationToken cancellationToken = default)
        {
            return await _auditoriaBusinessLogic.ObtenerlogAuditoria(request);
        }
    }
}
