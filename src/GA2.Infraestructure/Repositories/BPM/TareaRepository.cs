
using Dapper;
using GA2.Domain.Entities;
using GA2.Domain.Entities.Bpm;
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
    /// Tarea Repository
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/08/2021</date>
    public class TareaRepository : DapperGenerycRepository, ITareaRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">configuration aplicacion</param>
        public TareaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Crear Tarea
        /// </summary>
        /// <param name="tarea">Tarea model</param>
        /// <returns>Tarea creada</returns>
        public async Task<Tarea> CrearTarea(Tarea tarea)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.PCS_ID), tarea.PCS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_NOMBRE), tarea.TRA_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_FECHAINICIO), tarea.TRA_FECHAINICIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_FECHAFIN), tarea.TRA_FECHAFIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_CIERRE_ESTIMADO), tarea.TRA_CIERRE_ESTIMADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.RL_ID_RESPONSABLE), tarea.RL_ID_RESPONSABLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_CREATEDOPOR), tarea.TRA_CREATEDOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_FECHACREACION), tarea.TRA_FECHACREACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_ID_ENTRADA), tarea.TRA_ID_ENTRADA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_ID_SALIDA), tarea.TRA_ID_SALIDA);

            return await GetAsyncFirst<Tarea>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Actualizar Tarea
        /// </summary>
        /// <param name="tarea">Tarea model</param>
        /// <returns>Tarea actualizada</returns>
        public async Task<Tarea> ActualizarTarea(Tarea tarea)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_ID), tarea.TRA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.PCS_ID), tarea.PCS_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_NOMBRE), tarea.TRA_NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_FECHAINICIO), tarea.TRA_FECHAINICIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_FECHAFIN), tarea.TRA_FECHAFIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_CIERRE_ESTIMADO), tarea.TRA_CIERRE_ESTIMADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.RL_ID_RESPONSABLE), tarea.RL_ID_RESPONSABLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_MODIFICADOPOR), tarea.TRA_MODIFICADOPOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_FECHAMODIFICACION), tarea.TRA_FECHAMODIFICACION);

            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_ID_ENTRADA), tarea.TRA_ID_ENTRADA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_ID_SALIDA), tarea.TRA_ID_SALIDA);

            return await GetAsyncFirst<Tarea>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener Tarea por id
        /// </summary>
        /// <param name="tareaId">Identificador de tareaId</param>
        /// <returns>Tarea</returns>
        public async Task<Tarea> ObtenerTareaPorId(Guid tareaId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_ID), tareaId);

            return await GetAsyncFirst<Tarea>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Eliminar Tarea
        /// </summary>
        /// <param name="tarea">Tarea model</param>
        /// <returns>Tarea eliminada</returns>
        public async Task<Tarea> EliminarTareaPorId(Guid tareaId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.TRA_ID), tareaId);

            return await GetAsyncFirst<Tarea>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener  Tareas por proceso id
        /// </summary>
        /// <param name="tarea">Tareas model</param>
        /// <returns>Tareas list</returns>
        public async Task<IEnumerable<Tarea>> ObtenerTareasPorProcesoId(Guid procesoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTareaParameter.PCS_ID), procesoId);

            return await GetAsyncList<Tarea>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Domain.Entities.Bpm.EstadoTareaSolicitud>> ObtenerEstadoSolicitudTarea()
        {

            return await GetAsyncList<Domain.Entities.Bpm.EstadoTareaSolicitud>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Domain.Entities.Bpm.EstadoSolicitud>> ObtenerEstadoSolicitud()
        {

            return await GetAsyncList<Domain.Entities.Bpm.EstadoSolicitud>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener todas las Tareas
        /// </summary>
        /// <returns>Lista de Tareas</returns>
        public async Task<IEnumerable<Tarea>> ObtenerTareas()
        {
            return await GetAsyncList<Tarea>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }
    }
}
