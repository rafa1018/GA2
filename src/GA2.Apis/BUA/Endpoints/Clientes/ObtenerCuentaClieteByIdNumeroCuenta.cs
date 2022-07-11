using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Application.Dto.BUA;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.BUA.Endpoints.Clientes
{
    public class ObtenerCuentaClieteByIdNumeroCuenta : BaseAsyncEndpoint.WithRequest<RequestConsultaCuentaDto>.WithResponse<Response<CuentaDto>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        public ObtenerCuentaClieteByIdNumeroCuenta(IClientesBusinessLogic clientsBusinessLogic)
        {
            _clientsBusinessLogic = clientsBusinessLogic;
        }


        [HttpGet("api/clientes/ObtenerCuentaClieteByIdNumeroCuenta")]
        [Consumes("application/json")]
        [SwaggerOperation(
        Summary = "Trae la cunta de un cliente por id de cliente y numero de cuenta",
           Description = "Trae la cunta de un cliente por id de cliente y numero de cuenta",
           OperationId = "Client.ObtenerCuentaClieteByIdNumeroCuenta",
           Tags = new[] { "ClientEndpoint" })]
        public override async Task<ActionResult<Response<CuentaDto>>> HandleAsync([FromQuery]  RequestConsultaCuentaDto request, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ObtenerCuentaClieteByIdNumeroCuenta(request.NumeroCuenta, request.Idcliente);
        }
    }
}
