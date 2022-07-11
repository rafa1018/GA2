using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityFunctions.Endpoints.MenuEndpoints
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

        /// <summary>
        /// Ctro ObtenerMenu
        /// </summary>
        /// <param name="loginBusinessLogic">Business Logic Login</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>23/07/2021</date>
        public ObtenerMenu(ILoginBusinessLogic loginBusinessLogic)
        {
            _loginBusinessLogic = loginBusinessLogic;
        }

        /// <summary>
        /// Endpoint menus dtos
        /// </summary>
        /// <param name="req">Rquest vacio</param>
        /// <param name="executionContext">context functions</param>
        /// <returns>Jwt Response</returns>
        [Function("menu")]
        public async Task<Response<IEnumerable<MenuDto>>> Run([HttpTrigger(AuthorizationLevel.User, "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Login - ObtenerMenus");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            return await _loginBusinessLogic.ObtenerMenu();
        }
    }
}
