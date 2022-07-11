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
    /// Restricciones respotiry
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>17/08/2021</date>
    public class RestriccionesRepository : DapperGenerycRepository, IRestriccionesRepository
    {
        /// <summary>
        /// Restricciones Constructor
        /// </summary>
        /// <param name="configuration">Configuration application</param>
        public RestriccionesRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Crear Restricciones 
        /// </summary>
        /// <param name="restricciones">Restriccion model</param>
        /// <returns>Restriccion creada</returns>
        public async Task<Restricciones> CrearRestricciones(Restricciones restricciones)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.RTC_ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.TRA_ID), restricciones.TRA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.RTC_NOMBRE), restricciones.RTC_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.TRA_ID_RESTRICCION), restricciones.TRA_ID_RESTRICCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.RTC_CREATEDOPOR), restricciones.RTC_CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.RTC_FECHACREACION), restricciones.RTC_FECHACREACION);

            return await GetAsyncFirst<Restricciones>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// ActualizarRestricciones
        /// </summary>
        /// <param name="restricciones">Restriccion a actualizar</param>
        /// <returns>Restriccion actualizado</returns>
        public async Task<Restricciones> ActualizarRestricciones(Restricciones restricciones)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.RTC_ID), restricciones.RTC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.TRA_ID), restricciones.TRA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.RTC_NOMBRE), restricciones.RTC_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.TRA_ID_RESTRICCION), restricciones.TRA_ID_RESTRICCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.RTC_CREATEDOPOR), restricciones.RTC_CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.RTC_FECHACREACION), restricciones.RTC_FECHACREACION);

            return await GetAsyncFirst<Restricciones>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// EliminarRestricciones
        /// </summary>
        /// <param name="restriccionesId">Id de restriccion</param>
        /// <returns>Restriccion eliminado</returns>
        public async Task<Restricciones> EliminarRestricciones(Guid restriccionesId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.RTC_ID), restriccionesId);

            return await GetAsyncFirst<Restricciones>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerRestriccion id
        /// </summary>
        /// <param name="restriccionesId">restriccion id </param>
        /// <returns>restriccion</returns>
        public async Task<Restricciones> ObtenerRestriccionesId(Guid restriccionesId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumRestriccionesParameters.RTC_ID), restriccionesId);

            return await GetAsyncFirst<Restricciones>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
