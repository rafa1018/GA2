using GA2.Application.Dto.Producto;
using GA2.Transversals.Commons;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Interfaz que expone metodos de logica de negocio para Producto
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public interface IProductoBusinessLogic
    {
        Task<Response<ProductoDTO>> CrearProducto(ProductoDTO producto);
        Task<Response<ProductoDTO>> ObtenerProductoByID(int id);
        Task<Response<ProductoDTO>> EliminarProducto(int id);
        Task<Response<ProductoDTO>> ActualizarProducto(ProductoDTO producto);
    }
}