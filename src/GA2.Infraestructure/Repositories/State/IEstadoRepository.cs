using GA2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// lRepository de estado
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/202</date>
    /// </summary>
    public interface IEstadoRepository
    {
        /// <summary>
        /// Metodo Obtener Estado
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Lista de Estado</returns>
        Task<IEnumerable<Estado>> ObtenerEstados();
        /// <summary>
        /// Metodo Crear Estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Crear Estado</returns>
        Task<Estado> CrearEstado(Estado Estado);
        /// <summary>
        /// Metodo Actualizar Estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Actualizar Estado</returns>
        Task<Estado> ActualizarEstado(Estado Estado);
        /// <summary>
        /// Metodo Eliminar Estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Eliminar Estado</returns>
        Task<Estado> EliminarEstado(Estado Estado);
    }
}
