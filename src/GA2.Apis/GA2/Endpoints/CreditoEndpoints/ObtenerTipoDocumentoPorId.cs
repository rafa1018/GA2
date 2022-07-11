using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// Endpoint para Obtener Tipo Documento Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerTipoDocumentoPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<TipoDocumentoDto>>
    {

        private readonly ICreditoBusinessLogic _tipodocumentoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Tipo Documento Por Id
        /// </summary>
        /// <param name="tipodocumentoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerTipoDocumentoPorId(ICreditoBusinessLogic tipodocumentoBusinessLogic)
        {
            _tipodocumentoBusinessLogic = tipodocumentoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenertipodocumentoporid")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TipoDocumentoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener TipoDocumento por id",
           Description = "Obtener TipoDocumento por id",
           OperationId = "credito.obtenertipodocumentoporid",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<TipoDocumentoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._tipodocumentoBusinessLogic.ObtenerTipoDocumentoPorId(request);
        }
    }
}

