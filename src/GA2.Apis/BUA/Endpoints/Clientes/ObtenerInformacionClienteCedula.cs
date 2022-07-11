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
    /// Endpoint Obtener usuario por cedula
    /// <author>Erwin Pantoja España</author>
    /// </summary>
    // [Authorize]
    public class ObtenerInformacionClienteCedula : BaseAsyncEndpoint.WithRequest<int>.WithResponse<Response<ClienteCedulaDto>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="clientsBussinesLogic"></param>
        public ObtenerInformacionClienteCedula(IClientesBusinessLogic clientsBussinesLogic)
        {
            _clientsBusinessLogic = clientsBussinesLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identificacionCliente">Cedula del cliente</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns> 
        [SwaggerOperation(
        Summary = "Trae los datos de un usuario filtrado por cedula",
           Description = "Trae los datos de un usuario filtrado por cedula",
           OperationId = "Client.ObtenerInformacionClienteCedula",
           Tags = new[] { "ClientEndpoint" })]
        [HttpPost("api/clientes/ObtenerInformacionClienteCedula")]
        public override async Task<ActionResult<Response<ClienteCedulaDto>>> HandleAsync(int identificacionCliente, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ObtenerInformacionClienteCedula(identificacionCliente);
        }

    }
}
