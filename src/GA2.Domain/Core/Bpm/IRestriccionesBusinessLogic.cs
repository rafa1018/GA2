using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// Restriccion BusinessLogic
    /// </summary>
    /// <author>Oscar Julain Rojas</author>
    /// <date>17/08/2021</date>
    public interface IRestriccionesBusinessLogic
    {
        /// <summary>
        /// ActualizarRestricciones 
        /// </summary>
        /// <param name="restriccionesDto">Restricciones a actualizar</param>
        /// <returns>Actualizar Restricciones</returns>
        Task<Response<RestriccionesDto>> ActualizarRestricciones(RestriccionesDto restriccionesDto);

        /// <summary>
        /// Crear Restricciones 
        /// </summary>
        /// <param name="restriccionesDto">Restricciones a crear</param>
        /// <returns>Restricciones Creadas</returns>
        Task<Response<RestriccionesDto>> CreateRestricciones(RestriccionesDto restriccionesDto);

        /// <summary>
        /// Eliminar restricciones por id
        /// </summary>
        /// <param name="restriccionesDtoId">restricciones id</param>
        /// <returns>restriccioens eliminado</returns>
        Task<Response<RestriccionesDto>> EliminarRestriccionesPorId(Guid restriccionesDtoId);

        /// <summary>
        /// Obtener restricciones id
        /// </summary>
        /// <param name="restriccionesDtoId">restricciones Id</param>
        /// <returns>restricciones obtenida</returns>
        Task<Response<RestriccionesDto>> ObtenerRestriccionesPorId(Guid restriccionesDtoId);
    }
}