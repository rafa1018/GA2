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
    /// Endpoint para Actualizar Juzgado
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>05/04/2022</date>

    [Authorize]
    public class ActualizarJuzgado :
         BaseAsyncEndpoint.WithRequest<JuzgadosDto>
        .WithResponse<Response<JuzgadosDto>>
    {

        private readonly IEmbargosBusinessLogic _juzgadosBusinessLogic;

        /// <summary>
        /// Constructor clase ActualizarJuzgados
        /// </summary>
        /// <param name="juzgadosBusinessLogic"></param>
        public ActualizarJuzgado(IEmbargosBusinessLogic juzgadosBusinessLogic)
        {
            _juzgadosBusinessLogic = juzgadosBusinessLogic;
        }


        /// <summary>
        /// Actualizar Juzgado
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Embargos/ActualizarJuzgado")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<JuzgadosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Juzgado",
            Description = "Actualizar Juzgados",
            OperationId = "Embargos.ActualizarJuzgado",
            Tags = new[] { "EmbargosEndPoints" })]
        public async override Task<ActionResult<Response<JuzgadosDto>>> HandleAsync(JuzgadosDto request, CancellationToken cancellationToken = default)
        {
            return await _juzgadosBusinessLogic.ActualizarJuzgado(request);
        }
    }
}

