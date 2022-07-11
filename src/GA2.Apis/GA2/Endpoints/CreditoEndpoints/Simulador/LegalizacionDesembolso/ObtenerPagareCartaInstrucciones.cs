using Ardalis.ApiEndpoints;
using GA2.Domain.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;
using Commons = GA2.Transversals.Commons.CustomBaseEndpoints;
namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// 
    /// </summary>
    public class ObtenerPagareCartaInstrucciones:Commons.BaseAsyncEndpoint.WithRequest<Guid>.WithResponseCustoms<FileResult>
    {
        private ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerPagareCartaInstrucciones(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene la carta de instrucciones y el pagare
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/ObtenerPagareCartaInstrucciones")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Pagare Y Carta de Instrucciones",
            Description = "Obtener Pagare Y Carta de Instrucciones",
            OperationId = "credito.ObtenerPagareCartaInstrucciones",
            Tags = new[] { "CreditoEndpoint" })]
        public override async Task<FileResult> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.ObtenerPagareCartaInstrucciones(request);
        }
    }
}
