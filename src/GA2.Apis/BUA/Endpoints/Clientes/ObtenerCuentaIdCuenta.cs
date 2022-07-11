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

namespace GA2.Apis.BUA.Endpoints.Clientes
{
    public class ObtenerCuentaIdCuenta : BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<IEnumerable<CuentaDto>>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        public ObtenerCuentaIdCuenta(IClientesBusinessLogic clientsBusinessLogic)
        {
            _clientsBusinessLogic = clientsBusinessLogic;
        }

        [HttpGet("api/ObtenerCuentaIdCuenta")]
        [ProducesResponseType(typeof(Response<CuentaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene la cuenta por id de la cuenta",
           Description = "Obtiene la cuenta por id de la cuenta",
           OperationId = "client.ObtenerCuentaIdCuenta",
           Tags = new[] { "ClientEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<CuentaDto>>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ObtenerCuentaIdCuenta(request);
        }
    }
}
