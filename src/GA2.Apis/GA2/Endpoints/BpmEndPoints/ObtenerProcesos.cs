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
	/// Endpoint para Obtener todos los procesos
	/// </summary>
	/// <author>Erwin Pantoja España</author>
	/// <date>25/10/2021</date>
    [Authorize]
    public class ObtenerProcesos : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<ProcesoDto>>>
    {
        private readonly IProcesoBusinessLogic _procesoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Procesos
        /// </summary>
        /// <param name="procesoBusinessLogic"></param>
        /// <author>Erwin Pantoja</author>
        /// <date>25/10/2021</date>
        public ObtenerProcesos(IProcesoBusinessLogic procesoBusinessLogic)
        {
            _procesoBusinessLogic = procesoBusinessLogic;
        }


        /// <summary>
        /// EndPoint para crear una solicitud
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/bpm/obtenerProcesos")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ObtenerTramiteSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener todos los procesos",
           Description = "Metodo para obtener todos los procesos",
           OperationId = "bpm.obtenerProcesos",
           Tags = new[] { "BpmEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ProcesoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._procesoBusinessLogic.ObtenerProcesos();
        }
    }
}
