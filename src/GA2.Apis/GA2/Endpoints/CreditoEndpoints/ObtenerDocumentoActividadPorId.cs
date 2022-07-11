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
    /// Endpoint para Obtener Documento Actividad Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class ObtenerDocumentoActividadPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<DocumentoActividadDto>>
    {

        private readonly ICreditoBusinessLogic _documentoactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Documento Actividad Por Id
        /// </summary>
        /// <param name="documentoactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerDocumentoActividadPorId(ICreditoBusinessLogic documentoactividadBusinessLogic)
        {
            _documentoactividadBusinessLogic = documentoactividadBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerdocumentoactividadporid")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<DocumentoActividadDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtener DocumentoActividadPorId",
           Description = "Obtener Documento Actividad Por Id",
           OperationId = "credito.obtenerdocumentoactividadporid",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<DocumentoActividadDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._documentoactividadBusinessLogic.ObtenerDocumentoActividadPorId(request);
        }
    }
}

