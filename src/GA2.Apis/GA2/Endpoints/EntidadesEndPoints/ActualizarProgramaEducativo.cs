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
    /// Endpoint para Actualizar Programa Educativo
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>11/03/2022</date>
    
    [Authorize]
    public class ActualizarProgramaEducativo :
         BaseAsyncEndpoint.WithRequest<ProgramaEducativoDto>
        .WithResponse<Response<ProgramaEducativoDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Actualizar Programa Educativo
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Edwin Lopez</author>
        /// <date>11/03/2022</date>
        public ActualizarProgramaEducativo(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/Entidades/ActualizarProgramaEducativo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProgramaEducativoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Programa Educativo",
            Description = "Actualizar Programa Educativo",
            OperationId = "Entidades.ActualizarProgramaEducativo",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<ProgramaEducativoDto>>> HandleAsync(ProgramaEducativoDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.ActualizarProgramaEducativo(request);
        }
    }
}

