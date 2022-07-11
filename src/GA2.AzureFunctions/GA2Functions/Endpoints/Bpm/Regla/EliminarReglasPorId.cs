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

namespace GA2Functions.Endpoints.Bpm.Regla
{
    public class EliminarReglasPorId
    {
        private readonly IReglaBusinessLogic _reglaBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        public EliminarReglasPorId(IReglaBusinessLogic reglaBusinessLogic, ITokenClaims tokenClaims)
        {
            _reglaBusinessLogic = reglaBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint crear usuario
        /// </summary>
        /// <param name="req">prceso request</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>proceso request</returns>
        [Function("EliminarReglasPorId")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.User, "delete", Route = "bpm/EliminarReglasPorId/{reglasId}")] HttpRequestData req,
            string reglasId,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("BpmEndpoints - EliminarReglasPorId");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            _ = Guid.TryParse(reglasId, out var reglasDtoId);
            if (reglasId == null) throw new ArgumentNullException(nameof(reglasId));

            var result = await _reglaBusinessLogic.EliminarRegla(reglasDtoId);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
