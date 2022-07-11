using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.BUA.Endpoints.CuentasConceptos
{
    [Authorize]
    public class ObtenerDatosAdministracionCuentas : BaseAsyncEndpoint.WithRequest<DocumentoDTO>.WithResponse<Response<InfoClienteDto>>
    {
        private readonly ICuentasConceptosBusinessLogic _cuentasConceptosBusinessLogic;

        public ObtenerDatosAdministracionCuentas(ICuentasConceptosBusinessLogic cuentasConceptosBusinessLogic)
        {
            _cuentasConceptosBusinessLogic = cuentasConceptosBusinessLogic;
        }


 

        [SwaggerOperation(
        Summary = "Obtiene los datos basicos del cliente, cuentas, movimientos, conceptos de cuentas, aportes",
           Description = "Obtiene los datos basicos del cliente, cuentas, movimientos, conceptos de cuentas, aportes",
           OperationId = "CuentasConceptos.ObtenerDatosAdministracionCuentas",
           Tags = new[] { "CuentasConceptosEndPoints" })]
        [HttpGet("api/ObtenerDatosAdministracionCuentas")]
        public override async Task<ActionResult<Response<InfoClienteDto>>> HandleAsync([FromQuery] DocumentoDTO request, CancellationToken cancellationToken = default)
        {
            return await _cuentasConceptosBusinessLogic.ObtenerDatosAdministracionCuentas(request.tipoDocumentoId, request.numeroDocumento);
        }
    }
}
