using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.FenixEndpoints
{
    /// <summary>
    /// 
    /// </summary>
    //[Authorize]
    public class ValidarBiometria : BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<diffgram>>
    {
        private readonly IFenixBusinessLogic _fenixBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="fenixBusinessLogic"></param>
        public ValidarBiometria(IFenixBusinessLogic fenixBusinessLogic)
        {
            _fenixBusinessLogic = fenixBusinessLogic;
        }

        /// <summary>
        /// validarBiometria
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/credito/validarBiometria")]
        [ProducesResponseType(typeof(Response<diffgram>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Validar Biometria",
            Description = "Validar Biometria",
            OperationId = "Fenix.ValidarBiometria",
            Tags = new[] { "Fenix" })]
        public async override Task<ActionResult<Response<diffgram>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._fenixBusinessLogic.ValidarBiometria(request);
        }
    }
}
