using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Custom = GA2.Transversals.Commons.CustomBaseEndpoints;

namespace GA2.Apis.GA2.Endpoints.SolicitudEndPoints
{
    /// <summary>
    /// Endpoint para descargar archivos en una solicitud
    /// </summary>
    /// <author>Hanson Restrepo</author>
    public class DescargarArchivoPorSolicitud : 
        Custom.BaseAsyncEndpoint.WithRequest<string>
        .WithResponseCustoms<FileResult>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint descargar archivo solicitud
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        public DescargarArchivoPorSolicitud(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rutaStorage"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpGet("api/solicitud/DescargarArchivoPorSolicitud")]
        [ProducesResponseType(typeof(Response<FileResult>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "DescargarArchivoPorSolicitud",
            Description = "Descargar Archivo por Solicitud",
            OperationId = "Solicitud.DescargarArchivoPorSolicitud",
            Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<FileResult> HandleAsync(string rutaStorage, CancellationToken cancellationToken = default)
        {
            return await this._solicitudBusinessLogic.DescargarArchivoPorSolicitud(rutaStorage);
        }
    }
}
