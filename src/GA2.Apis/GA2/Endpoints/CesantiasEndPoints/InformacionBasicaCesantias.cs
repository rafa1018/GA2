using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para obtener la informacion basica del afiliado
    /// </summary>
    /// <author>Erwin Pantoja España</author>
    [Authorize]
    public class InformacionBasicaCesantias : BaseAsyncEndpoint
        .WithRequest<int>
        .WithResponse<Response<InformacionBasicaCesantiasDto>>
    {
        private readonly ICesantiasBusinessLogic _cesantiasBusinessLogic;

        /// <summary>
        /// Ctor endponit
        /// </summary>
        /// <param name="cesantiasBusinessLogic"></param>
        public InformacionBasicaCesantias(ICesantiasBusinessLogic cesantiasBusinessLogic)
        {
            _cesantiasBusinessLogic = cesantiasBusinessLogic;
        }


        /// <summary>
        /// Endpoint para obtener la informacion basica de un afiliado de BUA
        /// </summary>
        /// <param name="numeroIdentificacion">Cedula del afiliado</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/cesantias/InformacionBasicaCesantias")]
        [ProducesResponseType(typeof(Response<InformacionBasicaCesantiasDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene datos del afiliado",
            Description = "Obtiene datos del afiliado",
            OperationId = "credito.InformacionBasicaCesantias",
            Tags = new[] { "CesantiasEndpoint" })]
        public async override Task<ActionResult<Response<InformacionBasicaCesantiasDto>>> HandleAsync(int numeroIdentificacion, CancellationToken cancellationToken = default)
        {
            return await this._cesantiasBusinessLogic.InformacionBasicaCesantias(numeroIdentificacion);
        }
    }
}
