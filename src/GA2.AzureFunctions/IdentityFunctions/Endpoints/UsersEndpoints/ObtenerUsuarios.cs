using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityFunctions.Endpoints.UsersEndpoints
{
    class ObtenerUsuarios
    {
        /// <summary>
        /// Core Negocio Users
        /// </summary>
        private readonly IUsersBusinessLogic _usersBusinessLogic;

        /// <summary>
        /// Controlador Users
        /// </summary>
        /// <param name="usersBusinessLogic"></param>
        public ObtenerUsuarios(IUsersBusinessLogic usersBusinessLogic)
        {
            _usersBusinessLogic = usersBusinessLogic;
        }

        /// <summary>
        /// Endpoint obtenerusuarios
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("obtenerusuarios")]
        public async Task<Response<IEnumerable<UsuarioDto>>> Run([HttpTrigger(AuthorizationLevel.User, "get", Route = "users")]
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Users - ObtenerUsuarios");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _usersBusinessLogic.GetUsers();
        }
    }
}
