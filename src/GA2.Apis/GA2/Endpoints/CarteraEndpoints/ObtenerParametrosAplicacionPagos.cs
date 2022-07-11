using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// Obtiene los parametros para la aplicacion de pagos
    /// </summary>
   

    [Authorize]
    public class ObtenerParametrosAplicacionPagos:BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<ParametrosAplicacionPagosDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerParametrosAplicacionPagos(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerParametrosAplicacionPagos")]
        [ProducesResponseType(typeof(Response<AplicacionPagoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener Parametros Aplicacion Pagos",
           Description = "Obtener Parametros Aplicacion Pagos",
           OperationId = "credito.ObtenerParametrosAplicacionPagos",
           Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<ParametrosAplicacionPagosDto>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ObtenerParametrosAplicacionPagos();
        }
    }
}
