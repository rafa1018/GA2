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
    /// Endpoint para Eliminar Alerta Automaticas Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class EliminarAlertaAutomaticasPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<AlertaAutomaticasDto>>
    {

        private readonly ICreditoBusinessLogic _alertaBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Alerta Automaticas Por Id
        /// </summary>
        /// <param name="alertaBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public EliminarAlertaAutomaticasPorId(ICreditoBusinessLogic alertaBusinessLogic)
        {
            _alertaBusinessLogic = alertaBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/credito/eliminaralerta")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<AlertaAutomaticasDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Eliminar Alerta",
           Description = "Eliminar Alerta",
           OperationId = "Credito.eliminaralerta",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<AlertaAutomaticasDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._alertaBusinessLogic.EliminarAlertaAutomaticasPorid(request);
        }
    }
}

