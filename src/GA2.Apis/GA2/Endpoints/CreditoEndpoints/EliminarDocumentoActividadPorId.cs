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
    /// Endpoint para Eliminar Documento Actividad Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class EliminarDocumentoActividadPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<DocumentoActividadDto>>
    {

        private readonly ICreditoBusinessLogic _documentoactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Documento Actividad Por Id
        /// </summary>
        /// <param name="documentoactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public EliminarDocumentoActividadPorId(ICreditoBusinessLogic documentoactividadBusinessLogic)
        {
            _documentoactividadBusinessLogic = documentoactividadBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/credito/eliminardocumentoactividad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<DocumentoActividadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Eliminar DocumentoActividad",
           Description = "Eliminar DocumentoActividad",
           OperationId = "Credito.eliminardocumentoactividad",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<DocumentoActividadDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._documentoactividadBusinessLogic.EliminarDocumentoActividadPorid(request);
        }
    }
}

