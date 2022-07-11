using Ardalis.ApiEndpoints;
using GA2.Application.Dto.GrupoOpciones;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.GrupoOpciones
{
    public class ActualizaGrupoOpciones : BaseAsyncEndpoint
        .WithRequest<GrupoOpcionesDto>.WithResponse<Response<GrupoOpcionesDto>>
    {

        private readonly IGruposOpcionesLogic _gruposOpcionesLogic;

        public ActualizaGrupoOpciones(IGruposOpcionesLogic gruposusuariosLogic)
        {
            _gruposOpcionesLogic = gruposusuariosLogic;
        }

        [HttpPost("api/actualizargrupoopciones")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<GrupoOpcionesDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         Summary = "actualiza un  grupos de opciones",
         Description = "actualiza un  grupos de opciones",
         OperationId = "gruposopciones.actualizar",
         Tags = new[] { "GrupoOpcionesEndpoint" })]
        public override async Task<ActionResult<Response<GrupoOpcionesDto>>> HandleAsync(GrupoOpcionesDto request, CancellationToken cancellationToken = default)
        {
            return await this._gruposOpcionesLogic.ActualizaGruposOpciones(request);
        }
    }
}
