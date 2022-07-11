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
    /// Login G2 Users
    /// </summary>
    public class LoginGA2Repository : DapperGenerycRepository, ILoginGA2Repository
    {
        /// <summary>
        /// Constructor Login GA2 https://chordify.net/
        /// </summary>
        /// <param name="configuration">Configuracion aplicacion</param>
        /// <author>Oscar  Julian Rojas</author>
        /// <date>25/03/2021</date>
        public LoginGA2Repository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Login User 
        /// </summary>
        /// <param name="user">User submite login</param>
        /// <returns>User searched </returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>25/03/2021</date>
        public Task<User> LoginUser(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUsersParameters.USR_EMAIL), user.USR_EMAIL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUsersParameters.USR_USERNAME), user.USR_USERNAME);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUsersParameters.USR_PASSWORD), user.USR_PASSWORD);

            return GetAsyncFirst<User>(HelperDBParameters.BuilderFunction( HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public Task<User> LoginPaaUser(Cliente cliente)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.TID_ID), cliente.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_IDENTIFICACION), cliente.CLI_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.CLI_FECHA_EXPEDICION), cliente.CLI_FECHA_EXPEDICION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientParameters.DTL_TELEFONO), cliente.DTL_TELEFONO);

            return GetAsyncFirst<User>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public Task<IEnumerable<Menu>> ObtenerMenu()
        {
            return GetAsyncList<Menu>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public Task<IEnumerable<SubMenu>> ObtenerSubmenu()
        {
            return GetAsyncList<SubMenu>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }


        public Task<User> RecuperaContrasena(string tipo,string numero)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUsersParameters.TID_ID), tipo);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUsersParameters.USR_IDENTIFICACION), numero);

            return GetAsyncFirst<User>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
         
        }

        public Task<User> ActualizaTokenUser(Guid idUser, string token)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUsersParameters.USR_ID), idUser);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUsersParameters.TOKEN), token);

            return GetAsyncFirst<User>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }


        public async Task<User> ValidaTokenRestablecimiento(string token)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUsersParameters.TOKEN), token);
            return await GetAsyncFirst<User>("SELECT * FROM USR_USERS WHERE TOKEN=@TOKEN", parameters, CommandType.Text);
         
        }

        public async Task<IEnumerable<GrupoOpciones>> ObtenerOpcionesUsuariosById(Guid id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUsersParameters.USR_ID), id);
            return await GetAsyncList<GrupoOpciones>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }
    }
}
