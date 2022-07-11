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
    public class InsertarBeneficiariosPagoEmbargos : BaseAsyncEndpoint.WithRequest<BeneficiariosPagoEmbargoDto>.WithResponse<Response<BeneficiariosPagoEmbargoDto>>
    {

        IEmbargosBusinessLogic _embargosBusinessLogic;

        public InsertarBeneficiariosPagoEmbargos(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpPost("api/InsertarBeneficiariosPagoEmbargos")]
        [ProducesResponseType(typeof(Response<EmbargosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Inserta un beneficiario de pago de embargo",
        Description = "Inserta un beneficiario de pago de embargo",
        OperationId = "Embargos.InsertarBeneficiariosPagoEmbargos",
        Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<BeneficiariosPagoEmbargoDto>>> HandleAsync(BeneficiariosPagoEmbargoDto request, CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.InsertarBeneficiariosPagoEmbargos(request, Guid.Parse(User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value));
        }
    }
}
