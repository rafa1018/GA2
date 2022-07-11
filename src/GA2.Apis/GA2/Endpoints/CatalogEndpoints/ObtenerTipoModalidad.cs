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
	/// Endpoint para Obtener Tipo de Modalidad
	/// </summary>
	/// <author>Erwin Pantoja España</author>
	/// <date>22/09/2021</date>
    [Authorize]
    public class ObtenerTipoModalidad : 
        BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<IEnumerable<TipoModalidadDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Tipo Modalidad
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Erwin Pantoja España</author>
        /// <date>22/09/2021</date>
        public ObtenerTipoModalidad(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene todos los tipos de modalidad
        /// </summary>
        /// <param name="IdTipoSolicitud"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerTipoModalidad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoModalidadDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ObtenerTipoModalidad",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<TipoModalidadDto>>>> HandleAsync(string IdTipoSolicitud, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerTiposModalidad(IdTipoSolicitud);
        }
    }
}
