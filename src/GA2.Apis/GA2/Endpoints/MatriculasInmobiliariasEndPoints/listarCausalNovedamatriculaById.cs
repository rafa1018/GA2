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
    public class listarCausalNovedamatriculaById : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<IEnumerable<CausalNovedamatriculaDto>>>
    {

        private readonly IMatriculasInmobiliariasLogic _matriculasInmobiliariasLogic;

        public listarCausalNovedamatriculaById(IMatriculasInmobiliariasLogic matriculasInmobiliariasLogic)
        {
            _matriculasInmobiliariasLogic = matriculasInmobiliariasLogic;
        }


        [HttpGet("api/listarCausalMatriculaTipoById")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<CausalNovedamatriculaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
                  Summary = "Listar el causal de  bloqueo por tipo de operacion",
                  Description = "Listar el causal de  bloqueo por tipo de operacion",
                  OperationId = "matriculas.listarCausales",
                  Tags = new[] { "MatriculasEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<CausalNovedamatriculaDto>>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._matriculasInmobiliariasLogic.listarCausalNovedamatriculaById(request);
        }
    }
}
