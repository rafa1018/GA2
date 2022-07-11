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
    public class HistorialPropietariosMatriculaInmobiliariaById : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<IEnumerable<PropietariosMatriculasInmobiliariasDto>>>
    {
        private readonly IMatriculasInmobiliariasLogic _matriculasInmobiliariasLogic;

        public HistorialPropietariosMatriculaInmobiliariaById(IMatriculasInmobiliariasLogic matriculasInmobiliariasLogic)
        {
            _matriculasInmobiliariasLogic = matriculasInmobiliariasLogic;
        }


        [HttpGet("api/historialPropietariosMatriculaInmobiliariaById")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<PropietariosMatriculasInmobiliariasDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
                   Summary = "Historial de propietarios de matriculas inmoviliarias",
                   Description = "Optiene una lista con el historial de los propietarios de matricula inmoviliaria por Id",
                   OperationId = "matriculas.historialPropietarios",
                   Tags = new[] { "MatriculasEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<PropietariosMatriculasInmobiliariasDto>>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._matriculasInmobiliariasLogic.HistorialPropietariosMatriculaInmobiliariaById(request);
        }
    }
}
