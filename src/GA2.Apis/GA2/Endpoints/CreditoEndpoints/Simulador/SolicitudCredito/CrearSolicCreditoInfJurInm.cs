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

namespace GA2.Endpoints.CreditoEndpoints.Simulador.SolicitudCredito
{
    /// <summary>
    /// Crea Solicitud credito informacion juridica inmueble
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class CrearSolicCreditoInfJurInm : BaseAsyncEndpoint.WithRequest<SolicCreditoInfJurInmDto>.WithResponse<Response<SolicCreditoInfJurInmDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CrearSolicCreditoInfJurInm(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Crea Solicitud credito informacion juridica inmueble
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearSolicCreditoInfJurInm")]
        [ProducesResponseType(typeof(Response<SolicCreditoInfJurInmDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Solicitud Credito Informacion Juridica Inmueble",
            Description = "Crear Solicitud Credito Informacion Juridica Inmueble",
            OperationId = "credito.CrearSolicCreditoInfJurInm",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SolicCreditoInfJurInmDto>>> HandleAsync(SolicCreditoInfJurInmDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.CrearSolicCreditoInfJurInm(request);
        }
    }
}
