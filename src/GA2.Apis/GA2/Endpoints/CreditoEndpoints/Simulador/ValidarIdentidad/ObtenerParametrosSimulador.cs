using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Endpoints.CreditoEndpoints.Simulador
{
    /// <summary>
    /// 
    /// </summary>
    public class ObtenerParametrosSimulador : BaseAsyncEndpoint
        .WithoutRequest.WithResponse<Response<ParametrosSimuladorDto>>
    {
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;
        /// <summary>
        /// Endpoint Crear validacion identidad
        /// </summary>
        /// <param name="identidadBusinessLogic"></param>
        public ObtenerParametrosSimulador(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// 

        [HttpGet("api/credito/ObtenerParametrosSimulador")]
        [ProducesResponseType(typeof(Response<ValidacionIdentidadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Parametros del Simulador",
            Description = "Se onbtienen los parametros del simulador.",
            Tags = new[] { "ObtenerParametrosSimulador" })]
        public async override Task<ActionResult<Response<ParametrosSimuladorDto>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return  await this._identidadBusinessLogic.ObtenerParametrosSimuladorAsync();
        }
    }
}
