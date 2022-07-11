using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GA2Functions.Endpoints.LockEndpoints
{
    public class ActualizarBloqueo
    {
        private readonly IBloqueoBusinessLogic _lockBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lockBusinessLogic"></param>
        public ActualizarBloqueo(IBloqueoBusinessLogic lockBusinessLogic, ITokenClaims tokenClaims)
        {
            _lockBusinessLogic = lockBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint ActualizarBloqueo
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("ActualizarBloqueo")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route = "bloqueo/ActualizarBloqueo")] HttpRequestData req,
                                                FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("LockEnpoints - bloqueo/ActualizarBloqueo");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var bloqueo = JsonConvert.DeserializeObject<BloqueoDto>(body);

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out _))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var result =  await _lockBusinessLogic.ActualizarBloqueo(bloqueo);


            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
