using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.MatriculasInmobiliariasEndPoints
{
    public class EliminarMatriculaInmobiliaria : BaseAsyncEndpoint.WithRequest<MatriculaInmibiliariaDto>.WithResponse<Response<MatriculaInmibiliariaDto>>
    {

        private readonly IMatriculasInmobiliariasLogic _matriculasInmobiliariasLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matriculasInmobiliariasLogic"></param>
        public EliminarMatriculaInmobiliaria(IMatriculasInmobiliariasLogic matriculasInmobiliariasLogic)
        {
            _matriculasInmobiliariasLogic = matriculasInmobiliariasLogic;
        }


        /// <summary>
        ///  Crea un nuevo usuario
        /// </summary>
        /// <param name="request">Peticion usuario</param>
        /// <param name="cancellationToken">cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        [HttpPost("api/EliminarMatriculaInmobiliaria")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<CrearMatriculaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Elimina matricula Inmobiliaria",
           Description = "Elimina matricula Inmobiliaria",
           OperationId = "matriculas.EliminarMatriculaInmobiliaria",
           Tags = new[] { "MatriculasEndpoint" })]
        public override async Task<ActionResult<Response<MatriculaInmibiliariaDto>>> HandleAsync(MatriculaInmibiliariaDto request, CancellationToken cancellationToken = default)
        {

            return await this._matriculasInmobiliariasLogic.EliminarMatriculaInmobiliaria(request);
        }
    }
}
