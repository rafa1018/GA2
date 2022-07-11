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

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class CargarDatosFinancieros:BaseAsyncEndpoint.WithRequest<DatosFinancierosDto>.WithResponse<Response<DatosFinancierosDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CargarDatosFinancieros(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// CargarDatosFinancieros
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/cargarDatosFinancieros")]
        [ProducesResponseType(typeof(Response<DatosFinancierosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation("Cargar Datos Financieros",
            Description = "Cargar Datos Financieros",
            OperationId = "credito.CargarDatosFinancieros",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<DatosFinancierosDto>>> HandleAsync(DatosFinancierosDto request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.CargarDatosFinancieros(request);
        }
    }
}
