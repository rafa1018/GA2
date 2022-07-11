using Ardalis.ApiEndpoints;
using GA2.Application.Dto.GrupoOpciones;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints.GrupoOpciones
{
    public class GetAllOpciones : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<OpcionesDto>>>
    {
        private readonly IGruposOpcionesLogic _gruposOpcionesLogic;

        public GetAllOpciones(IGruposOpcionesLogic gruposOpcionesLogic)
        {
            _gruposOpcionesLogic = gruposOpcionesLogic;
        }


        [HttpGet("api/getAllOpciones")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<GrupoOpcionesDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene todos las opciones",
           Description = "Obtiene todas las opciones",
           OperationId = "gruposopciones.getallOpciones",
           Tags = new[] { "GrupoOpcionesEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<OpcionesDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._gruposOpcionesLogic.ObtenerOpciones();
        }
    }
}
