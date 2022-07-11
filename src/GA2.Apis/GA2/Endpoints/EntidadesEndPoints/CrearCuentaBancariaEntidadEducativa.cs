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
    /// Endpoint para Crear una Cuenta Bancaria de una Entidad Educativa
    /// </summary>
    /// <author>Edwin Lopez</author>
    /// <date>15/03/2022</date>
    
    [Authorize]
    public class CrearCuentaBancariaEntidadEducativa :
         BaseAsyncEndpoint.WithRequest<CuentaBancariaEntidadEducativaDto>
        .WithResponse<Response<CuentaBancariaEntidadEducativaDto>>
    {

        private readonly IEntidadesBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Cuenta Bancaria Entidad Educativa
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public CrearCuentaBancariaEntidadEducativa(IEntidadesBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
  
        [HttpPost("api/Entidades/CrearCuentaBancariaEntidadEducativa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<CuentaBancariaEntidadEducativaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Crear una Cuenta Bancaria de una Entidad Educativa",
            Description = "Crear una Cuenta Bancaria de una Entidad Educativa",
            OperationId = "Entidades.CuentaBancariaEntidadEducativa",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<CuentaBancariaEntidadEducativaDto>>> HandleAsync(CuentaBancariaEntidadEducativaDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.CrearCuentaBancariaEntidadEducativa(request);
        }
    }
}

