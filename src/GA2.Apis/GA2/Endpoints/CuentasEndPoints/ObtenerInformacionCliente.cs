using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CuentasEndPoints
{
    [Authorize]
    public class ObtenerInformacionCliente : BaseAsyncEndpoint.WithRequest<ConsultaClienteDto>.WithResponse<Response<InfoClienteDto>>
    {
        private readonly ICuentasClientesBusinessLogic _cuentasClientesBusinessLogic;

        public ObtenerInformacionCliente(ICuentasClientesBusinessLogic cuentasClientesBusinessLogic)
        {
            _cuentasClientesBusinessLogic = cuentasClientesBusinessLogic;
        }


        [SwaggerOperation(
        Summary = "Obtiene los datos basicos del cliente, cuentas, movimientos, conceptos de cuentas, aportes",
           Description = "Obtiene los datos basicos del cliente, cuentas, movimientos, conceptos de cuentas, aportes",
           OperationId = "CuentasClientes.ObtenerInformacionCliente",
           Tags = new[] { "CuentasClientes" })]
        [HttpPost("api/ObtenerInformacionCliente")]
        public override async Task<ActionResult<Response<InfoClienteDto>>> HandleAsync(ConsultaClienteDto request, CancellationToken cancellationToken = default)
        {
            return await _cuentasClientesBusinessLogic.ObtenerInformacionCliente(request.tipoDocumentoId, request.numeroDocumento);
        }
    }
}
