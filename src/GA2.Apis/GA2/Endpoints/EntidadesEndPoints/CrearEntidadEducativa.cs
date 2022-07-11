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
    /// Endpoint para Crear una Entidad Educativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class CrearEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<EntidadEducativaDto>
        .WithResponse<Response<EntidadEducativaDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint CrearEntidadEducativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public CrearEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Crear Entidad Educativa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/Entidades/CrearEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<EntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Crear Entidad Educativa",
            Description = "Crear Entidad Educativa",
            OperationId = "Entidades.EntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<EntidadEducativaDto>>> HandleAsync(EntidadEducativaDto request, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.CrearEntidadEducativa(request);
        }
    }
}

