using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
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
    public class DeleteUser : BaseAsyncEndpoint
        .WithRequest<UsuarioDto>.WithResponse<Response<UsuarioDto>>
    {

        /// <summary>
        /// Core Negocio Users
        /// </summary>
        private readonly IUsersBusinessLogic _usersBusinessLogic;

        /// <summary>
        /// Controlador Users
        /// </summary>
        /// <param name="usersBusinessLogic"></param>
        public DeleteUser(IUsersBusinessLogic usersBusinessLogic)
        {
            _usersBusinessLogic = usersBusinessLogic;
        }


        /// <summary>
        /// Eliminar usuario
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>10/03/2021</date>
        /// <returns></returns>
        //[HttpDelete("api/users/{Id}")]
        [HttpPost("api/users/delete")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<UsuarioDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Eliminar usuario",
           Description = "Elimina el usuario registrado",
           OperationId = "users.delete",
           Tags = new[] { "UsersEndpoint" })]
        public async override Task<ActionResult<Response<UsuarioDto>>> HandleAsync(UsuarioDto request, CancellationToken cancellationToken = default)
        {
            return await this._usersBusinessLogic.DeleteUser(request.Id);
        }
    }
}
