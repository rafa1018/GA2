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

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// Actualiza los datos personales de vivienda
    /// </summary>.
    //[Authorize]
    public class ActualizarPersonalesVivienda:BaseAsyncEndpoint.WithRequest<SimulacionDatosPersonalesDto>.WithResponse<Response<SimulacionDatosPersonalesDto>>
    {
        private readonly ICreditoBusinessLogic _creditoBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="creditoBusinessLogic"></param>
        public ActualizarPersonalesVivienda(ICreditoBusinessLogic creditoBusinessLogic)
        {
            _creditoBusinessLogic = creditoBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch
            ("api/credito/actualizarPersonalesVivienda")]
        [ProducesResponseType(typeof(Response<SimulacionDatosPersonalesDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualizar Datos Personales Vivienda Simulacion",
            Description = "Actualizar Datos Personales Vivienda Simulacion",
            OperationId = "credito.ActualizarPersonalesVivienda",
            Tags = new[] { "CreditoEndpoint" })]
        public override async Task<ActionResult<Response<SimulacionDatosPersonalesDto>>> HandleAsync(SimulacionDatosPersonalesDto request, CancellationToken cancellationToken = default)
        {
            return await _creditoBusinessLogic.ActualizarPersonalesVivienda(request);
        }
    }
}
