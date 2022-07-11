using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.MatriculasInmobiliariasEndPoints
{
    public class listarOperacionesMatriculas : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<OperacionesMatriculasDto>>>
    {
        private readonly IMatriculasInmobiliariasLogic _matriculasInmobiliariasLogic;

        public listarOperacionesMatriculas(IMatriculasInmobiliariasLogic matriculasInmobiliariasLogic)
        {
            _matriculasInmobiliariasLogic = matriculasInmobiliariasLogic;
        }


        [HttpGet("api/listarOperacionesMatriculas")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<PropietariosMatriculasInmobiliariasDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
                  Summary = "Listar operaciones matriculas inmobiliarias",
                  Description = "Listar operaciones matriculas inmobiliarias",
                  OperationId = "matriculas.listarMatriculas",
                  Tags = new[] { "MatriculasEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<OperacionesMatriculasDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {

            return await this._matriculasInmobiliariasLogic.listarOperacionesMatriculas();

        }
    }
}
