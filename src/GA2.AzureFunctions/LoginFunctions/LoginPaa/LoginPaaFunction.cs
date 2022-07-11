using GA2.Application.Dto.Identity;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;

namespace LoginPaa
{
    public class LoginPaaFunction
    {
        private readonly ILoginBusinessLogic _loginBusinessLogic;

        public LoginPaaFunction(ILoginBusinessLogic loginBusinessLogic)
        {
            _loginBusinessLogic = loginBusinessLogic;
        }

        [Function("LoginPaaFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Login - LoginPaaFunction");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var loginpaa = JsonConvert.DeserializeObject<LoginPaaDto>(body);

            await response.WriteAsJsonAsync(await _loginBusinessLogic.LoginGA2Paa(loginpaa));

            return response;
        }
    }
}
