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
using System.Text;
using System.Threading.Tasks;

namespace BUAFunctions.Endpoints.RolEndpoints
{
    class UpdateRol
    {
        private readonly IRolBusinessLogic _rolBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Rol Business Logic 
        /// </summary>
        /// <param name="rolBusinessLogic">Business Logic</param>
        public UpdateRol(IRolBusinessLogic rolBusinessLogic, ITokenClaims tokenClaims)
        {
            _rolBusinessLogic = rolBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint Eliminar Rol
        /// </summary>
        /// <param name="req">RolDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>RolDto</returns>
        [Function("updaterol")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "patch", Route ="roles")] HttpRequestData req,
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
            var login = JsonConvert.DeserializeObject<RolDto>(body);
            var result = await _rolBusinessLogic.UpdateRol(login);

            response.StatusCode = HttpStatusCode.OK;
            await response.WriteAsJsonAsync<Response<RolDto>>(result);

            return response;
        }
    }
}
