using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityFunctions.Endpoints.RolEndpoints
{
    class UpdateRol
    {
        private readonly IRolBusinessLogic _rolBusinessLogic;

        /// <summary>
        /// Rol Business Logic 
        /// </summary>
        /// <param name="rolBusinessLogic">Business Logic</param>
        public UpdateRol(IRolBusinessLogic rolBusinessLogic)
        {
            _rolBusinessLogic = rolBusinessLogic;
        }

        /// <summary>
        /// Endpoint Eliminar Rol
        /// </summary>
        /// <param name="req">RolDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>RolDto</returns>
        [Function("updaterol")]
        public async Task<Response<RolDto>> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route ="roles")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Roles - Update");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var rol = JsonConvert.DeserializeObject<RolDto>(body);

            return await _rolBusinessLogic.UpdateRol(rol);
        }
    }
}
