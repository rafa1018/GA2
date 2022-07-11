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
    /// Endpoint para Crear una sede de una Entidad Educativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class CrearSedeEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<SedeEntidadEducativaDto>
        .WithResponse<Response<SedeEntidadEducativaDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint CrearSedeEntidadEducativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public CrearSedeEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Entidades/CrearSedeEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<SedeEntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Crear Sede Entidad Educativa",
            Description = "Crear Sede Entidad Educativa",
            OperationId = "Entidades.CrearSedeEntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<SedeEntidadEducativaDto>>> HandleAsync(SedeEntidadEducativaDto request, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.CrearSedeEntidadEducativa(request);
        }
    }
}

