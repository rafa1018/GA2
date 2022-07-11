using Ardalis.ApiEndpoints;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Commons = GA2.Transversals.Commons.CustomBaseEndpoints;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.CargaArchivos
{
    /// <summary>
    /// Descarga de documentos desde blobstorage
    /// </summary>
    [Authorize]
    public class DescargarDocumentos : Commons.BaseAsyncEndpoint.WithRequest<string>.WithResponseCustoms<FileResult>
    {
        private ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public DescargarDocumentos(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Crea Datos Comite Credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/descargarDocumentos")]
        [ProducesResponseType(typeof(FileResult), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Descargar Documentos",
            Description = "Descargar Documentos",
            OperationId = "credito.DescargarDocumentos",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<FileResult> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.DescargarDocumentos(request);
        }
    }
}
