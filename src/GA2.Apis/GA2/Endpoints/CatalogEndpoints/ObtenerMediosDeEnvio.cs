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
	/// Endpoint para Obtener Actividades Economicas
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>18/05/2021</date>
    [Authorize]
    public class ObtenerMediosDeEnvio : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<MedioDeEnvioDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Actividades Economicas
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerMediosDeEnvio(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene all catalogos
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerMediosDeEnvio")]
        [ProducesResponseType(typeof(Response<IEnumerable<MedioDeEnvioDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene medios de envio",
            Description = "Obtiene medios de envio",
            OperationId = "catalogos.ObtenerMediosDeEnvio",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<MedioDeEnvioDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerMediosDeEnvio();
        }
    }
}
