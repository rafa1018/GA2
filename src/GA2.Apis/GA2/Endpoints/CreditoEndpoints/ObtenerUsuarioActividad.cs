﻿using Ardalis.ApiEndpoints;
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

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Endpoint para Obtener Usuario Actividad
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>   
    [Authorize]
    public class ObtenerUsuarioActividad : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<UsuarioActividadDto>>>
    {
        private readonly ICreditoBusinessLogic _usuarioactividadBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Obtener Usuario Actividad
        /// </summary>
        /// <param name="usuarioactividadBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public ObtenerUsuarioActividad(ICreditoBusinessLogic usuarioactividadBusinessLogic)
        {
            _usuarioactividadBusinessLogic = usuarioactividadBusinessLogic;
        }


        /// <summary>
        /// Obtiene all ciudades
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/credito/obtenerusuarioactividad")]
        [ProducesResponseType(typeof(Response<IEnumerable<UsuarioActividadDto>>), StatusCodes.Status200OK)]
        [SwaggerOperation(
            Summary = "Obtiene UsuarioActividad",
            Description = "Obtiene UsuarioActividad",
            OperationId = "Credito.obtenerusuarioactividad",
            Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<UsuarioActividadDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return await this._usuarioactividadBusinessLogic.ObtenerUsuarioActividad();
        }

    }
}
