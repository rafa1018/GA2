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
    /// Endpoint para Obtener Ciduades Por Departamentos
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>18/05/2021</date>
    [Authorize]
    public class ObtenerCiudadesPorDepartamento : BaseAsyncEndpoint.WithRequest<int>.WithResponse<Response<IEnumerable<CiudadDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Ciduades Por Departamento
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerCiudadesPorDepartamento(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// Obtiene valores el catalogo ciudades que correspondan al depatamento
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/Catalogos/obtenerciduadespordepartamento")]
        [ProducesResponseType(typeof(Response<IEnumerable<CiudadDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene valores el catalogo ciudades que correspondan al depatamento",
            Description = "Obtiene valores el catalogo ciudades que correspondan al depatamento",
            OperationId = "catalogos.obtenerciduadespordepartamento",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<CiudadDto>>>> HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerCiudadesPorDepartamento(request);
        }
    }
}
