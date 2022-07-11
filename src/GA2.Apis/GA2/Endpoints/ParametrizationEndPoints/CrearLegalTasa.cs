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
    /// Endpoint para actualizar parametrizacion legal tasa
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    [Authorize]
    public class CrearLegalTasa : BaseAsyncEndpoint.WithRequest<ParametrizacionLegalTasaDto>.WithResponse<Response<ParametrizacionLegalTasaDto>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Insert Legal Tasa
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public CrearLegalTasa(IParametrizacionBusinessLogic parametrizationBusinessLogic)
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
        [HttpPost("api/parametrizacion/CrearLegalTasa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ParametrizacionLegalTasaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene parametrizacion legal tasa",
            Description = "Obtiene parametrizacion legal tasa",
            OperationId = "parametrizacion.updateLegalTasa",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<ParametrizacionLegalTasaDto>>> HandleAsync(ParametrizacionLegalTasaDto request, CancellationToken cancellationToken = default)
        {
            return await _parametrizationBusinessLogic.CrearLegalTasa(request);
        }
    }
}