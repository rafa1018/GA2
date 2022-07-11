using GA2.Application.Dto;
using GA2.Transversals.Commons;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Domain.Core
{
    /// <summary>
    /// lBusinessLogic de Bloqueo
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public interface IBloqueoBusinessLogic
    {
        /// <summary>
        /// Metodo Obtener Bloqueo
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns>Lista de Bloqueo</returns>
        Task<Response<IEnumerable<BloqueoDto>>> ObtenerBloqueoAsync();
        /// <summary>
        /// Metodo Crear Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns>Modelo Crear Bloqueo</returns>
        Task<Response<BloqueoDto>> CrearBloqueo(BloqueoDto parametrizacionBloqueoDto);
        /// <summary>
        /// Metodo Actualizar Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns>Modelo Actualizar Bloqueo</returns>
        Task<Response<BloqueoDto>> ActualizarBloqueo(BloqueoDto parametrizacionBloqueoDto);
        /// <summary>
        /// Metodo Eliminar Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/2021</date>
        /// <returns>Modelo Eliminar Bloqueo</returns>
        Task<Response<BloqueoDto>> EliminarBloqueo(BloqueoDto parametrizacionBloqueoDto);
    }
}