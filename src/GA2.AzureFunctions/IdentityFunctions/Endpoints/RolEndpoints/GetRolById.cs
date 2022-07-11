using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace IdentityFunctions.Endpoints.RolEndpoints
{
    class GetRolById
    {
        private readonly IRolBusinessLogic _rolBusinessLogic;

        /// <summary>
        /// Rol Business Logic 
        /// </summary>
        /// <param name="rolBusinessLogic">Business Logic</param>
        public GetRolById(IRolBusinessLogic rolBusinessLogic)
        {
            _rolBusinessLogic = rolBusinessLogic;
        }

       /// <summary>
       /// Endpoint obtener rol por id
       /// </summary>
       /// <param name="Id">Id rol get</param>
       /// <param name="executionContext"></param>
       /// <returns>RolDto</returns>
       /// <author>Oscar Julian Rojas </author>
        [Function("getrolbyId")]
        public async Task<Response<RolDto>> Run([HttpTrigger(AuthorizationLevel.User, "get", Route ="roles/{id}")] Guid Id,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Roles - RolesById");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _rolBusinessLogic.GetByIdRol(Id);
        }
    }
}
