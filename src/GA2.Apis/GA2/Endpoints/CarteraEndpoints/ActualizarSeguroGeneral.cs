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

namespace GA2.Apis.GA2.Endpoints.CarteraEndpoints
{

    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class ActualizarSeguroGeneral : BaseAsyncEndpoint.WithRequest<ParamGeneralesSegurosDto>.WithResponse<Response<ParamGeneralesSegurosDto>>
    {

        private readonly ICarteraBusinessLogic _carteraBusinessLogic;

        public ActualizarSeguroGeneral(ICarteraBusinessLogic carteraBusinessLogic)
        {
            _carteraBusinessLogic = carteraBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        //[ValidateAntiForgeryToken]
        [HttpPost("api/cartera/actualizarSeguroGeneral")]
        [ProducesResponseType(typeof(Response<ParamGeneralesSegurosDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Actualizar parametros de seguro general ",
            Description = "Actualizar parametros de seguro general",
            OperationId = "cartera.ActualizarSeguroGeneral",
            Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<ParamGeneralesSegurosDto>>> HandleAsync(ParamGeneralesSegurosDto request, CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ActualizarSeguroGeneral(request);
        }
    }
}
