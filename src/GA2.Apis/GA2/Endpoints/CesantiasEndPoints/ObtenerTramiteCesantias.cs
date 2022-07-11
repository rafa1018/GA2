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

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para realizar el trámite de la solicitud de cesantias
    /// </summary>
    /// <author>Erwin Pantoja España</author>
    [Authorize]
    public class ObtenerTramiteCesantias : BaseAsyncEndpoint
        .WithRequest<ParametrosObtenerCesantiasDto>
        .WithResponse<Response<ObtenerTramiteCesantiasDto>>
    {
        private readonly ICesantiasBusinessLogic _cesantiasBusinessLogic;

        /// <summary>
        /// Ctor endponit
        /// </summary>
        /// <param name="cesantiasBusinessLogic"></param>
        public ObtenerTramiteCesantias(ICesantiasBusinessLogic cesantiasBusinessLogic)
        {
            _cesantiasBusinessLogic = cesantiasBusinessLogic;
        }


        /// <summary>
        /// Endpoint para realizar el trámite de la solicitud de cesantias
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/cesantias/obtenerTramiteCesantias")]
        [ProducesResponseType(typeof(Response<ObtenerTramiteCesantiasDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Tramite de Solicitud de cesantias",
            Description = "Obtiene Tramite de Cesantias",
            OperationId = "credito.obtenerTramiteCesantias",
            Tags = new[] { "CesantiasEndpoint" })]
        public async override Task<ActionResult<Response<ObtenerTramiteCesantiasDto>>> HandleAsync(ParametrosObtenerCesantiasDto request, CancellationToken cancellationToken = default)
        {
            return await this._cesantiasBusinessLogic.ObtenerTramiteCesantias(request);
        }
    }
}
