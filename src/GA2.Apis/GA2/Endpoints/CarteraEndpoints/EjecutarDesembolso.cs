using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Domain.Entities;
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

namespace GA2.Apis.GA2.Endpoints.CreditoEndpoints.Simulador.LegalizacionDesembolso
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class EjecutarDesembolso : BaseAsyncEndpoint.WithRequest<RequestEjecucionDesembolsoDto>.WithResponse<Response<ProductoClienteDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public EjecutarDesembolso(ICarteraBusinessLogic carteraBusinessLogic)
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
        [HttpPost("api/credito/ejecutarDesembolso")]
        [ProducesResponseType(typeof(Response<ProductoClienteDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Ejecutar Desembolso",
            Description = "Obtiene Productos Por Cliente",
            OperationId = "credito.EjecutarDesembolso",
            Tags = new[] { "CarteraEndpoint" })]

        public async override Task<ActionResult<Response<ProductoClienteDto>>> HandleAsync(RequestEjecucionDesembolsoDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.EjecutarDesembolso(request);
        }
    }
}
