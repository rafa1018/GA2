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
    /// Endpoint para Obtener Tipo Documento
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    //[Authorize]
    public class ObtenerTipoDocumento : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TipoDocumentoDto>>>
    {
        private readonly ICreditoBusinessLogic _tipodocumentoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Tipo Documento
        /// </summary>
        /// <param name="tipodocumentoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerTipoDocumento(ICreditoBusinessLogic tipodocumentoBusinessLogic)
        {
            _tipodocumentoBusinessLogic = tipodocumentoBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerTipoDocumento")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoDocumentoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene TipoDocumento",
            Description = "Obtiene TipoDocumento",
            OperationId = "credito.obtenerTipoDocumento",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<TipoDocumentoDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {

            return await this._tipodocumentoBusinessLogic.ObtenerTipoDocumento();
        }

    }
}
