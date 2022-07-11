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
    public class ActualizarEmbargoCuentaConcepto : BaseAsyncEndpoint.WithRequest<EmbargoCuentaConceptoDto>.WithResponse<Response<EmbargoCuentaConceptoDto>>
    {

        IEmbargosBusinessLogic _embargosBusinessLogic;

        public ActualizarEmbargoCuentaConcepto(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpPost("api/ActualizarEmbargoCuentaConcepto")]
        [ProducesResponseType(typeof(Response<EmbargosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Actualiza un embargo de cuenta y concepto",
          Description = "Actualiza un embargo de cuenta y concepto",
          OperationId = "Embargos.ActualizarEmbargoCuentaConcepto",
          Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<EmbargoCuentaConceptoDto>>> HandleAsync(EmbargoCuentaConceptoDto request, CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ActualizarEmbargoCuentaConcepto(request, Guid.Parse(User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value));
        }
    }
}
