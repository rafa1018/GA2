using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BUAFunctions.Endpoints.RolPorUsuarioEndpoint
{
    public class ActualiazarFormulario
    {
        private readonly IFormularioBusinessLogic _formularioBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Ctor Actualizar formulario
        /// </summary>
        /// <param name="formularioBusinessLogic">Business Logic formualrio</param>
        public ActualiazarFormulario(IFormularioBusinessLogic formularioBusinessLogic, ITokenClaims tokenClaims)
        {
            _formularioBusinessLogic = formularioBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint actualizar formulariodto 
        /// </summary>
        /// <param name="req">FormularioDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>RolDto</returns>
        [Function("actualiazarformulario")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route = "roles/formularioactualizar")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Login - Functions");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var body = await RequestBody.ReadRquestBodyFunction(req.Body);
            var login = JsonConvert.DeserializeObject<FormularioDto>(body);
            var result = await _formularioBusinessLogic.ActualizarFormulario(login);

            response.StatusCode = HttpStatusCode.OK;
            await response.WriteAsJsonAsync<Response<FormularioDto>>(result);

            return response;
        }
    }
}
