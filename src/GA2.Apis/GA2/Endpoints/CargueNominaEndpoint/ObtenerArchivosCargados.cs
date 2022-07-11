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

namespace GA2.Endpoints.CargueNominaEndpoint
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ObtenerArchivosCargados : BaseAsyncEndpoint.WithRequest<int>.WithResponse<Response<IEnumerable<DocumentoDto>>>
    {
        private readonly IMovimientoBusinessLogic _movimientoBusinessLogic;

        /// <summary>
        /// Movimiento business logic
        /// </summary>
        /// <param name="movimientoBusinessLogic"></param>
        /// <date>19/05/2021</date>
        /// <author>Oscar Julian Rojas</author>
        public ObtenerArchivosCargados(IMovimientoBusinessLogic movimientoBusinessLogic)
        {
            _movimientoBusinessLogic = movimientoBusinessLogic;
        }

        /// <summary>
        /// Obtener archivos cargados
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/obtenerarchivoscargados")]
        [ProducesResponseType(typeof(Response<DocumentoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener archivos cargados",
            Description = "Obtener Archivos Nomina",
            OperationId = "fileupload.obtenerarchivoscargados",
            Tags = new[] { "CargueNominaEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<DocumentoDto>>>> HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            return await this._movimientoBusinessLogic.ObtenerDocumentosCarga(request);
        }
    }
}
