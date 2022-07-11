using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IdentityFunctions.Endpoints.UsersEndpoints
{
    public class EliminarUsuario
    {
        /// <summary>
        /// Core Negocio Users
        /// </summary>
        private readonly IUsersBusinessLogic _usersBusinessLogic;

        /// <summary>
        /// Controlador Users
        /// </summary>
        /// <param name="usersBusinessLogic"></param>
        public EliminarUsuario(IUsersBusinessLogic usersBusinessLogic)
        {
            _usersBusinessLogic = usersBusinessLogic;
        }

        /// <summary>
        /// Endpoint eliminar usuario 
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("eliminarusuario")]
        public async Task<Response<UsuarioDto>> Run([HttpTrigger(AuthorizationLevel.User, "delete", Route = "users/{id}")] Guid Id,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Users - EliminarUsuario");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _usersBusinessLogic.DeleteUser(Id);
        }
    }
}
