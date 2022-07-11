using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
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
    public class GetAllUsers : BaseAsyncEndpoint
        .WithoutRequest
           .WithResponse<Response<IEnumerable<UsuarioDto>>>
    {

        /// <summary>
        /// Core Negocio Users
        /// </summary>
        private readonly IUsersBusinessLogic _usersBusinessLogic;

        /// <summary>
        /// Controlador Users
        /// </summary>
        /// <param name="usersBusinessLogic"></param>
        public GetAllUsers(IUsersBusinessLogic usersBusinessLogic)
        {
            _usersBusinessLogic = usersBusinessLogic;
        }

        /// <summary>
        /// Obtiene todos los usuarios del sistema
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>24/02/2021</date>
        /// <returns>Lista de usuarios</returns>
        [HttpGet("api/users")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<UsuarioDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene todos los usuarios del sistema",
           Description = "Obtiene todos los usuarios del sistema",
           OperationId = "users.getall",
           Tags = new[] { "UsersEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<UsuarioDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._usersBusinessLogic.GetUsers();
        }
    }
}
