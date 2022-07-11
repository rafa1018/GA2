using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Metodo para actualización de la información ingresada por el usuario del codigo OTP
    /// </summary>
    ///
    public class ActualizarInformacionOtp : BaseAsyncEndpoint
        .WithRequest<ValidacionIdentidadDto>.WithResponse<Response<ValidacionIdentidadDto>>
    {

        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;
        /// <summary>
        /// Endpoint Actualizar informacion del OTP
        /// </summary>
        /// <param name="identidadBusinessLogic"></param>
        public ActualizarInformacionOtp(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
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
        [HttpPut("api/credito/ActualizarInformacionOtp")]
        [ProducesResponseType(typeof(Response<ValidacionIdentidadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualiza la información ingresada por el usuario del codigo OTP",
            Description = "Se debe enviar obligatoriamente el modelo completo",
            OperationId = "credito.ActualizarInformacionOtp",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ValidacionIdentidadDto>>> HandleAsync(ValidacionIdentidadDto request, CancellationToken cancellationToken = default)
        {
            return await _identidadBusinessLogic.ActualizarValidacionOTP(request);
        }
    }
}
