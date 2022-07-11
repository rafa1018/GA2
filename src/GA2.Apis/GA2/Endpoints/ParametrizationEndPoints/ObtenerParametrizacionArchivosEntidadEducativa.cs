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
    /// Endpoint para obtener la parametrizacion de los archivos por modalidad de solicitud
    /// <author>Erwin Pantoja España</author>
    /// <date>14/10/2021</date>
    /// </summary>
    /// [Authorize]
    public class ObtenerParametrizacionArchivosEntidadEducativa : BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<IEnumerable<ParametrizacionArchivoEntidadEducativaDto>>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Update Legal Tasa
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        /// <author>Erwin Pantoja España</author>
        /// <date>18/05/2021</date>
        public ObtenerParametrizacionArchivosEntidadEducativa(IParametrizacionBusinessLogic parametrizationBusinessLogic)
        {
            _parametrizationBusinessLogic = parametrizationBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entidadId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/Parametrizacion/ObtenerParametrizacionArchivosEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<ParametrizacionArchivoEntidadEducativaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene los archivos parametrizados por EntidadE ducativa",
            Description = "Obtiene parametrizacion de archivos por Entidad Educativa",
            OperationId = "parametrizacion.obtenerArchivosPorEntidadEducativa",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ParametrizacionArchivoEntidadEducativaDto>>>> HandleAsync(string entidadId, CancellationToken cancellationToken = default)
        {
            return await _parametrizationBusinessLogic.ObtenerParametrizacionArchivosEntidadEducativa(entidadId);
        }
    }
}
