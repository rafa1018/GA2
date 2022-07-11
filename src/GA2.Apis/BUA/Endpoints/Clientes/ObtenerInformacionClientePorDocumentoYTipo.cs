using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
namespace GA2.Apis.BUA.Endpoints.Clientes
{
    /// <summary>
    /// Endpoint Obtener usuario por tipo y número de documento
    /// <author>Erwin Pantoja España</author>
    /// </summary>
    [Authorize]
    public class ObtenerInformacionClientePorDocumentoYTipo : BaseAsyncEndpoint.WithRequest<RequestConsultaClienteDto>.WithResponse<Response<ClienteCesantiasDto>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        /// <summary>
        /// Constructor e inyección de dependencias
        /// </summary>
        /// <param name="clientsBussinesLogic"></param>
        public ObtenerInformacionClientePorDocumentoYTipo(
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
        Summary = "Trae el usuario",
           Description = "Trae los datos de un usuario cpnsultando por identificacion y tipo id",
           OperationId = "Client.ObtenerInformacionClientePorDocumentoYTipo",
           Tags = new[] { "ClientEndpoint" })]
        [HttpGet("api/clientes/ObtenerInformacionClientePorDocumentoYTipo")]
        public override async Task<ActionResult<Response<ClienteCesantiasDto>>> HandleAsync([FromQuery] RequestConsultaClienteDto request, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ObtenerInformacionClientePorDocumentoYTipo(request.tipoDocumentoId, request.numeroDocumento, request.idCliente);
        }
    }
}
