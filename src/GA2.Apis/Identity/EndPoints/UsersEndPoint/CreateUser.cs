using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace GA2.Apis.Identity.Controllers
{
    /// <summary>
    /// UserController
    /// </summary>
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>24/02/2021</date>
   [Authorize]
    public class CreateUser : BaseAsyncEndpoint
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
        public CreateUser(IUsersBusinessLogic usersBusinessLogic)
        {
            _usersBusinessLogic = usersBusinessLogic;
        }

        /// <summary>
        ///  Crea un nuevo usuario
        /// </summary>
        /// <param name="request">Peticion usuario</param>
        /// <param name="cancellationToken">cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/users")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<UsuarioDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crea un nuevo usuario",
           Description = "Crea un nuevo usuario",
           OperationId = "users.create",
           Tags = new[] { "UsersEndpoint" })]
        public async override Task<ActionResult<Response<UsuarioDto>>> HandleAsync(UsuarioDto request, CancellationToken cancellationToken = default)
        {

            var userId = User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value;
            return await this._usersBusinessLogic.CreateUser(request, Guid.Parse(userId));
        }
    }
}
