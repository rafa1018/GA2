using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Endpoints.CreditoEndpoints.Simulador
{
    /// <summary>
    /// EndPoint Validacion Score del Cliente
    /// </summary>
    public class ValidacionScoreCliente : BaseAsyncEndpoint
        .WithRequest<ValidacionIdentidadDto>.WithResponse<Response<ValidacionIdentidadDto>>
    {
        private readonly IValidacionIdentidadBusinessLogic _identidadBusinessLogic;
        /// <summary>
        /// Endpoint Crear validacion identidad
        /// </summary>
        /// <param name="identidadBusinessLogic"></param>
        public ValidacionScoreCliente(IValidacionIdentidadBusinessLogic identidadBusinessLogic)
        {
            _identidadBusinessLogic = identidadBusinessLogic;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// 

        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/ValidacionScoreCliente")]
        [ProducesResponseType(typeof(Response<ValidacionIdentidadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Realiza las validaciones del Score del Clienrte con el Buro",
            Description = "",
            OperationId = "credito.ValidacionScoreCliente",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ValidacionIdentidadDto>>> HandleAsync(ValidacionIdentidadDto request, CancellationToken cancellationToken = default)
        {
            return await this._identidadBusinessLogic.ValidacionScoreCliente(request);
        }
    }
}
