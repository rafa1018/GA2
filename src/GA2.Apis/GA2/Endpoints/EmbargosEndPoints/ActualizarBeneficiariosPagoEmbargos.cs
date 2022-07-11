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

namespace GA2.Apis.GA2.Endpoints.EmbargosEndPoints
{
    [Authorize]
    public class ActualizarBeneficiariosPagoEmbargos : BaseAsyncEndpoint.WithRequest<BeneficiariosPagoEmbargoDto>.WithResponse<Response<BeneficiariosPagoEmbargoDto>>
    {

        IEmbargosBusinessLogic _embargosBusinessLogic;

        public ActualizarBeneficiariosPagoEmbargos(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpPost("api/ActualizarBeneficiariosPagoEmbargos")]
        [ProducesResponseType(typeof(Response<EmbargosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar un beneficiario de pago embargo",
           Description = "Actualizar un beneficiario de pago embargo",
           OperationId = "Embargos.ActualizarBeneficiariosPagoEmbargos",
           Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<BeneficiariosPagoEmbargoDto>>> HandleAsync(BeneficiariosPagoEmbargoDto request, CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ActualizarBeneficiariosPagoEmbargos(request, Guid.Parse(User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value));
        }
    }
}
