using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public class CesantiasRepository : DapperGenerycRepository, ICesantiasRepository
    {
        public CesantiasRepository(IConfiguration configuration) : base(configuration) { }


        /// <summary>
        /// Obtiene tramite solicitud
        /// </summary>
        /// <author>Erwin Pantoja España</author>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public async Task<ObtenerTramiteCesantias> ObtenerTramiteCesantias(ParametrosObtenerCesantias solicitud)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCesantiasParameters.idCliente), solicitud.CLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCesantiasParameters.solicitudId), solicitud.SOL_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSolicitudCesantiasParameters.subModalidadId), solicitud.TPS_SUB_ID);



            ObtenerTramiteCesantias response = new ObtenerTramiteCesantias();
            response = await GetAsyncFirst<ObtenerTramiteCesantias>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }
    }
}
