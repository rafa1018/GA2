using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    /// <summary>
    /// Repositorio parametros del cargue de nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    public class ParamCargueNominaRepository : DapperGenerycRepository, IParamCargueNominaRepository
    {
        /// <summary>
        /// Construnctor del repositorio
        /// </summary>
        /// <author>Nicolas Florez Sarrazola</author>
        /// <date>12/04/2021</date>
        /// <param name="configuration"></param>
        public ParamCargueNominaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// Metodo para obtener los parametros del cargue de nómina
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ParamCargueNom> ObtenerParametrosCargueNomina(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCargueNominaParams.PAR_VERSION), id);
            return await GetAsyncFirst<ParamCargueNom>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
    }
}
