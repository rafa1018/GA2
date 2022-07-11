using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    [Authorize]
    public class CrearSolicCreditoConyugue :
         BaseAsyncEndpoint.WithRequest<InformacionConyugueDto>
        .WithResponse<Response<InformacionConyugueDto>>
    {

        ICreditoBusinessLogic _creditoBusinessLogic;

        public CrearSolicCreditoConyugue(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/credito/CrearSolicCreditoConyugue")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<InformacionConyugueDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear Solicitud de Credito datos Conyugue",
           Description = "Crear Solicitud de Credito datos Conyugue",
           OperationId = "Credito.CrearSolicCreditoConyugue",
           Tags = new[] { "CreditoEndpoint" })]
        public override async Task<ActionResult<Response<InformacionConyugueDto>>> HandleAsync(InformacionConyugueDto request, CancellationToken cancellationToken = default)
        {

            var userId = User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value;
            request.CreadoPor = Guid.Parse(userId);

            return await this._creditoBusinessLogic.CrearSolicCreditoConyugue(request);


        }
    }
}
