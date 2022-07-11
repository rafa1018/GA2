using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Domain.Entities;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.BUA.Endpoints.CuentasConceptos
{
    // [Authorize]
    public class InsertarCuentas : BaseAsyncEndpoint.WithRequest<InsertCuentaConcepto>.WithResponse<Response<InsertCuentaConcepto>>
    {

        private readonly ICuentasBusinessLogic _cuentasConceptosBusinessLogic;

        public InsertarCuentas(ICuentasBusinessLogic cuentasConceptosBusinessLogic)
        {
            _cuentasConceptosBusinessLogic = cuentasConceptosBusinessLogic;
        }

        [HttpPost("api/InsertarNuevasCuentas")]
        [ProducesResponseType(typeof(Response<InsertCuentaConcepto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Inserta  una cuenta ",
           Description = "Inserta una cuenta",
           OperationId = "CuentasConceptos.InsertarNuevasCuentas",
           Tags = new[] { "CuentasConceptosEndPoints" })]
        public override async Task<ActionResult<Response<InsertCuentaConcepto>>> HandleAsync(InsertCuentaConcepto request, CancellationToken cancellationToken = default)
        {
            // request.CreadoPor = Guid.Parse(User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value);
            return await this._cuentasConceptosBusinessLogic.CrearCuentaAfiliado(request);
        }
    }
}
