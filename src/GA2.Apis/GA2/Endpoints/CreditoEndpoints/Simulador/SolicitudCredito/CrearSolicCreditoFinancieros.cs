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

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.SolicitudCredito
{
    /// <summary>
    /// Crear Solicitud Credito Financieros
    /// </summary>
    [Authorize]
    public class CrearSolicCreditoFinancieros : BaseAsyncEndpoint.WithRequest<CreditoFinancieroDto>.WithResponse<Response<CreditoFinancieroDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CrearSolicCreditoFinancieros(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Carga Archivo al blob storage para solicitud credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearSolicCreditoFinancieros")]
        [ProducesResponseType(typeof(Response<CreditoFinancieroDto>), StatusCodes.Status200OK)]
        [SwaggerOperation("Crear Solicitud Credito Financieros",
            Description = "Crear Solicitud Credito Financieros",
            OperationId = "credito.CrearSolicCreditoFinancieros",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<CreditoFinancieroDto>>> HandleAsync(CreditoFinancieroDto request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.CrearSolicCreditoFinancieros(request);
        }
    }
}
