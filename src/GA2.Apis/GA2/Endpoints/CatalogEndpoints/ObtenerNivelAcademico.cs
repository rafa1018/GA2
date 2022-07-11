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

namespace GA2.Apis.GA2.Endpoints.CatalogEndpoints
{
    /// <summary>
    /// Obtener Nivel Academico
    /// </summary>
    [Authorize]
    public class ObtenerNivelAcademico : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<NivelAcademicoDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogosBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogosBusinessLogic"></param>
        public ObtenerNivelAcademico(ICatalogosBusinessLogic catalogosBusinessLogic)
        {
            _catalogosBusinessLogic = catalogosBusinessLogic;
        }

        // <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        [HttpGet("api/catalogos/ObtenerNivelAcademico")]
        [ProducesResponseType(typeof(Response<IEnumerable<NivelAcademicoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Nivel Academico",
            Description = "Obtener Nivel Academico",
            OperationId = "catalogos.ObtenerNivelAcademico",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<NivelAcademicoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await _catalogosBusinessLogic.ObtenerNivelAcademico();
        }
    }
}
