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
	/// Endpoint para Obtener Programa Educativo
	/// </summary>
	/// <author>Hanson Restrepo</author>
	/// <date>26/01/2022</date>
    [Authorize]
    public class ObtenerProgramaEducativo :
        BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<IEnumerable<ProgramaEducativoDto>>>
    {
        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Programa Educativo
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>26/01/2022</date>
        public ObtenerProgramaEducativo(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }

        /// <summary>
        /// Obtiene todos los Programas Educativos
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/Entidades/ObtenerProgramaEducativo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<ProgramaEducativoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene catalogo",
            Description = "Obtiene catalogo",
            OperationId = "Entidades.ObtenerProgramaEducativo",
            Tags = new[] { "EntidadesEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<ProgramaEducativoDto>>>> HandleAsync(Guid idEntidad, CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerProgramaEducativo(idEntidad);
        }
    }
}
