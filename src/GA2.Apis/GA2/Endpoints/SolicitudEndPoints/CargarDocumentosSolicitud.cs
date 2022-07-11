using System.Linq;
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
using System;

namespace GA2.Apis.GA2.Endpoints.SolicitudEndPoints
{
    /// <summary>
    /// Endpoint carga documento solicitud de cesantías
    /// </summary>
    [Authorize]
    public class CargarDocumentosSolicitud : BaseAsyncEndpoint.WithRequest<IFormCollection>.WithResponse<Response<bool>>
    {
        private readonly ISolicitudBusinessLogic _solicitudBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Cargar documento
        /// </summary>
        /// <param name="solicitudBusinessLogic"></param>
        /// <author>Erwin Pantoja</author>
        /// <date>20/10/2021</date>
        public CargarDocumentosSolicitud(ISolicitudBusinessLogic solicitudBusinessLogic)
        {
            _solicitudBusinessLogic = solicitudBusinessLogic;
        }

        /// <summary>
        /// Carga Archivo al blob storage para solicitud de cesantías
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/solicitud/cargarDocumentosSolicitud")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation("Carga Archivo al blob storage para solicitud de cesantias",
            Description = "Carga Archivo al blob storage para solicitud de cesantias",
            OperationId = "Solicitud.CargarDocumentosSolicitud",
            Tags = new[] { "SolicitudEndpoint" })]
        public async override Task<ActionResult<Response<bool>>> HandleAsync(IFormCollection request, CancellationToken cancellationToken = default)
        {
            List<CargarDocumentosSolicitudDto> listaArchivos = new List<CargarDocumentosSolicitudDto>();
            Guid idSolicitud = new Guid(request["idSolicitud"].ToString());
            for (int i = 0; i < request.Keys.Count; i++) {
                if (request[$"archivoParametrizadoId[{i}]"].ToString() != "") {
                    listaArchivos.Add(new CargarDocumentosSolicitudDto { 
                        archivoParametrizadoId = new Guid(request[$"archivoParametrizadoId[{i}]"].ToString()),
                        archivosCargados = request.Files.GetFiles($"archivosCargados[{i}]").ToList()
                    });
                }
            }
            return await _solicitudBusinessLogic.CargarDocumentosSolicitud(listaArchivos, idSolicitud);
        }
    }
}
