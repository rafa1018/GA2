using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class GetRolById :
        BaseAsyncEndpoint.WithRequest<Guid>
        .WithResponse<Response<RolDto>>
    {

        private readonly IRolBusinessLogic _rolBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rolBusinessLogic"></param>
        public GetRolById(IRolBusinessLogic rolBusinessLogic)
        {
            _rolBusinessLogic = rolBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/roles/{Id}")]
        [ProducesResponseType(typeof(Response<RolDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene un rol",
           Description = "Obtiene un rol",
           OperationId = "roles.getbyid",
           Tags = new[] { "RolesEndpoint" })]
        public async override Task<ActionResult<Response<RolDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._rolBusinessLogic.GetByIdRol(request);
        }
    }
}
