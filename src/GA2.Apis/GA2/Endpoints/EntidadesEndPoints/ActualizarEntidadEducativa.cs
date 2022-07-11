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
    /// Endpoint para Actualizar Entidad Educativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>11/05/2021</date>
    
    [Authorize]
    public class ActualizarEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<EntidadEducativaDto>
        .WithResponse<Response<EntidadEducativaDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Actualizar Entidad Educativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ActualizarEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Actualizar Entidad Educativa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/Entidades/ActualizarEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<EntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Entidad Educativa",
            Description = "Actualizar Entidad Educativa",
            OperationId = "Entidades.ActualizarEntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<EntidadEducativaDto>>> HandleAsync(EntidadEducativaDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.ActualizarEntidadEducativa(request);
        }
    }
}

