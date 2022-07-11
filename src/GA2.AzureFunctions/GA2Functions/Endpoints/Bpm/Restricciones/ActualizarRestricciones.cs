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

namespace GA2Functions.Endpoints.Bpm.Restricciones
{
    public class ActualizarRestricciones
    {
        private readonly IRestriccionesBusinessLogic _restriccionesBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        public ActualizarRestricciones(IRestriccionesBusinessLogic restriccionesBusinessLogic, ITokenClaims tokenClaims)
        {
            _restriccionesBusinessLogic = restriccionesBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint crear usuario
        /// </summary>
        /// <param name="req">prceso request</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>proceso request</returns>
        [Function("ActualizarRestricciones")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "put", Route = "bpm/ActualizarRestricciones")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("BpmEndpoints - ActualizarRestricciones");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var restriccionesDto = JsonConvert.DeserializeObject<RestriccionesDto>(body);

            var result = await _restriccionesBusinessLogic.ActualizarRestricciones(restriccionesDto);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
