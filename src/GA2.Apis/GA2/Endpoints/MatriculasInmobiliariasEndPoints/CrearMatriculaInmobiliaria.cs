using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.MatriculasInmobiliariasEndPoints
{
    public class CrearMatriculaInmobiliaria : BaseAsyncEndpoint.WithRequest<CrearMatriculaDto>.WithResponse<Response<CrearMatriculaDto>>
    {

        private readonly IMatriculasInmobiliariasLogic _matriculasInmobiliariasLogic;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matriculasInmobiliariasLogic"></param>
        public CrearMatriculaInmobiliaria(IMatriculasInmobiliariasLogic matriculasInmobiliariasLogic)
        {
            _matriculasInmobiliariasLogic = matriculasInmobiliariasLogic;
        }


        /// <summary>
        ///  Crea un nuevo usuario
        /// </summary>
        /// <param name="request">Peticion usuario</param>
        /// <param name="cancellationToken">cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        [HttpPost("api/CrearMatriculaInmobiliaria")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<CrearMatriculaDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Crea matricula Inmobiliaria",
           Description = "Crea matricula Inmobiliaria",
           OperationId = "matriculas.CrearMatriculaInmobiliaria",
           Tags = new[] { "MatriculasEndpoint" })]
        public override async Task<ActionResult<Response<CrearMatriculaDto>>> HandleAsync(CrearMatriculaDto request, CancellationToken cancellationToken = default)
        {

            return await this._matriculasInmobiliariasLogic.CrearMatriculaInmobiliaria(request);
        }
    }
}
