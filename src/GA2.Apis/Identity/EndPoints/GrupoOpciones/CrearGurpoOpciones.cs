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
    public class CrearGurpoOpciones : BaseAsyncEndpoint
        .WithRequest<GrupoOpcionesDto>.WithResponse<Response<GrupoOpcionesDto>>
    {

        private readonly IGruposOpcionesLogic _gruposOpcionesLogic;

        public CrearGurpoOpciones(IGruposOpcionesLogic gruposusuariosLogic)
        {
            _gruposOpcionesLogic = gruposusuariosLogic;
        }

        [HttpPost("api/creategrupoopciones")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<GrupoOpcionesDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         Summary = "crear un  grupos de opciones",
         Description = "crea un grupo de opciones",
         OperationId = "gruposopciones.create",
         Tags = new[] { "GrupoOpcionesEndpoint" })]
        public override async Task<ActionResult<Response<GrupoOpcionesDto>>> HandleAsync(GrupoOpcionesDto request, CancellationToken cancellationToken = default)
        {
             return await this._gruposOpcionesLogic.CrearGruposOpciones(request);   
        }
    }
}
