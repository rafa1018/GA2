using GA2.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IFormularioRepository
    {

        /// <summary>
        /// ActualizarFormulario
        /// </summary>
        /// <param name="formulario"></param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Formulario Actualizado</returns>
        Task<Formulario> ActualizarFormulario(Formulario formulario);

        /// <summary>
        /// Crear Formulario
        /// </summary>
        /// <param name="formulario"></param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>formulario Creado</returns>
        Task<Formulario> CrearFormulario(Formulario formulario);

        /// <summary>
        /// ObtenerFormularioPorId
        /// </summary>
        /// <param name="formulario"></param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Formulio por id</returns>
        Task<Formulario> ObtenerFormularioPorId(Formulario formulario);

        /// <summary>
        /// ObtenerFormularios
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Obteniene los formulario </returns>
        Task<IEnumerable<Formulario>> ObtenerFormularios();
    }
}