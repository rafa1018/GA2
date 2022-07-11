
using Ardalis.ApiEndpoints;
using GA2.Application.Dto.GrupoUsuarios;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.GrupoUsuarios
{
    public class DeleteGrupoUsuario : BaseAsyncEndpoint
        .WithRequest<GruposUsuariosDto>.WithResponse<Response<GruposUsuariosDto>>
    {

        private readonly IGruposUsuariosLogic _gruposusuariosLogic;

        public DeleteGrupoUsuario(IGruposUsuariosLogic gruposusuariosLogic)
        {
            _gruposusuariosLogic = gruposusuariosLogic;
        }


        /// <summary>
        ///  Crea un nuevo usuario
        /// </summary>
        /// <param name="request">Peticion usuario</param>
        /// <param name="cancellationToken">cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/deletegrupousaurios")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<GruposUsuariosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Elimina un grupo de usuario",
           Description = "Elimina un grupo de usuario",
           OperationId = "grupos.delete",
           Tags = new[] { "GrupoUsuariosEndpoint" })]
        public override async Task<ActionResult<Response<GruposUsuariosDto>>> HandleAsync(GruposUsuariosDto request, CancellationToken cancellationToken = default)
        {
            return await this._gruposusuariosLogic.DeleteGrupoUsuario(request);
           
        }
    }
}
