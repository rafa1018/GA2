using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.MatriculasInmobiliariasEndPoints
{
    public class FiltroMatriculasInmobiliarias : BaseAsyncEndpoint.WithRequest<FiltroMatriculasInmobiliariasDto>.WithResponse<Response<IEnumerable<MatriculaInmibiliariaDto>>>
    {

        private readonly IMatriculasInmobiliariasLogic _matriculasInmobiliariasLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matriculasInmobiliariasLogic"></param>
        public FiltroMatriculasInmobiliarias(IMatriculasInmobiliariasLogic matriculasInmobiliariasLogic)
        {
            _matriculasInmobiliariasLogic = matriculasInmobiliariasLogic;
        }


        /// <summary>
        ///  Crea un nuevo usuario
        /// </summary>
        /// <param name="request">Peticion usuario</param>
        /// <param name="cancellationToken">cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        [HttpPost("api/filterMatriculasInmobiliaria")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<MatriculaInmibiliariaDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Filtro las matriculas Inmobiliarias",
           Description = "Filtra las matriculas inmobiliarias por Numero de matrricula,Numero de identificacion del propietario y tipo de documento",
           OperationId = "matriculas.filter",
           Tags = new[] { "MatriculasEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<MatriculaInmibiliariaDto>>>> HandleAsync(FiltroMatriculasInmobiliariasDto request, CancellationToken cancellationToken = default)
        {

            return await this._matriculasInmobiliariasLogic.FilterMatriculasInmobiliarias(request);
        }
 
    }
}
