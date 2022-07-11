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
    /// Endpoint para Crear Programa Educativo
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class CrearProgramaEducativo :
         BaseAsyncEndpoint.WithRequest<ProgramaEducativoDto>
        .WithResponse<Response<ProgramaEducativoDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Programa Educativo
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public CrearProgramaEducativo(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Crear Programa Educativo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        [HttpPost("api/Entidades/CrearProgramaEducativo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProgramaEducativoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Crear Programa Educativo",
            Description = "Crear Programa Educativo",
            OperationId = "Entidades.CrearProgramaEducativo",
            Tags = new[] { "EntidadesEndpoint" })]
        public override async Task<ActionResult<Response<ProgramaEducativoDto>>> HandleAsync(ProgramaEducativoDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.CrearProgramaEducativo(request);
        }
    }
}

