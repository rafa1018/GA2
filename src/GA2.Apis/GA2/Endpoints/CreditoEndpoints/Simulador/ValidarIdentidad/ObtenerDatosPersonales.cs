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
    /// Endpoint Obtener datos personales
    /// </summary>
    public class ObtenerDatosPersonales : BaseAsyncEndpoint
        .WithRequest<ValidacionIdentidadDto>.WithResponse<Response<SimulacionDatosPersonalesDto>>
    {

        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;
        /// <summary>
        /// Constructor para la inyección de dependencias
        /// </summary>
        /// <param name="identidadBusinessLogic"></param>
        public ObtenerDatosPersonales(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }

        /// <summary>
        /// Endpoint Obtener datos personales
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param> 
        /// <returns></returns>
        /// 
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/ObtenerDatosPersonales")]
        [ProducesResponseType(typeof(Response<SimulacionDatosPersonalesDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene los datospersonales del usuario por número de documento cedula",
            Description = "Se debe enviar obligatoriamente el modelo completo",
            OperationId = "credito.ObtenerDatosPersonales",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SimulacionDatosPersonalesDto>>> HandleAsync(ValidacionIdentidadDto request, CancellationToken cancellationToken = default)
        {
            var numeroDocumento = request.NumeroDocumento;
            return new Response<SimulacionDatosPersonalesDto> { Data = await _identidadBusinessLogic.ObtenerDatosPersonalesAsync(numeroDocumento) };
        }
    }
}
