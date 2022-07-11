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
    /// Endpoint para obtener los productos por cliente
    /// </summary>
    /// <author>Sergio Ortega</author>
    /// <date>06/09/2021</date>
    [Authorize]
    public class ObtenerProductoCliente : BaseAsyncEndpoint.WithRequest<SolicitudProductoPorClienteDto>.WithResponse<Response<IEnumerable<ProductoClienteDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public ObtenerProductoCliente(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/obtenerProductoCliente")]
        [ProducesResponseType(typeof(Response<IEnumerable<ProductoClienteDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene Productos Por Cliente",
            Description = "Obtiene Productos Por Cliente",
            OperationId = "credito.ObtenerProductoCliente",
            Tags = new[] { "CarteraEndpoint" })]

        public async override Task<ActionResult<Response<IEnumerable<ProductoClienteDto>>>> HandleAsync(SolicitudProductoPorClienteDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ObtenerProductoCliente(request);
        }
    }
}
