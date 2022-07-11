using Ardalis.ApiEndpoints;
using GA2.Application.Dto.GrupoUsuarios;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.GrupoUsuarios
{


    public class GetAllGrupoUsuarios : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<GruposUsuariosDto>>>
    {


        private readonly IGruposUsuariosLogic _gruposusuariosLogic;

        public GetAllGrupoUsuarios(IGruposUsuariosLogic gruposusuariosLogic)
        {
            _gruposusuariosLogic = gruposusuariosLogic;
        }


        [HttpGet("api/grupousaurios")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<GruposUsuariosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene todos los grupos de usuarios",
           Description = "Obtiene todos los grupos de usuarios con estado activo del sistema",
           OperationId = "grupos.getall",
           Tags = new[] { "GrupoUsuariosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<GruposUsuariosDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._gruposusuariosLogic.ObtenerGruposUsuarios();               

        }
    }
}
