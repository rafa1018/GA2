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
    /// Endpoint para Actualizar Cuenta Bancaria Entidad Educativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>11/05/2021</date>

    [Authorize]
    public class ActualizarCuentaBancariaEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<CuentaBancariaEntidadEducativaDto>
        .WithResponse<Response<CuentaBancariaEntidadEducativaDto>>
    {

        private readonly IEntidadesBusinessLogic _entidadesBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Actualizar Entidad Educativa
        /// </summary>
        /// <param name="entidadesBusinessLogic"></param>
        /// <author>Edwin Lopez</author>
        /// <date>11/05/2021</date>
        public ActualizarCuentaBancariaEntidadEducativa(IEntidadesBusinessLogic entidadesBusinessLogic)
        {
            _entidadesBusinessLogic = entidadesBusinessLogic;
        }

        /// <summary>
        /// Actualizar Cuenta Bancaria Entidad Educativa
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Entidades/ActualizarCuentaBancariaEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<CuentaBancariaEntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Cuenta Bancaria Entidad Educativa",
            Description = "Actualizar Cuenta Bancaria Entidad Educativa",
            OperationId = "Entidades.ActualizarCuentaBancariaEntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<CuentaBancariaEntidadEducativaDto>>> HandleAsync(CuentaBancariaEntidadEducativaDto request, CancellationToken cancellationToken = default)
        {
            return await _entidadesBusinessLogic.ActualizarCuentaBancariaEntidadEducativa(request);
        }
    }
}

