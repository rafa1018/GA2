using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.EmbargosEndPoints
{
    public class EliminarBeneficiariosPagoEmbargos : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<BeneficiariosPagoEmbargoDto>>
    {
        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public EliminarBeneficiariosPagoEmbargos(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }



        [HttpDelete("api/EliminarBeneficiariosPagoEmbargos")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<EmbargosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
        Summary = "Eliminar un beneficiario de pago embargo",
          Description = "Eliminar un beneficiario de pago embargo",
          OperationId = "Embargos.EliminarBeneficiariosPagoEmbargos",
          Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<BeneficiariosPagoEmbargoDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.EliminarBeneficiariosPagoEmbargos(request);
        }
    }
}
