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

namespace GA2.Apis.GA2.Endpoints.EntidadesEndPoints
{
    /// <summary>
    /// Endpoint carga documentos entidades educativas
    /// </summary>
    /// [Authorize]
    public class CargarDocumentosEntidad : BaseAsyncEndpoint.WithRequest<IFormCollection>.WithResponse<Response<bool>>
    {
        private readonly IEntidadesBusinessLogic _entidadesBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Cargar documento
        /// </summary>
        /// <param name="entidadesBusinessLogic"></param>
        /// <author>Erwin Pantoja</author>
        /// <date>20/10/2021</date>
        public CargarDocumentosEntidad(IEntidadesBusinessLogic entidadesBusinessLogic)
        {
            _entidadesBusinessLogic = entidadesBusinessLogic;
        }

        /// <summary>
        /// Carga Archivo al blob storage para solicitud de cesantías
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/Entidades/CargarDocumentosEntidad")]
        [ProducesResponseType(typeof(Response<bool>), StatusCodes.Status200OK)]
        [SwaggerOperation("Carga Archivo al blob storage de las entidades",
            Description = "Carga Archivo al blob storage de las entidades",
            OperationId = "Entidades.CargarDocumentosEntidad",
            Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<bool>>> HandleAsync(IFormCollection request, CancellationToken cancellationToken = default)
        {
            List<CargarDocumentosEntidadDto> listaArchivos = new List<CargarDocumentosEntidadDto>();
            Guid idEntidad = new Guid(request["idEntidad"].ToString());
            for (int i = 0; i < request.Keys.Count; i++)
            {
                if (request[$"archivoParametrizadoId[{i}]"].ToString() != "")
                {
                    listaArchivos.Add(new CargarDocumentosEntidadDto
                    {
                        ArchivoParametrizadoId = new Guid(request[$"archivoParametrizadoId[{i}]"].ToString()),
                        ArchivosCargados = request.Files.GetFiles($"archivosCargados[{i}]").ToList()
                    });
                }
            }
            return await _entidadesBusinessLogic.CargarDocumentosEntidad(listaArchivos, idEntidad);
        }
    }
}
