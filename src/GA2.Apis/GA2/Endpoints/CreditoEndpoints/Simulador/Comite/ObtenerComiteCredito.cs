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

namespace GA2.Endpoints.CreditoEndpoints.Simulador.Comite
{
    /// <summary>
    /// Endpoint Obtener datos de comite credito
    /// </summary>
    [Authorize]
    public class ObtenerComiteCredito : BaseAsyncEndpoint.WithRequest<DatosComiteCreditoDto>.WithResponse<Response<List<DatosComiteCreditoDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerComiteCredito(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene Datos Comite Credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerComiteCredito")]
        [ProducesResponseType(typeof(Response<List<DatosComiteCreditoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Datos Comite Credito",
            Description = "Obtiene Datos Comite Credito",
            OperationId = "credito.ObtenerComiteCredito",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<List<DatosComiteCreditoDto>>>> HandleAsync(DatosComiteCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerComiteCredito(request);
        }
    }
}


