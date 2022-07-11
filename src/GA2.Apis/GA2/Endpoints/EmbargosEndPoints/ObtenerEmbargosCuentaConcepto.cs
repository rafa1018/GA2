

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
    public class ObtenerEmbargosCuentaConcepto:BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<EmbargoCuentaConceptoDto>>>
    {
        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;
        public ObtenerEmbargosCuentaConcepto(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpGet("api/ObtenerEmbargosCuentaConcepto")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<EmbargoCuentaConceptoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Listar todos los embargos de cuenta y conceptos",
            Description = "Listar todos los embargos de cuenta y conceptos",
            OperationId = "Embargos.ObtenerEmbargosCuentaConcepto",
            Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<EmbargoCuentaConceptoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ObtenerEmbargosCuentaConcepto();
        }
    }
}
