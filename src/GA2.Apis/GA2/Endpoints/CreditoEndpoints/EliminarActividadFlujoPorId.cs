﻿using Ardalis.ApiEndpoints;
using GA2.Application.Dto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.Identity.EndPoints
{
    /// <summary>
    /// Endpoint para Eliminar Actividad Flujo Por Id
    /// </summary>
    /// <author>Cristian Gonzalez Parra</author>
    /// <date>11/05/2021</date>
    [Authorize]
    public class EliminarActividadFlujoPorId :
         BaseAsyncEndpoint.WithRequest<string>
        .WithResponse<Response<ActividadFlujoDto>>
    {

        private readonly ICreditoBusinessLogic _actividadflujoBusinessLogic;

        /// <summary>
        /// Constructor del Endpoint Eliminar Actividad Flujo Por Id
        /// </summary>
        /// <param name="actividadflujoBusinessLogic"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>11/05/2021</date>
        public EliminarActividadFlujoPorId(ICreditoBusinessLogic actividadflujoBusinessLogic)
        {
            _actividadflujoBusinessLogic = actividadflujoBusinessLogic;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("api/credito/eliminaractividadflujo")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ActividadFlujoDto>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Eliminar ActividadFlujo",
           Description = "Eliminar ActividadFlujo",
           OperationId = "Credito.eliminaractividadflujo",
           Tags = new[] { "CreditoEndpoint" })]
        public async override Task<ActionResult<Response<ActividadFlujoDto>>> HandleAsync(string request, CancellationToken cancellationToken = default)
        {
            return await this._actividadflujoBusinessLogic.EliminarActividadFlujoPorid(request);
        }
    }
}

