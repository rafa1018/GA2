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
    /// Endpoint para Obtener Documento Actividad
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerDocumentoActividad : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<DocumentoActividadDto>>>
    {
        private readonly ICreditoBusinessLogic _documentoactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Documento Actividad
        /// </summary>
        /// <param name="documentoactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerDocumentoActividad(ICreditoBusinessLogic documentoactividadBusinessLogic)
        {
            _documentoactividadBusinessLogic = documentoactividadBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerdocumentoactividad")]
        [ProducesResponseType(typeof(Response<IEnumerable<DocumentoActividadDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene DocumentoActividad",
            Description = "Obtiene DocumentoActividad",
            OperationId = "credito.obtenerdocumentoactividad",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<DocumentoActividadDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._documentoactividadBusinessLogic.ObtenerDocumentoActividad();
        }

    }
}
