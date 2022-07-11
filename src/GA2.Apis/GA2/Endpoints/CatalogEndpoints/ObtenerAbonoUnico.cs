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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ObtenerAbonoUnico:BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<AbonoUnicoDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogos;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogos"></param>
        public ObtenerAbonoUnico(ICatalogosBusinessLogic catalogos)
        {
            _catalogos = catalogos;
        }

        /// <summary>
        /// obtener Abono Unico
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/obtenerAbonoUnico")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<AbonoUnicoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Obtener Abono Unico",
            Description = "Obtener Abono Unico",
            OperationId = "catalogos.ObtenerAbonoUnico",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<AbonoUnicoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogos.ObtenerAbonoUnico();
        }
    }
}
