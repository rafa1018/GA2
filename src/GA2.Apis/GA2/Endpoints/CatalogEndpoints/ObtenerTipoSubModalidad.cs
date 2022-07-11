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
	/// Endpoint para Obtener Tipo de SubModalidad
	/// </summary>
	/// <author>Erwin Pantoja España</author>
	/// <date>22/09/2021</date>
    public class ObtenerTipoSubModalidad:
        BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<IEnumerable<TipoSubModalidadDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Tipo SubModalidad
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Erwin Pantoja España</author>
        /// <date>22/09/2021</date>
        public ObtenerTipoSubModalidad(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene todos los tipos de modalidad
        /// </summary>
        /// <param name="IdTipoModalidad"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerTipoSubModalidad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoSubModalidadDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ObtenerTipoSubModalidad",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<TipoSubModalidadDto>>>> HandleAsync(string IdTipoModalidad, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerTiposSubModalidad(IdTipoModalidad);
        }
    }
}
