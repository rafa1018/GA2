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

   
    public class ObtenerTablasAuditoria : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TablasAuditoriaDto>>>
    {
        private readonly IAuditoriaBusinessLogic _auditoriaBusinessLogic;

        public ObtenerTablasAuditoria(IAuditoriaBusinessLogic auditoriaBusinessLogic)
        {
            _auditoriaBusinessLogic = auditoriaBusinessLogic;
        }


        [HttpGet("api/ObtenerTablasAuditoria")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<TablasAuditoriaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Lista las tablas audirtadas",
           Description = "Lista las tablas audirtadas",
           OperationId = "Auditoria.ObtenerTablasAuditoria",
           Tags = new[] { "AuditoriaEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<TablasAuditoriaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _auditoriaBusinessLogic.ObtenerTablasAuditoria();
        }
    }
}
