using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Tareas businesslogic 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>17/08/2021</date>
    public interface ITareaBusinessLogic
    {
        /// <summary>
        /// Actualizar tarea
        /// </summary>
        /// <param name="tareaDto">Tarea a actualizar</param>
        /// <returns>Tarea actualizada</returns>
        Task<Response<TareaDto>> ActualizarTarea(TareaDto tareaDto);

        /// <summary>
        /// Crear Tarea
        /// </summary>
        /// <param name="tareaDto">Tarea dto</param>
        /// <returns>Tarea creada</returns>
        Task<Response<TareaDto>> CrearTarea(TareaDto tareaDto);

        /// <summary>
        /// Eliminar tareas por id
        /// </summary>
        /// <param name="tareaId">Tarea id</param>
        /// <returns>Tarea eliminada</returns>
        Task<Response<TareaDto>> EliminarTareasPorId(Guid tareaId);

        /// <summary>
        /// Obtener tareas por id
        /// </summary>
        /// <param name="tareaId">tarea id</param>
        /// <returns>Tarea obtenida</returns>
        Task<Response<TareaDto>> ObtenerTareasPorId(Guid tareaId);

        /// <summary>
        /// Obtener Tarea por proceso id
        /// </summary>
        /// <param name="procesoId">Proceso id</param>
        /// <returns>Tareas del proceso</returns>
        Task<Response<IReadOnlyList<TareaDto>>> ObtenerTareasPorProcesoId(Guid procesoId);

        /// <summary>
        /// Obtener todas las Tareas
        /// </summary>
        /// <returns>Lista de Tareas</returns>
        Task<Response<IEnumerable<TareaDto>>> ObtenerTareas();
    }
}