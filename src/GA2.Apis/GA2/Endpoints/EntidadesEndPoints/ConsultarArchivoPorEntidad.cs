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


namespace GA2.Apis.GA2.Endpoints.EntidadesEndPoints
{
    /// <summary>
    /// Endpoint para consultar los archivos de una solicitud
    /// </summary>
    /// <author>Hanson Restrepo</author>
    //[Authorize]
    public class ConsultarArchivoPorEntidad :
         BaseAsyncEndpoint.WithRequest<Guid>
        .WithResponse<Response<IEnumerable<ConsultarArchivoPorEntidadDto>>>
    {
        private readonly IEntidadesBusinessLogic _entidadesBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint consultar archivo por solicitud
        /// </summary>
        /// <param name="entidadesBusinessLogic"></param>
        /// <author>Hanson Restrepo</author>
        /// <date>07/03/2022</date>
        public ConsultarArchivoPorEntidad(IEntidadesBusinessLogic entidadesBusinessLogic)
        {
            _entidadesBusinessLogic = entidadesBusinessLogic;
        }

        /// <summary>
        /// Consulta Archivo al blob storage para solicitud de cesantías
        /// </summary>
        /// <param name="IdEntidad"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/Entidades/ConsultarArchivoPorEntidad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ObtenerTramiteSolicitudDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Consultar archivos por Entidades",
           Description = "Consultar archivos por Entidades",
           OperationId = "Entidades.ConsultarArchivoPorEntidad",
           Tags = new[] { "EntidadesEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ConsultarArchivoPorEntidadDto>>>> HandleAsync(Guid IdEntidad, CancellationToken cancellationToken = default)
        {
            return await this._entidadesBusinessLogic.ConsultarArchivoPorEntidad(IdEntidad);
        }
    }
}
