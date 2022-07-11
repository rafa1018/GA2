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

namespace GA2.Apis.BUA.Endpoints.Clientes
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ObtenerCuentaById : BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<CuentaDto>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="clientsBusinessLogic"></param>
        public ObtenerCuentaById(IClientesBusinessLogic clientsBusinessLogic)
        {
            _clientsBusinessLogic = clientsBusinessLogic;
        }

        /// <summary>
        /// Update client info
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        //[ValidateAntiForgeryToken]
        [HttpGet("api/clientes/ObtenerCuentaById")]
        [ProducesResponseType(typeof(Response<CuentaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene la cuenta de un cliente por su identificacion",
           Description = "Obtiene la cuenta de un cliente por su identificacion",
           OperationId = "client.ObtenerCuentaById",
           Tags = new[] { "ClientEndpoint" })]
        public async override Task<ActionResult<Response<CuentaDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ObtenerCuentaById(request);
        }
    }
}
