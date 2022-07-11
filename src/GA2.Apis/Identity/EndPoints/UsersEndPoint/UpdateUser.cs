using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.UsersEndPoint
{
    /// <summary>
    /// UserController
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>24/02/2021</date>
    [Authorize]
    public class UpdateUser : BaseAsyncEndpoint
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
        public UpdateUser(IUsersBusinessLogic usersBusinessLogic)
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
        [HttpPatch("api/users")]
        [ProducesResponseType(typeof(Response<UsuarioDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar usuario",
           Description = "Actualiza el usuario registrado",
           OperationId = "users.update",
           Tags = new[] { "UsersEndpoint" })]
        public override async Task<ActionResult<Response<UsuarioDto>>> HandleAsync(UsuarioDto request, CancellationToken cancellationToken = default)
        {
            return await this._usersBusinessLogic.UpdateUser(request);
        }
    }
}
