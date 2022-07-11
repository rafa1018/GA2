using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.MenuEndPoint
{
    /// <summary>
    /// 
    /// </summary>
    public class ObtenerMenu :
        BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<MenuDto>>>
    {

        private readonly ILoginBusinessLogic _loginBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginBusinessLogic"></param>
        public ObtenerMenu(ILoginBusinessLogic loginBusinessLogic)
        {
            _loginBusinessLogic = loginBusinessLogic;
        }

        /// <summary>
        /// Endpoint Menus dtos
        /// </summary>
        /// <param name="cancellationToken">Cancelacion Token</param>
        /// <returns></returns>
        [HttpGet("api/menu")]
        [ProducesResponseType(typeof(Response<MenuDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene lista roles",
           Description = "Obtiene lista roles",
           OperationId = "roles.getall",
           Tags = new[] { "RolesEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<MenuDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._loginBusinessLogic.ObtenerMenu();
        }
    }
}
