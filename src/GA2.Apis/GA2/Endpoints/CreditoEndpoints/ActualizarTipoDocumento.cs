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
	/// Endpoint para Actualizar Tipo Documento
	/// </summary>
	/// <author>Cristian Gonzalez Parra</author>
	/// <date>11/05/2021</date>
    [Authorize]
    public class ActualizarTipoDocumento :
         BaseAsyncEndpoint.WithRequest<TipoDocumentoDto>
        .WithResponse<Response<TipoDocumentoDto>>
    {

        private readonly ICreditoBusinessLogic _tipodocumentoBusinessLogic;

        /// <summary>
        /// Constructor de Endpoint Actualizar Tipo Documento
        /// </summary>
        /// <param name="tipodocumentoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ActualizarTipoDocumento(ICreditoBusinessLogic tipodocumentoBusinessLogic)
        {
            _tipodocumentoBusinessLogic = tipodocumentoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name = "request"></param >
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/credito/actualizartipodocumento")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<TipoDocumentoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualizar TipoDocumento",
           Description = "Actualizar TipoDocumento",
           OperationId = "Credito.actualizartipodocumento",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<TipoDocumentoDto>>> HandleAsync(TipoDocumentoDto request, CancellationToken cancellationToken = default)
        {
            return await this._tipodocumentoBusinessLogic.ActualizarTipoDocumento(request);
        }
    }
}

