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
    /// Reglas Repository
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    public class ReglasRepository : DapperGenerycRepository, IReglasRepository
    {
        public ReglasRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Crear Reglas
        /// </summary>
        /// <param name="regla">Regla a crear</param>
        /// <returns>Regla creada</returns>
        public async Task<Reglas> CrearReglas(Reglas regla)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.TRA_ID), regla.TRA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_NOMBRE), regla.RGL_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_CUMPLEREGLA), regla.RGL_CUMPLEREGLA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_CREATEDOPOR), regla.RGL_CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_FECHACREACION), regla.RGL_FECHACREACION);

            return await GetAsyncFirst<Reglas>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Actualizar Reglas
        /// </summary>
        /// <param name="regla">Actualizar reglas</param>
        /// <returns>Regla actualizada</returns>
        public async Task<Reglas> ActualizarReglas(Reglas regla)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.TRA_ID), regla.TRA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_NOMBRE), regla.RGL_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_CUMPLEREGLA), regla.RGL_CUMPLEREGLA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_MODIFICADOPOR), regla.RGL_MODIFICADOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_FECHAMODIFICACION), regla.RGL_FECHAMODIFICACION);

            return await GetAsyncFirst<Reglas>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener reglas por id
        /// </summary>
        /// <param name="reglaId">Id regla</param>
        /// <returns>Regla especificada</returns>
        public async Task<Reglas> ObtenerReglasPorId(Guid reglaId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_ID), reglaId);

            return await GetAsyncFirst<Reglas>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Eliminar reglas por id
        /// </summary>
        /// <param name="reglaId">regla id</param>
        /// <returns>Regla eliminada</returns>
        public async Task<Reglas> EliminarReglasPorId(Guid reglaId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumReglasParameters.RGL_ID), reglaId);

            return await GetAsyncFirst<Reglas>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
