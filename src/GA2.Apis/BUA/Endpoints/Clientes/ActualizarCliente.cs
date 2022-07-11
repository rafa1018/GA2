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

namespace GA2.Apis.BUA.Endpoints
{
    /// <summary>
    /// Endpoint que actualiza los datos de usuario
    /// <author>Nicolas Florez Sarrazola</author>
    /// </summary>
    [Authorize]
    public class ActualizarCliente : BaseAsyncEndpoint.WithRequest<ClienteDto>.WithResponse<Response<ClienteDto>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="clientsBusinessLogic"></param>
        public ActualizarCliente(IClientesBusinessLogic clientsBusinessLogic)
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
        [HttpPatch("api/clientes")]
        [ProducesResponseType(typeof(Response<ClienteDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualiza los datos de un cliente",
           Description = "Actualiza un cliente",
           OperationId = "client.actualizarcliente",
           Tags = new[] { "ClientEndpoint" })]
        public async override Task<ActionResult<Response<ClienteDto>>> HandleAsync(ClienteDto request, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ActualizarCliente(request);
        }
    }
}
