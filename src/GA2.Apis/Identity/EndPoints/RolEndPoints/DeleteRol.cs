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
    /// 
    /// </summary>
    [Authorize]
    public class DeleteRol : BaseAsyncEndpoint
        .WithRequest<RolDto>.WithResponse<Response<RolDto>>
    {

        private readonly IRolBusinessLogic _rolBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rolBusinessLogic"></param>
        public DeleteRol(IRolBusinessLogic rolBusinessLogic)
        {
            _rolBusinessLogic = rolBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/roles")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<RolDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Elimina un nuevo rol",
           Description = "Elimina un nuevo rol",
           OperationId = "roles.delte",
           Tags = new[] { "RolesEndpoint" })]
        public async override Task<ActionResult<Response<RolDto>>> HandleAsync(RolDto request, CancellationToken cancellationToken = default)
        {
            return await this._rolBusinessLogic.DeleteRol(request);
        }
    }
}
