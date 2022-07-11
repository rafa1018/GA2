using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.DatosPersonales
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    public class ObtenerSimulacionPersonales:BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<SimulacionDatosPersonalesDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerSimulacionPersonales(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerSimulacionPersonales")]
        [ProducesResponseType(typeof(Response<IEnumerable<SimulacionDatosPersonalesDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Datos Personales Simulacion",
            Description = "Obtener Datos Personales Simulacion",
            OperationId = "credito.obtenerDatosPersonalesSimulacion",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SimulacionDatosPersonalesDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerSimulacionPersonales(request);
        }
    }
}
