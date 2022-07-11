using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para Obtener Alerta Automaticas
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerAlertaAutomaticas : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<AlertaAutomaticasDto>>>
    {
        private readonly ICreditoBusinessLogic _alertaautomaticasBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Alerta Automaticas
        /// </summary>
        /// <param name="alertaautomaticasBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerAlertaAutomaticas(ICreditoBusinessLogic alertaautomaticasBusinessLogic)
        {
            _alertaautomaticasBusinessLogic = alertaautomaticasBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obteneralertaautomaticas")]
        [ProducesResponseType(typeof(Response<IEnumerable<AlertaAutomaticasDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene AlertaAutomaticas",
            Description = "Obtiene AlertaAutomaticas",
            OperationId = "credito.obteneralertaautomaticas",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<AlertaAutomaticasDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._alertaautomaticasBusinessLogic.ObtenerAlertaAutomaticas();
        }

    }
}
