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

namespace GA2Functions.Endpoints.Bpm.Proceso
{
    public class ObtenerProcesoPorId
    {
        private readonly IProcesoBusinessLogic _procesoBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        public ObtenerProcesoPorId(IProcesoBusinessLogic procesoBusinessLogic, ITokenClaims tokenClaims)
        {
            _procesoBusinessLogic = procesoBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint obtener proceso por id
        /// </summary>
        /// <param name="req">Requestdata</param>
        /// <param name="procesoId">Proceso id</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("ObtenerProcesoPorId")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.User, "get", Route = "bpm/ObtenerProcesoPorId/{procesoId}")] HttpRequestData req,
            string procesoId,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("BpmEndpoints - ObtenerProcesoPorId");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            _ = Guid.TryParse(procesoId, out var procesoDtoId);
            if (procesoId == null) throw new ArgumentNullException(nameof(procesoId));

            var result = await _procesoBusinessLogic.ObtenerProcesoPorId(procesoDtoId);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
