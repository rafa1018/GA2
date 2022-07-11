using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// ProcesoRepository
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/08/2021</date>
    public interface IProcesoRepository
    {
        /// <summary>
        /// /ActualizarProceso
        /// </summary>
        /// <param name="proceso">Proceso</param>
        /// <returns>Proceso Actualizado</returns>
        Task<Procesos> ActualizarProceso(Procesos proceso);

        /// <summary>
        /// Crear Proceso
        /// </summary>
        /// <param name="proceso">Proceso a crear</param>
        /// <returns>Proceso Creado</returns>
        Task<Procesos> CrearProceso(Procesos proceso);

        /// <summary>
        /// Eliminar proceso por id
        /// </summary>
        /// <param name="procesoId">Proceso id </param>
        /// <returns>Proceso eliminado</returns>
        Task<Procesos> EliminarProcesoProId(Guid procesoId);

        /// <summary>
        /// ObtenerProceso Por Id
        /// </summary>
        /// <param name="procesoId">Proceso id</param>
        /// <returns>Proceso solicitado</returns>
        Task<Procesos> ObtenerProcesoPorId(Guid procesoId);

        /// <summary>
        /// ObtenerProceso Todos los procesos
        /// </summary>
        /// <returns>Lista de Procesos</returns>
        Task<IEnumerable<Procesos>> ObtenerProcesos();
    }
}