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
    /// Procesar archivos de carga
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>20/05/2021</date>
    [Authorize]
    public class ProcesarArchivosCarga : BaseAsyncEndpoint.WithRequest<IEnumerable<DocumentoDto>>.WithResponse<Response<IEnumerable<DocumentoDto>>>
    {
        /// <summary>
        /// DI movimiento logica de negocio
        /// </summary>
        private readonly IMovimientoBusinessLogic _movimeintoBusinessLogic;

        /// <summary>
        /// Constructor Procesar movimiento de carga 
        /// </summary>
        /// <param name="movimeintoBusinessLogic">DI movimiento logica de negocio</param>
        public ProcesarArchivosCarga(IMovimientoBusinessLogic movimeintoBusinessLogic)
        {
            _movimeintoBusinessLogic = movimeintoBusinessLogic;
        }

        /// <summary>
        /// Procesar archivos de carga endpoint
        /// </summary>
        /// <param name="request">Lista de archivos cargados</param>
        /// <param name="cancellationToken">Cancelacion de peticion</param>
        /// <returns>Lista de archivos procesados</returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/procesararchivoscargados")]
        [ProducesResponseType(typeof(Response<DocumentoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Procesar archivos cargados",
            Description = "Procesar Archivos Nomina",
            OperationId = "fileupload.procesararchivoscargados",
            Tags = new[] { "CargueNominaEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<DocumentoDto>>>> HandleAsync(IEnumerable<DocumentoDto> request, CancellationToken cancellationToken = default)
        {
            return await _movimeintoBusinessLogic.AprobarCargueNomina(request);
        }
    }
}
