using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    public class ObtenerFuentesRecursosSolicitud:BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<IEnumerable<SolicitudCreditosDesembolsosDto>>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerFuentesRecursosSolicitud(ICreditoBusinessLogic creditoBusinessLogic)
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
        [HttpGet("api/credito/ObtenerFuentesRecursosSolicitud")]
        [ProducesResponseType(typeof(Response<DatosSolicCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation("Obtener Fuentes Recursos Solicitud",
            Description = "Obtener Fuentes Recursos Solicitud",
            OperationId = "credito.ObtenerFuentesRecursosSolicitud",
            Tags = new[] { "CreditoEndpoint" })]
        public override Task<ActionResult<Response<IEnumerable<SolicitudCreditosDesembolsosDto>>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return _creditoBusinessLogic.ObtenerFuentesRecursosSolicitud(request);
        }
    }
}
