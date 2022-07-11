using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.EmbargosEndPoints
{
    public class ObtenerEmbargosRangoFecha : BaseAsyncEndpoint.WithRequest<ConsultaEmbargoRangoFecha>.WithResponse<Response<IEnumerable<EmbargosDto>>>
    {
        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public ObtenerEmbargosRangoFecha(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }


        [HttpPost("api/ObtenerEmbargosRangoFecha")]
        [Consumes("application/json")]
        [SwaggerOperation(
       Summary = "Obtiene lista de embargos por rango de fechas radicago work manager",
          Description = "Obtiene lista de embargos por rango de fechas radicago work manager",
          OperationId = "Embargos.ObtenerEmbargosRangoFecha",
          Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<EmbargosDto>>>> HandleAsync(ConsultaEmbargoRangoFecha request, CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ObtenerEmbargosRangoFecha(request.FechaInicial, request.FechaFinal) ;
        }
    }
}
