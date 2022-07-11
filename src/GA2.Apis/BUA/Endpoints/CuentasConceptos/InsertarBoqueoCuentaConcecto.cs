using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
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
    [Authorize]
    public class InsertarBoqueoCuentaConcecto : BaseAsyncEndpoint.WithRequest<BloqueoCuentaConceptoDto>.WithResponse<Response<BloqueoCuentaConceptoDto>>
    {

        private readonly ICuentasConceptosBusinessLogic _cuentasConceptosBusinessLogic;

        public InsertarBoqueoCuentaConcecto(ICuentasConceptosBusinessLogic cuentasConceptosBusinessLogic)
        {
            _cuentasConceptosBusinessLogic = cuentasConceptosBusinessLogic;
        }

        [HttpPost("api/InsertarBoqueoCuentaConcecto")]
        [ProducesResponseType(typeof(Response<EmbargosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Inserta un bloquo de una cuenta o un concecto",
           Description = "Inserta un bloquo de una cuenta o un concecto",
           OperationId = "CuentasConceptos.InsertarBoqueoCuentaConcecto",
           Tags = new[] { "CuentasConceptosEndPoints" })]
        public override async Task<ActionResult<Response<BloqueoCuentaConceptoDto>>> HandleAsync(BloqueoCuentaConceptoDto request, CancellationToken cancellationToken = default)
        {
            request.CreadoPor = Guid.Parse(User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value);
            return await this._cuentasConceptosBusinessLogic.InsertarBoqueoCuentaConcecto(request);
        }
    }
}
