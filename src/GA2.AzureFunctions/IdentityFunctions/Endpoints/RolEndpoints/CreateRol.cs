using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace IdentityFunctions.Endpoints.RolEndpoints
{
    public class CreateRol
    {
        private readonly IRolBusinessLogic _rolBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rolBusinessLogic"></param>
        public CreateRol(IRolBusinessLogic rolBusinessLogic)
        {
            _rolBusinessLogic = rolBusinessLogic;
        }

        /// <summary>
        /// Endpoint Crear Rol
        /// </summary>
        /// <param name="req">RolDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>RolDto</returns>
        [Function("createrol")]
        public async Task<Response<RolDto>> Run([HttpTrigger(AuthorizationLevel.User, "post", Route ="roles")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Roles - Create");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var rol = JsonConvert.DeserializeObject<RolDto>(body);

            return await _rolBusinessLogic.CreateRol(rol);
        }
    }
}
