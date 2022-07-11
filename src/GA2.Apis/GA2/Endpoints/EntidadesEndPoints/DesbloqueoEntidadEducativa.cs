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
    /// Endpoint para Desbloqueo de Entidad Educativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class DesbloqueoEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<BloqueoEntidadEducativaDto>
        .WithResponse<Response<BloqueoEntidadEducativaDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint DesbloqueoEntidadEducativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public DesbloqueoEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// DesbloqueoEntidadEducativa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/Entidades/DesbloqueoEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<BloqueoEntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Desbloqueo Entidad Educativa",
            Description = "Desbloqueo Entidad Educativa",
            OperationId = "Entidades.DesbloqueoEntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<BloqueoEntidadEducativaDto>>> HandleAsync(BloqueoEntidadEducativaDto request, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.DesbloqueoEntidadEducativa(request);
        }

    }
}

