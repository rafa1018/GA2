using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// lRepository de Notificacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>17/05/2021</date>
    /// </summary>
    public interface INotificacionRepository
    {
        /// <summary>
        /// Metodo Obtener Notificacion
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>17/05/2021</date>
        /// <returns>Lista de Notificacion</returns>
        Task<IEnumerable<Notificacion>> ObtenerNotificaciones(Guid userId);
        /// <summary>
        /// Metodo Crear Notificacion mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>17/05/2021</date>
        /// <returns>Modelo Crear Notificacion</returns>
        Task<Notificacion> CrearNotificacion(Notificacion Notificacion);
        /// <summary>
        /// Metodo Actualizar Notificacion mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>17/05/2021</date>
        /// <returns>Modelo Actualizar Notificacion</returns>
        Task<Notificacion> ActualizarNotificacion(Notificacion Notificacion);
    }
}
