using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para Eliminar Juzgado Por Dpto
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>05/04/2022</date>

    [Authorize]
    public class ObtenerJuzgadosPorDepartamento : BaseAsyncEndpoint
        .WithRequest<int>.WithResponse<Response<IEnumerable<JuzgadosDto>>>
    {
        private readonly IEmbargosBusinessLogic _juzgadosBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Juzgados Por Dpto 
        /// </summary>
        /// <param name="juzgadosBusinessLogic"></param>
        public ObtenerJuzgadosPorDepartamento(IEmbargosBusinessLogic juzgadosBusinessLogic)
        {
            _juzgadosBusinessLogic = juzgadosBusinessLogic;
        }

        /// <summary>
        /// ObtenerJuzgadosPorDepartamento
        /// </summary>
        /// <param name="idDpto"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Embargos/ObtenerJuzgadosPorDepartamento")]
        [ProducesResponseType(typeof(Response<IEnumerable<JuzgadosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene todos los juzgados por departamento",
           Description = "Obtiene todos los juzgados por departamento",
           OperationId = "Embargos.ObtenerJuzgadosPorDepartamento",
           Tags = new[] { "EmbargosEndPoints" })]

        public override async Task<ActionResult<Response<IEnumerable<JuzgadosDto>>>> HandleAsync(int idDpto, CancellationToken cancellationToken = default)
        {
            return await this._juzgadosBusinessLogic.ObtenerJuzgadosPorDepartamento(idDpto);
        }
    }
}
