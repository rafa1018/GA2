using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Anaddido Repository Implementacion
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>13/08/2021</date>
    public interface IAnadidosRepository
    {
        /// <summary>
        /// ActualizarAnadido
        /// </summary>
        /// <param name="anadido">anaddido a actualizar</param>
        /// <returns>Anadido actualizar</returns>
        Task<Anadidos> ActualizarAnidados(Anadidos anadido);

        /// <summary>
        /// Crear Anadido
        /// </summary>
        /// <param name="anadido">Anadido model</param>
        /// <returns>Anadido creado</returns>
        Task<Anadidos> CrearAnidados(Anadidos anadido);

        /// <summary>
        /// eliminar anadido por id
        /// </summary>
        /// <param name="anadidoId">Anadido id</param>
        /// <returns>Anadido eliminado</returns>
        Task<Anadidos> EliminarAnadidos(Guid anadidoId);

        /// <summary>
        /// Obtener Anadido por Id
        /// </summary>
        /// <param name="anadidoId">AnadidoId </param>
        /// <returns>Anadido pedido</returns>
        Task<Anadidos> ObtenerAnadidoPorId(Guid anadidoId);

        /// <summary>
        /// ObtenerAnadidosPorTareaId
        /// </summary>
        /// <param name="tareaId">Tarea Id</param>
        /// <returns>Lista de Anadidos</returns>
        Task<IEnumerable<Anadidos>> ObtenerAnadidosPorTareaId(Guid tareaId);
    }
}