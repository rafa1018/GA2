using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BUAFunctions.Endpoints.UsersEndpoints
{
    class ActualizarUsuario
    {
        /// <summary>
        /// Core Negocio Users
        /// </summary>
        private readonly IUsersBusinessLogic _usersBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Controlador Users
        /// </summary>
        /// <param name="usersBusinessLogic"></param>
        public ActualizarUsuario(IUsersBusinessLogic usersBusinessLogic, ITokenClaims tokenClaims)
        {
            _usersBusinessLogic = usersBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint actualizar usuario 
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("actualizarusuario")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route = "users")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Login - Functions");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var login = JsonConvert.DeserializeObject<UsuarioDto>(body);
            var result = await _usersBusinessLogic.UpdateUser(login);

            response.StatusCode = HttpStatusCode.OK;
            await response.WriteAsJsonAsync<Response<UsuarioDto>>(result);

            return response;
        }
    }
}
