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
    /// Endpoint para Eliminar Juzgado Por Ciudad
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>05/04/2022</date>
    
    [Authorize]
    public class ObtenerJuzgadosPorCiudad : BaseAsyncEndpoint
        .WithRequest<JuzgadoDptoCiudadDto>.WithResponse<Response<IEnumerable<JuzgadosDto>>>
    {
        private readonly IEmbargosBusinessLogic _juzgadosBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Juzgados Por Ciudad 
        /// </summary>
        /// <param name="juzgadosBusinessLogic"></param>
        public ObtenerJuzgadosPorCiudad(IEmbargosBusinessLogic juzgadosBusinessLogic)
        {
            _juzgadosBusinessLogic = juzgadosBusinessLogic;
        }

        /// <summary>
        /// ObtenerJuzgadosPorCiudad
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Embargos/ObtenerJuzgadosPorCiudad")]
        [ProducesResponseType(typeof(Response<IEnumerable<JuzgadosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene todas los juzgados de una ciudad",
           Description = "Obtiene todas los juzgados de una ciudad",
           OperationId = "Embargos.ObtenerJuzgadosPorCiudad",
           Tags = new[] { "EmbargosEndPoints" })]



        public override async Task<ActionResult<Response<IEnumerable<JuzgadosDto>>>> HandleAsync(JuzgadoDptoCiudadDto request, CancellationToken cancellationToken = default)
        {
            return await _juzgadosBusinessLogic.ObtenerJuzgadosPorCiudad(request);
        }
    }
}
