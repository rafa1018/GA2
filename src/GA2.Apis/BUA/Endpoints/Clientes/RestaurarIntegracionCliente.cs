using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.BUA.Endpoints.Clientes
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class RestaurarIntegracionCliente : BaseAsyncEndpoint.WithRequest<RestaurarIntegracionClienteDTO>.WithResponse<Response<ClienteDto>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        /// <summary>
        /// Constructor e inyección de dependencias
        /// </summary>
        /// <param name="clientsBussinesLogic"></param>
        public RestaurarIntegracionCliente(
            IClientesBusinessLogic clientsBussinesLogic)
        {
            _clientsBusinessLogic = clientsBussinesLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns> 
        [SwaggerOperation(
        Summary = "Trae los datos de un usuario",
           Description = "Trae los datos de un usuario al enviar un id por request",
           OperationId = "Client.restaurarIntegracionCliente",
           Tags = new[] { "ClientEndpoint" })]
        //[ValidateAntiForgeryToken]
        [HttpPost("api/clientes/restaurarIntegracionCliente")]
        public override async Task<ActionResult<Response<ClienteDto>>> HandleAsync(RestaurarIntegracionClienteDTO request, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.RestaurarIntegracionCliente(request, User.Claims);
        }
    }
}
