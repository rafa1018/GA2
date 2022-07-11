using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Endpoints.CreditoEndpoints.Simulador.SolicitudCredito
{
    /// <summary>
    /// Enpoint para crear simulacion del cliente
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    //[Authorize]
    public class CrearSimulacionCliente : BaseAsyncEndpoint.WithRequest<CreacionSimulacionClienteDto>.WithResponse<Response<IEnumerable<SimulacionDto>>>
    {
        private readonly IProspeccionBusinessLogic _prospeccionBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prospeccionBusinessLogic"></param>
        public CrearSimulacionCliente(IProspeccionBusinessLogic prospeccionBusinessLogic)
        {
            _prospeccionBusinessLogic = prospeccionBusinessLogic;
        }


        /// <summary>
        /// crea simulacion del cliente
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("/api/prospeccion/CrearSimulacionCliente")]
        [ProducesResponseType(typeof(Response<IEnumerable<SimulacionDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation("Crear Simulacion Cliente",
            Description = "Crear Simulacion Clienteo",
            OperationId = "prospeccion.CrearSimulacionCliente",
            Tags = new[] { "ProspeccionEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<SimulacionDto>>>> HandleAsync(CreacionSimulacionClienteDto request, CancellationToken cancellationToken = default)
        {
            return await _prospeccionBusinessLogic.CrearSimulacionCliente(request);
        }
    }
}
