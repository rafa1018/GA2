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

namespace GA2.Apis.Identity.EndPoints
{

    /// <summary>
    /// Endpoint Rol por usuario
    /// </summary>
    [Authorize]
    public class CrearFormularioEndpoint : BaseAsyncEndpoint
        .WithRequest<FormularioDto>.WithResponse<Response<FormularioDto>>
    {
        private readonly IFormularioBusinessLogic _formularioBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formularioBusinessLogic"></param>
        public CrearFormularioEndpoint(IFormularioBusinessLogic formularioBusinessLogic)
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
        [HttpPost]
        [Route("roles/formulariocrear")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<FormularioDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Crear un formulario para roles",
          Description = "Crear un formulario",
          OperationId = "roles.formulariocrear",
          Tags = new[] { "RolesEndpoint" })]
        public override async Task<ActionResult<Response<FormularioDto>>> HandleAsync(FormularioDto request, CancellationToken cancellationToken = default)
        {
            return await _formularioBusinessLogic.CrearFormulario(request);
        }
    }
}
