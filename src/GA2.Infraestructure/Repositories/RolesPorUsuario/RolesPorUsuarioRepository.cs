using Dapper;
using GA2.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories
{
    public class RolesPorUsuarioRepository : DapperGenerycRepository
    {
        public RolesPorUsuarioRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<RolesPorUsuario> CreaarRolPorUsuario(RolesPorUsuario rolesPorUsuario)
        {
            DynamicParameters parameters = new DynamicParameters();

            //parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.CONTAINERNAME), cuentaStorage.CONTAINERNAME);
            //parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.MODULO), cuentaStorage.MODULO);
            //parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.BLOBNAME), cuentaStorage.BLOBNAME);
            //parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.CREADOPOR), cuentaStorage.CREADOPOR);
            //parameters.Add(HelpersEnums.GetEnumDescription(EmunBlobstorageParameters.FECHACREACION), cuentaStorage.FECHACREACION);

            return await GetAsyncFirst<RolesPorUsuario>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }


    }
}
