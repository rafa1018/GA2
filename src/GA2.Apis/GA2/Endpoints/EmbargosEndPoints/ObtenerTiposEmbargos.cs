﻿using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints.EmbargosEndPoints
{
    public class ObtenerTiposEmbargos : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TipoEmbargosDto>>>
    {

        private readonly IEmbargosBusinessLogic _embargosBusinessLogic;

        public ObtenerTiposEmbargos(IEmbargosBusinessLogic embargosBusinessLogic)
        {
            _embargosBusinessLogic = embargosBusinessLogic;
        }

        [HttpGet("api/ObtenerTiposEmbargos")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<IEnumerable<TipoEmbargosDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
             Summary = "Listar todos los tipos de embargos",
             Description = "Listar todos los tipos de embargos",
             OperationId = "Embargos.ObtenerTiposEmbargos",
             Tags = new[] { "EmbargosEndPoints" })]
        public override async Task<ActionResult<Response<IEnumerable<TipoEmbargosDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._embargosBusinessLogic.ObtenerTiposEmbargos();
        }
    }
}
