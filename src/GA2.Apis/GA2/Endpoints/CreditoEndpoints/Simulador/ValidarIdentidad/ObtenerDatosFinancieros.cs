using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Domain.Entities.Credito;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// </summary>
    public class ObtenerDatosFinancieros : BaseAsyncEndpoint
        .WithRequest<ValidacionIdentidadDto>.WithResponse<Response<SimulacionDatosFinancierosDto>>
    {

        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;
        /// <summary>
        /// Constructor para la inyección de dependencias
        /// </summary>
        /// <param name="identidadBusinessLogic"></param>
        public ObtenerDatosFinancieros(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
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
        [HttpPost("api/credito/ObtenerDatosFinancieros")]
        [ProducesResponseType(typeof(Response<SimulacionDatosFinancierosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener datos financieros",
            Description = "Obtiene los datos financieros del usuario por número de documento cedula",
            OperationId = "credito.ObtenerDatosPersonales",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<SimulacionDatosFinancierosDto>>> HandleAsync(ValidacionIdentidadDto request, CancellationToken cancellationToken = default)
        {
            var numeroDocumento = request.NumeroDocumento;
            return new Response<SimulacionDatosFinancierosDto> { Data = await this._identidadBusinessLogic.ObtenerDatosFinancierosAsync(numeroDocumento) };
        }
    }
}
