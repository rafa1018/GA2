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
    public class ObtenerInformacionByCedula : BaseAsyncEndpoint.WithRequest<int>.WithResponse<Response<ClienteCedulaDto>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="clientsBussinesLogic"></param>
        public ObtenerInformacionByCedula(IClientesBusinessLogic clientsBussinesLogic)
        {
            _clientsBusinessLogic = clientsBussinesLogic;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="identificacion">Cedula del cliente</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns> 
        [SwaggerOperation(
        Summary = "Trae los datos de un usuario filtrado por cedula",
           Description = "Trae los datos de un usuario filtrado por cedula",
           OperationId = "Client.ObtenerInformacionByCedula",
           Tags = new[] { "ClientEndpoint" })]
        [HttpGet("api/clientes/ObtenerInformacionByCedula")]
        public override async Task<ActionResult<Response<ClienteCedulaDto>>> HandleAsync(int identificacion, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ObtenerInformacionClienteCedula(identificacion);
        }

    }
}
