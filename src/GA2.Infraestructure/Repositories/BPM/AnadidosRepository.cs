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
    /// Anaddido Repository Implementacion
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>13/08/2021</date>
    public class AnadidosRepository : DapperGenerycRepository, IAnadidosRepository
    {
        /// <summary>
        /// AnadidoRepository
        /// </summary>
        /// <param name="configuration">Configuration application</param>
        public AnadidosRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Crear Anadido
        /// </summary>
        /// <param name="anadido">Anadido model</param>
        /// <returns>Anadido creado</returns>
        public async Task<Anadidos> CrearAnidados(Anadidos anadido)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.TRA_ID), anadido.TRA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_NOMBREANADIDO), anadido.AND_NOMBREANADIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_FILE), anadido.AND_FILE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_TIPO), anadido.AND_TIPO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_CREATEDOPOR), anadido.AND_CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_FECHACREACION), anadido.AND_FECHACREACION);

            return await GetAsyncFirst<Anadidos>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// ActualizarAnadido
        /// </summary>
        /// <param name="anadido">anaddido a actualizar</param>
        /// <returns>Anadido actualizar</returns>
        public async Task<Anadidos> ActualizarAnidados(Anadidos anadido)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_ID), anadido.AND_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.TRA_ID), anadido.TRA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_NOMBREANADIDO), anadido.AND_NOMBREANADIDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_FILE), anadido.AND_FILE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_TIPO), anadido.AND_TIPO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_MODIFICADOPOR), anadido.AND_MODIFICADOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_FECHAMODIFICACION), anadido.AND_FECHAMODIFICACION);

            return await GetAsyncFirst<Anadidos>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener Anadido por Id
        /// </summary>
        /// <param name="anadidoId">AnadidoId </param>
        /// <returns>Anadido pedido</returns>
        public async Task<Anadidos> ObtenerAnadidoPorId(Guid anadidoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_ID), anadidoId);

            return await GetAsyncFirst<Anadidos>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerAnadidosPorTareaId
        /// </summary>
        /// <param name="tareaId">Tarea Id</param>
        /// <returns>Lista de Anadidos</returns>
        public async Task<IEnumerable<Anadidos>> ObtenerAnadidosPorTareaId(Guid tareaId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.TRA_ID), tareaId);

            return await GetAsyncList<Anadidos>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// eliminar anadido por id
        /// </summary>
        /// <param name="anadidoId">Anadido id</param>
        /// <returns>Anadido eliminado</returns>
        public async Task<Anadidos> EliminarAnadidos(Guid anadidoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAnadidosParameter.AND_ID), anadidoId);

            return await GetAsyncFirst<Anadidos>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
