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
    public class EliminarRestriccionesPorId
    {
        private readonly IRestriccionesBusinessLogic _restriccionesBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        public EliminarRestriccionesPorId(IRestriccionesBusinessLogic restriccionesBusinessLogic, ITokenClaims tokenClaims)
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
        [Function("EliminarRestriccionesPorId")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.User, "delete", Route = "bpm/EliminarRestriccionesPorId/{restriccionesId}")] HttpRequestData req,
            string restriccionesId,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("BpmEndpoints - EliminarRestriccionesPorId");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            _ = Guid.TryParse(restriccionesId, out var restriccionesDtoId);
            if (restriccionesId == null) throw new ArgumentNullException(nameof(restriccionesId));

            var result = await _restriccionesBusinessLogic.EliminarRestriccionesPorId(restriccionesDtoId);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }

    }
}
