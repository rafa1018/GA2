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

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{/// <summary>
 /// Endpoint para obtener los productos por cliente
 /// </summary>
 /// <author>Sergio Ortega</author>
 /// <date>06/09/2021</date>
    [Authorize]
    public class ObtenerTipoActor : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TipoActorDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerTipoActor(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/cartera/obtenerTipoActor")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoActorDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene los tipos de actores",
            Description = "Obtiene los tipos de actores",
            OperationId = "cartera.ObtenerTipoActor",
            Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TipoActorDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ObtenerTipoActor();
        }
    }
}
