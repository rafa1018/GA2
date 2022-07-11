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
    public class InsertarDesembargo : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<DesembargoDto>>
    {

        IEmbargosBusinessLogic _embargosBusinessLogic;

        public InsertarDesembargo(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpPost("api/InsertarDesembargo")]
        [ProducesResponseType(typeof(Response<EmbargosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Desembarga una cuenta",
          Description = "Desembarga una cuenta",
          OperationId = "Embargos.InsertarDesembargo",
          Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<DesembargoDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.InsertarDesembargo(request);
        }
    }
}
