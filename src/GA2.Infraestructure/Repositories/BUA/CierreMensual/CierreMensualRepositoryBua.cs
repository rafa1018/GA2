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
    public class CierreMensualRepositoryBua : DapperGenerycRepository, ICierreMensualRepositoryBua
    {
        public CierreMensualRepositoryBua(IConfiguration configuration) : base(configuration){ }

        public async Task<RespuestaCierreMensual> CierreMensual(ProgramacionCierreMensual programacion)
        {
            DynamicParameters parameters = new DynamicParameters();

            //GLOBALES
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.TIPO_PROCESO), programacion.TIPO_PROCESO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.GENERA_ACTUALIZACION), programacion.GENERA_ACTUALIZACION);

            //AHORRO
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.CUENTA_ABONO_AHORRO), programacion.CUENTA_ABONO_AHORRO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.CONCEPTOS_AHORRO), programacion.CONCEPTOS_AHORRO);

            //CESANTIAS
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.CUENTA_ABONO_CESANTIAS), programacion.CUENTA_ABONO_CESANTIAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.CONCEPTOS_CESANTIAS), programacion.CONCEPTOS_CESANTIAS);

            //GENERAL
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.IPC), programacion.IPC);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.ANIO), programacion.ANIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.MES), programacion.MES);

            // IDENTIFICADOR TABLA GA2
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.ID_PROGRAMACION), programacion.ID);


            return await GetAsyncFirst<RespuestaCierreMensual>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            
        }

        public async Task<IEnumerable<ProgramacionCierreMensual>> ConsultarProgramacionCierreMensual()
        {
            return await GetAsyncList<ProgramacionCierreMensual>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ReporteCierreMensual>> ReporteCierreMensual(Guid Id)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreMensualParams.ID_PROGRAMACION), Id);

            return await GetAsyncList<ReporteCierreMensual>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
