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
    /// Endpoint para Eliminar una Entidad Educativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class EliminarEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<EntidadEducativaDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// EliminarEntidadEducativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public EliminarEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Eliminar Entidad Educativa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/Entidades/EliminarEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<EntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Eliminar Entidad Educativa",
            Description = "Eliminar Entidad Educativa",
            OperationId = "Entidades.EntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<EntidadEducativaDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.EliminarEntidadEducativaPorId(request);
        }
    }
}

