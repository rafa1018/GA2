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
    public class AuditoriaRepository : DapperGenerycRepository, IAuditoriaRepository
    {
        public AuditoriaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Auditoria>> ObtenerlogAuditoria(ConsultaAuditoria parametros) {


            DynamicParameters param = new DynamicParameters();
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_USR_ID), parametros.AUR_USR_ID);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_NOM_TABLE), parametros.AUR_NOM_TABLE);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_VER_DETALLE), parametros.AUR_VER_DETALLE);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_FECHA_FILTRO_FIN), parametros.AUR_FECHA_FILTRO_FIN);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_FECHA_FILTRO_INICIO), parametros.AUR_FECHA_FILTRO_INICIO);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_AGRUPADOR), parametros.AUR_AGRUPADOR);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.PAGENUM), parametros.PAGENUM);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.PAGESIZE), parametros.PAGESIZE);

            return await GetAsyncList<Auditoria>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), param, CommandType.StoredProcedure);


        }

        public async Task<IEnumerable<TablasAuditoria>> ObtenerTablasAuditoria()
        {
            return await GetAsyncList<TablasAuditoria>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO),null, CommandType.StoredProcedure);
        }

        public async Task<int> ObtenerNumeroRegistrologAuditoria(ConsultaAuditoria parametros)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_USR_ID), parametros.AUR_USR_ID);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_NOM_TABLE), parametros.AUR_NOM_TABLE);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_VER_DETALLE), parametros.AUR_VER_DETALLE);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_FECHA_FILTRO_FIN), parametros.AUR_FECHA_FILTRO_FIN);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_FECHA_FILTRO_INICIO), parametros.AUR_FECHA_FILTRO_INICIO);
            param.Add(HelpersEnums.GetEnumDescription(EnumAuditoriaParameter.AUR_AGRUPADOR), parametros.AUR_AGRUPADOR);
  

            return await GetAsyncFirst<int>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), param, CommandType.StoredProcedure);



        }


            
    }
}
