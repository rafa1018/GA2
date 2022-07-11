using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// lBusinessLogic de estado
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/202</date>
    /// </summary>
    public interface IEstadoBusinessLogic
    {
        /// <summary>
        /// Metodo Obtener Estado
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Lista de Estado</returns>
        Task<Response<IEnumerable<EstadoDto>>> ObtenerEstado();
        /// <summary>
        /// Metodo Crear Estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Crear Estado</returns>
        Task<Response<EstadoDto>> CrearEstado(EstadoDto parametrizacionEstadoDto);
        /// <summary>
        /// Metodo Actualizar Estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Actualizar Estado</returns>
        Task<Response<EstadoDto>> ActualizarEstado(EstadoDto parametrizacionEstadoDto);
        /// <summary>
        /// Metodo Eliminar Estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns>Modelo Eliminar Estado</returns>
        Task<Response<EstadoDto>> EliminarEstado(EstadoDto parametrizacionEstadoDto);
    }
}
