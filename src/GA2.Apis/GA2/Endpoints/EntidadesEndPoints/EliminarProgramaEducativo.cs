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
    /// Endpoint para Eliminar Programa Educativo
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class EliminarProgramaEducativo :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<ProgramaEducativoDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// EliminarProgramaEducativo
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public EliminarProgramaEducativo(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Eliminar Entidad Educativa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/Entidades/EliminarProgramaEducativoPorId")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProgramaEducativoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Eliminar Entidad Educativa",
            Description = "Eliminar Entidad Educativa",
            OperationId = "Entidades.EntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<ProgramaEducativoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.EliminarProgramaEducativoPorId(request);
        }
    }
}

