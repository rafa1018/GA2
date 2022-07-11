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

namespace BUAFunctions.Endpoints.MenuEndpoints
{
    /// <summary>
    /// Obtener Menu Endpoint
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ObtenerMenu
    {
        /// <summary>
        /// Business Logic Login
        /// </summary>
        private readonly ILoginBusinessLogic _loginBusinessLogic;
        private readonly ITokenClaims _tokenClaims;

        /// <summary>
        /// Ctro ObtenerMenu
        /// </summary>
        /// <param name="loginBusinessLogic">Business Logic Login</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>23/07/2021</date>
        public ObtenerMenu(ILoginBusinessLogic loginBusinessLogic, ITokenClaims tokenClaims)
        {
            _loginBusinessLogic = loginBusinessLogic;
            _tokenClaims = tokenClaims;
        }

        /// <summary>
        /// Endpoint menus dtos
        /// </summary>
        /// <param name="req">Rquest vacio</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>Jwt Response</returns>
        [Function("menu")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.User, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Login - ObtenerMenus");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var token = req.Headers.GetValues("Authorization").FirstOrDefault();
            var response = req.CreateResponse();

            if (!_tokenClaims.EsTokenValido(token, out IEnumerable<Claim> claims))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var result = await _loginBusinessLogic.ObtenerMenu();

            response.StatusCode = HttpStatusCode.OK;
            await response.WriteAsJsonAsync<Response<IEnumerable<MenuDto>>>(result);

            return response;
        }
    }
}
