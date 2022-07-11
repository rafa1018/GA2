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
    /// Endpoint para actualizar Aseguradoras
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ActualizarAseguradoras :
         BaseAsyncEndpoint.WithRequest<AseguradorasDto>
        .WithResponse<Response<AseguradorasDto>>
    {

        private readonly ICreditoBusinessLogic _aseguradorasBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Aseguradoras
        /// </summary>
        /// <param name="aseguradorasBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ActualizarAseguradoras(ICreditoBusinessLogic aseguradorasBusinessLogic)
        {
            _aseguradorasBusinessLogic = aseguradorasBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name = "request"></param >
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/credito/actualizaraseguradoras")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<AseguradorasDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Aseguradoras",
           Description = "Actualizar Aseguradoras",
           OperationId = "Credito.actualizaraseguradoras",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<AseguradorasDto>>> HandleAsync(AseguradorasDto request, CancellationToken cancellationToken = default)
        {
            return await this._aseguradorasBusinessLogic.ActualizarAseguradoras(request);
        }
    }
}

