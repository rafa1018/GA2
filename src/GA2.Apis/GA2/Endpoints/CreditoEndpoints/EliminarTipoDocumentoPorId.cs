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
    /// Endpoint para Eliminar Tipo Documento Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class EliminarTipoDocumentoPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<TipoDocumentoDto>>
    {

        private readonly ICreditoBusinessLogic _tipodocumentoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Tipo Documento Por Id
        /// </summary>
        /// <param name="tipodocumentoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public EliminarTipoDocumentoPorId(ICreditoBusinessLogic tipodocumentoBusinessLogic)
        {
            _tipodocumentoBusinessLogic = tipodocumentoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/credito/eliminartipodocumento")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TipoDocumentoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Eliminar TipoDocumento",
           Description = "Eliminar TipoDocumento",
           OperationId = "credito.eliminartipodocumento",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<TipoDocumentoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._tipodocumentoBusinessLogic.EliminarTipoDocumentoPorid(request);
        }
    }
}

