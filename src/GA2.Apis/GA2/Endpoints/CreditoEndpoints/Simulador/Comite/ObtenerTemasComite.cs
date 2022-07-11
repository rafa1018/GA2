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
    /// Endpoint Obtener integrantes comite
    /// </summary>
    [Authorize]
    public class ObtenerTemasComite : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TemaComiteDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerTemasComite(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Aprueba Datos Comite Credito
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerTemasComite")]
        [ProducesResponseType(typeof(IEnumerable<TemaComiteDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Tema Comite",
            Description = "Obtener Tema Comite",
            OperationId = "credito.ObtenerTemasComite",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TemaComiteDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerTemasComite();
        }
    }
}


