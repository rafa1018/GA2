using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// Endpoint para Crear Alerta Automaticas
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearAlertaAutomaticas :
         BaseAsyncEndpoint.WithRequest<AlertaAutomaticasDto>
        .WithResponse<Response<AlertaAutomaticasDto>>
    {

        private readonly ICreditoBusinessLogic _alertaBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Crear Alerta Automaticas
        /// </summary>
        /// <param name="alertaBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearAlertaAutomaticas(ICreditoBusinessLogic alertaBusinessLogic)
        {
            _alertaBusinessLogic = alertaBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearalertaautomaticas")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<AlertaAutomaticasDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crea una Alerta Automatica",
           Description = "Crea una Alerta Automatica",
           OperationId = "Credito.crearalertaautomaticas",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<AlertaAutomaticasDto>>> HandleAsync(AlertaAutomaticasDto request, CancellationToken cancellationToken = default)
        {
            return await this._alertaBusinessLogic.CrearAlertaAutomaticas(request);
        }
    }
}

