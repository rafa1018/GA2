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
    public class ObtenerAnadidosPorTareaId
    {
        private readonly IAnadidosBusinessLogic _anadidosBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        public ObtenerAnadidosPorTareaId(IAnadidosBusinessLogic anadidosBusinessLogic, ITokenClaims tokenClaims)
        {
            _anadidosBusinessLogic = anadidosBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        [Function("ObtenerAnadidosPorTareaId")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.User, "get", Route = "bpm/ObtenerAnadidosPorTareaId/{anadidoId}")] HttpRequestData req,
            string anadidoId,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("BpmEndpoints - ObtenerAnadidosPorTareaId");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();
            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            _ = Guid.TryParse(anadidoId, out var anadidoDtoId);
            if (anadidoId == null) throw new ArgumentNullException(nameof(anadidoId));
            var result = await _anadidosBusinessLogic.ObtenerAnadidosPorTareaId(anadidoDtoId);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
