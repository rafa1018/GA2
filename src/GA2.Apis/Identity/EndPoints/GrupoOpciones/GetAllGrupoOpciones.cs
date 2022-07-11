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
    public class GetAllGrupoOpciones : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<GrupoOpcionesDto>>>
    {

        private readonly IGruposOpcionesLogic _gruposOpcionesLogic;

        public GetAllGrupoOpciones(IGruposOpcionesLogic gruposusuariosLogic)
        {
            _gruposOpcionesLogic = gruposusuariosLogic;
        }



        [HttpGet("api/grupoopciones")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<OpcionesDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene todos los grupos de opciones",
           Description = "Obtiene todos los grupos de opciones con estado activo del sistema",
           OperationId = "gruposopciones.getall",
           Tags = new[] { "GrupoOpcionesEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<GrupoOpcionesDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._gruposOpcionesLogic.ObtenerGruposOpciones();
        }
    }
}
