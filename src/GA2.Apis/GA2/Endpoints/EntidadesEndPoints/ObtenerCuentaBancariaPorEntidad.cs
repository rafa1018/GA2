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
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Obtener Obtener Cuenta Bancaria Por Entidad
    /// </summary>
    
    [Authorize]
    public class ObtenerCuentaBancariaPorEntidad :
        BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<IEnumerable<CuentaBancariaEntidadEducativaDto>>>

    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Cuenta Bancaria Por Entidad
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>26/01/2022</date>
        public ObtenerCuentaBancariaPorEntidad(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// ObtenerCuentaBancariaPorEntidad
        /// </summary>
        /// <param name="idEntidad"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/Entidades/ObtenerCuentaBancariaPorEntidad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<CuentaBancariaEntidadEducativaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Cuenta Bancaria Por Entidad",
            Description = "Obtener Cuenta Bancaria Por Entidad",
            OperationId = "Entidades.ObtenerCuentaBancariaPorEntidad",
            Tags = new[] { "EntidadesEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<CuentaBancariaEntidadEducativaDto>>>> HandleAsync(string idEntidad, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.ObtenerCuentaBancariaPorEntidad(idEntidad);
        }
    }
}
