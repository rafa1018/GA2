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
using System.Threading;
using System.Threading.Tasks;
using Commons = GA2.Transversals.Commons.CustomBaseEndpoints;

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class CargarArchivoAplicacionPagoMasivo : Commons.BaseAsyncEndpoint.WithRequest<int>.WithResponseCustoms<Response<List<AplicacionPagoDto>>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;
        private readonly IHttpContextAccessor _contextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        /// <param name="contextAccessor"></param>
        public CargarArchivoAplicacionPagoMasivo(ICarteraBusinessLogic carteraBusinessLogic, IHttpContextAccessor contextAccessor)
        {
            _carteraBusinessLogic = carteraBusinessLogic ?? throw new ArgumentException(nameof(carteraBusinessLogic));
            _contextAccessor = contextAccessor ?? throw new ArgumentException(nameof(contextAccessor));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="unidadEjecutora"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/cartera/CargarArchivoAplicacionPagoMasivo")]
        [ProducesResponseType(typeof(Response<List<AplicacionPagoDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Cargar archivo aplicacion pago masivo",
            Description = "Cargar archivo aplicacion pago masivo",
            OperationId = "cartera.CargarArchivoAplicacionPagoMasivo",
            Tags = new[] { "CarteraEndpoint" })]
        public override async Task<Response<List<AplicacionPagoDto>>> HandleAsync(int unidadEjecutora, CancellationToken cancellationToken = default)
        {
            var files = _contextAccessor.HttpContext.Request.Form.Files;

            return await _carteraBusinessLogic.CargarArchivoAplicacionPagoMasivo(files[0], unidadEjecutora);

        }
    }
}
