using GA2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public interface IRolRepository
    {
        /// <summary>
        /// Actualizar Rol
        /// </summary>
        /// <param name="rol">Rol a actualizar</param>
        /// <date>21/04/2021</date>
        ///<author>Oscar Julian Rojas</author>
        /// <returns>Rol Actualizado</returns>
        Task<Rol> ActualizarRol(Rol rol);
        /// <summary>
        /// Crear nuevo rol
        /// </summary>
        /// <param name="rol">Rol a crear</param>
        /// <returns>Rol Creado</returns>
        /// <auth>Oscar Julian Rojas</auth>
        /// <date>21/04/2021</date>
        Task<Rol> CrearRol(Rol rol);

        /// <summary>
        /// DeleteRol
        /// </summary>
        /// <param name="rol">Rol a eliminar</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Rol Eliminado</returns>
        Task<Rol> EliminarRol(Rol rol);

        /// <summary>
        /// Otener todos los roles
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Lista de roles</returns>
        Task<IEnumerable<Rol>> ObtenerRoles();

        /// <summary>
        /// Obtener Rol por id
        /// </summary>
        /// <param name="id">Id rol</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Rol consultado</returns>
        Task<Rol> ObtenerRolPorId(Guid id);
    }
}