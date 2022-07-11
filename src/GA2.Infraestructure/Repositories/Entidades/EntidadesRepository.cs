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
    public class EntidadesRepository : DapperGenerycRepository, IEntidadesRepository
    {
        public EntidadesRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<EntidadEducativa>> ObtenerEntidadEducativa()
        {
            return await GetAsyncList<EntidadEducativa>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<EntidadEducativa>> ObtenerEntidadEducativaPorNombreNit(EntidadEducativa entidad)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_TIPO_IDENTIFICACION), entidad.ENE_TIPO_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_NIT), entidad.ENE_NIT);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_NOMBRE_RAZON_SOCIAL), entidad.ENE_NOMBRE_RAZON_SOCIAL);

            return await GetAsyncList<EntidadEducativa>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<ProgramaEducativo>> ObtenerProgramaEducativo(Guid idEntidad)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.ENE_ID), idEntidad);

            return await GetAsyncList<ProgramaEducativo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<ProgramaEducativo> CrearProgramaEducativo(ProgramaEducativo programaEducativo)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_DESCRIPCION), programaEducativo.PGE_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_ESTADO), programaEducativo.PGE_ESTADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_CREATEDOPOR), programaEducativo.PGE_CREATEDOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_FECHACREACION), programaEducativo.PGE_FECHACREACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_MODIFICADOPOR), programaEducativo.PGE_MODIFICADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_FECHAMODIFICACION), programaEducativo.PGE_FECHAMODIFICACION);


            return await GetAsyncFirst<ProgramaEducativo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<NivelEducativo>> ObtenerNivelEducativoCesantias(Guid idPrograma)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumNivelEducativoParametros.PGN_ID), idPrograma);

            return await GetAsyncList<NivelEducativo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<EntidadSeguroEducativo>> ObtenerEntidadSeguroEducativo()
        {
            var response = await GetAsyncList<EntidadSeguroEducativo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
            return response;
        }
        public async Task<EntidadEducativa> CrearEntidadEducativa(EntidadEducativa entidadEducativa)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_TIPO_IDENTIFICACION), entidadEducativa.ENE_TIPO_IDENTIFICACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_NIT), entidadEducativa.ENE_NIT);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_NOMBRE_RAZON_SOCIAL), entidadEducativa.ENE_NOMBRE_RAZON_SOCIAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_CORREO_ELECTRONICO), entidadEducativa.ENE_CORREO_ELECTRONICO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_DPC_ID), entidadEducativa.ENE_DPC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_DIRECCION), entidadEducativa.ENE_DIRECCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_TELEFONO), entidadEducativa.ENE_TELEFONO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_NOMBRE_CONTACTO), entidadEducativa.ENE_NOMBRE_CONTACTO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_ESTADO), entidadEducativa.ENE_ESTADO);

            return await GetAsyncFirst<EntidadEducativa>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<EntidadEducativa> ActualizarEntidadEducativa(EntidadEducativa entidadEducativa)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_ID), entidadEducativa.ENE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_TIPO_IDENTIFICACION), entidadEducativa.ENE_TIPO_IDENTIFICACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_NIT), entidadEducativa.ENE_NIT);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_NOMBRE_RAZON_SOCIAL), entidadEducativa.ENE_NOMBRE_RAZON_SOCIAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_CORREO_ELECTRONICO), entidadEducativa.ENE_CORREO_ELECTRONICO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_DPC_ID), entidadEducativa.ENE_DPC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_DIRECCION), entidadEducativa.ENE_DIRECCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_TELEFONO), entidadEducativa.ENE_TELEFONO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_NOMBRE_CONTACTO), entidadEducativa.ENE_NOMBRE_CONTACTO);

            return await GetAsyncFirst<EntidadEducativa>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<EntidadEducativa> EliminarEntidadEducativaPorId(string EntidadEducativaId)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEntidadEducativaParameters.ENE_ID), EntidadEducativaId);

            return await GetAsyncFirst<EntidadEducativa>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<SedeEntidadEducativa>> ObtenerSedesPorEntidadEducativa(string EntidadEducativaId)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSedeEntidadEducativaParameters.ENE_ID), EntidadEducativaId);

            return await GetAsyncList<SedeEntidadEducativa>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<SedeEntidadEducativa> CrearSedeEntidadEducativa(SedeEntidadEducativa sedeEntidadEducativa)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumSedeEntidadEducativaParameters.ENE_ID), sedeEntidadEducativa.ENE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSedeEntidadEducativaParameters.SNE_SEDE_NOMBRE_RAZON_SOCIAL), sedeEntidadEducativa.SNE_SEDE_NOMBRE_RAZON_SOCIAL);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSedeEntidadEducativaParameters.SNE_SEDE_DPC_ID), sedeEntidadEducativa.SNE_SEDE_DPC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSedeEntidadEducativaParameters.SNE_SEDE_ESTADO), sedeEntidadEducativa.SNE_SEDE_ESTADO);

            return await GetAsyncFirst<SedeEntidadEducativa>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<SedeEntidadEducativa> EliminarSedeEntidadEducativaPorId(string sedeEntidadEducativaId)
        {
            DynamicParameters parametros = new();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumSedeEntidadEducativaParameters.SNE_SEDE_ID), sedeEntidadEducativaId);

            return await GetAsyncFirst<SedeEntidadEducativa>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<ListarProgramaEducativo>> ObtenerProgramaEducativoPorEntidad(string idEntidad)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.ENE_ID), idEntidad);

            return await GetAsyncList<ListarProgramaEducativo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<ProgramaEducativo> EliminarProgramaEducativoPorId(string idProgramaEducativo)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_ID), idProgramaEducativo);

            return await GetAsyncFirst<ProgramaEducativo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<ProgramaEducativo> ActualizarProgramaEducativo(ProgramaEducativo programaEducativo)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_ID), programaEducativo.PGE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_DESCRIPCION), programaEducativo.PGE_DESCRIPCION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_MODIFICADOPOR), programaEducativo.PGE_MODIFICADOPOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumProgramaEducativoParametros.PGE_FECHAMODIFICACION), programaEducativo.PGE_FECHAMODIFICACION);

            return await GetAsyncFirst<ProgramaEducativo>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<BloqueoEntidadEducativa> BloqueoEntidadEducativa(BloqueoEntidadEducativa bloqueoEntidadEducativa)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_ID), bloqueoEntidadEducativa.ENE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_TIPO_OPERACION), bloqueoEntidadEducativa.ENE_TIPO_OPERACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_CAUSAL_BLOQUEO), bloqueoEntidadEducativa.ENE_CAUSAL_BLOQUEO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_FECHA_BLOQUEO), bloqueoEntidadEducativa.ENE_FECHA_BLOQUEO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_FUNCIONARIO_BLOQUEO), bloqueoEntidadEducativa.ENE_FUNCIONARIO_BLOQUEO);

            return await GetAsyncFirst<BloqueoEntidadEducativa>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<BloqueoEntidadEducativa> DesbloqueoEntidadEducativa(BloqueoEntidadEducativa bloqueoEntidadEducativa)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_ID), bloqueoEntidadEducativa.ENE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_TIPO_OPERACION), bloqueoEntidadEducativa.ENE_TIPO_OPERACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_CAUSAL_BLOQUEO), bloqueoEntidadEducativa.ENE_CAUSAL_BLOQUEO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_FECHA_BLOQUEO), bloqueoEntidadEducativa.ENE_FECHA_BLOQUEO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_FUNCIONARIO_BLOQUEO), bloqueoEntidadEducativa.ENE_FUNCIONARIO_BLOQUEO);

            return await GetAsyncFirst<BloqueoEntidadEducativa>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<BloqueoEntidadEducativa>> ObtenerBloqueoEntidadEducativa(string idEntidadEducativa)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_ID), idEntidadEducativa);

            return await GetAsyncList<BloqueoEntidadEducativa>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<CuentaBancariaEntidadEducativa>> ObtenerCuentaBancariaPorEntidad(string idEntidadEducativa)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumBloqueoEntidadEducativaParameters.ENE_ID), idEntidadEducativa);

            return await GetAsyncList<CuentaBancariaEntidadEducativa>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<CuentaBancariaEntidadEducativa> CrearCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativa cuentaBancariaEntidadEducativa)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_CTA_BANCARIA), cuentaBancariaEntidadEducativa.ENE_CTA_BANCARIA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_ID), cuentaBancariaEntidadEducativa.ENE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_ENT_ID), cuentaBancariaEntidadEducativa.ENE_ENT_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_NUMERO_CTA), cuentaBancariaEntidadEducativa.ENE_NUMERO_CTA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_CTA_ESTADO), cuentaBancariaEntidadEducativa.ENE_CTA_ESTADO);

            return await GetAsyncFirst<CuentaBancariaEntidadEducativa>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<CuentaBancariaEntidadEducativa> ActualizarCuentaBancariaEntidadEducativa(CuentaBancariaEntidadEducativa cuentaBancariaEntidadEducativa)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_CTA_BANCARIA), cuentaBancariaEntidadEducativa.ENE_CTA_BANCARIA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_ID), cuentaBancariaEntidadEducativa.ENE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_ENT_ID), cuentaBancariaEntidadEducativa.ENE_ENT_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_NUMERO_CTA), cuentaBancariaEntidadEducativa.ENE_NUMERO_CTA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_CTA_ESTADO), cuentaBancariaEntidadEducativa.ENE_CTA_ESTADO);

            return await GetAsyncFirst<CuentaBancariaEntidadEducativa>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<CuentaBancariaEntidadEducativa> EliminarCuentaBancariaEntidadEducativa(Guid idCuenta)
        {
            DynamicParameters parametros = new();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCuentaBancariaEntidadParametros.ENE_CTA_BANCARIA), idCuenta);

            return await GetAsyncFirst<CuentaBancariaEntidadEducativa>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<InsertarArchivoEntidad> InsertarArchivoPorEntidad(InsertarArchivoEntidad insertarArchivoEntidad)
        {
            DynamicParameters parameters = new();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoEntidadParameters.NombreArchivo), insertarArchivoEntidad.ENE_NOMBRE_ARCHIVO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoEntidadParameters.RutaArchivo), insertarArchivoEntidad.ENE_RUTA_STORAGE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoEntidadParameters.ExtensionArchivo), insertarArchivoEntidad.ENE_EXTENSION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoEntidadParameters.Entidad), insertarArchivoEntidad.ENE_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoEntidadParameters.Parametrizacion), insertarArchivoEntidad.ENE_PAM_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoEntidadParameters.CreadoPor), insertarArchivoEntidad.ENE_PAM_CREATEDOPOR);

            InsertarArchivoEntidad response = new();
            response = await GetAsyncFirst<InsertarArchivoEntidad>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }
        public async Task<IEnumerable<ConsultarArchivoPorEntidad>> ConsultarArchivoPorEntidad(Guid IdEntidad)
        {
            DynamicParameters parameters = new();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumInsertarArchivoEntidadParameters.Entidad), IdEntidad);

            IEnumerable<ConsultarArchivoPorEntidad> response;
            response = await GetAsyncList<ConsultarArchivoPorEntidad>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

            return response;
        }

    }
}
