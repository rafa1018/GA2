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
    public class ObtenerDesembargo : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<ObtenerDesembargoDto>>>
    {
        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public ObtenerDesembargo(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpGet("api/ObtenerDesembargo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<EmbargosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         Summary = "Historial de desembargos",
         Description = "Historial de desembargos",
         OperationId = "Embargos.ObtenerDesembargo",
         Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<ObtenerDesembargoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ObtenerDesembargo();
;        }
    }
}
