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
    public class EliminarEmbargo : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<EmbargosDto>>
    {
        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public EliminarEmbargo(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }

        [HttpDelete("api/EliminarEmbargo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<EmbargosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Eliminar un embargo por Id",
            Description = "Eliminar un embargo por Id",
            OperationId = "Embargos.EliminarEmbargo",
            Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<EmbargosDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.EliminarEmbargo(request);
        }
    }
}
