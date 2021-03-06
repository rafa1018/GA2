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
    public class EliminarBloqueo
    {

        private readonly IBloqueoBusinessLogic _lockBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lockBusinessLogic"></param>
        public EliminarBloqueo(IBloqueoBusinessLogic lockBusinessLogic, ITokenClaims tokenClaims)
        {
            _lockBusinessLogic = lockBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint EliminarBloqueo
        /// </summary>
        /// <param name="req">UsuarioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>UsuarioDto</returns>
        [Function("EliminarBloqueo")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "delete", Route = "bloqueo/EliminarBloqueo")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("LockEnpoints - bloqueo/EliminarBloqueo");
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

            var result =  await _lockBusinessLogic.EliminarBloqueo(bloqueo);

            var settingsSerializer = new JsonSerializerSettings { ContractResolver = new LowerCaseContractResolverpublic() };
            var resultJson = JsonConvert.SerializeObject(result, Formatting.Indented, settingsSerializer);
            await response.WriteStringAsync(resultJson);

            return response;
        }
    }
}
