using GA2.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Reglas Repository
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public interface IReglasRepository
    {
        /// <summary>
        /// Actualizar Reglas
        /// </summary>
        /// <param name="regla">Actualizar reglas</param>
        /// <returns>Regla actualizada</returns>
        Task<Reglas> ActualizarReglas(Reglas regla);

        /// <summary>
        /// Crear Reglas
        /// </summary>
        /// <param name="regla">Regla a crear</param>
        /// <returns>Regla creada</returns>
        Task<Reglas> CrearReglas(Reglas regla);

        /// <summary>
        /// Eliminar reglas por id
        /// </summary>
        /// <param name="reglaId">regla id</param>
        /// <returns>Regla eliminada</returns>
        Task<Reglas> EliminarReglasPorId(Guid reglaId);

        /// <summary>
        /// Obtener reglas por id
        /// </summary>
        /// <param name="reglaId">Id regla</param>
        /// <returns>Regla especificada</returns>
        Task<Reglas> ObtenerReglasPorId(Guid reglaId);
    }
}