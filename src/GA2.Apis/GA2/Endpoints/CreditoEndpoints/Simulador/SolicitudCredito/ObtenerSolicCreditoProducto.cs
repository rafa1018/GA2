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

namespace GA2.Endpoints.Credito.Simulador
{
    /// <summary>
    /// Obtiene solicitud Credito producto
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    //[Authorize]
    public class ObtenerSolicCreditoProducto : BaseAsyncEndpoint.WithRequest<PeticionSolicitudCreditoProductoDto>.WithResponse<Response<RespuestaSolicitudCreditoProductoDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerSolicCreditoProducto(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene solicitud Credito producto
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerSolicCreditoProducto")]
        [ProducesResponseType(typeof(Response<RespuestaSolicitudCreditoProductoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Solicitud Credito Producto",
            Description = "Obtiene Solicitud Credito Producto",
            OperationId = "credito.ObtenerSolicCreditoProducto",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<RespuestaSolicitudCreditoProductoDto>>> HandleAsync(PeticionSolicitudCreditoProductoDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerSolicCreditoProducto(request);
        }
    }
}
