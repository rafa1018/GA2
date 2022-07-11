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
    /// Endpoint para actualizar parametrizacion de tasas
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    [Authorize]
    public class CrearTasa : BaseAsyncEndpoint.WithRequest<ParametrizacionTasaDto>.WithResponse<Response<ParametrizacionTasaDto>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Crear Tasa
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public CrearTasa(IParametrizacionBusinessLogic parametrizationBusinessLogic)
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
        [HttpPatch("api/parametrizacion/CrearTasa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ParametrizacionTasaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene parametrizacion de tasas",
            Description = "Obtiene parametrizacion de tasas",
            OperationId = "parametrizacion.updateCrearTasa",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<ParametrizacionTasaDto>>> HandleAsync(ParametrizacionTasaDto request, CancellationToken cancellationToken = default)
        {
            return await _parametrizationBusinessLogic.CrearTasa(request);
        }
    }
}