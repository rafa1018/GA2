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

namespace GA2.Apis.GA2.Endpoints.SevenEndpoints.CuentasContables
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ObtenerCuentaContable: BaseAsyncEndpoint.WithRequest<GetCuentaContableRequestDto>.WithResponse<Response<object>>
    {
        private readonly ISevenBusinesslogic _sevenBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sevenBusinessLogic"></param>
        public ObtenerCuentaContable(ISevenBusinesslogic sevenBusinessLogic)
        {
            _sevenBusinessLogic = sevenBusinessLogic;
        }

        /// <summary>
        /// Obtener Cuenta Contable
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("api/credito/ObtenerCuentaContable")]
        [ProducesResponseType(typeof(Response<object>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtener Cuenta Contable",
            Description = "Obtener Cuenta Contable",
            OperationId = "Seven.ObtenerCuentaContable",
            Tags = new[] { "Seven" })]
        public async override Task<ActionResult<Response<object>>> HandleAsync(GetCuentaContableRequestDto request, CancellationToken cancellationToken = default)
        {
            return await this._sevenBusinessLogic.ObtenerCuentaContable(request);
        }
    }
}
