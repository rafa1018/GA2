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

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class CrearExcepcionPorMunicipio : BaseAsyncEndpoint.WithRequest<ParamGeneralesSegurosDto>.WithResponse<Response<ParamGeneralesSegurosDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="carteraBusinessLogic"></param>
        public CrearExcepcionPorMunicipio(ICarteraBusinessLogic carteraBusinessLogic)
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
        [HttpPost("api/cartera/crearExcepcionPorMunicipio")]
        [ProducesResponseType(typeof(Response<ParamGeneralesSegurosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Crea excepcion seguro por municipio",
            Description = "Crea excepcion seguro por municipio",
            OperationId = "cartera.ObtenerExcepSeguroPorMunicipio",
            Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<ParamGeneralesSegurosDto>>> HandleAsync(ParamGeneralesSegurosDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.CrearExcepcionPorMunicipio(request);
                
        }
    }
}
