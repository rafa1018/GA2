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

namespace GA2.Apis.GA2.Endpoints.EmbargosEndPoints
{
    public class ObtenerBeneficiariosEmbargo : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<BeneficiariosPagoEmbargoDto>>>
    {

        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public ObtenerBeneficiariosEmbargo(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpGet("api/ObtenerBeneficiariosEmbargo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<EmbargoCuentaConceptoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Listar todos los beneficiarios de pago de embargos",
            Description = "Listar todos los beneficiarios de pago de embargos",
            OperationId = "Embargos.ObtenerBeneficiariosEmbargo",
            Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<BeneficiariosPagoEmbargoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ObtenerBeneficiariosEmbargo();
        }
    }
}
