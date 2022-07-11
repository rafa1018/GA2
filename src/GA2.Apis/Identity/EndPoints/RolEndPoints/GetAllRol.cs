using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class GetAllRol :
        BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<RolDto>>>
    {

        private readonly IRolBusinessLogic _rolBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rolBusinessLogic"></param>
        public GetAllRol(IRolBusinessLogic rolBusinessLogic)
        {
            _rolBusinessLogic = rolBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/roles")]
        [ProducesResponseType(typeof(Response<RolDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene lista roles",
           Description = "Obtiene lista roles",
           OperationId = "roles.getall",
           Tags = new[] { "RolesEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<RolDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._rolBusinessLogic.GetAllRol();
        }
    }
}
