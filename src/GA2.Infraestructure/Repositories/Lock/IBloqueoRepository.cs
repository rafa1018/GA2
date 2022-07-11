using GA2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// lRepository de Bloqueo
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public interface IBloqueoRepository
    {
        /// <summary>
        /// Metodo Obtener Bloqueo
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns>Lista de Bloqueo</returns>
        Task<IEnumerable<Bloqueo>> ObtenerBloqueos();
        /// <summary>
        /// Metodo Crear Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns>Modelo Crear Bloqueo</returns>
        Task<Bloqueo> CrearBloqueo(Bloqueo Bloqueo);
        /// <summary>
        /// Metodo Actualizar Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns>Modelo Actualizar Bloqueo</returns>
        Task<Bloqueo> ActualizarBloqueo(Bloqueo Bloqueo);
        /// <summary>
        /// Metodo Eliminar Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns>Modelo Eliminar Bloqueo</returns>
        Task<Bloqueo> EliminarBloqueo(Bloqueo Bloqueo);
    }
}
