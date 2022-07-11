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
    public class CronogramaRepository : DapperGenerycRepository, ICronogramaRepository
    {
        /// <summary>
        /// Constructor del repositorio
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="configuration"></param>
        public CronogramaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<IEnumerable<Cronograma>> AgregarUnidadEjecutoraCronograma(Cronograma cronograma)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.UEJ_ID), cronograma.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.CRO_FECHA_REPORTE), cronograma.CRO_FECHA_REPORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.CRO_FECHA_INICIO), cronograma.CRO_FECHA_INICIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.CRO_FECHA_FIN), cronograma.CRO_FECHA_FIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.CRO_PERIODO), cronograma.CRO_PERIODO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.FRT_ID), cronograma.FRT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.MDE_ID), cronograma.MDE_ID);

            return await GetAsyncList<Cronograma>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Cronograma>> EditarFechaReporteCronograma(Cronograma cronograma)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.CRO_ID), cronograma.CRO_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.CRO_FECHA_REPORTE), cronograma.CRO_FECHA_REPORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.FRT_ID), cronograma.FRT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.MDE_ID), cronograma.MDE_ID);

            return await GetAsyncList<Domain.Entities.Cronograma>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Cronograma>> EliminarUnidadEjecutoraCronograma(int idCronograma)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCronograma.CRO_ID), idCronograma);

            return await GetAsyncList<Domain.Entities.Cronograma>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Domain.Entities.Cronograma>> ObtenerUnidadesEjecutorasCronograma()
        {
            DynamicParameters parameters = new DynamicParameters();

            return await GetAsyncList<Domain.Entities.Cronograma>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
