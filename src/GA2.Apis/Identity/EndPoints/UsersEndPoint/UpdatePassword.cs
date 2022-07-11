using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.UsersEndPoint
{
    public class UpdatePassword : BaseAsyncEndpoint
         .WithRequest<UsuarioDto>
         .WithResponse<Response<UsuarioDto>>
    {

        /// <summary>
        /// Core Negocio Users
        /// </summary>
        private readonly IUsersBusinessLogic _usersBusinessLogic;

        /// <summary>
        /// Controlador Users
        /// </summary>
        /// <param name="usersBusinessLogic"></param>
        public UpdatePassword(IUsersBusinessLogic usersBusinessLogic)
        {
            _usersBusinessLogic = usersBusinessLogic;
        }

        /// <summary>
        /// Actualizar usuario
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>User actualizado</returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/UpdatePassword")]
        [ProducesResponseType(typeof(Response<UsuarioDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar la contraseña del usuario",
           Description = "Actualiza la contraseña del usuario",
           OperationId = "users.updatePassword",
           Tags = new[] { "UsersEndpoint" })]
        public override async Task<ActionResult<Response<UsuarioDto>>> HandleAsync(UsuarioDto request, CancellationToken cancellationToken = default)
        {
            return await this._usersBusinessLogic.UpdateUserPassword(request);
        }
    }


}
