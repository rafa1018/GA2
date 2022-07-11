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
    public class ObtenerPuntosAtencionInconsistencia :
        BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<PuntosAtencionInconsistenciaDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener puntos de atención para Inconsistencia documental
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>25/05/2022</date>
        public ObtenerPuntosAtencionInconsistencia(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// Obtiene los puntos de atención para Inconsistencia documental
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerPuntosAtencionInconsistencia")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<PuntosAtencionInconsistenciaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "catalogos.ObtenerPuntosAtencionInconsistencia",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<PuntosAtencionInconsistenciaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerPuntosAtencionInconsistencia();
        }
    }
}
