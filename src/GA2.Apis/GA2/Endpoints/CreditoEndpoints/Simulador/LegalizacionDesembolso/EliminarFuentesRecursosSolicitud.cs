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
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    [Authorize]
    public class EliminarFuentesRecursosSolicitud : BaseAsyncEndpoint.WithRequest<RequestEliminarFuentesRecursosDto>.WithResponse<Response<IEnumerable<SolicitudCreditosDesembolsosDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public EliminarFuentesRecursosSolicitud(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpDelete("api/credito/EliminarFuentesRecursosSolicitud")]
        [ProducesResponseType(typeof(Response<IEnumerable<SolicitudCreditosDesembolsosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation("Eliminar Fuentes Recursos Solicitud",
            Description = "Eliminar Fuentes Recursos Solicitud",
            OperationId = "credito.EliminarFuentesRecursosSolicitud",
            Tags = new[] { "CreditoEndpoint" })]

        public async override Task<ActionResult<Response<IEnumerable<SolicitudCreditosDesembolsosDto>>>> HandleAsync([FromQuery]RequestEliminarFuentesRecursosDto request, CancellationToken cancellationToken = default)
        {

            return await _creditoBusinessLogic.EliminarFuentesRecursosSolicitud(new SolicitudCreditosDesembolsosDto { idSolicitudCredito=request.IdSolicitudCredito, idSolicitudDesembolso=request.IdSolicitudDesembolso});
        }
    }
}
