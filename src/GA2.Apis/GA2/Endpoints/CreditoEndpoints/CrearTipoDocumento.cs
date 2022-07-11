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
    /// Endpoint para Crear Tipo Documento
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearTipoDocumento :
         BaseAsyncEndpoint.WithRequest<TipoDocumentoDto>
        .WithResponse<Response<TipoDocumentoDto>>
    {

        private readonly ICreditoBusinessLogic _tipodocumentoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Tipo Documento
        /// </summary>
        /// <param name="tipodocumentoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearTipoDocumento(ICreditoBusinessLogic tipodocumentoBusinessLogic)
        {
            _tipodocumentoBusinessLogic = tipodocumentoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/creartipodocumento")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TipoDocumentoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear TipoDocumento",
           Description = "Crear TipoDocumento",
           OperationId = "Credito.creartipodocumento",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<TipoDocumentoDto>>> HandleAsync(TipoDocumentoDto request, CancellationToken cancellationToken = default)
        {
            return await this._tipodocumentoBusinessLogic.CrearTipoDocumento(request);
        }
    }
}

