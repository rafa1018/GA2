using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.BUA.Endpoints.Clientes
{
    /// <summary>
    /// Endpoint que recibe un json y lista de usuarios no existentes
    /// </summary>
    [Authorize]
    public class ValidarMultiplesClientes : BaseAsyncEndpoint.WithRequest<ComponentesDTO>.WithoutResponse
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientsBusinessLogic"></param>
        public ValidarMultiplesClientes(IClientesBusinessLogic clientsBusinessLogic)
        {
            _clientsBusinessLogic = clientsBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>void</returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/validarclientes")]
        [Consumes("application/json")]
        [RequestSizeLimit(100_000_000)]
        [ProducesResponseType(typeof(Response<IEnumerable<ClienteSinCrearDTO>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Envía un Json y retorna listas de usuarios.",
            Description = "Envía un Json y retorna listas de usuarios No existentes en BUA",
            OperationId = "client.validarClientes",
            Tags = new[] { "ClientEndpoint" })]
        public async override Task<ActionResult> HandleAsync(ComponentesDTO request, CancellationToken cancellationToken = default)
        {
            var json = JsonConvert.SerializeObject(request.BODY);
            return Ok(await _clientsBusinessLogic.ValidarClientes(json));
        }
    }
}
