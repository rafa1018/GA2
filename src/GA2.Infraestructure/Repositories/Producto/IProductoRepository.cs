using GA2.Domain.Entities;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Interfaz del repositorio de producto
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    public interface IProductoRepository
    {
        Task<Producto> CrearProducto(Producto producto);
        Task<Producto> ObtenerProductoByID(int id);
        Task<Producto> EliminarProducto(Producto producto);
        Task<Producto> ActualizarProducto(Producto producto);
    }
}