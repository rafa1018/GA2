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
    /// Endpoint para obtener parametro transaccion
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>17/05/2021</date>
    [Authorize]
    public class ObtenerParametrosTransaccion : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<ParametroTransaccionDto>>>
    {
        private readonly IParametrizacionBusinessLogic _parametrizationBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint obtener parametro transaccion
        /// </summary>
        /// <param name="parametrizationBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>17/05/2021</date>
        public ObtenerParametrosTransaccion(IParametrizacionBusinessLogic parametrizationBusinessLogic)
        {
            _parametrizationBusinessLogic = parametrizationBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/parametrizacion/ObtenerParametroTransaccion")]
        [ProducesResponseType(typeof(Response<IEnumerable<ParametroTransaccionDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene parametrizaciones de transaccion",
            Description = "Actualiza parametrizaciones de transaccion",
            OperationId = "parametrizacion.getParametroTransaccion",
            Tags = new[] { "ParametrizationEndPoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ParametroTransaccionDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            //return null;
            return await this._parametrizationBusinessLogic.ObtenerParametrosTransaccion();
        }
    }
}
