using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.MatriculasInmobiliariasEndPoints
{
    [Authorize]
    public class InsertNovedMatriculaInmobiliaria : BaseAsyncEndpoint.WithRequest<NovedadesMatriculasInmobiliariasDto>.WithResponse<Response<IEnumerable<NovedadesMatriculasInmobiliariasDto>>>
    {

        private readonly IMatriculasInmobiliariasLogic _matriculasInmobiliariasLogic;

        public InsertNovedMatriculaInmobiliaria(IMatriculasInmobiliariasLogic matriculasInmobiliariasLogic)
        {
            _matriculasInmobiliariasLogic = matriculasInmobiliariasLogic;
        }


        /// <summary>
        ///  Crea un nuevo usuario
        /// </summary>
        /// <param name="request">Peticion usuario</param>
        /// <param name="cancellationToken">cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        [HttpPost("api/insertNovedMatriculaInmobiliaria")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<NovedadesMatriculasInmobiliariasDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Insertar novedad matriculas inmoviliarias",
           Description = "Inserta una novedad de una matricula inmobiliaria",
           OperationId = "matriculas.insertNovedad",
           Tags = new[] { "MatriculasEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<NovedadesMatriculasInmobiliariasDto>>>> HandleAsync(NovedadesMatriculasInmobiliariasDto request, CancellationToken cancellationToken = default)
        {

            //request.UserCreadorId = System.Guid.Parse(User.Claims.Where(c => c.Type == "USR_ID").FirstOrDefault().Value);
            
            return await this._matriculasInmobiliariasLogic.InsertNovedMatriculaInmobiliaria(request);
           
        }
    }
}
