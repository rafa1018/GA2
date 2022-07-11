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
    /// Endpoint para Obtener Usuario Actividad Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerUsuarioActividadPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<UsuarioActividadDto>>
    {

        private readonly ICreditoBusinessLogic _usuarioactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Usuario Actividad Por Id
        /// </summary>
        /// <param name="usuarioactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerUsuarioActividadPorId(ICreditoBusinessLogic usuarioactividadBusinessLogic)
        {
            _usuarioactividadBusinessLogic = usuarioactividadBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerusuarioactividadporid")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<UsuarioActividadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener UsuarioActividad",
           Description = "Obtener UsuarioActividad porid",
           OperationId = "Obtener.obtenerusuarioactividadporid",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<UsuarioActividadDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._usuarioactividadBusinessLogic.ObtenerUsuarioActividadPorId(request);
        }
    }
}

