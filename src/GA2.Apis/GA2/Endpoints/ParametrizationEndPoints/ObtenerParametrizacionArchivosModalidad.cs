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
    [Authorize]
    public class ObtenerParametrizacionArchivosModalidad : BaseAsyncEndpoint.WithRequest<int>.WithResponse<Response<IEnumerable<ParametrizacionArchivoModalidadDto>>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Update Legal Tasa
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        /// <author>Erwin Pantoja España</author>
        /// <date>18/05/2021</date>
        public ObtenerParametrizacionArchivosModalidad(IParametrizacionBusinessLogic parametrizationBusinessLogic)
        {
            _parametrizationBusinessLogic = parametrizationBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoModalidadId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/parametrizacion/obtenerArchivosPorModalidad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<ParametrizacionArchivoModalidadDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene los archivos parametrizados por modalidad",
            Description = "Obtiene parametrizacion de archivos por modalidad",
            OperationId = "parametrizacion.obtenerArchivosPorModalidad",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ParametrizacionArchivoModalidadDto>>>> HandleAsync(int tipoModalidadId, CancellationToken cancellationToken = default)
        {
            return await _parametrizationBusinessLogic.ObtenerParametrizacionArchivosModalidad(tipoModalidadId);
        }
    }
}
