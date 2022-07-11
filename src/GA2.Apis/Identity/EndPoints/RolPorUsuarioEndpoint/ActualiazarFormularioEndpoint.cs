using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.RolPorUsuarioEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ActualiazarFormularioEndpoint : BaseAsyncEndpoint
       .WithRequest<FormularioDto>.WithResponse<Response<FormularioDto>>
    {
        private readonly IFormularioBusinessLogic _formularioBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formularioBusinessLogic"></param>
        public ActualiazarFormularioEndpoint(IFormularioBusinessLogic formularioBusinessLogic)
        {
            _formularioBusinessLogic = formularioBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPut]
        [Route("roles/formularioactualizar")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FormularioDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualiza un formulario para roles",
           Description = "Actualiza un formulario",
           OperationId = "roles.formularioactualizar",
           Tags = new[] { "RolesEndpoint" })]
        public override async Task<ActionResult<Response<FormularioDto>>> HandleAsync(FormularioDto request, CancellationToken cancellationToken = default)
        {
            return await _formularioBusinessLogic.ActualizarFormulario(request);
        }
    }
}
