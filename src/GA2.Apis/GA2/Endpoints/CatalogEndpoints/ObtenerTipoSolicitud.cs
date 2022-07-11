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
	/// Endpoint para Obtener Tipo de Solicitud
	/// </summary>
	/// <author>Erwin Pantoja España</author>
	/// <date>22/09/2021</date>
    [Authorize]
    public class ObtenerTipoSolicitud : BaseAsyncEndpoint
        .WithRequest<int>.WithResponse<Response<IEnumerable<TipoSolicitudDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Tipo Solicitud
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Erwin Pantoja</author>
        /// <date>22/09/2021</date>
        public ObtenerTipoSolicitud(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene todas los tipos de solicitud
        /// </summary>
        /// <param name="IdTipoActor"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerTipoSolicitud")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoSolicitudDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ObtenerTipoSolicitud",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<TipoSolicitudDto>>>> HandleAsync(int IdTipoActor, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerTiposSolicitud(IdTipoActor);
        }
    }
}
