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

namespace GA2.Apis.GA2.Endpoints.CatalogEndpoints
{
    public class ObtenerTipoSolicitudNovedadMatricula : BaseAsyncEndpoint.WithoutRequest
        .WithResponse<Response<IEnumerable<TipoSolicitudNovedadMatriculaDto>>>
    {
        private readonly ICatalogosBusinessLogic _catalogsBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Obtener Catalogos
        /// </summary>
        /// <param name="catalogsBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>18/05/2021</date>
        public ObtenerTipoSolicitudNovedadMatricula(ICatalogosBusinessLogic catalogsBusinessLogic)
        {
            _catalogsBusinessLogic = catalogsBusinessLogic;
        }


        /// <summary>
        /// Obtiene all catalogos
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogos/ObtenerTipoSolicitudNovedadMatricula")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoSolicitudNovedadMatriculaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Tipo Solicitud Novedad Matricula",
            Description = "Obtener Tipo Solicitud Novedad Matricula",
            OperationId = "catalogos.ObtenerTipoSolicitudNovedadMatricula",
            Tags = new[] { "CatalogosEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TipoSolicitudNovedadMatriculaDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._catalogsBusinessLogic.ObtenerTipoSolicitudNovedadMatricula();
        }
    }
}
