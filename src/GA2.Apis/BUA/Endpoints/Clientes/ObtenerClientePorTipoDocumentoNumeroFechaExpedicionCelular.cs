using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Application.Dto.Identity;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.BUA.Endpoints
{
    /// <summary>
    /// Obtiene Cliente Paa
    /// </summary>
    public class ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular :
                BaseAsyncEndpoint.WithRequest<LoginPaaDto>.WithResponse<Response<ClienteDto>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        /// <summary>
        /// Constructor e inyección de dependencias
        /// </summary>
        /// <param name="clientsBussinesLogic"></param>
        public ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular(IClientesBusinessLogic clientsBussinesLogic)
        {
            _clientsBusinessLogic = clientsBussinesLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns> 
        [HttpGet("api/clientes/ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular")]
        [SwaggerOperation(
        Summary = "Trae los datos de un usuario",
           Description = "Trae los datos de un usuario al enviar un id por request",
           OperationId = "Client.ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular",
           Tags = new[] { "ClientEndpoint" })]
        public override async Task<ActionResult<Response<ClienteDto>>> HandleAsync([FromQuery] LoginPaaDto request, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ObtenerClientePorTipoDocumentoNumeroFechaExpedicionCelular(
                request.TipoDocumento, request.NumeroIdentificacion, request.NumeroCelular, request.FechaExpedicion);
        }
    }
}
