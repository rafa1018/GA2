using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public class AfiliacionesRepository : DapperGenerycRepository, IAfiliacionesRepository
    {
        public AfiliacionesRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<Afiliacion> ActualizarAfiliacion(Afiliacion consultaAfiliacionesRequestDTO)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_ID), consultaAfiliacionesRequestDTO.AFL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.CLI_IDENTIFICACION), consultaAfiliacionesRequestDTO.CLI_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_NUMERO_RADICADO), consultaAfiliacionesRequestDTO.AFL_NUMERO_RADICADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_FECHA_RADICADO), consultaAfiliacionesRequestDTO.AFL_FECHA_RADICADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_TRAMITE_AFILIACION), consultaAfiliacionesRequestDTO.AFL_TRAMITE_AFILIACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_FECHA_PRIMER_APORTE), consultaAfiliacionesRequestDTO.AFL_FECHA_PRIMER_APORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_FECHA_ULTIMO_APORTE), consultaAfiliacionesRequestDTO.AFL_FECHA_ULTIMO_APORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_NUMERO_CUOTAS), consultaAfiliacionesRequestDTO.AFL_NUMERO_CUOTAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_CONSERVA_ANTIGUEDAD), consultaAfiliacionesRequestDTO.AFL_CONSERVA_ANTIGUEDAD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_RATIFICACION_CUOTAS), consultaAfiliacionesRequestDTO.AFL_RATIFICACION_CUOTAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_OBSERVACIONES), consultaAfiliacionesRequestDTO.AFL_OBSERVACIONES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_NUMERO_ACTO_ADMINISTRATIVO), consultaAfiliacionesRequestDTO.AFL_NUMERO_ACTO_ADMINISTRATIVO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_FECHA_NOTIFICACION), consultaAfiliacionesRequestDTO.AFL_FECHA_NOTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_CAMPO_CESANTIAS), consultaAfiliacionesRequestDTO.AFL_CAMPO_CESANTIAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_ACTIVACION_DESCUENTO), consultaAfiliacionesRequestDTO.AFL_ACTIVACION_DESCUENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_LIQUIDACION_CUOTA_FONDO_SOLIDARIDAD), consultaAfiliacionesRequestDTO.AFL_LIQUIDACION_CUOTA_FONDO_SOLIDARIDAD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_REINTEGRO_APORTES), consultaAfiliacionesRequestDTO.AFL_REINTEGRO_APORTES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_PERIODO_APORTES_DESDE), consultaAfiliacionesRequestDTO.AFL_PERIODO_APORTES_DESDE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_PERIODO_APORTES_HASTA), consultaAfiliacionesRequestDTO.AFL_PERIODO_APORTES_HASTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_ASIGNACION_BASICA_MENSUAL), consultaAfiliacionesRequestDTO.AFL_ASIGNACION_BASICA_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_DERECHO_LIQUIDACION_CUOTAS), consultaAfiliacionesRequestDTO.AFL_DERECHO_LIQUIDACION_CUOTAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_DESCRIPCION_PROCEDENCIA_AFILIACION), consultaAfiliacionesRequestDTO.AFL_DESCRIPCION_PROCEDENCIA_AFILIACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.EAF_ID), consultaAfiliacionesRequestDTO.EAF_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.CLD_ID), consultaAfiliacionesRequestDTO.CLD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.TPF_ID), consultaAfiliacionesRequestDTO.TPF_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.FRZ_ID), consultaAfiliacionesRequestDTO.FRZ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.CTG_ID), consultaAfiliacionesRequestDTO.CTG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.UEJ_ID), consultaAfiliacionesRequestDTO.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.TPP_ID), consultaAfiliacionesRequestDTO.TPP_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.PRC_ID), consultaAfiliacionesRequestDTO.PRC_ID);

            return await GetAsyncFirst<Afiliacion>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<Afiliacion> InsertarAfiliacion(Afiliacion consultaAfiliacionesRequestDTO)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.CLI_IDENTIFICACION), consultaAfiliacionesRequestDTO.CLI_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_NUMERO_RADICADO), consultaAfiliacionesRequestDTO.AFL_NUMERO_RADICADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_FECHA_RADICADO), consultaAfiliacionesRequestDTO.AFL_FECHA_RADICADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_TRAMITE_AFILIACION), consultaAfiliacionesRequestDTO.AFL_TRAMITE_AFILIACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_FECHA_PRIMER_APORTE), consultaAfiliacionesRequestDTO.AFL_FECHA_PRIMER_APORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_FECHA_ULTIMO_APORTE), consultaAfiliacionesRequestDTO.AFL_FECHA_ULTIMO_APORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_NUMERO_CUOTAS), consultaAfiliacionesRequestDTO.AFL_NUMERO_CUOTAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_CONSERVA_ANTIGUEDAD), consultaAfiliacionesRequestDTO.AFL_CONSERVA_ANTIGUEDAD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_RATIFICACION_CUOTAS), consultaAfiliacionesRequestDTO.AFL_RATIFICACION_CUOTAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_OBSERVACIONES), consultaAfiliacionesRequestDTO.AFL_OBSERVACIONES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_NUMERO_ACTO_ADMINISTRATIVO), consultaAfiliacionesRequestDTO.AFL_NUMERO_ACTO_ADMINISTRATIVO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_FECHA_NOTIFICACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_CAMPO_CESANTIAS), consultaAfiliacionesRequestDTO.AFL_CAMPO_CESANTIAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_ACTIVACION_DESCUENTO), consultaAfiliacionesRequestDTO.AFL_ACTIVACION_DESCUENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_LIQUIDACION_CUOTA_FONDO_SOLIDARIDAD), consultaAfiliacionesRequestDTO.AFL_LIQUIDACION_CUOTA_FONDO_SOLIDARIDAD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_REINTEGRO_APORTES), consultaAfiliacionesRequestDTO.AFL_REINTEGRO_APORTES);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_PERIODO_APORTES_DESDE), consultaAfiliacionesRequestDTO.AFL_PERIODO_APORTES_DESDE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_PERIODO_APORTES_HASTA), consultaAfiliacionesRequestDTO.AFL_PERIODO_APORTES_HASTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_ASIGNACION_BASICA_MENSUAL), consultaAfiliacionesRequestDTO.AFL_ASIGNACION_BASICA_MENSUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_DERECHO_LIQUIDACION_CUOTAS), consultaAfiliacionesRequestDTO.AFL_DERECHO_LIQUIDACION_CUOTAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.AFL_DESCRIPCION_PROCEDENCIA_AFILIACION), consultaAfiliacionesRequestDTO.AFL_DESCRIPCION_PROCEDENCIA_AFILIACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.CLI_NOMBRE_COMPLETO), consultaAfiliacionesRequestDTO.CLI_NOMBRE_COMPLETO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.CLI_FECHA_ALTA), consultaAfiliacionesRequestDTO.CLI_FECHA_ALTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.EAF_ID), consultaAfiliacionesRequestDTO.EAF_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.CLD_ID), consultaAfiliacionesRequestDTO.CLD_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.TPF_ID), consultaAfiliacionesRequestDTO.TPF_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.FRZ_ID), consultaAfiliacionesRequestDTO.FRZ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.CTG_ID), consultaAfiliacionesRequestDTO.CTG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.UEJ_ID), consultaAfiliacionesRequestDTO.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.TPP_ID), consultaAfiliacionesRequestDTO.TPP_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.PRC_ID), consultaAfiliacionesRequestDTO.PRC_ID);

            return await GetAsyncFirst<Afiliacion>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Afiliacion>> ObtenerAfiliacionByIdentificacion(ConsultaAfiliacion consultaAfiliacionesRequestDTO)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.TID_ID), consultaAfiliacionesRequestDTO.TID_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAfiliacionesParameters.CLI_IDENTIFICACION), consultaAfiliacionesRequestDTO.CLI_IDENTIFICACION);

            return await GetAsyncList<Afiliacion>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
