using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.Comite
{
    /// <summary>
    /// Genera un flujo de firmas para un 
    /// </summary>
    public class CrearFlujoFirmasComite:BaseAsyncEndpoint.WithRequest<RequestFlujoFirmasDto>.WithResponse<object>
    {
        private readonly IGestorDocumentalBusinessLogic _gestorDocumentalBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="gestorDocumentalBusinessLogic"></param>
        public CrearFlujoFirmasComite(IGestorDocumentalBusinessLogic gestorDocumentalBusinessLogic)
        {
            _gestorDocumentalBusinessLogic = gestorDocumentalBusinessLogic;
        }

        /// <summary>
        /// insertForm
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearFlujoFirmasComite")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crear Flujo Firmas Comite",
            Description = "Crear Flujo Firmas Comite",
            OperationId = "credito.CrearFlujoFirmasComite",
            Tags = new[] { "WorkManager" })]
        public async override Task<ActionResult<object>> HandleAsync(RequestFlujoFirmasDto request, CancellationToken cancellationToken = default)
        {
            return await _gestorDocumentalBusinessLogic.CrearFlujoFirmasComite(request);
        }
    }
}
