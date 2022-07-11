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

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.CargaArchivos
{
    /// <summary>
    /// Cargar archivos de credito al blobstorage
    /// </summary>
    [Authorize]
    public class CargarDocumentos : BaseAsyncEndpoint.WithRequest<IFormFile>.WithResponse<Response<String>>
    {
        private ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public CargarDocumentos(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// Crea Datos Comite Credito
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/cargarDocumentos")]
        [ProducesResponseType(typeof(Response<String>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Cargar Documentos",
            Description = "Cargar Documentos",
            OperationId = "credito.CargarDocumentos",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<string>>> HandleAsync(IFormFile request, CancellationToken cancellationToken = default)
        {
            return await this._creditoBusinessLogic.CargarDocumentos(request);
        }
    }
}
