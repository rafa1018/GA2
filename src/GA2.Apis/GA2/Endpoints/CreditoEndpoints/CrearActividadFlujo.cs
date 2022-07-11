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
    /// Endpoint para Crear Actividad Flujo
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearActividadFlujo :
         BaseAsyncEndpoint.WithRequest<ActividadFlujoDto>
        .WithResponse<Response<ActividadFlujoDto>>
    {

        private readonly ICreditoBusinessLogic _actividadflujoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Alerta
        /// </summary>
        /// <param name="actividadflujoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearActividadFlujo(ICreditoBusinessLogic actividadflujoBusinessLogic)
        {
            _actividadflujoBusinessLogic = actividadflujoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/crearactividadflujo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ActividadFlujoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear ActividadFlujo",
           Description = "Crear ActividadFlujo",
           OperationId = "Credito.crearactividadflujo",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ActividadFlujoDto>>> HandleAsync(ActividadFlujoDto request, CancellationToken cancellationToken = default)
        {
            return await this._actividadflujoBusinessLogic.CrearActividadFlujo(request);
        }
    }
}

