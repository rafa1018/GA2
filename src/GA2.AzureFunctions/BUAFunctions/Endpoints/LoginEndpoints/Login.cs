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

namespace GA2.BUAFunctions.Endpoints.LoginEndpoints
{
    /// <summary>
    /// Endpoint function Login
    /// </summary>
    /// <date>23/07/2021</date>
    public class Login
    {
        /// <summary>
        /// logic Business Identity
        /// </summary>
        private readonly ILoginBusinessLogic _loginBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="loginBusinessLogic">Service Logic Business</param>
        public Login(ILoginBusinessLogic loginBusinessLogic, ITokenClaims tokenClaims)
        {
            _loginBusinessLogic = loginBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint login post
        /// </summary>
        /// <param name="req">loginDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>Jwt Response</returns>
        [Function("Login")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous,"post")] HttpRequestData req,
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
            var login = JsonConvert.DeserializeObject<LoginDto>(body);
            var result = await _loginBusinessLogic.LoginGA2(login);
            
            response.StatusCode = HttpStatusCode.OK;
            //await response.WriteAsJsonAsync<Response<string>>(result);

            return response;
        }
    }
}
