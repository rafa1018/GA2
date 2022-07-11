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
    /// Endpoint para Eliminar Usuario Actividad Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class EliminarUsuarioActividadPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<UsuarioActividadDto>>
    {

        private readonly ICreditoBusinessLogic _usuarioactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Usuario Actividad Por Id
        /// </summary>
        /// <param name="usuarioactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public EliminarUsuarioActividadPorId(ICreditoBusinessLogic usuarioactividadBusinessLogic)
        {
            _usuarioactividadBusinessLogic = usuarioactividadBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/credito/eliminarusuarioactividad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<UsuarioActividadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Eliminar UsuarioActividad",
           Description = "Eliminar UsuarioActividad",
           OperationId = "credito.eliminarusuarioactividad",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<UsuarioActividadDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._usuarioactividadBusinessLogic.EliminarUsuarioActividadPorid(request);
        }
    }
}

