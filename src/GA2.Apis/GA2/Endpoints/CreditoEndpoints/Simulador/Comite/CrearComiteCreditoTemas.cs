using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Endpoints.CreditoEndpoints.Simulador.Comite
{
    /// <summary>
    /// Endpoint Crear Tema comite
    /// </summary>
    [Authorize]
    public class CrearComiteCreditoTemas : BaseAsyncEndpoint.WithRequest<TemaComiteCreditoDto>.WithResponse<Response<TemaComiteCreditoDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CrearComiteCreditoTemas(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Crear Comite Credito Temas
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearComiteCreditoTemas")]
        [ProducesResponseType(typeof(Response<TemaComiteCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Comite Credito Temas",
            Description = "Crear Comite Credito Temas",
            OperationId = "credito.CrearComiteCreditoTemas",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<TemaComiteCreditoDto>>> HandleAsync(TemaComiteCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.CrearComiteCreditoTemas(request);
        }
    }
}


