using Ardalis.ApiEndpoints;
using GA2.Application.Dto.Producto;
using GA2.Domain.Core;
using GA2.Transversals.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace GA2.Apis.GA2.Endpoints
{
    /// <summary>
    /// Obtiene un producto mediante el ID
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    [Authorize]
    public class ObtenerProductoByID : BaseAsyncEndpoint.WithRequest<int>.WithResponse<Response<ProductoDTO>>
    {
        private readonly IProductoBusinessLogic _productoBusinessLogic;
        /// <summary>
        /// Ctor e inyeccion dependencias
        /// </summary>
        /// <param name="productoBusinessLogic"></param>
        public ObtenerProductoByID(IProductoBusinessLogic productoBusinessLogic)
        {
            _productoBusinessLogic = productoBusinessLogic;
        }

        /// <summary>
        ///  Obtiene un producto por su id
        /// </summary>
        /// <param name = "request" > Peticion usuario</param>
        /// <param name = "cancellationToken" > cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        [HttpGet("api/producto")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProductoDTO>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Buscar un producto",
           Description = "Buscar un producto",
           OperationId = "producto.get",
           Tags = new[] { "ProductosEndpoint" })]
        public async override Task<ActionResult<Response<ProductoDTO>>> HandleAsync(int request, CancellationToken cancellationToken = default)
        {
            return await this._productoBusinessLogic.ObtenerProductoByID(request);
        }
    }
}
