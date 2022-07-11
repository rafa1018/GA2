using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public class CierreAnualRepositoryBua : DapperGenerycRepository, ICierreAnualRepositoryBua
    {
        public CierreAnualRepositoryBua(IConfiguration configuration) : base(configuration){ }

        public async Task<RespuestaCierreAnual> CierreAnual(ProgramacionCierreAnual programacion)
        {
            DynamicParameters parameters = new DynamicParameters();

            //GLOBALES
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.TIPO_PROCESO), programacion.TIPO_PROCESO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.GENERA_ACTUALIZACION), programacion.GENERA_ACTUALIZACION);

            //AHORRO
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CUENTA_ABONO_AHORRO), programacion.CUENTA_ABONO_AHORRO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CONCEPTOS_AHORRO), programacion.CONCEPTOS_AHORRO);

            //CESANTIAS
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CUENTA_ABONO_CESANTIAS), programacion.CUENTA_ABONO_CESANTIAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CONCEPTOS_CESANTIAS), programacion.CONCEPTOS_CESANTIAS);

            //GENERAL
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.IPC), programacion.IPC);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.ANIO), programacion.ANIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.MES), programacion.MES);

            // IDENTIFICADOR TABLA GA2
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.ID_PROGRAMACION), programacion.ID);


            return await GetAsyncFirst<RespuestaCierreAnual>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            
        }

        public async Task<IEnumerable<ProgramacionCierreAnual>> ConsultarProgramacionCierreAnual()
        {
            return await GetAsyncList<ProgramacionCierreAnual>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }
    }
}
