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
    /// <author>Nicolas Florez Sarrazola</author>
    /// <Date>15/07/2021</Date>
    [Authorize]
    public class CargarDatosSolicCreditoTasasDesembolso:BaseAsyncEndpoint.WithRequest<DatosSolicCreditoDto>.WithResponse<Response<DatosSolicCreditoDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CargarDatosSolicCreditoTasasDesembolso(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/cargarDatosSolicCreditoTasasDesembolso")]
        [ProducesResponseType(typeof(Response<DatosSolicCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation("Cargar Datos Solic Credito Tasas Y Desembolso",
            Description = "Cargar Datos Solic Credito Tasas Y Desembolso",
            OperationId = "credito.CargarDatosSolicCreditoTasasDesembolso",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<DatosSolicCreditoDto>>> HandleAsync(DatosSolicCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.CargarDatosSolicCreditoTasasDesembolso(request);
        }
    }
}
