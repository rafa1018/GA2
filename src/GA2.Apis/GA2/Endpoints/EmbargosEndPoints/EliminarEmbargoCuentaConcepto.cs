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
    public class EliminarEmbargoCuentaConcepto : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<EmbargoCuentaConceptoDto>>
    {

        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public EliminarEmbargoCuentaConcepto(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpDelete("api/EliminarEmbargoCuentaConcepto")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<EmbargosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Eliminar un embargo cuenta concepto por id",
            Description = "Eliminar un embargo cuenta concepto por id",
            OperationId = "Embargos.EliminarEmbargoCuentaConcepto",
            Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<EmbargoCuentaConceptoDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.EliminarEmbargoCuentaConcepto(request);
        }
    }
}
