using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
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

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.FuenteRescursos
{
    /// <summary>
    /// Endpoint Para Obtener Fuentes Recursos
    /// </summary>
    [Authorize]
    public class ObtenerFuentesRecursos : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<FuenteRecursosDto>>>
    {
        private readonly ICreditoBusinessLogic _tipoactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Fuentes Recursos
        /// </summary>
        /// <param name="tipoactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerFuentesRecursos(ICreditoBusinessLogic tipoactividadBusinessLogic)
        {
            _tipoactividadBusinessLogic = tipoactividadBusinessLogic;
        }


        /// <summary>
        /// Obtener Fuentes Recursos
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerFuentesRecursos")]
        [ProducesResponseType(typeof(Response<IEnumerable<FuenteRecursosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Fuentes Recursos",
            Description = "Obtener Fuentes Recursos",
            OperationId = "credito.ObtenerFuentesRecursos",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<FuenteRecursosDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._tipoactividadBusinessLogic.ObtenerFuentesRecursos();
        }
    }
}
