using Ardalis.ApiEndpoints;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.ValidarIdentidad
{
    public class ObtenerOtpCliente:BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<string>>
    {
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;
        /// <summary>
        /// Endpoint Actualizar informacion del OTP
        /// </summary>
        /// <param name="identidadBusinessLogic"></param>
        public ObtenerOtpCliente(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }

        /// <summary>
        /// Endpoin ActualizarInformacionOtp
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// 
        //[ValidateAntiForgeryToken]
        [HttpGet("api/credito/ObtenerOtpCliente")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene codigo Otp",
            Description = "Obtiene codigo Otp",
            OperationId = "credito.ObtenerOtpCliente",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<string>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await _identidadBusinessLogic.ObtenerOtpCliente(request);
        }


    }
}
