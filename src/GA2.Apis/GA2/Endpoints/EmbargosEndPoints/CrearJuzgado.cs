using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints
{

    /// <summary>
    /// Endpoint para Crear Juzgado
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>05/04/2022</date>

    [Authorize]
    public class CrearJuzgado :
         BaseAsyncEndpoint.WithRequest<JuzgadosDto>
        .WithResponse<Response<JuzgadosDto>>
    {

        private readonly IEmbargosBusinessLogic _juzgadoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Juzgados
        /// </summary>
        /// <param name="juzgadosBusinessLogic"></param>
        public CrearJuzgado(IEmbargosBusinessLogic juzgadosBusinessLogic)
        {
            _juzgadoBusinessLogic = juzgadosBusinessLogic;
        }


        /// <summary>
        /// CrearJuzgado
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Embargos/CrearJuzgado")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<JuzgadosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Crear Juzgado",
            Description = "Crear Juzgado",
            OperationId = "Embargos.CrearJuzgado",
            Tags = new[] { "EmbargosEndPoints" })]
        public async override Task<ActionResult<Response<JuzgadosDto>>> HandleAsync(JuzgadosDto request, CancellationToken cancellationToken = default)
        {
            return await this._juzgadoBusinessLogic.CrearJuzgado(request);
        }
    }
}

