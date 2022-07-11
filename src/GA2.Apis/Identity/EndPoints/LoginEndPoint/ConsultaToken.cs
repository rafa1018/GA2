using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.LoginEndPoint
{
    public class ConsultaToken : BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<UsuarioDto>>
    {
        /// <summary>
        /// Inyeccion de negocio usuarios
        /// </summary>
        private readonly ILoginBusinessLogic _loginBusinessLogic;

        /// <summary>
        /// Controlador Login
        /// </summary>
        /// <param name="loginBusinessLogic"></param>
        public ConsultaToken(ILoginBusinessLogic loginBusinessLogic)
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
        [HttpGet("api/consultatoken")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            summary: "Valida el toquen de restablecimiento de contraseña",
            description: "Valida el toquen de restablecimiento de contraseña",
            OperationId = "login.tokenrestablecimiento",
            Tags = new[] { "LoginEndpoint" }
            )]
        public override async Task<ActionResult<Response<UsuarioDto>>> HandleAsync(string token, CancellationToken cancellationToken = default)
        {
            return await this._loginBusinessLogic.validaToken(token);
        }
    }
}
