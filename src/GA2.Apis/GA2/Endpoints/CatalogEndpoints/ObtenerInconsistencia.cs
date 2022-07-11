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
	/// Endpoint para Obtener Tipo de Inconsistencia documental
	/// </summary>
	/// <author>Hanson Restrepo</author>
	/// <date>24/05/2022</date>
    public class ObtenerInconsistencia:
        BaseAsyncEndpoint.WithRequest<int>.WithResponse<Response<IEnumerable<TipoInconsistenciaDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Tipo de Inconsistencia documental
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>24/05/2022</date>
        public ObtenerInconsistencia(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene todos los tipos de modalidad
        /// </summary>
        /// <param name="GrupoInconsistencia"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerInconsistencia")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoInconsistenciaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ObtenerInconsistencia",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<TipoInconsistenciaDto>>>> HandleAsync(int GrupoInconsistencia, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerInconsistencias(GrupoInconsistencia);
        }
    }
}
