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
	/// Endpoint para actualizar Alertas Automaticas
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>11/05/2021</date>
    [Authorize]
    public class ActualizarAlertaAutomaticas :
         BaseAsyncEndpoint.WithRequest<AlertaAutomaticasDto>
        .WithResponse<Response<AlertaAutomaticasDto>>
    {

        private readonly ICreditoBusinessLogic _alertaBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Alerta
        /// </summary>
        /// <param name="alertaBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ActualizarAlertaAutomaticas(ICreditoBusinessLogic alertaBusinessLogic)
        {
            _alertaBusinessLogic = alertaBusinessLogic;
        }


        /// <summary>
        /// </summary>
        /// <param name = "request"></param >
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/credito/actualizaralertaautomaticas")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<AlertaAutomaticasDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Alerta Automaticas",
           Description = "Actualizar Alerta Automaticas",
           OperationId = "Credito.actualizaralertaautomaticas",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<AlertaAutomaticasDto>>> HandleAsync(AlertaAutomaticasDto request, CancellationToken cancellationToken = default)
        {
            return await this._alertaBusinessLogic.ActualizarAlertaAutomaticas(request);
        }
    }
}

