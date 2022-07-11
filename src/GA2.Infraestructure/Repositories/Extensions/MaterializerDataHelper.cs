using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using static GA2.Transversals.Commons.HelpersEnums;

namespace GA2.Infraestructure.Repositories
{

    /// <summary>
    /// Helper de parametros sql
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>18/02/2021</date>
    public static class HelperDBParameters
    {

        /// <summary>
        /// Asigna un nuevo parametro sql
        /// </summary>
        /// <param name="ParameterName">Nombre del parametro</param>
        /// <param name="value">valor parametro</param>
        /// <param name="type">Tipo de parametro</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/02/2021</date>
        /// <returns>Parametro Sql</returns>
        public static SqlParameter NewParameter(string ParameterName, object value, SqlDbType type)
        {
            return new SqlParameter
            {
                ParameterName = ParameterName,
                SqlValue = value ?? DBNull.Value,
                SqlDbType = type
            };
        }

        /// <summary>
        /// Constructor de consulta si se expecifica un schema de base de datos
        /// </summary>
        /// <param name="squema">Schema de base datos</param>
        /// <param name="name">Nombre procedimiento o funcion de base datos</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/02/2021</date>
        /// <returns>Nombre del procedimiento o funcion con el schema especificado</returns>
        public static string BuilderFunction(EnumSchemas squema, [System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return squema switch
                {
                    EnumSchemas.DBO => $"{GetEnumDescription(EnumSchemas.DBO)}.{name}",
                    EnumSchemas.SETTING => $"{GetEnumDescription(EnumSchemas.SETTING)}.{name}",
                    EnumSchemas.SECURITY => $"{GetEnumDescription(EnumSchemas.SECURITY)}.{name}",

                    _ => name,
                };
            }
            else
                return name;
        }

        /// <summary>
        /// Enumeracion de Schemas de base de datos
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/02/2021</date>
        public enum EnumSchemas
        {
            [Description("dbo")]
            DBO,

            [Description("setting")]
            SETTING,

            [Description("security")]
            SECURITY
        }
    }
}
