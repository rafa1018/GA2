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
    /// Endpoint para Obtener Tipo Abono
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>09/09/2021</date>
    [Authorize]
    public class ObtenerTipoAbono : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TipoAbonoDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Tipo Credito
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerTipoAbono(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerTipoAbono")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoAbonoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ObtenerTipoAbono",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<TipoAbonoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerTipoAbono();
        }

    }
}
