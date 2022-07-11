
using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.BUA.Endpoints
{
    /// <summary>
    /// Endpoint Obtener usuario por id
    /// <author>Nicolas Florez Sarrazola</author>
    /// </summary>
    [Authorize]
    public class ObtenerClienteInformacion : BaseAsyncEndpoint.WithRequest<int>.WithResponse<Response<ClienteDto>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="clientsBussinesLogic"></param>
        public ObtenerClienteInformacion(IClientesBusinessLogic clientsBussinesLogic)
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
           OperationId = "Client.ObtenerClienteInformacion",
           Tags = new[] { "ClientEndpoint" })]
        [HttpGet("api/clientes")]
        public override async Task<ActionResult<Response<ClienteDto>>> HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ObtenerClienteInformacion(request);
        }
    }
}
