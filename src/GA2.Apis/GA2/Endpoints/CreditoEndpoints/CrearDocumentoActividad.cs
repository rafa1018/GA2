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
    /// Endpoint para Crear Documento Actividad
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class CrearDocumentoActividad :
         BaseAsyncEndpoint.WithRequest<DocumentoActividadDto>
        .WithResponse<Response<DocumentoActividadDto>>
    {

        private readonly ICreditoBusinessLogic _documentoactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Crear Documento Actividad
        /// </summary>
        /// <param name="documentoactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public CrearDocumentoActividad(ICreditoBusinessLogic documentoactividadBusinessLogic)
        {
            _documentoactividadBusinessLogic = documentoactividadBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/creardocumentoactividad")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<DocumentoActividadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crear DocumentoActividad",
           Description = "Crear DocumentoActividad",
           OperationId = "Credito.creardocumentoactividad",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<DocumentoActividadDto>>> HandleAsync(DocumentoActividadDto request, CancellationToken cancellationToken = default)
        {
            return await this._documentoactividadBusinessLogic.CrearDocumentoActividad(request);
        }
    }
}

