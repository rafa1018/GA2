using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.Prospeccion
{
    /// <summary>
    /// Obtiene el cliente para la prospeccion
    /// </summary>
    public class ObtenerClienteProspeccion : BaseAsyncEndpoint.WithRequest<DataClienteProspeccionDto>.WithResponse<Response<DataClienteProspeccionDto>>
    {
        private readonly IProspeccionBusinessLogic _prospeccionBusinessLogic;
        /// <summary>
        /// Ctor e inyeccion dependencias
        /// </summary>
        /// <param name="prospeccionBusinessLogic"></param>
        public ObtenerClienteProspeccion(IProspeccionBusinessLogic prospeccionBusinessLogic)
        {
            _prospeccionBusinessLogic = prospeccionBusinessLogic;
        }

        /// <summary>
        ///  Obtiene un producto por su id
        /// </summary>
        /// <param name = "request" > Peticion usuario</param>
        /// <param name = "cancellationToken" > cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        [HttpGet("api/prospeccion/ObtenerClienteProspeccion")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<DataClienteProspeccionDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene el cliente para la prospeccion",
           Description = "Obtiene el cliente para la prospeccion",
           OperationId = "prospeccion.ObtenerClienteProspeccion",
           Tags = new[] { "ProspeccionEndpoint" })]
        public async override Task<ActionResult<Response<DataClienteProspeccionDto>>> HandleAsync([FromQuery]DataClienteProspeccionDto request, CancellationToken cancellationToken = default)
        {
            return await _prospeccionBusinessLogic.ObtenerClienteProspeccion(request);
        }
    }
}
