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
    /// Endpoint para Obtener Consecutivo Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class Afiliadoporidentificacion :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<AfiliadoporIdentificacionDTO>>
    {
       

        private readonly ICuentaBusinessLogic _afiliadoporidentificacionBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Consecutivo Por Id
        /// </summary>
        /// <param name="afiliadoporidentificacionBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public Afiliadoporidentificacion(ICuentaBusinessLogic afiliadoporidentificacionBusinessLogic)
        {
            _afiliadoporidentificacionBusinessLogic = afiliadoporidentificacionBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/Afiliadoporidentificacion")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<AfiliadoporIdentificacionDTO>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obetner Afiliadoporidentificacion",
           Description = "Obtener Afiliadoporidentificacion ",
           OperationId = "credito.Afiliadoporidentificacion",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<AfiliadoporIdentificacionDTO>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._afiliadoporidentificacionBusinessLogic.ObtenerAfiliadoporIdentificacion(request);
        }
    }
}

