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

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
	/// Endpoint para Obtener Entidad Educativa
	/// </summary>
	/// <author>Hanson Restrepo</author>
	/// <date>26/01/2022</date>
    // [Authorize]
    public class ObtenerEntidadEducativa : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<EntidadEducativaDto>>>
    {
        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Entidad Educativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public ObtenerEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }
        /// <summary></summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/Entidades/ObtenerEntidadEducativa")]
        [ProducesResponseType(typeof(Response<IEnumerable<EntidadEducativaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene todas las entidades educativas del catalogo",
           Description = "Obtiene todas las entidades educativas del catalogo",
           OperationId = "Entidades.obtenerentidadeducativa",
           Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<EntidadEducativaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerEntidadEducativa();
        }
    }
}
