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
    /// Endpoint para actualizar parametrizacion de seguro
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>15/03/2021</date>
    /// </summary>
    [Authorize]
    public class CrearSeguro : BaseAsyncEndpoint.WithRequest<ParametrizacionSeguroDto>.WithResponse<Response<ParametrizacionSeguroDto>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint parametro Crear Seguro
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public CrearSeguro(IParametrizacionBusinessLogic parametrizationBusinessLogic)
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
        [HttpPatch("api/parametrizacion/CrearSeguro")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ParametrizacionSeguroDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Seguros",
            Description = "crear parametrizacion de seguros",
            OperationId = "seguros.crearSeguro",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<ParametrizacionSeguroDto>>> HandleAsync(ParametrizacionSeguroDto request, CancellationToken cancellationToken = default)
        {
            return await _parametrizationBusinessLogic.CrearSeguro(request);
        }
    }
}
