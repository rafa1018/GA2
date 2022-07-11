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
    public class ActualizarEmbargo : BaseAsyncEndpoint.WithRequest<InsetEmbargosDto>.WithResponse<Response<EmbargosDto>>
    {

        IEmbargosBusinessLogic _embargosBusinessLogic;

        public ActualizarEmbargo(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpPost("api/ActualizarEmbargo")]
        [ProducesResponseType(typeof(Response<EmbargosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar un embargo",
           Description = "Actualizar un embargo",
           OperationId = "Embargos.ActualizarEmbargo",
           Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<EmbargosDto>>> HandleAsync(InsetEmbargosDto request, CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ActualizarEmbargo(request, Guid.Parse(User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value));
        }
    }
}
