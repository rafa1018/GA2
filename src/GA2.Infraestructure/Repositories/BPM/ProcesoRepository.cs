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
    /// ProcesoRepository
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/08/2021</date>
    public class ProcesoRepository : DapperGenerycRepository, IProcesoRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">Configuracion aplicacion</param>
        public ProcesoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Crear Proceso
        /// </summary>
        /// <param name="proceso">Proceso a crear</param>
        /// <returns>Proceso Creado</returns>
        public async Task<Procesos> CrearProceso(Procesos proceso)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PCS_ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PCS_NOMBRE), proceso.PCS_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PCS_DESCRIPCION), proceso.PCS_DESCRIPCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PCS_ESTADO), proceso.PCS_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PSC_CREATEDOPOR), proceso.PSC_CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PSC_FECHACREACION), proceso.PSC_FECHACREACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PSC_VERSION), proceso.PSC_VERSION);

            return await GetAsyncFirst<Procesos>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// /ActualizarProceso
        /// </summary>
        /// <param name="proceso">Proceso</param>
        /// <returns>Proceso Actualizado</returns>
        public async Task<Procesos> ActualizarProceso(Procesos proceso)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PCS_ID), proceso.PCS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PCS_NOMBRE), proceso.PCS_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PCS_DESCRIPCION), proceso.PCS_DESCRIPCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PCS_ESTADO), proceso.PCS_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PSC_MODIFICADOPOR), proceso.PSC_MODIFICADOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PSC_FECHAMODIFICACION), proceso.PSC_FECHAMODIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PSC_VERSION), proceso.PSC_VERSION);

            return await GetAsyncFirst<Procesos>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// ObtenerProceso Por Id
        /// </summary>
        /// <param name="procesoId">Proceso id</param>
        /// <returns>Proceso solicitado</returns>
        public async Task<Procesos> ObtenerProcesoPorId(Guid procesoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PCS_ID), procesoId);


            return await GetAsyncFirst<Procesos>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Eliminar proceso por id
        /// </summary>
        /// <param name="procesoId">Proceso id </param>
        /// <returns>Proceso eliminado</returns>
        public async Task<Procesos> EliminarProcesoProId(Guid procesoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProcesoParameter.PCS_ID), procesoId);

            return await GetAsyncFirst<Procesos>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }


        /// <summary>
        /// ObtenerProceso Todos los procesos
        /// </summary>
        /// <returns>Lista de Procesos</returns>
        public async Task<IEnumerable<Procesos>> ObtenerProcesos() {
            return await GetAsyncList<Procesos>(HelperDBParameters.BuilderFunction(
                     HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }
    }
}
