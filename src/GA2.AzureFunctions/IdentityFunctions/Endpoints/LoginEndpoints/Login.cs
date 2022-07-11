using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GA2.IdentityFunctions.Endpoints.LoginEndpoints
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

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="loginBusinessLogic">Service Logic Business</param>
        public Login(ILoginBusinessLogic loginBusinessLogic)
        {
            _loginBusinessLogic = loginBusinessLogic;
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
            var response = req.CreateResponse();
            var logger = executionContext.GetLogger("Login - Functions");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var login = JsonConvert.DeserializeObject<LoginDto>(body);
            var result = await _loginBusinessLogic.LoginGA2(login);
            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
         
            await response.WriteStringAsync(resultJson);
            return response;
        }
    }
}
