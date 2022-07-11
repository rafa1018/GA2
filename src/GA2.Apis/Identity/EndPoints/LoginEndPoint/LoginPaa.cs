using Ardalis.ApiEndpoints;
using GA2.Application.Dto.Identity;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.LoginEndPoint
{
    /// <summary>
    /// LoginController
    /// </summary>
    [AllowAnonymous]
    public class LoginPaa : BaseAsyncEndpoint
        .WithRequest<LoginPaaDto>
        .WithResponse<Response<string>>
    {
        /// <summary>
        /// Inyeccion de negocio usuarios
        /// </summary>
        private readonly ILoginBusinessLogic _loginBusinessLogic;


        /// <summary>
        /// Controlador Login
        /// </summary>
        /// <param name="loginBusinessLogic"></param>
        public LoginPaa(ILoginBusinessLogic loginBusinessLogic)
        {
            this._loginBusinessLogic = loginBusinessLogic;
        }

        /// <summary>
        /// LoginEndPoint
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/loginpaa")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            summary: "Login user into app",
            description: "Login to users",
            OperationId = "login.loginpaa",
            Tags = new[] { "LoginEndpoint" }
            )]
        public async override Task<ActionResult<Response<string>>> HandleAsync(LoginPaaDto request, CancellationToken cancellationToken = default)
        {
            return await this._loginBusinessLogic.LoginGA2Paa(request);
        }
    }
}
