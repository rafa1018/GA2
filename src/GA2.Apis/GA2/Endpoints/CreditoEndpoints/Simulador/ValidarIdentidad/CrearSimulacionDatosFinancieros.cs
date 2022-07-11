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

namespace GA2.Endpoints.CreditoEndpoints.Simulador
{
    /// <summary>
    /// EndPoint para Crear los datos financieros de la simulacion
    /// </summary>
    //[Authorize]
    public class CrearSimulacionDatosFinancieros : BaseAsyncEndpoint
        .WithRequest<SimulacionDatosFinancierosDto>.WithResponse<Response<SimulacionDatosFinancierosDto>>
    {
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;

        /// <summary>
        /// Endpoint Crear validacion identidad
        /// </summary>
        /// <param name="identidadBusinessLogic"></param>
        public CrearSimulacionDatosFinancieros(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// 

        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/CrearSimulacionDatosFinancieros")]
        [ProducesResponseType(typeof(Response<SimulacionDatosFinancierosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crea Datos Financieros de la Simulacion",
            Description = "",
            OperationId = "credito.CrearSimulacionDatosFinancieros",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SimulacionDatosFinancierosDto>>> HandleAsync(SimulacionDatosFinancierosDto request, CancellationToken cancellationToken = default)
        {
            return await this._identidadBusinessLogic.CrearSimulacionDatosFinancieros(request);
        }
    }
}
