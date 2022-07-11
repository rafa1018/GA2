using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.MatriculasInmobiliariasEndPoints
{
    public class HistorialNovedadsMatriculaInmobiliariaById : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<IEnumerable<HistotialNovedadesMatriculasInmobiliariasDto>>>
    {
        private readonly IMatriculasInmobiliariasLogic _matriculasInmobiliariasLogic;

        public HistorialNovedadsMatriculaInmobiliariaById(IMatriculasInmobiliariasLogic matriculasInmobiliariasLogic)
        {
            _matriculasInmobiliariasLogic = matriculasInmobiliariasLogic;
        }


        [HttpGet("api/historialNovedadsMatriculaInmobiliariaById")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<HistotialNovedadesMatriculasInmobiliariasDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
                  Summary = "Historial de novedades matriculas inmoviliarias",
                  Description = "Optiene una lista con el historial de novedades matricula inmoviliaria por Id",
                  OperationId = "matriculas.historialNovedades",
                  Tags = new[] { "MatriculasEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<HistotialNovedadesMatriculasInmobiliariasDto>>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._matriculasInmobiliariasLogic.HistorialNovedadsMatriculaInmobiliariaById(request);
        }
    }
}
