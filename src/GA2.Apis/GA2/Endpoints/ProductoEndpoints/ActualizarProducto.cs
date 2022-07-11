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
    /// Actualiza un Producto
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    [Authorize]
    public class ActualizarProducto : BaseAsyncEndpoint.WithRequest<ProductoDTO>.WithResponse<Response<ProductoDTO>>
    {


        private readonly IProductoBusinessLogic _productoBusinessLogic;
        /// <summary>
        /// Ctor e inyeccion dependencias
        /// </summary>
        /// <param name="productoBusinessLogic"></param>
        public ActualizarProducto(IProductoBusinessLogic productoBusinessLogic)
        {
            _productoBusinessLogic = productoBusinessLogic;
        }

        /// <summary>
        ///  Actualiza un producto
        /// </summary>
        /// <param name = "request" > Peticion usuario</param>
        /// <param name = "cancellationToken" > cancelacion si se desea</param>
        /// <returns>Usuario Creado</returns>
        //[ValidateAntiForgeryToken]
        [HttpPatch("api/producto")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<ProductoDTO>), StatusCodes.Status200OK)]
        [SwaggerOperation(
           Summary = "Actualiza un producto",
           Description = "Actualiza un producto",
           OperationId = "producto.update",
           Tags = new[] { "ProductosEndpoint" })]
        public async override Task<ActionResult<Response<ProductoDTO>>> HandleAsync(ProductoDTO request, CancellationToken cancellationToken = default)
        {
            return await this._productoBusinessLogic.ActualizarProducto(request);
        }
    }
}
