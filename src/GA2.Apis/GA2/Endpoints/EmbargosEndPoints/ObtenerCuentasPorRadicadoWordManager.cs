
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using GA2.Transversals.Commons.CustomBaseEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.EmbargosEndPoints
{
    public class ObtenerCuentasPorRadicadoWordManager : BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<IEnumerable<CuentaClienteDto>>>
    {

        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public ObtenerCuentasPorRadicadoWordManager(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpGet("api/ObtenerCuentasPorRadicadoWordManager")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<CuentaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Listar todos las cuentas del cliente por numero de radicado word maneger",
            Description = "Listar todos las cuentas del cliente por numero de radicado word maneger",
            OperationId = "Embargos.ObtenerCuentasPorRadicadoWordManager",
            Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<CuentaClienteDto>>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ObtenerCuentasPorRadicadoWordManager(request);

        }
    }
}
