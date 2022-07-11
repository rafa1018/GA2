using GA2.Application.Dto;
using GA2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// lRepository de Mensaje
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>28/05/2021</date>
    /// </summary>
    public interface IMensajeRepository
    {
        /// <summary>
        /// Metodo Obtener Mensaje
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>28/05/2021</date>
        /// <returns>Lista de Mensaje</returns>
        Task<Mensaje> ObtenerMensaje(string CodigoMensaje);
    }
}
