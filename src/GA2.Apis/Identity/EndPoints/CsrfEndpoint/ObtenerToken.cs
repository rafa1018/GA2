using Ardalis.ApiEndpoints;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.CsrfEndpoint
{
    /// <summary>
    /// Obtener token csrf
    /// </summary>
    [Authorize]
    public class ObtenerToken: BaseAsyncEndpoint.WithoutRequest.WithoutResponse
    {
       
        /// <summary>
        /// Obtener token csrf
        /// </summary>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/obtenerToken")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            summary: "Login user into app",
            description: "token to users",
            OperationId = "login.token",
            Tags = new[] { "LoginEndpoint" }
            )]
        public async override Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {
            var headers = Request.HttpContext.Response.Headers.Where(x=> x.Key == "Set-Cookie").FirstOrDefault();
            await Task.CompletedTask;
            return Ok(headers.Value);
        }
    }
}
