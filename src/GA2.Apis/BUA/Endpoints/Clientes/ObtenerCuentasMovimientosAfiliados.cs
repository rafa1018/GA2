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

namespace GA2.Apis.BUA.Endpoints
{
    /// <summary>
    /// Endpoint que actualiza los datos de usuario
    /// <author>Nicolas Florez Sarrazola</author>
    /// </summary>
    [Authorize]
    public class ObtenerCuentasMovimientosAfiliados : BaseAsyncEndpoint.WithRequest<string>.WithResponse<Response<IEnumerable<CuentaAfiliadoDTO>>>
    {
        private readonly IClientesBusinessLogic _clientsBusinessLogic;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="clientsBusinessLogic"></param>
        public ObtenerCuentasMovimientosAfiliados(IClientesBusinessLogic clientsBusinessLogic)
        {
            _clientsBusinessLogic = clientsBusinessLogic;
        }

        /// <summary>
        /// Update client info
        /// </summary>
        /// <param name="identificacion"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        //[ValidateAntiForgeryToken]
        [HttpGet("api/clientes/obtenerCuentasMovimientosAfiliado")]
        [ProducesResponseType(typeof(Response<CuentaAfiliadoDTO>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Obtiene el resumen de cuentas de un afiliado",
           Description = "Obtiene el resumen de cuentas de un afiliado",
           OperationId = "client.obtenerCuentasMovimientosAfiliado",
           Tags = new[] { "ClientEndpoint" })]
        public async override Task<ActionResult<Response<IEnumerable<CuentaAfiliadoDTO>>>> HandleAsync(string identificacion, CancellationToken cancellationToken = default)
        {
            return await _clientsBusinessLogic.ObtenerCuentasMovimientosAfiliado(identificacion);
        }
    }
}

