using Commons = GA2.Transversals.Commons.CustomBaseEndpoints;
using Ardalis.ApiEndpoints;
using System.Collections.Generic;
using GA2.Domain.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using GA2.Application.Dto;
using System.Threading.Tasks;
using System.Threading;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class CargaMasivaLeasing : Commons.BaseAsyncEndpoint.WithRequest<IFormFile>.WithoutResponse
    {
        private readonly ICarteraBusinessLogic  _carteraBusinessLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public CargaMasivaLeasing(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/cartera/cargaMasivaLeasing")]
        [SwaggerOperation(
            Summary = "Cargar archivo masivo leasing",
            Description = "Cargar archivo masivo leasing",
            OperationId = "cartera.CargaMasivaLeasing",
            Tags = new[] { "CarteraEndpoint" })]
        public override async Task<ActionResult> HandleAsync(IFormFile request, CancellationToken cancellationToken = default)
        {
            return await _carteraBusinessLogic.CargaMasivaLeasing(request);
        }
    }
}
