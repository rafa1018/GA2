using GA2.Domain.Entities;
using GA2.Domain.Entities.Bpm;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Tarea Repository
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/08/2021</date>
    public interface ITareaRepository
    {
        /// <summary>
        /// Actualizar Tarea
        /// </summary>
        /// <param name="tarea">Tarea model</param>
        /// <returns>Tarea actualizada</returns>
        Task<Tarea> ActualizarTarea(Tarea tarea);

        /// <summary>
        /// Crear Tarea
        /// </summary>
        /// <param name="tarea">Tarea model</param>
        /// <returns>Tarea creada</returns>
        Task<Tarea> CrearTarea(Tarea tarea);

        /// <summary>
        /// Eliminar Tarea
        /// </summary>
        /// <param name="tarea">Tarea model</param>
        /// <returns>Tarea eliminada</returns>
        Task<Tarea> EliminarTareaPorId(Guid tareaId);

        /// <summary>
        /// Obtener Tarea por id
        /// </summary>
        /// <param name="tareaId">Identificador de tareaId</param>
        /// <returns>Tarea</returns>
        Task<Tarea> ObtenerTareaPorId(Guid tareaId);

        /// <summary>
        /// Obtener  Tareas por proceso id
        /// </summary>
        /// <param name="tarea">Tareas model</param>
        /// <returns>Tareas list</returns>
        Task<IEnumerable<Tarea>> ObtenerTareasPorProcesoId(Guid procesoId);

        /// <summary>
        /// Obtener todas las Tareas
        /// </summary>
        /// <returns>Lista de Tareas</returns>
        Task<IEnumerable<Tarea>> ObtenerTareas();

        Task<IEnumerable<Domain.Entities.Bpm.EstadoTareaSolicitud>> ObtenerEstadoSolicitudTarea();
        Task<IEnumerable<Domain.Entities.Bpm.EstadoSolicitud>> ObtenerEstadoSolicitud();

    }
}