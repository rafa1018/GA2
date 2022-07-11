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

namespace GA2.Apis.GA2.Endpoints.CatalogEndpoints
{
    [Authorize]
    public class CrearSexo:BaseAsyncEndpoint.WithRequest<SexoDto>.WithResponse<Response<SexoDto>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Tipo De Sexo
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <date>18/05/2021</date>
        public CrearSexo(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Catalogos/CrearSexo")]
        [ProducesResponseType(typeof(Response<SexoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crea sexos del catalogo",
           Description = "Crea sexos del catalogo",
           OperationId = "catalogos.CrearSexo",
           Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<SexoDto>>> HandleAsync(SexoDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogsBusinessLogic.CrearSexo(request);
        }
    }
}
