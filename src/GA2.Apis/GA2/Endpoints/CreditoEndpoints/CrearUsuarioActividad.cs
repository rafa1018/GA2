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
    /// Endpoint para Crear Usuario Actividad
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearUsuarioActividad :
         BaseAsyncEndpoint.WithRequest<UsuarioActividadDto>
        .WithResponse<Response<UsuarioActividadDto>>
    {

        private readonly ICreditoBusinessLogic _usuarioactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Usuario Actividad 
        /// </summary>
        /// <param name="usuarioactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearUsuarioActividad(ICreditoBusinessLogic usuarioactividadBusinessLogic)
        {
            _usuarioactividadBusinessLogic = usuarioactividadBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearusuarioactividad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<UsuarioActividadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear UsuarioActividad",
           Description = "Crear UsuarioActividad",
           OperationId = "Credito.crearusuarioactividad",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<UsuarioActividadDto>>> HandleAsync(UsuarioActividadDto request, CancellationToken cancellationToken = default)
        {
            return await this._usuarioactividadBusinessLogic.CrearUsuarioActividad(request);
        }
    }
}

