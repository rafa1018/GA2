using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Interface ILogErrorRepository
    /// </summary>
    public class LogErrorRepository : DapperGenerycRepository, ILogErrorRepository
    {
        /// <summary>
        /// Instance Inyeccion Configuracion
        /// </summary>
        /// <param name="configuration">Configuracion aplicacion Api</param>
        public LogErrorRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// CreateLog Error Insert
        /// </summary>
        /// <param name="error">Error reportado por el middleware</param>
        /// <author>Oscar Julian Rojas Garces</author>
        /// <date>22/02/2021</date>
        /// <returns>Response Error</returns>
        public async Task<ERRORRESPONSE> CreateLogError(ERRORRESPONSE error)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLogErrorParameters.LogErrorId), error.LOGERRORID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLogErrorParameters.CLIENT_ID), error.CLIENTID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLogErrorParameters.MESSAGE), error.MESSAGE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLogErrorParameters.CONTROLLER_NAME), error.CONTROLLERNAME);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLogErrorParameters.ACTION_NAME), error.ACTIONNAME!=null?error.ACTIONNAME:"");
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLogErrorParameters.STACK_TRACE), error.STACKTRACE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLogErrorParameters.ERROR_CODE), error.ERRORCODE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLogErrorParameters.REQUEST_IP), error.REQUESTIP != null ? error.REQUESTIP : "");
            parameters.Add(HelpersEnums.GetEnumDescription(EnumLogErrorParameters.LOG_DATE), error.LOGDATE);

            try
            {
                return await GetAsyncFirst<ERRORRESPONSE>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}