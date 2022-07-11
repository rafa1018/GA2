using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    public class FormularioCreditoConyugue : BaseAsyncEndpoint.WithRequest<Guid>
        .WithResponse<Response<FormularioCreditoConyugueDto>>
    {

        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        public FormularioCreditoConyugue(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }


        [HttpGet("api/credito/ObtenerFormularioCreditoConyugue")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FormularioCreditoConyugueDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener datos del conyugue formulario de credito",
           Description = "Obtener datos del conyugue formulario de credito",
           OperationId = "Obtener.ObtenerFormularioCreditoConyugue",
           Tags = new[] { "CreditoEndpoint" })]
        public override async Task<ActionResult<Response<FormularioCreditoConyugueDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.FormularioCreditoConyugue(request);
        }
    }
}
