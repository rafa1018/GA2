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
    /// Obtiene los registros generales de los seguros
    /// </summary>


    [Authorize]
    public class ObtenerSeguroGeneral : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<ParamGeneralesSegurosDto>>>
    {
        
        
        
            private readonly ICarteraBusinessLogic _carteraBusinessLogic;

            /// <summary>
            /// Ctor
            /// </summary>
            /// <param name="carteraBusinessLogic"></param>
            public ObtenerSeguroGeneral(ICarteraBusinessLogic carteraBusinessLogic)
            {
                _carteraBusinessLogic = carteraBusinessLogic;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cancellationToken"></param>
            /// <returns></returns>
            [HttpGet("api/cartera/obtenerSeguroGeneral")]
            [ProducesResponseType(typeof(Response<ParamGeneralesSegurosDto>), StatusCodes.Status200OK)]
            [SwaggerOperation(
               Summary = "Obtener Registros seguros general",
               Description = "Obtener Registros seguros general",
               OperationId = "credito.ObtenerSeguroGeneral",
               Tags = new[] { "CarteraEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<ParamGeneralesSegurosDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._carteraBusinessLogic.ObtenerSeguroGeneral();
        }
    }
 }
