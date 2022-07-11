using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Endpoints.FileEndpoints
{
    /// <summary>
    /// Endpoint para carga de archivos de nómina
    /// </summary>
    [Authorize]
    public class CargarNominaEndpoint : BaseAsyncEndpoint.WithRequest<IFormFile>.WithResponse<Response<DocumentoDto>>
    {
        private readonly IMovimientoBusinessLogic _movimeintoBusinessLogic;
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="movimientoBusinessLogic"></param>
        public CargarNominaEndpoint(IMovimientoBusinessLogic movimientoBusinessLogic)
        {
            _movimeintoBusinessLogic = movimientoBusinessLogic;
        }

        /// <summary>
        /// Endpoint
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/cargarchivonomina")]
        [RequestSizeLimit(100_000_000)]
        [ProducesResponseType(typeof(Response<DocumentoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Carga Archivo Nomina",
            Description = "Carga Archivo Nomina",
            OperationId = "fileupload.CargaArchivoNomina",
            Tags = new[] { "CargueNominaEndpoint" })]
        public async override Task<ActionResult<Response<DocumentoDto>>> HandleAsync(IFormFile request, CancellationToken cancellationToken = default)
        {
            var userId = User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value;
            return await _movimeintoBusinessLogic.CargarArchivoNomina(request, Guid.Parse(userId));
        }
    }
}
