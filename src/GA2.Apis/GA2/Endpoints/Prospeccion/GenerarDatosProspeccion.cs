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

namespace GA2.Apis.GA2.Endpoints.Prospeccion
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class GenerarDatosProspeccion : BaseAsyncEndpoint.WithRequest<DatosProspeccionDto>.WithResponse<Response<DatosProspeccionDto>>
    {
        private readonly IProspeccionBusinessLogic _prospeccionBusinessLogic;
        /// <summary>
        /// Ctor e inyeccion dependencias
        /// </summary>
        /// <param name="prospeccionBusinessLogic"></param>
        public GenerarDatosProspeccion(IProspeccionBusinessLogic prospeccionBusinessLogic)
        {
            _prospeccionBusinessLogic = prospeccionBusinessLogic;
        }

        /// <summary>
        ///  Obtiene un producto por su id
        /// </summary>
        /// <param name = "request" > Peticion usuario</param>
        /// <param name = "cancellationToken" > cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        [HttpPost("api/prospeccion/GenerarDatosProspeccion")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<DatosProspeccionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crea los datos para la prospeccion",
           Description = "Crea los datos para la prospeccion",
           OperationId = "prospeccion.GenerarDatosProspeccion",
           Tags = new[] { "ProspeccionEndpoint" })]

        public async override Task<ActionResult<Response<DatosProspeccionDto>>> HandleAsync(DatosProspeccionDto request, CancellationToken cancellationToken = default)
        {
            return await _prospeccionBusinessLogic.GenerarDatosProspeccion(request);
        }
    }
}
