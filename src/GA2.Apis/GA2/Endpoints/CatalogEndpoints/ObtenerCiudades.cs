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
    /// Endpoint para Obtener Ciudades
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>18/05/2021</date>
    [Authorize]
    public class ObtenerCiudades : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<CiudadDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Ciudades
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerCiudades(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/Catalogos/obtenerciudades")]
        [ProducesResponseType(typeof(Response<IEnumerable<CiudadDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.obtenerciudades",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<CiudadDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerCiudades();
        }
    }
}
