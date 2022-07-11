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
    public abstract class DapperGenerycWorkerRepository
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
        protected DapperGenerycWorkerRepository(IConfiguration configuration) => _configuration = configuration;

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
        public async Task<TOutput> ObtenerParametrosCargueNomina<TOutput>(
            string NameProcedureOrQueryString, DynamicParameters parameters, CommandType typeCommand) where TOutput : new()
        {
            try
            {
                using var connection = GetConnection(_configuration.GetConnectionString("connectionGA2"));
                var cmd = new CommandDefinition(NameProcedureOrQueryString, null, null, null, typeCommand);
                await connection.OpenAsync();
                if (parameters != null)
                    cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
                return await connection.QueryFirstOrDefaultAsync<TOutput>(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
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
        public async Task<TOutput> ObtenerBlobStoragePorId<TOutput>(
            string NameProcedureOrQueryString, DynamicParameters parameters, CommandType typeCommand) where TOutput : new()
        {
            try
            {
                using var connection = GetConnection(_configuration.GetConnectionString("connectionGA2"));
                var cmd = new CommandDefinition(NameProcedureOrQueryString, null, null, null, typeCommand);
                await connection.OpenAsync();
                if (parameters != null)
                    cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
                return await connection.QueryFirstOrDefaultAsync<TOutput>(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
        public async Task<IEnumerable<TOutput>> ValidarNominaAsync<TOutput>(string NameProcedureOrQueryString, DynamicParameters parameters, CommandType typeCommand) where TOutput : new()
        {
                using var connection = GetConnection(_configuration.GetConnectionString("connectionBUA"));
                var cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
                await connection.OpenAsync();
                if (parameters != null)
                    cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
                return await connection.QueryAsync<TOutput>(cmd);
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
        public async Task<IEnumerable<TOutput>> ObtenerDocumentosCarga<TOutput>(string NameProcedureOrQueryString, DynamicParameters parameters, CommandType typeCommand) where TOutput : new()
        {
            try
            {
                using var connection = GetConnection(_configuration.GetConnectionString("connectionGA2"));
                var cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
                await connection.OpenAsync();
                if (parameters != null)
                    cmd = new CommandDefinition(NameProcedureOrQueryString, parameters, null, null, typeCommand);
                return await connection.QueryAsync<TOutput>(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
        public async Task<IEnumerable<TOutput>> ParametrosCreacionCuentaAsync<TOutput>(
            string NameProcedureOrQueryString, DynamicParameters parameters, CommandType typeCommand, IsolationLevel isolation) where TOutput : new()
        {
            using var connection = GetConnection(_configuration.GetConnectionString("connectionBUA"));
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
