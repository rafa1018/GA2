using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.MatriculasInmobiliariasEndPoints
{
    public class InformacionBasicaMatriculaInmobiliariaById : BaseAsyncEndpoint.WithRequest<Guid>.WithResponse<Response<MatriculaInmibiliariaDto>>
    {

        private readonly IMatriculasInmobiliariasLogic _matriculasInmobiliariasLogic;

        public InformacionBasicaMatriculaInmobiliariaById(IMatriculasInmobiliariasLogic matriculasInmobiliariasLogic)
        {
            _matriculasInmobiliariasLogic = matriculasInmobiliariasLogic;
        }


        /// <summary>
        ///  Crea un nuevo usuario
        /// </summary>
        /// <param name="request">Peticion usuario</param>
        /// <param name="cancellationToken">cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        [HttpGet("api/informacionBasicaMatriculaInmobiliariaById")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<MatriculaInmibiliariaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Informacion basica de matriculas inmoviliarias",
           Description = "Optiene la informacion basica de la matricula inmoviliaria por Id",
           OperationId = "matriculas.infoBasica",
           Tags = new[] { "MatriculasEndpoint" })]
        public override async Task<ActionResult<Response<MatriculaInmibiliariaDto>>> HandleAsync(Guid request, CancellationToken cancellationToken = default)
        {
            return await this._matriculasInmobiliariasLogic.InformacionBasicaMatriculaInmobiliariaById(request);
        }
    }
}
