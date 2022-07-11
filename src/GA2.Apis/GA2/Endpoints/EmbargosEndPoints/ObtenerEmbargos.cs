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
    public class ObtenerEmbargos : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<EmbargosDto>>>
    {

        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public ObtenerEmbargos(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpGet("api/ObtenerEmbargos")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<EmbargosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Listar todos los embargos",
            Description = "Listar todos los embargos",
            OperationId = "Embargos.ObtenerEmbargos",
            Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<EmbargosDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ObtenerEmbargos();
        }
    }
}
