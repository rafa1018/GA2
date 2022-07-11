using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using GA2.Transversals.Commons.CustomBaseEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.LoginEndPoint
{
    public class RecuperarContrasena : BaseAsyncEndpoint
        .WithRequest<RecuperarContrasenaDto>.WithResponse<Response<string>>
    {

        /// <summary>
        /// Inyeccion de negocio usuarios
        /// </summary>
        private readonly ILoginBusinessLogic _loginBusinessLogic;

        /// <summary>
        /// Controlador Login
        /// </summary>
        /// <param name="loginBusinessLogic"></param>
        public RecuperarContrasena(ILoginBusinessLogic loginBusinessLogic)
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
        [HttpPost("api/recuperacontrasena")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            summary: "Recupera la contraseña del usuario",
            description: "Recuperar la conntraseña del usuario por medio tipo de documento y numero",
            OperationId = "login.recuperaContraseña",
            Tags = new[] { "LoginEndpoint" }
            )]


        public async override Task<ActionResult<Response<string>>> HandleAsync(RecuperarContrasenaDto request, CancellationToken cancellationToken = default)
        {
                  
            return await this._loginBusinessLogic.RecuperaContrasena(request);
        }
    }
}

