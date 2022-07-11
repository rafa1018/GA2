using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
	/// Endpoint para Obtener Nivel Educativo
	/// </summary>
	/// <author>Hanson Restrepo</author>
	/// <date>26/01/2022</date>
    [Authorize]
    public class ObtenerNivelEducativoCesantias :
        BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<IEnumerable<NivelEducativoDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Nivel Educativo
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>26/01/2022</date>
        public ObtenerNivelEducativoCesantias(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// Obtiene todos los Niveles Educativos
        /// </summary>
        /// <param name="idPrograma"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerNivelEducativoCesantias")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<NivelEducativoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ObtenerNivelEducativoCesantias",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<NivelEducativoDto>>>> HandleAsync(Guid idPrograma, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerNivelEducativoCesantias(idPrograma);
        }
    }
}
