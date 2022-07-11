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
    public class FormularioCreditoBasica :


        BaseAsyncEndpoint.WithRequest<Guid>
        .WithResponse<Response<FormularioCreditoBasicaDto>>
        
       
    {

        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        public FormularioCreditoBasica(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }



        [HttpGet("api/credito/FormularioCreditoBasica")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FormularioCreditoBasicaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener datos basicos para el formulario de credito",
           Description = "Obtener datos basicos para el formulario de credito",
           OperationId = "Obtener.FormularioCreditoBasica",
           Tags = new[] { "CreditoEndpoint" })]
        public override async Task<ActionResult<Response<FormularioCreditoBasicaDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.FormularioCreditoBasica(request);
        }
    }
}
