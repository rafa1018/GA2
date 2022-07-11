using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data.Lock;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Repository de Bloqueo
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>17/05/2021</date>
    /// </summary>
    public class BloqueoRepository : DapperGenerycRepository, IBloqueoRepository
    {
        public BloqueoRepository(IConfiguration configuration) : base(configuration)
        {
        }
        /// <summary>
        /// Metodo Obtener Bloqueo
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>17/05/2021</date>
        /// <returns></returns>
        public async Task<IEnumerable<Bloqueo>> ObtenerBloqueos()
        {
            return await GetAsyncList<Bloqueo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }
        /// <summary>
        /// Metodo Crear Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>17/05/2021</date>
        /// <param name="BloqueoParametrization"></param>
        /// <returns></returns>
        public async Task<Bloqueo> CrearBloqueo(Bloqueo BloqueoParametrization)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.ID), BloqueoParametrization.MOD_B_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.CODIGO), BloqueoParametrization.MOD_B_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.CONCEPTO), BloqueoParametrization.MOD_B_CONCEPTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.DIASMORA), BloqueoParametrization.MOD_B_DIAS_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.REVERSIBLE), BloqueoParametrization.MOD_B_REVERSIBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.ACELERACIONDEUDA), BloqueoParametrization.MOD_B_ACELERACION_DEUDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.MODIFICADOPOR), BloqueoParametrization.MOD_B_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.ESTADO), 1);

            return await GetAsyncFirst<Bloqueo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
        /// <summary>
        /// Metodo Actualizar Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>17/05/2021</date>
        /// <param name="BloqueoParametrization"></param>
        /// <returns></returns>
        public async Task<Bloqueo> ActualizarBloqueo(Bloqueo BloqueoParametrization)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.ID), BloqueoParametrization.MOD_B_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.CODIGO), BloqueoParametrization.MOD_B_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.CONCEPTO), BloqueoParametrization.MOD_B_CONCEPTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.DIASMORA), BloqueoParametrization.MOD_B_DIAS_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.REVERSIBLE), BloqueoParametrization.MOD_B_REVERSIBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.ACELERACIONDEUDA), BloqueoParametrization.MOD_B_ACELERACION_DEUDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.MODIFICADOPOR), BloqueoParametrization.MOD_B_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.ESTADO), 1);

            return await GetAsyncFirst<Bloqueo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
        /// <summary>
        /// Metodo Eliminar Bloqueo mediante el Dto
        /// </summary>
        /// <author>Camilo Andres Yaya Poveda</author>
        /// <date>17/05/2021</date>
        /// <param name="BloqueoParametrization"></param>
        /// <returns></returns>
        public async Task<Bloqueo> EliminarBloqueo(Bloqueo BloqueoParametrization)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.ID), BloqueoParametrization.MOD_B_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.CODIGO), BloqueoParametrization.MOD_B_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.CONCEPTO), BloqueoParametrization.MOD_B_CONCEPTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.DIASMORA), BloqueoParametrization.MOD_B_DIAS_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.REVERSIBLE), BloqueoParametrization.MOD_B_REVERSIBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.ACELERACIONDEUDA), BloqueoParametrization.MOD_B_ACELERACION_DEUDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.FECHAMODIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.MODIFICADOPOR), BloqueoParametrization.MOD_B_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoParameters.ESTADO), 1);

            return await GetAsyncFirst<Bloqueo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
