using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// Endpoint para Obtener Sedes Por Entidad Educativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    // [Authorize]
    public class ObtenerSedesPorEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<IEnumerable<SedeEntidadEducativaDto>>>
    {

        private readonly IEntidadesBusinessLogic _entidadEducativaBusinessLogic;

        /// <summary>
        /// ObtenerSedesPorEntidadEducativa
        /// </summary>
        /// <param name="entidadEducativaBusinessLogic"></param>
        public ObtenerSedesPorEntidadEducativa(IEntidadesBusinessLogic entidadEducativaBusinessLogic)
        {
            _entidadEducativaBusinessLogic = entidadEducativaBusinessLogic;
        }


        /// <summary>
        /// Obtener Sedes Por Entidad Educativa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/Entidades/ObtenerSedesPorEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<SedeEntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Obtener Sedes Por Entidad Educativa",
            Description = "Obtener Sedes Por Entidad Educativa",
            OperationId = "Entidades.EntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]

        public async override Task<ActionResult<Response<IEnumerable<SedeEntidadEducativaDto>>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._entidadEducativaBusinessLogic.ObtenerSedesPorEntidadEducativa(request);
        }
    }
}

