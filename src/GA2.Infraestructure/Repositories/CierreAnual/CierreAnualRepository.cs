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
    public class CierreAnualRepository
        : DapperGenerycRepository, ICierreAnualRepository
    {
        public CierreAnualRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<bool> ValidarExisteCierre(int anio, int mes)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.ANIO), anio);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.MES), mes);

            return await GetAsyncFirst<bool>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }
        public async Task<int> ObtenerCuentaAbono(string concepto)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CONCEPTOS), concepto);

            return await GetAsyncFirst<int>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<float> ObtenerIPC()
        {
            return await GetAsyncFirst<float>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<List<int>> ObtenerCategoriaConceptos(string concepto)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CONCEPTOS), concepto);


            var resultado = await GetAsyncList<int>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return resultado.AsList();

        }

        public async Task<ProgramacionCierreAnual> ProgramarCierreAnual(ParametrosCierreAnual programacionCierre, CierreAnual cierre)
        {
            var conceptosAhorros = "";
            var conceptosCesantias = "";


            if (cierre.ListConceptosAhorros.Count > 0)
            {
                conceptosAhorros = String.Join(", ", cierre.ListConceptosAhorros);
            }

            if (cierre.ListConceptosCesantias.Count > 0)
            {
                conceptosCesantias = String.Join(", ", cierre.ListConceptosCesantias);
            }

            DynamicParameters parametros = new();

            // PARAMETROS ENTRADA
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.USUARIO), programacionCierre.Usuario);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.GENERA_ACTUALIZACION), programacionCierre.GeneraActualizacion);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.TIPO_PROCESO), programacionCierre.TipoProceso);
            // PARAMETROS OBTENIDOS

            //AHORRO
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CUENTA_ABONO_AHORRO), cierre.CuentaAbonoAhorros);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CONCEPTOS_AHORRO), conceptosAhorros);

            //CESANTIAS
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CUENTA_ABONO_CESANTIAS), cierre.CuentaAbonoCesantias);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CONCEPTOS_CESANTIAS), conceptosCesantias);

            //GENERAL
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.IPC), cierre.IPC);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.ANIO), cierre.Anio);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.MES), cierre.Mes);

            return (ProgramacionCierreAnual)await GetAsyncFirst<ProgramacionCierreAnual>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        public async Task<IPC> ObtenerIPCMes()
        {
            return await GetAsyncFirst<IPC>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<ProgramacionCierreAnual> ActualizaEstadoCierreAnual(Guid id, int estado)
        {
            DynamicParameters parametros = new();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CCT_ID), id);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCierreAnualParams.CCT_ESTADO), estado);
            return await GetAsyncFirst<ProgramacionCierreAnual>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ProgramacionCierreAnual>> ConsultarProgramacionCierreAnual()
        {
            return await GetAsyncList<ProgramacionCierreAnual>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

    }
}
