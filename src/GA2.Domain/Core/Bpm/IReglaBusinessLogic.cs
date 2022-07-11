using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Regla business logic
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>17/08/2021</date>
    public interface IReglaBusinessLogic
    {
        /// <summary>
        /// Actualizar reglas
        /// </summary>
        /// <param name="reglaDto">regla a actualizar</param>
        /// <returns>regla actualizada</returns>
        Task<Response<ReglasDto>> ActualizarReglas(ReglasDto reglaDto);

        /// <summary>
        /// Obtener regla por id
        /// </summary>
        /// <param name="reglaDtoId"></param>
        /// <returns></returns>
        Task<Response<ReglasDto>> ObtenerReglasPorId(Guid reglaDtoId);

        /// <summary>
        /// Crear Reglas
        /// </summary>
        /// <param name="reglaDto">Regla a crear</param>
        /// <returns>Regla creada</returns>
        Task<Response<ReglasDto>> CrearReglas(ReglasDto reglaDto);

        /// <summary>
        /// Eliminar regla por id
        /// </summary>
        /// <param name="reglaDtoId">regla id a eliminar</param>
        /// <returns>Regla eliminada</returns>
        Task<Response<ReglasDto>> EliminarRegla(Guid reglaDtoId);
    }
}