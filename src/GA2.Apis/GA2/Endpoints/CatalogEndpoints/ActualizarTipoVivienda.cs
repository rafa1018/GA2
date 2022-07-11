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
    /// Endpoint para Actualizar Tipo Vivienda
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ActualizarTipoVivienda :
         BaseAsyncEndpoint.WithRequest<TipoViviendaDto>
        .WithResponse<Response<TipoViviendaDto>>
    {

        private readonly ICatalogosBusinessLogic _tipoviviendaBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Actualizar Tipo Vivienda
        /// </summary>
        /// <param name="tipoviviendaBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ActualizarTipoVivienda(ICatalogosBusinessLogic tipoviviendaBusinessLogic)
        {
            _tipoviviendaBusinessLogic = tipoviviendaBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/ActualizarTipoVivienda")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TipoViviendaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar Tipo Vivienda",
            Description = "Actualizar Tipo Vivienda",
            OperationId = "catalogos.ActualizarTipoVivienda",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<TipoViviendaDto>>> HandleAsync(TipoViviendaDto request, CancellationToken cancellationToken = default)
        {
            return await this._tipoviviendaBusinessLogic.ActualizarTipoVivienda(request);
        }
    }
}

