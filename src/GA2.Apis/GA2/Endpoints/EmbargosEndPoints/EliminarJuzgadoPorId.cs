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
    /// Endpoint para Eliminar Juzgado Por Id
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>05/04/2022</date>

    [Authorize]
    public class EliminarJuzgadoPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<JuzgadosDto>>
    {

        private readonly IEmbargosBusinessLogic _juzgadosBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint EliminarJuzgados
        /// </summary>
        /// <param name="juzgadosBusinessLogic"></param>
        public EliminarJuzgadoPorId(IEmbargosBusinessLogic juzgadosBusinessLogic)
        {
            _juzgadosBusinessLogic = juzgadosBusinessLogic;
        }


        /// <summary>
        /// EliminarJuzgados
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/Embargos/EliminarJuzgados")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<JuzgadosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Eliminar Juzgado",
            Description = "Eliminar Juzgado",
            OperationId = "Embargos.EntidadJuzgado",
            Tags = new[] { "EmbargosEndPoints" })]
        public async override Task<ActionResult<Response<JuzgadosDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await _juzgadosBusinessLogic.EliminarJuzgadoPorId(request);
        }
    }
}

