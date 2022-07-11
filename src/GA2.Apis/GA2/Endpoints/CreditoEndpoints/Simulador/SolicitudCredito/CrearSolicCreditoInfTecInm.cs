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
    /// Crea Solicitud Credito Informacion tecnica Inmueble
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    [Authorize]
    public class CrearSolicCreditoInfTecInm : BaseAsyncEndpoint.WithRequest<SolicCreditoInfTecInmDto>.WithResponse<Response<SolicCreditoInfTecInmDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CrearSolicCreditoInfTecInm(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Crea Solicitud Credito Informacion tecnica Inmueble
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearSolicCreditoInfTecInm")]
        [ProducesResponseType(typeof(Response<SolicCreditoInfTecInmDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Solicitud Credito Informacion Tecnica Inmueble",
            Description = "Crear Solicitud Credito Informacion Tecnica Inmueble",
            OperationId = "credito.CrearSolicCreditoInfTecInm",
            Tags = new[] { "CreditoEndpoint" })]

        public async override Task<ActionResult<Response<SolicCreditoInfTecInmDto>>> HandleAsync(SolicCreditoInfTecInmDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.CrearSolicCreditoInfTecInm(request);
        }
    }
}
