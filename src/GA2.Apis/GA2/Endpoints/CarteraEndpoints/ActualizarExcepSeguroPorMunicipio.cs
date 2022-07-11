using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{
    public class ActualizarExcepSeguroPorMunicipio : BaseAsyncEndpoint.WithRequest<ParamGeneralesSegurosDto>.WithResponse<Response<ParamGeneralesSegurosDto>>
    {
        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        public ActualizarExcepSeguroPorMunicipio(ICarteraBusinessLogic carteraBusinessLogic)
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
        [HttpPost("api/cartera/actualizarExcepSeguroPorMunicipio")]
        [ProducesResponseType(typeof(Response<ParamGeneralesSegurosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualiza excepcion seguro por municipio",
            Description = "Actualiza excepcion seguro por municipio",
            OperationId = "cartera.ActualizarExcepSeguroPorMunicipio",
            Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<ParamGeneralesSegurosDto>>> HandleAsync(ParamGeneralesSegurosDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ActualizarExcepSeguroPorMunicipio(request);
        }
    }
}
