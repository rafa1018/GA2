using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityFunctions.Endpoints.RolEndpoints
{
    public class GetAllRol
    {
        private readonly IRolBusinessLogic _rolBusinessLogic;

        /// <summary>
        /// Rol Business Logic 
        /// </summary>
        /// <param name="rolBusinessLogic">Business Logic</param>
        public GetAllRol(IRolBusinessLogic rolBusinessLogic)
        {
            _rolBusinessLogic = rolBusinessLogic;
        }

        /// <summary>
        /// Endpoint Obtener Roles
        /// </summary>
        /// <param name="executionContext">context functions</param>
        /// <returns>RolDto</returns>
        [Function("getallroles")]
        public async Task<Response<IEnumerable<RolDto>>> Run([HttpTrigger(AuthorizationLevel.User, "get", Route ="roles")] FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Roles - GetAllRoles");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _rolBusinessLogic.GetAllRol();
        }
    }
}
