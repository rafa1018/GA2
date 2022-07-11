using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace GA2.Apis.GA2.Endpoints.SolicitudEndPoints
{
    /// <summary>
    /// Endpoint para consultar los archivos de un tipo de sub modalidad
    /// </summary>
    /// <author>Erwin Pantoja España</author>
    // [Authorize]
    public class ConsultarDocumentosPorSubModalidad :
         BaseAsyncEndpoint.WithRequest<ConsultaDocumentoSubModalidadTarea>
        .WithResponse<Response<IEnumerable<DocumentosPorSubModalidadDto>>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Erwin Pantoja</author>
        /// <date>20/10/2021</date>
        public ConsultarDocumentosPorSubModalidad(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }

        /// <summary>
        /// EndPoint para crear una solicitud
        /// </summary>
        /// <param name="consultaDocumentoSubModalidadTarea"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/solicitud/ConsultarDocumentosPorSubModalidad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(IEnumerable<DocumentosPorSubModalidadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Consultar documentos por sub modalidad",
           Description = "Consultar documentos por sub modalidad",
           OperationId = "Solicitud.ConsultarDocumentosPorSubModalidad",
           Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<DocumentosPorSubModalidadDto>>>> HandleAsync(ConsultaDocumentoSubModalidadTarea consultaDocumentoSubModalidadTarea, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.ConsultarDocumentosPorSubModalidad(consultaDocumentoSubModalidadTarea);
        }
    }
}
