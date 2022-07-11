using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// Endpoint para Obtener Bloqueo EntidadEducativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class ObtenerBloqueoEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<IEnumerable<BloqueoEntidadEducativaDto>>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// ObtenerBloqueoEntidadEducativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public ObtenerBloqueoEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/Entidades/ObtenerBloqueoEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<BloqueoEntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Obtener BloqueoEntidad Educativa",
            Description = "Obtener BloqueoEntidad Educativa",
            OperationId = "Entidades.ObtenerBloqueoEntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<BloqueoEntidadEducativaDto>>>> HandleAsync(string idEntidad, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.ObtenerBloqueoEntidadEducativa(idEntidad);
        }

    }
}

