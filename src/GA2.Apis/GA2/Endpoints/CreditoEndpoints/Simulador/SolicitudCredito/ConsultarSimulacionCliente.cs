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
    /// Enpoint para consultar simulacion del cliente
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    //[Authorize]
    public class ConsultarSimulacionCliente : BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<SimulacionClienteDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ConsultarSimulacionCliente(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// consultar simulacion del cliente
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpGet("api/credito/consultarSimulacionCliente")]
        [ProducesResponseType(typeof(Response<SimulacionClienteDto>), StatusCodes.Status200OK)]
        [SwaggerOperation("Consultar Simulacion Cliente",
            Description = "Consultar Simulacion Clienteo",
            OperationId = "credito.ConsultarSimulacionCliente",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SimulacionClienteDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.ConsultarSimulacionCliente(request);
        }
    }
}
