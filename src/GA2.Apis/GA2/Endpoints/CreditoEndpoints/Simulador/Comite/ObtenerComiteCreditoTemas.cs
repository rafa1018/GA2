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
    /// Endpoint Obtener Comite Credito Temas
    /// </summary>
    [Authorize]
    public class ObtenerComiteCreditoTemas : BaseAsyncEndpoint.WithRequest<RequestTemaComiteCreditoDto>.WithResponse<Response<IEnumerable<TemaComiteCreditoDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerComiteCreditoTemas(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Aprueba Datos Comite Credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerComiteCreditoTemas")]
        [ProducesResponseType(typeof(IEnumerable<TemaComiteCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Comite Credito Temas",
            Description = "Obtener Comite Credito Temas",
            OperationId = "credito.ObtenerComiteCreditoTemas",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TemaComiteCreditoDto>>>> HandleAsync(RequestTemaComiteCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerComiteCreditoTemas(request);
        }
    }
}


