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
    /// Obtener Programa Educativo Por Entidad
    /// </summary>
    
    [Authorize]
    public class ObtenerProgramaEducativoPorEntidad :
        BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<IEnumerable<ListarProgramaEducativoDto>>>

    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Programa Educativo
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>26/01/2022</date>
        public ObtenerProgramaEducativoPorEntidad(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// ObtenerProgramaEducativoPorEntidad
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/Entidades/ObtenerProgramaEducativoPorEntidad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<ProgramaEducativoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene el Programa Educativo Por Entidad",
            Description = "Obtiene el Programa Educativo Por Entidad",
            OperationId = "Entidades.ObtenerProgramaEducativoPorEntidad",
            Tags = new[] { "EntidadesEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<ListarProgramaEducativoDto>>>> HandleAsync(string idEntidad, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.ObtenerProgramaEducativoPorEntidad(idEntidad);
        }
    }
}
