using GA2.Domain.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;
using Commons = GA2.Transversals.Commons.CustomBaseEndpoints;

namespace GA2.Endpoints.CreditoEndpoints.Simulador.Comite
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    public class ObtenerDatosSolicComite : Commons.BaseAsyncEndpoint.WithRequest<Guid>.WithResponseCustoms<FileResult>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ObtenerDatosSolicComite(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Obtiene Datos Solicitud Comite
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerDatosSolicComite")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Datos Solicitud Comite",
            Description = "Obtiene Datos Solicitud Comite",
            OperationId = "credito.ObtenerDatosSolicComite",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<FileResult> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.ObtenerDatosSolicComite(request);
        }
    }
}


