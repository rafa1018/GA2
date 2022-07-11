using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Rol Repository Aplicacion
    /// </summary>
    /// <auth>Oscar Julian Rojas</auth>
    /// <date>21/04/2021</date>
    public class RolRepository : DapperGenerycRepository, IRolRepository
    {
        /// <summary>
        /// Constructor Rol Repository
        /// </summary>
        /// <param name="configuration">Configuracion Aplicación</param>
        /// <auth>Oscar Julian Rojas</auth>
        /// <date>21/04/2021</date>
        public RolRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Crear nuevo rol
        /// </summary>
        /// <param name="rol">Rol a crear</param>
        /// <returns>Rol Creado</returns>
        /// <auth>Oscar Julian Rojas</auth>
        /// <date>21/04/2021</date>
        public async Task<Rol> CrearRol(Rol rol)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_DESCRIPCION), rol.RL_DESCRIPCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_CREADOPOR), rol.RL_CREADOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_FECHACREACION), rol.RL_FECHACREACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_ESTADO), rol.RL_ESTADO);

            return await GetAsyncFirst<Rol>(QueryRol.QueryInsert, parameters, CommandType.Text);
        }

        /// <summary>
        /// Actualizar Rol
        /// </summary>
        /// <param name="rol">Rol a actualizar</param>
        /// <date>21/04/2021</date>
        ///<author>Oscar Julian Rojas</author>
        /// <returns>Rol Actualizado</returns>
        public async Task<Rol> ActualizarRol(Rol rol)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_ID), rol.RL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_DESCRIPCION), rol.RL_DESCRIPCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_MODIFICADOPOR), rol.RL_MODIFICADOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_FECHAMODIFICACION), rol.RL_FECHAMODIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_ESTADO), rol.RL_ESTADO);

            return await GetAsyncFirst<Rol>(QueryRol.QueryUpdate, parameters, CommandType.Text);
        }

        /// <summary>
        /// DeleteRol
        /// </summary>
        /// <param name="rol">Rol a eliminar</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Rol Eliminado</returns>
        public async Task<Rol> EliminarRol(Rol rol)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_ID), rol.RL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_ESTADO), rol.RL_ESTADO);

            return await GetAsyncFirst<Rol>(QueryRol.QueryDelete, parameters, CommandType.Text);
        }

        /// <summary>
        /// Otener todos los roles
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Lista de roles</returns>
        public async Task<IEnumerable<Rol>> ObtenerRoles()
        {
            return await GetAsyncList<Rol>(QueryRol.QueryGet, null, CommandType.Text);
        }

        /// <summary>
        /// Obtener Rol por id
        /// </summary>
        /// <param name="id">Id rol</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/04/2021</date>
        /// <returns>Rol consultado</returns>
        public async Task<Rol> ObtenerRolPorId(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRolParameters.RL_ID), id);
            return await GetAsyncFirst<Rol>(QueryRol.QueryGet, parameters, CommandType.Text);
        }
    }
}
