using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Repositorio Generico para Dapper 
    /// </summary>
    /// <author>Oscar Julian Rojas </author>
    /// <date>18/02/2021</date>
    public abstract class DapperGenerycRepository
    {
        /// <summary>
        /// Configuration App
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/02/2021</date>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">IConfiguration</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/02/2021</date>
        protected DapperGenerycRepository(IConfiguration configuration) => this._configuration = configuration;

        /// <summary>
        /// Obtener conexion de base datos
        /// </summary>
        /// <param name="dbConnection">Cadena de conexion</param>
        /// <returns>Instancia de conexion a base datos</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/02/2021</date>
        private SqlConnection GetConnection(string dbConnection) => new SqlConnection(dbConnection);

        /// <summary>
        /// Obtiene el primer elemento que arroje la consulta a la base datos
        /// </summary>
        /// <typeparam name="TOutput">Modelo en el que se casteara el resultado</typeparam>
        /// <param name="NameProcedureOrQueryString">Nombre del procedimiento o funcion</param>
        /// <param name="parameters">Parametros para realizar la consutla</param>
        /// <param name="typeCommand">Tipo de commando envido a ejectutar</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/02/2021</date>
        /// <returns>Modelo consultado</returns>
        public async Task<TOutput> GetAsyncFirst<TOutput>(
            string NameProcedureOrQueryString, DynamicParameters parameters, CommandType typeCommand) where TOutput : new()
        {
            using var connection = GetConnection(this._configuration.GetConnectionString("connectionName"));
            var cmd = new CommandDefinition(NameProcedureOrQueryString, null, null, null, typeCommand);
            await connection.OpenAsync();
            if (parameters != null)
                cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
            var retorno= await connection.QueryFirstOrDefaultAsync<TOutput>(cmd);
            return retorno;
        }

        /// <summary>
        /// Dapper using lists
        /// </summary>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="NameProcedureOrQueryString"></param>
        /// <param name="parameters"></param>
        /// <param name="typeCommand"></param>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>26/03/2021</date>
        /// <returns>Get result transaction</returns>
        public async Task<IEnumerable<TOutput>> GetAsyncList<TOutput>(string NameProcedureOrQueryString, DynamicParameters parameters, CommandType typeCommand) where TOutput : new()
        {
            using var connection = GetConnection(this._configuration.GetConnectionString("connectionName"));
            var cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
            await connection.OpenAsync();
            if (parameters != null)
                cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
            return await connection.QueryAsync<TOutput>(cmd);
        }

        /// <summary>
        /// Dapper using transaction querys or procedures
        /// </summary>
        /// <typeparam name="TOutput">Salida de la transaccion</typeparam>
        /// <param name="NameProcedureOrQueryString">Query string</param>
        /// <param name="parameters">parameters querys</param>
        /// <param name="typeCommand">type process querys</param>
        /// <param name="isolation">isolation transaction</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>26/03/2021</date>
        /// <returns>Get result transaction</returns>
        public async Task<IEnumerable<TOutput>> GetAsyncTransaction<TOutput>(
            string NameProcedureOrQueryString, DynamicParameters parameters, CommandType typeCommand, IsolationLevel isolation) where TOutput : new()
        {
            using var connection = GetConnection(this._configuration.GetConnectionString("connectionName"));
            await connection.OpenAsync();
            using var transaction = await connection.BeginTransactionAsync(isolation);
            try
            {
                var result = await connection.QueryAsync<TOutput>(NameProcedureOrQueryString, parameters, transaction, null, typeCommand);
                await transaction.CommitAsync();
                await transaction.DisposeAsync();
                return result;
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                await transaction.DisposeAsync();
                throw new Exception(e.Message);
            }
        }
    }
}
