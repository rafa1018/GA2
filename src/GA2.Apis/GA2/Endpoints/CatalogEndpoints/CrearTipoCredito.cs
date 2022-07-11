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
    /// Endpoint para Crear Tipo Credito
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearTipoCredito :
         BaseAsyncEndpoint.WithRequest<TipoCreditoDto>
        .WithResponse<Response<TipoCreditoDto>>
    {

        private readonly ICatalogosBusinessLogic _tipocreditoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Tipo Credito
        /// </summary>
        /// <param name="tipocreditoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearTipoCredito(ICatalogosBusinessLogic tipocreditoBusinessLogic)
        {
            _tipocreditoBusinessLogic = tipocreditoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/CrearTipoCredito")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TipoCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Crear Tipo Credito",
            Description = "Crear Tipo Credito",
            OperationId = "catalogos.CrearTipoCredito",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<TipoCreditoDto>>> HandleAsync(TipoCreditoDto request, CancellationToken cancellationToken = default)
        {
            return await this._tipocreditoBusinessLogic.CrearTipoCredito(request);
        }
    }
}

