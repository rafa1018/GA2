using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.WorkManager
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateForm:BaseAsyncEndpoint.WithRequest<RequestUpdateDto>.WithResponse<object>
    {
        private readonly IGestorDocumentalBusinessLogic _WMBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="wMBusinessLogic"></param>
        public UpdateForm(IGestorDocumentalBusinessLogic wMBusinessLogic)
        {
            _WMBusinessLogic = wMBusinessLogic;
        }

        /// <summary>
        /// updateForm
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/updateForm")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Update Form",
            Description = "Update Form",
            OperationId = "credito.UpdateForm",
            Tags = new[] { "WorkManager" })]
        public override async Task<ActionResult<object>> HandleAsync(RequestUpdateDto request, CancellationToken cancellationToken = default)
        {
            return await _WMBusinessLogic.ActualizarRegistro(request);
        }
    }
}
