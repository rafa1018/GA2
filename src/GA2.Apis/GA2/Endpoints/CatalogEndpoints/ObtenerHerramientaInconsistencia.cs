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
	/// Endpoint para Obtener lista de herramientas de Inconsistencia documental
	/// </summary>
	/// <author>Hanson Restrepo</author>
	/// <date>25/05/2022</date>
    public class ObtenerHerramientaInconsistencia :
        BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<HerramientaInconsistenciaDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener lista de herramientas de Inconsistencia documental
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>25/05/2022</date>
        public ObtenerHerramientaInconsistencia(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// Obtiene la lista de herramientas de Inconsistencia documental
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerHerramientaInconsistencia")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<HerramientaInconsistenciaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ObtenerHerramientaInconsistencia",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<HerramientaInconsistenciaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerHerramientaInconsistencia();
        }
    }
}
