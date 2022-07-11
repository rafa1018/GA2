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
    /// Endpoint para Crear Tipo Vivienda
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearTipoVivienda :
         BaseAsyncEndpoint.WithRequest<TipoViviendaDto>
        .WithResponse<Response<TipoViviendaDto>>
    {

        private readonly ICatalogosBusinessLogic _tipoviviendaBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Tipo Vivienda
        /// </summary>
        /// <param name="tipoviviendaBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearTipoVivienda(ICatalogosBusinessLogic tipoviviendaBusinessLogic)
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
        [HttpPost("api/CrearTipoVivienda")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TipoViviendaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear Tipo Vivienda",
            Description = "Crear Tipo Vivienda",
            OperationId = "catalogos.CrearTipoVivienda",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<TipoViviendaDto>>> HandleAsync(TipoViviendaDto request, CancellationToken cancellationToken = default)
        {
            return await this._tipoviviendaBusinessLogic.CrearTipoVivienda(request);
        }
    }
}

