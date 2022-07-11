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
    /// EndPoint para Crear la simulacion y los datos personales
    /// </summary>
    //[Authorize]
    public class CrearSimulacionDatosPersonales : BaseAsyncEndpoint
        .WithRequest<SimulacionDatosPersonalesDto>.WithResponse<Response<SimulacionDatosPersonalesDto>>
    {
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;

        /// <summary>
        /// Endpoint Crear validacion identidad
        /// </summary>
        /// <param name="identidadBusinessLogic"></param>
        public CrearSimulacionDatosPersonales(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
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
        [HttpPost("api/credito/CrearSimulacionDatosPersonales")]
        [ProducesResponseType(typeof(Response<SimulacionDatosPersonalesDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crea Simulacion y Datos Personales",
            Description = "",
            OperationId = "credito.CrearSimulacionDatosPersonales",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SimulacionDatosPersonalesDto>>> HandleAsync(SimulacionDatosPersonalesDto request, CancellationToken cancellationToken = default)
        {
            return await this._identidadBusinessLogic.CrearSimulacionDatosPersonales(request);
        }
    }
}
