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
    /// Obtinee los datos de salario y conceptos
    /// </summary>
    [Authorize]
    public class ObtenerDatosFinancierosPersonales:BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<DatosFinancierosPersonalesDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerDatosFinancierosPersonales(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        ///  Obtiene solicitud  credito basica
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerDatosFinancierosPersonales")]
        [ProducesResponseType(typeof(Response<DatosFinancierosPersonalesDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Datos Financieros Personales",
            Description = "Obtener Datos Financieros Personales",
            OperationId = "credito.ObtenerDatosFinancierosPersonales",
            Tags = new[] { "CreditoEndpoint" })]

        public async override Task<ActionResult<Response<DatosFinancierosPersonalesDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerDatosFinancierosPersonales(request);
        }
    }
}
