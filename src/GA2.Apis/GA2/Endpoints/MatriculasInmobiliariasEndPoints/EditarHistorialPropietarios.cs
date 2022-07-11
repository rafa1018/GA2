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
    public class EditarHistorialPropietarios : BaseAsyncEndpoint.WithRequest<PropietariosMatriculasInmobiliariasDto>.WithResponse<Response<PropietariosMatriculasInmobiliariasDto>>
    {
        private readonly IMatriculasInmobiliariasLogic _matriculasInmobiliariasLogic;

        public EditarHistorialPropietarios(IMatriculasInmobiliariasLogic matriculasInmobiliariasLogic)
        {
            _matriculasInmobiliariasLogic = matriculasInmobiliariasLogic;
        }


        [HttpPost("api/EditarHistorialPropietarios")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<PropietariosMatriculasInmobiliariasDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
                   Summary = "Historial de propietarios de matriculas inmoviliarias",
                   Description = "Optiene una lista con el historial de los propietarios de matricula inmoviliaria por Id",
                   OperationId = "matriculas.historialPropietarios",
                   Tags = new[] { "MatriculasEndpoint" })]
        public override async Task<ActionResult<Response<PropietariosMatriculasInmobiliariasDto>>> HandleAsync(PropietariosMatriculasInmobiliariasDto request, CancellationToken cancellationToken = default)
        {
            return await this._matriculasInmobiliariasLogic.EditarHistorialPropietarios(request);
        }
    }
}
