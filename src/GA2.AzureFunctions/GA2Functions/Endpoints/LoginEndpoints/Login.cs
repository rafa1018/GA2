using Azure.Core.Serialization;
using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace GA2.GA2Functions.Endpoints.LoginEndpoints
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
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "options","post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Login - Functions");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse();

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var login = JsonConvert.DeserializeObject<LoginDto>(body);
            if(login != null)
            {
                var result = await _loginBusinessLogic.LoginGA2(login);
                //var serializerSettings = new JsonSerializerSettings();
                //serializerSettingsOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)
                //serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //serializerSettings.
                //var jsonSerialize = JsonConvert.SerializeObject(result,);

                response.StatusCode = HttpStatusCode.OK;
                await response.WriteAsJsonAsync(result, "application/json");
                return response;
            }

            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }
    }
}
