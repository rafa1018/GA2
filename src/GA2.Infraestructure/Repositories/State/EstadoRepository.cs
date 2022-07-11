using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data.State;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Repository de estado
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/202</date>
    /// </summary>
    public class EstadoRepository : DapperGenerycRepository, IEstadoRepository
    {
        public EstadoRepository(IConfiguration configuration) : base(configuration)
        {
        }
        /// <summary>
        /// Metodo Obtener Estado
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <returns></returns>
        public async Task<IEnumerable<Estado>> ObtenerEstados()
        {
            return await GetAsyncList<Estado>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }
        /// <summary>
        /// Metodo Crear Estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="estadoParametrization"></param>
        /// <returns></returns>
        public async Task<Estado> CrearEstado(Estado estadoParametrization)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.ID), estadoParametrization.EST_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.CODIGO), estadoParametrization.EST_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.CONCEPTO), estadoParametrization.EST_CONCEPTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.DIASMORAACTIVAESTADO), estadoParametrization.EST_DIAS_MORA_ACTIVA_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.SALDODEUDA), estadoParametrization.EST_SALDO_DEUDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.MODIFICADOPOR), estadoParametrization.EST_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.ESTADO), 1);

            return await GetAsyncFirst<Estado>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
        /// <summary>
        /// Metodo Actualizar Estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="estadoParametrization"></param>
        /// <returns></returns>
        public async Task<Estado> ActualizarEstado(Estado estadoParametrization)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.ID), estadoParametrization.EST_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.CODIGO), estadoParametrization.EST_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.CONCEPTO), estadoParametrization.EST_CONCEPTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.DIASMORAACTIVAESTADO), estadoParametrization.EST_DIAS_MORA_ACTIVA_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.SALDODEUDA), estadoParametrization.EST_SALDO_DEUDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.MODIFICADOPOR), estadoParametrization.EST_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.ESTADO), 1);

            return await GetAsyncFirst<Estado>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
        /// <summary>
        /// Metodo Eliminar Estado mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>20/04/202</date>
        /// <param name="estadoParametrization"></param>
        /// <returns></returns>
        public async Task<Estado> EliminarEstado(Estado estadoParametrization)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.ID), estadoParametrization.EST_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.CODIGO), estadoParametrization.EST_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.CONCEPTO), estadoParametrization.EST_CONCEPTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.DIASMORAACTIVAESTADO), estadoParametrization.EST_DIAS_MORA_ACTIVA_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.SALDODEUDA), estadoParametrization.EST_SALDO_DEUDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.MODIFICADOPOR), estadoParametrization.EST_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEstadoParameters.ESTADO), 1);

            return await GetAsyncFirst<Estado>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
