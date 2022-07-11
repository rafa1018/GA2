using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para actualizar parametrizacion legal alivio
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    [Authorize]
    public class CrearLegalAlivio : BaseAsyncEndpoint.WithRequest<ParametrizacionLegalAlivioDto>.WithResponse<Response<ParametrizacionLegalAlivioDto>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Crear Legal Alivio
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>17/05/2021</date>
        public CrearLegalAlivio(IParametrizacionBusinessLogic parametrizationBusinessLogic)
        {
            _parametrizationBusinessLogic = parametrizationBusinessLogic;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/parametrizacion/CrearLegalAlivio")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ParametrizacionLegalAlivioDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene parametrizacion legal Alivio",
            Description = "Obtiene parametrizacion legal Alivio",
            OperationId = "parametrizacion.CrearLegaAlivio",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<ParametrizacionLegalAlivioDto>>> HandleAsync(ParametrizacionLegalAlivioDto request, CancellationToken cancellationToken = default)
        {
            return await _parametrizationBusinessLogic.CrearLegalAlivio(request);
        }
    }
}