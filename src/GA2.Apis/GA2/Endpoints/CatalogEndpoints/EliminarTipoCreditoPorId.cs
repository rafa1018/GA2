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
    /// Endpoint para Crear Eliminar Tipo Credito Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class EliminarTipoCreditoPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<TipoCreditoDto>>
    {

        private readonly ICatalogosBusinessLogic _tipocreditoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Tipo Credito Por Id
        /// </summary>
        /// <param name="tipocreditoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public EliminarTipoCreditoPorId(ICatalogosBusinessLogic tipocreditoBusinessLogic)
        {
            _tipocreditoBusinessLogic = tipocreditoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/EliminarTipoCredito")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TipoCreditoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          Summary = "Elimina Tipo Credito",
            Description = "Elimina Tipo Credito",
            OperationId = "catalogos.EliminarTipoCredito",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<TipoCreditoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._tipocreditoBusinessLogic.EliminarTipoCreditoPorid(request);
        }
    }
}

