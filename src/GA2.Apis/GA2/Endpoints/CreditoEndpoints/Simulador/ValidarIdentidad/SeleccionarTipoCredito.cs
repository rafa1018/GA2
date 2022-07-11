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
    /// </summary>
    public class SeleccionarTipoCredito : BaseAsyncEndpoint
        .WithRequest<ValidacionIdentidadDto>.WithResponse<Response<ValidacionIdentidadDto>>
    {
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;

        /// <summary>
        /// Endpoint Crear validacion identidad
        /// </summary>
        /// <param name="identidadBusinessLogic"></param>
        public SeleccionarTipoCredito(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// 

        [HttpGet("api/credito/SeleccionarTipoCredito")]
        [ProducesResponseType(typeof(Response<ValidacionIdentidadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Seleccionar Tipo de Credito",
            Description = "Se debe enviar el siguiente parametro: TcrId  el cual contiene el id para la seleccion de los productos ofertados.",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ValidacionIdentidadDto>>> HandleAsync(ValidacionIdentidadDto request, CancellationToken cancellationToken = default)
        {
            return await this._identidadBusinessLogic.SeleccionarTipoCredito(request);
        }
    }
}
