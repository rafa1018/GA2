using Dapper;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data.GrupoUsuarios;
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
    public class GrupoOpcionesRepository : DapperGenerycRepository, IGrupoOpcionesRepository
    {
        public GrupoOpcionesRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<GrupoOpciones> ActualizaGrupoOpciones(GrupoOpciones grupo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.ID), grupo.ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.CODIGO), grupo.CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.NOMBRE), grupo.NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.DESCRIPCION), grupo.DESCRIPCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.ESTADO), grupo.ESTADO);

            return await GetAsyncFirst<GrupoOpciones>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<GrupoOpciones> CrearGrupoOpciones(GrupoOpciones grupo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.CODIGO), grupo.CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.NOMBRE), grupo.NOMBRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.DESCRIPCION), grupo.DESCRIPCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.ESTADO), grupo.ESTADO);

            return await GetAsyncFirst<GrupoOpciones>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<GrupoOpciones> EliminarGruposOpciones(int id)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.ID), id);

            return await GetAsyncFirst<GrupoOpciones>("DELETE FROM SEG_GRUPO_OPCIONES  WHERE ID=@ID", parameters, CommandType.Text);
        
        }

        public async Task<GrupoOpciones> EliminarGruposOpcionesGrupoById(int grupoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.ID), grupoId);

            return await GetAsyncFirst<GrupoOpciones>("DELETE FROM SEG_GRUPO_X_OPCIONES  WHERE GRP_ID=@ID", parameters, CommandType.Text);
        }

        public async Task<GrupoOpciones> InsertGruposOpcionesGrupoById(int grupoId,int opId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposPorOpciones.OPC_ID), opId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposPorOpciones.GRP_ID), grupoId);

            return await GetAsyncFirst<GrupoOpciones>("INSERT INTO SEG_GRUPO_X_OPCIONES (OPC_ID,GRP_ID) VALUES(@OPC_ID,@GRP_ID)", parameters, CommandType.Text);
        }

        public async Task<IEnumerable<GrupoOpciones>> GetGrupoOpcionesGrupoById(int grupoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposPorOpciones.GRP_ID), grupoId);

            return await GetAsyncList<GrupoOpciones>("SELECT GOP.* FROM SEG_GRUPO_X_OPCIONES GXP INNER JOIN SEG_GRUPO_OPCIONES GOP ON GOP.ID=GXP.OPC_ID WHERE GXP.GRP_ID=@GRP_ID", parameters, CommandType.Text);

        }

        public async Task<IEnumerable<GrupoOpciones>> ObtenerGrupoOpciones()
        {
           return await GetAsyncList<GrupoOpciones>(HelperDBParameters.BuilderFunction(
           HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<GrupoOpciones> ObtenerGrupoOpcionesById(string codigo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.CODIGO), codigo);


            return await GetAsyncFirst<GrupoOpciones>("SELECT * FROM SEG_GRUPO_OPCIONES WHERE CODIGO=@CODIGO", parameters, CommandType.Text);
            
        }

        public async Task<IEnumerable<GrupoOpciones>> GetOpcionesGrupoById(int grupoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposPorOpciones.GRP_ID), grupoId);

            return await GetAsyncList<GrupoOpciones>("SELECT OP.* FROM OPC_SEG_OPCIONES OP INNER JOIN SEG_GRUPOOPCIONES_OPC_OPCIONES GRO ON GRO.OPC_ID = OP.ID  WHERE GRO.GRP_ID = @GRP_ID", parameters, CommandType.Text);

        }

        public async Task<IEnumerable<GrupoOpciones>> GetAllOpciones()
        {
            return await GetAsyncList<GrupoOpciones>("SELECT * FROM OPC_SEG_OPCIONES", null, CommandType.Text);
        }

        public async Task<GrupoOpciones> EliminarOpcionesGrupoById(int grupoId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposUsuarios.ID), grupoId);

            return await GetAsyncFirst<GrupoOpciones>("DELETE FROM SEG_GRUPOOPCIONES_OPC_OPCIONES WHERE GRP_ID=@ID", parameters, CommandType.Text);
        }


        public async Task<GrupoOpciones> InsertOpcionesGrupoById(int grupoId, int opId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposPorOpciones.OPC_ID), opId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumGruposPorOpciones.GRP_ID), grupoId);

            return await GetAsyncFirst<GrupoOpciones>("INSERT INTO SEG_GRUPOOPCIONES_OPC_OPCIONES (OPC_ID,GRP_ID) VALUES(@OPC_ID,@GRP_ID)", parameters, CommandType.Text);
        }
    }
}
