using GA2.Application.Dto;
using GA2.Application.Main;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
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


namespace GA2.BUAFunctions.Endpoints.AfiliadoEndPoints
{
    /// <summary>
    /// 
    /// </summary>
    public class RestaurarIntegracionCliente
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Constructor e inyección de dependencias
        /// </summary>
        /// <param name="clientsBussinesLogic"></param>
        public RestaurarIntegracionCliente(
            IClientesBusinessLogic clientsBussinesLogic, ITokenClaims tokenClaims)
        {
            _clientsBusinessLogic = clientsBussinesLogic;
            _tokenClaims = tokenClaims;
        }

        // <summary>
        /// Endpoint login post
        /// </summary>
        /// <param name="req">loginDto</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>Jwt Response</returns>
        [Function("RestaurarIntegracionCliente")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "restaurarIntegracionCliente")] HttpRequestData req,
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
            var login = JsonConvert.DeserializeObject<RestaurarIntegracionClienteDTO>(body);
            var result = await _clientsBusinessLogic.RestaurarIntegracionCliente(login, claims);

            response.StatusCode = HttpStatusCode.OK;
            await response.WriteAsJsonAsync<Response<ClienteDto>>(result);

            return response;
        }
    }
}
