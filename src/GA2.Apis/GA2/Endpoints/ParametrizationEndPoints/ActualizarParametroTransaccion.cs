
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
	/// Endpoint para actualizar parametro transaccion
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>17/05/2021</date>
    [Authorize]
    public class ActualizarParametroTransaccion : BaseAsyncEndpoint.WithRequest<ParametroTransaccionDto>.WithResponse<Response<ParametroTransaccionDto>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint parametro transaccion
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ActualizarParametroTransaccion(IParametrizacionBusinessLogic parametrizationBusinessLogic)
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
        [HttpPatch("api/parametrizacion/ActualizarParametroTransaccion")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ParametroTransaccionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualiza parametrizacion de transaccion",
            Description = "Actualiza parametrizacion de transaccion",
            OperationId = "parametrizacion.ActualizarParametroTransaccion",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<ParametroTransaccionDto>>> HandleAsync(ParametroTransaccionDto request, CancellationToken cancellationToken = default)
        {
            //return null;
            return await _parametrizationBusinessLogic.ActualizarParametroTransaccion(request);
        }
    }
}
