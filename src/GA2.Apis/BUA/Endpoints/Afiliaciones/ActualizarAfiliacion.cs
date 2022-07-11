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

namespace GA2.Apis.BUA.Endpoints.Afiliaciones
{
    public class ActualizarAfiliacion : BaseAsyncEndpoint.WithRequest<AfiliacionDto>.WithResponse<Response<AfiliacionDto>>
    {
        private readonly IAfiliacionesBusinessLogic _afiliacionesBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="clientsBusinessLogic"></param>
        public ActualizarAfiliacion(IAfiliacionesBusinessLogic afiliacionesBusinessLogic)
        {
            _afiliacionesBusinessLogic = afiliacionesBusinessLogic;
        }

        /// <summary>
        /// Update client info
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        //[ValidateAntiForgeryToken]
        [HttpPost("api/ActualizarAfiliacion")]
        [ProducesResponseType(typeof(Response<IEnumerable<AfiliacionDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualiza una afiliación",
           Description = "Actualiza una afiliación",
           OperationId = "afiliaciones.InsertarAfiliacion",
           Tags = new[] { "AfiliacionesEndpoint" })]
        public async override Task<ActionResult<Response<AfiliacionDto>>> HandleAsync(AfiliacionDto request, CancellationToken cancellationToken = default)
        {
            return await _afiliacionesBusinessLogic.ActualizarAfiliacion(request);
        }
    }
}
