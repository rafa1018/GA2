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
    public class ObtenerTiposProcesosEmbargos : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TiposProcesosDto>>>
    {

        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public ObtenerTiposProcesosEmbargos(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }

        [HttpGet("api/ObtenerTiposProcesosEmbargos")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<TiposProcesosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Listar todos los tipos de procesos de embargos",
            Description = "Listar todos los tipos de procesos de embargos",
            OperationId = "Embargos.ObtenerTiposProcesosEmbargos",
            Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<TiposProcesosDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ObtenerTiposProcesosEmbargos();         
        }


    }
}
