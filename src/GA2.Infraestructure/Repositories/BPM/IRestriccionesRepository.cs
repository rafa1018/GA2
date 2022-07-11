using GA2.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Restricciones respotiry
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>17/08/2021</date>
    public interface IRestriccionesRepository
    {
        /// <summary>
        /// ActualizarRestricciones
        /// </summary>
        /// <param name="restricciones">Restriccion a actualizar</param>
        /// <returns>Restriccion actualizado</returns>
        Task<Restricciones> ActualizarRestricciones(Restricciones restricciones);

        /// <summary>
        /// Crear Restricciones 
        /// </summary>
        /// <param name="restricciones">Restriccion model</param>
        /// <returns>Restriccion creada</returns>
        Task<Restricciones> CrearRestricciones(Restricciones restricciones);

        /// <summary>
        /// EliminarRestricciones
        /// </summary>
        /// <param name="restriccionesId">Id de restriccion</param>
        /// <returns>Restriccion eliminado</returns>
        Task<Restricciones> EliminarRestricciones(Guid restriccionesId);

        /// <summary>
        /// ObtenerRestriccion id
        /// </summary>
        /// <param name="restriccionesId">restriccion id </param>
        /// <returns>restriccion</returns>
        Task<Restricciones> ObtenerRestriccionesId(Guid restriccionesId);
    }
}