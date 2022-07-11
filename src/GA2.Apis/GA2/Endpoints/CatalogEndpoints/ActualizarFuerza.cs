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
    public class ActualizarFuerza:BaseAsyncEndpoint.WithRequest<FuerzasDto>.WithResponse<Response<FuerzasDto>>
    {
        private readonly ICatalogosBusinessLogic _catalogosBusinessLogic;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        public ActualizarFuerza(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogosBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene all fuerzas
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPatch("api/Catalogos/ActualizarFuerza")]
        [ProducesResponseType(typeof(Response<FuerzasDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualiza catalogo",
            Description = "Actualiza catalogo",
            OperationId = "catalogos.ActualizarFuerza",
            Tags = new[] { "CatalogosEndpoint" })]
        public override async Task<ActionResult<Response<FuerzasDto>>> HandleAsync(FuerzasDto request, CancellationToken cancellationToken = default)
        {
            return await _catalogosBusinessLogic.ActualizarFuerza(request);
        }
    }
         

}
