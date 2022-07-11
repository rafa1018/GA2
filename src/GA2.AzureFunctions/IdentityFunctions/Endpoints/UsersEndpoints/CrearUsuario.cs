using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace IdentityFunctions.Endpoints.UsersEndpoints
{
    public  class CrearUsuario
    {
        /// <summary>
        /// Core Negocio Users
        /// </summary>
        private readonly IUsersBusinessLogic _usersBusinessLogic;

        /// <summary>
        /// Controlador Users
        /// </summary>
        /// <param name="usersBusinessLogic"></param>
        public CrearUsuario(IUsersBusinessLogic usersBusinessLogic)
        {
            _usersBusinessLogic = usersBusinessLogic;
        }

        /// <summary>
        /// Endpoint crear usuario
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("crearusuario")]
        public async Task<Response<UsuarioDto>> Run([HttpTrigger(AuthorizationLevel.User, "post", Route = "users")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Users - crearusuario");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var formularioDto = JsonConvert.DeserializeObject<UsuarioDto>(body);

            //return await _usersBusinessLogic.CreateUser(formularioDto);
            return null;
        }
    }
}
