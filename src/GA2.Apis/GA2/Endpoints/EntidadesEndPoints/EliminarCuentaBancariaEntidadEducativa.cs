using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// Endpoint para Eliminar CuentaBancaria EntidadEducativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class EliminarCuentaBancariaEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<Guid>
        .WithResponse<Response<CuentaBancariaEntidadEducativaDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint EliminarCuentaBancariaEntidadEducativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public EliminarCuentaBancariaEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Eliminar Entidad Educativa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/Entidades/EliminarCuentaBancariaEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<CuentaBancariaEntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Eliminar Entidad Educativa",
            Description = "Eliminar Cuenta Bancaria Entidad Educativa",
            OperationId = "Entidades.EliminarCuentaBancariaEntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<CuentaBancariaEntidadEducativaDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.EliminarCuentaBancariaEntidadEducativa(request);
        }
    }
}

