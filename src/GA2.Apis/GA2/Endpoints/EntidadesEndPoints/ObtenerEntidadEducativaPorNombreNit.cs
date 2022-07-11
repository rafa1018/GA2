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
    
    [Authorize]
    public class ObtenerEntidadEducativaPorNombreNit : BaseAsyncEndpoint
        .WithRequest<EntidadEducativaDto>.WithResponse<Response<IEnumerable<EntidadEducativaDto>>>
    {
        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Entidad Educativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public ObtenerEntidadEducativaPorNombreNit(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// ObtenerEntidadEducativaPorNitNombre
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Entidades/ObtenerEntidadEducativaPorNitNombre")]
        [ProducesResponseType(typeof(Response<IEnumerable<EntidadEducativaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene todas las entidades educativas del catalogo",
           Description = "Obtiene todas las entidades educativas del catalogo",
           OperationId = "Entidades.ObtenerEntidadEducativaPorNitNombre",
           Tags = new[] { "EntidadesEndpoint" })]

        public override async Task<ActionResult<Response<IEnumerable<EntidadEducativaDto>>>> HandleAsync(EntidadEducativaDto request, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerEntidadEducativaPorNombreNit(request);
        }
    }
}
