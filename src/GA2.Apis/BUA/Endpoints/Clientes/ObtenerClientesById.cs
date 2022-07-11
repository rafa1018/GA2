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
    public class ObtenerClientesById : BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<IEnumerable<ClienteDto>>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        public ObtenerClientesById(IClientesBusinessLogic clientsBusinessLogic)
        {
            _clientsBusinessLogic = clientsBusinessLogic;
        }


        [HttpGet("api/clientes/ObtenerClientesById")]
        [ProducesResponseType(typeof(Response<CuentaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Obtiene todos los cliente por lista de id",
          Description = "Obtiene todos los cliente por lista de id",
          OperationId = "client.ObtenerClientesById",
          Tags = new[] { "ClientEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<ClienteDto>>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ObtenerClientesById(request);
        }
    }
}
