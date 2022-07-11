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

namespace GA2.Apis.BUA.Endpoints.CuentasConceptos
{
    [Authorize]
    public class ObtenerCausalBloqueoCuentasConceptos : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<CausalBloqueoCuentaDto>>>
    {
        private readonly ICuentasConceptosBusinessLogic _cuentasConceptosBusinessLogic;

        public ObtenerCausalBloqueoCuentasConceptos(ICuentasConceptosBusinessLogic cuentasConceptosBusinessLogic)
        {
            _cuentasConceptosBusinessLogic = cuentasConceptosBusinessLogic;
        }


        [HttpGet("api/ObtenerCausalBloqueoCuentasConceptos")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<CausalBloqueoCuentaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Lista las causales de bloqueo de cuentas y concptos",
           Description = "Lista las causales de bloqueo de cuentas y concptos",
           OperationId = "CuentasConceptos.ObtenerCausalBloqueoCuentasConceptos",
           Tags = new[] { "CuentasConceptosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<CausalBloqueoCuentaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _cuentasConceptosBusinessLogic.ObtenerCausalBloqueoCuentasConceptos();
        }
    }
}
