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
    public class ObtenerTiposRetenciones : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TipoRetencionDto>>>
    {

        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public ObtenerTiposRetenciones(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpGet("api/ObtenerTiposRetenciones")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<TiposProcesosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         Summary = "Listar todos los tipos de retenciones",
         Description = "Listar todos los tipos de retenciones",
         OperationId = "Embargos.ObtenerTiposRetenciones",
         Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<TipoRetencionDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ObtenerTiposRetenciones();
        }
    }
}
