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
    /// Endpoint para Crear Bloqueo Entidad Educativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class BloqueoEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<BloqueoEntidadEducativaDto>
        .WithResponse<Response<BloqueoEntidadEducativaDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint BloqueoEntidadEducativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public BloqueoEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Crear Bloqueo Entidad Educativa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Entidades/BloqueoEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<BloqueoEntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Crear Bloqueo Entidad Educativa",
            Description = "Crear Bloqueo Entidad Educativa",
            OperationId = "Entidades.EntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<BloqueoEntidadEducativaDto>>> HandleAsync(BloqueoEntidadEducativaDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.BloqueoEntidadEducativa(request);
        }
    }
}

