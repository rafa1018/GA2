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
    /// Endpoint para Obtener Alerta Automaticas Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerAlertaAutomaticasPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<AlertaAutomaticasDto>>
    {

        private readonly ICreditoBusinessLogic _alertaBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Alerta Automaticas Por Id
        /// </summary>
        /// <param name="alertaBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerAlertaAutomaticasPorId(ICreditoBusinessLogic alertaBusinessLogic)
        {
            _alertaBusinessLogic = alertaBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obteneralertaporid")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<AlertaAutomaticasDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener Alertaporid",
           Description = "Obtener Alerta por Id",
           OperationId = "credito.obteneralertaporid",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<AlertaAutomaticasDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._alertaBusinessLogic.ObtenerAlertaAutomaticasPorId(request);
        }
    }
}

