using GA2.Application.Dto.Identity;
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

namespace BUAFunctions.Endpoints.LoginEndpoints
{
    /// <summary>
    /// Endpoint Login Paa
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>23/07/2021</date>
    public class LoginPaa
    {
        /// <summary>
        /// Inyeccion de negocio usuarios
        /// </summary>
        private readonly ILoginBusinessLogic _loginBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Ctro Login Paa
        /// </summary>
        /// <param name="loginBusinessLogic">Service login business logic</param>
        public LoginPaa(ILoginBusinessLogic loginBusinessLogic, ITokenClaims tokenClaims)
        {
            _loginBusinessLogic = loginBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint login paa
        /// </summary>
        /// <param name="req">loginPaaDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>Jwt Response</returns>
        [Function("loginpaa")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Login - GA2Paa");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var login = JsonConvert.DeserializeObject<LoginPaaDto>(body);
            var result = await _loginBusinessLogic.LoginGA2Paa(login);

            response.StatusCode = HttpStatusCode.OK;
            await response.WriteAsJsonAsync<Response<string>>(result);

            return response;
        }
    }
}
