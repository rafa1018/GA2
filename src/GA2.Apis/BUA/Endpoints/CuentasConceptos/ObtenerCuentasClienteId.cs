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
    public class ObtenerCuentasClienteId : BaseAsyncEndpoint.WithRequest<int>.WithResponse<Response<IEnumerable<CuentaClienteDto>>>
    {

        private readonly ICuentasConceptosBusinessLogic _cuentasConceptosBusinessLogic;

        public ObtenerCuentasClienteId(ICuentasConceptosBusinessLogic cuentasConceptosBusinessLogic)
        {
            _cuentasConceptosBusinessLogic = cuentasConceptosBusinessLogic;
        }



        [HttpGet("api/ObtenerCuentasClienteId")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<CuentaClienteDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Lista las cuentas por id de cliente",
          Description = "Lista las cuentas por id de cliente",
          OperationId = "CuentasConceptos.ObtenerCuentasClienteId",
          Tags = new[] { "CuentasConceptosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<CuentaClienteDto>>>> HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            return await this._cuentasConceptosBusinessLogic.ObtenerCuentasCliente(request);
        }
    }
}
