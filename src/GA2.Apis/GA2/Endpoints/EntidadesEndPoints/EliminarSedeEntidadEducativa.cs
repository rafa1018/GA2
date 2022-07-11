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
    /// Endpoint para Eliminar Sede Entidad Educativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class EliminarSedeEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<SedeEntidadEducativaDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// EliminarSedesEntidadEducativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public EliminarSedeEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Eliminar Entidad Educativa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/Entidades/EliminarSedesEntidadEducativaPorId")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<SedeEntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Eliminar Sede Entidad Educativa",
            Description = "Eliminar Sede Entidad Educativa",
            OperationId = "Entidades.EliminarSedesEntidadEducativaPorId",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<SedeEntidadEducativaDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.EliminarSedesEntidadEducativaPorId(request);
        }
    }
}

