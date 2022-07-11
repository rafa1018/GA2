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
    public class EliminaGrupoOpciones : BaseAsyncEndpoint
        .WithRequest<GrupoOpcionesDto>.WithResponse<Response<GrupoOpcionesDto>>
    {


        private readonly IGruposOpcionesLogic _gruposOpcionesLogic;

        public EliminaGrupoOpciones(IGruposOpcionesLogic gruposusuariosLogic)
        {
            _gruposOpcionesLogic = gruposusuariosLogic;
        }

        [HttpPost("api/deletegrupoopciones")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<GrupoOpcionesDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         Summary = "Elimina grupo de opciones",
         Description = "elimina un gupo de opciones",
         OperationId = "gruposopciones.delete",
         Tags = new[] { "GrupoOpcionesEndpoint" })]
        public override async Task<ActionResult<Response<GrupoOpcionesDto>>> HandleAsync(GrupoOpcionesDto request, CancellationToken cancellationToken = default)
        {
            return await this._gruposOpcionesLogic.EliminarGruposOpciones(request);
            
        }
    }
}
