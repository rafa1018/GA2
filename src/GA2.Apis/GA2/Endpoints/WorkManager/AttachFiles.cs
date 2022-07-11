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

namespace GA2.Apis.GA2.Endpoints.WorkManager
{
    /// <summary>
    /// 
    /// </summary>
    public class AttachFiles : BaseAsyncEndpoint.WithRequest<AttachRequestDto>.WithResponse<object>
    {
        private readonly IGestorDocumentalBusinessLogic _WMBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="wMBusinessLogic"></param>
        public AttachFiles(IGestorDocumentalBusinessLogic wMBusinessLogic)
        {
            _WMBusinessLogic = wMBusinessLogic;
        }

        /// <summary>
        /// attachFiles
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/attachFiles")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Attach Files",
            Description = "Attach Files",
            OperationId = "credito.AttachFiles",
            Tags = new[] { "WorkManager" })]
        public override async Task<ActionResult<object>> HandleAsync(AttachRequestDto request, CancellationToken cancellationToken = default)
        {
            return await _WMBusinessLogic.AttachFiles(request);;
        }
    }
}
