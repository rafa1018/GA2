using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Anadidos business logic
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>17/08/2021</date>
    public interface IAnadidosBusinessLogic
    {
        /// <summary>
        /// Actualizar analizado
        /// </summary>
        /// <param name="anadidoDto">anadido a actualizar</param>
        /// <returns>anadido actualizado</returns>
        Task<Response<AnadidosDto>> ActualizarAnadido(AnadidosDto anadidoDto);

        /// <summary>
        /// Crear anadido 
        /// </summary>
        /// <param name="anadidoDto">anadido a crear</param>
        /// <returns>anadido creado</returns>
        Task<Response<AnadidosDto>> CrearAnadido(AnadidosDto anadidoDto);
        /// <summary>
        /// Obtener anadido por id
        /// </summary>
        /// <param name="anadidoId">anadido id</param>
        /// <returns>anandido obtenido</returns>
        Task<Response<AnadidosDto>> ObtenerAnadidosPorId(Guid anadidoId);

        /// <summary>
        /// Obtener por tarea id
        /// </summary>
        /// <param name="tareaId">Tarea id</param>
        /// <returns>Anadidos por tarea</returns>
        Task<Response<AnadidosDto>> ObtenerAnadidosPorTareaId(Guid tareaId);

        /// <summary>
        /// Eliminar anadido por id
        /// </summary>
        /// <param name="anadidoId">anadido id</param>
        /// <returns>anandido eliminado</returns>
        Task<Response<AnadidosDto>> EliminarAnadidosPorId(Guid anadidoId);
    }
}