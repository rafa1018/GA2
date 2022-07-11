using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.Bpm
{
    public class ActualizarAnadido
    {
        private readonly IAnadidosBusinessLogic _anadidosBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        public ActualizarAnadido(IAnadidosBusinessLogic anadidosBusinessLogic, ITokenClaims tokenClaims)
        {
            _anadidosBusinessLogic = anadidosBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ActualizarAnadido")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "put", Route = "bpm/ActualizarAnadido")] HttpRequestData req,
          FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("BpmEndpoint - ActualizarAnadido");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var anadidoDto = JsonConvert.DeserializeObject<AnadidosDto>(body);

            var result = await _anadidosBusinessLogic.ActualizarAnadido(anadidoDto);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);

            await response.WriteStringAsync(resultJson);
            return response;
        }
    }
}
