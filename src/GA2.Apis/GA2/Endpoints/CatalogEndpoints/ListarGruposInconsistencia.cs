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
	/// Endpoint para Obtener lista de grupos de Inconsistencia documental
	/// </summary>
	/// <author>Hanson Restrepo</author>
	/// <date>25/05/2022</date>
    public class ListarGruposInconsistencia :
        BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<GrupoInconsistenciaDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener lista de grupos de Inconsistencia documental
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>25/05/2022</date>
        public ListarGruposInconsistencia(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// Obtiene todos los tipos de modalidad
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ListarGruposInconsistencia")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<GrupoInconsistenciaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ListarGruposInconsistencia",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<GrupoInconsistenciaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ListarGruposInconsistencia();
        }
    }
}