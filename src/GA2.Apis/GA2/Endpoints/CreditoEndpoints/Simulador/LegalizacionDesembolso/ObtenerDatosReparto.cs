using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// Obtiene los datos de reparto
    /// </summary>
    [Authorize]
    public class ObtenerDatosReparto:BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<DatosRepartoDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Datos Reparto
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerDatosReparto(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerDatosReparto")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<DatosRepartoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener Datos Reparto",
           Description = "Obtener Datos Reparto",
           OperationId = "credito.ObtenerDatosReparto",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<DatosRepartoDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerDatosReparto(request);
        }
    }
}
