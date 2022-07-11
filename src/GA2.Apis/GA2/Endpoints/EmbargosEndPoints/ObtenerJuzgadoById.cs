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
    public class ObtenerJuzgadoById : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<JuzgadosGuidDto>>
    {

        private readonly IEmbargosBusinessLogic _juzgadosBusinessLogic;

        public ObtenerJuzgadoById(IEmbargosBusinessLogic juzgadosBusinessLogic)
        {
            _juzgadosBusinessLogic = juzgadosBusinessLogic;
        }


        [HttpGet("api/ObtenerJuzgadoById")]
        [ProducesResponseType(typeof(Response<JuzgadosGuidDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Obtiene un juzgado po su id",
          Description = "Obtiene un juzgado po su id",
          OperationId = "Embargos.ObtenerJuzgadoById",
          Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<JuzgadosGuidDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await _juzgadosBusinessLogic.ObtenerJuzgadoById(request);
        }
    }
}
