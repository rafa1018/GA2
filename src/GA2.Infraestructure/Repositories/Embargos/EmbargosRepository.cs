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
    public class EmbargosRepository : DapperGenerycRepository, IEmbargosRepository
    {
        #region Juzgados


        public async Task<JuzgadosGuid> ObtenerJuzgadoById(Guid id)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.ID_JUZGADO), id);

            return await GetAsyncFirst<JuzgadosGuid>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }


        public EmbargosRepository(IConfiguration configuration) : base(configuration) { }
        public async Task<Juzgados> ActualizarJuzgado(Juzgados juzgado)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.ID_JUZGADO), juzgado.ID_JUZGADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.CODIGO_INTERNO), juzgado.CODIGO_INTERNO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.NOMBRE), juzgado.NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.ID_DPD), juzgado.ID_DPD);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.ID_DPC), juzgado.ID_DPC);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.NRO_CUENTA), juzgado.NRO_CUENTA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.CODIGO_OFICINA), juzgado.CODIGO_OFICINA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.CORREO_ELECTRONICO), juzgado.CORREO_ELECTRONICO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.CELULAR), juzgado.CELULAR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.CONTACTO), juzgado.CONTACTO);


            return await GetAsyncFirst<Juzgados>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<Juzgados> CrearJuzgado(Juzgados juzgado)
        {
            DynamicParameters parametros = new();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.CODIGO_INTERNO), juzgado.CODIGO_INTERNO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.NOMBRE), juzgado.NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.ID_DPD), juzgado.ID_DPD);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.ID_DPC), juzgado.ID_DPC);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.NRO_CUENTA), juzgado.NRO_CUENTA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.CODIGO_OFICINA), juzgado.CODIGO_OFICINA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.CORREO_ELECTRONICO), juzgado.CORREO_ELECTRONICO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.CELULAR), juzgado.CELULAR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.CONTACTO), juzgado.CONTACTO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.ESTADO), juzgado.ESTADO);

            return await GetAsyncFirst<Juzgados>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<Juzgados> EliminarJuzgadoPorId(string idJuzgado)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.ID_JUZGADO), idJuzgado);

            return await GetAsyncFirst<Juzgados>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        

        public async Task<IEnumerable<Juzgados>> ObtenerJuzgadosPorCiudad(int idDpto, int idCiudad)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCiudadesPorDepartamentoParametros.DPD_ID), idDpto);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumCiudadesPorDepartamentoParametros.DPC_ID), idCiudad);

            return await GetAsyncList<Juzgados>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Juzgados>> ObtenerJuzgadosPorDepartamento(int idDpto)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.ID_DPD), idDpto);

            return await GetAsyncList<Juzgados>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Juzgados>> ObtenerJuzgadosPorNombre(string nombreJuzgado)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumJuzgadosParameters.NOMBRE), nombreJuzgado);

            return await GetAsyncList<Juzgados>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }


        #endregion



        public async Task<IEnumerable<TipoEmbargos>> ObtenerTiposEmbargos()
        {
            return await GetAsyncList<TipoEmbargos>(HelperDBParameters.BuilderFunction( HelperDBParameters.EnumSchemas.DBO),null, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TiposProcesos>> ObtenerTiposProcesosEmbargos()
        {
            return await GetAsyncList<TiposProcesos>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO),null, CommandType.StoredProcedure);
        }

        public async Task<Embargo> InsertarEmbargo(Embargo embargo)
        {

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_RADICADO_WORK_MANAGER), embargo.EBA_RADICADO_WORK_MANAGER);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_FECHA_RADICADO_WORK_MANAGER), embargo.EBA_FECHA_RADICADO_WORK_MANAGER);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_RADICADO_JUZGADO), embargo.EBA_RADICADO_JUZGADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_FECHA_RADICADO_JUZGADO), embargo.EBA_FECHA_RADICADO_JUZGADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_EMAIL_RESPUESTA), embargo.EBA_EMAIL_RESPUESTA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_DIRECCION_RESPUESTA), embargo.EBA_DIRECCION_RESPUESTA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_NOMBRE_DEMANDANTE), embargo.EBA_NOMBRE_DEMANDANTE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_NOMBRE_DEMANDADO), embargo.EBA_NOMBRE_DEMANDADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_EXPEDIENTE_BANCO_AGRARIO), embargo.EBA_EXPEDIENTE_BANCO_AGRARIO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_REMANENTE), embargo.EBA_REMANENTE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_OBSERVACIONES), embargo.EBA_OBSERVACIONES);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_RESPUESTA), embargo.EBA_RESPUESTA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_VALOR), embargo.EBA_VALOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.CLI_ID), embargo.CLI_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EMB_ID_JUZGADO), embargo.EMB_ID_JUZGADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.TPE_ID), embargo.TPE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.TIE_ID), embargo.TIE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_CREADOPOR), embargo.EBA_CREADOPOR);

            return await GetAsyncFirst<Embargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<Embargo>> ObtenerEmbargos()
        {
            return await GetAsyncList<Embargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<Embargo> EliminarEmbargo(Guid Id)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_ID),Id);
            return await GetAsyncFirst<Embargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<Embargo> ActualizarEmbargo(Embargo embargo)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_ID), embargo.EBA_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_RADICADO_WORK_MANAGER), embargo.EBA_RADICADO_WORK_MANAGER);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_FECHA_RADICADO_WORK_MANAGER), embargo.EBA_FECHA_RADICADO_WORK_MANAGER);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_RADICADO_JUZGADO), embargo.EBA_RADICADO_JUZGADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_FECHA_RADICADO_JUZGADO), embargo.EBA_FECHA_RADICADO_JUZGADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_EMAIL_RESPUESTA), embargo.EBA_EMAIL_RESPUESTA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_DIRECCION_RESPUESTA), embargo.EBA_DIRECCION_RESPUESTA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_NOMBRE_DEMANDANTE), embargo.EBA_NOMBRE_DEMANDANTE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_NOMBRE_DEMANDADO), embargo.EBA_NOMBRE_DEMANDADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_EXPEDIENTE_BANCO_AGRARIO), embargo.EBA_EXPEDIENTE_BANCO_AGRARIO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_REMANENTE), embargo.EBA_REMANENTE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_OBSERVACIONES), embargo.EBA_OBSERVACIONES);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_RESPUESTA), embargo.EBA_RESPUESTA);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_VALOR), embargo.EBA_VALOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.CLI_ID), embargo.CLI_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EMB_ID_JUZGADO), embargo.EMB_ID_JUZGADO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.TPE_ID), embargo.TPE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.TIE_ID), embargo.TIE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_ACTUALIZADOPOR), embargo.EBA_ACTUALIZADOPOR);

            return await GetAsyncFirst<Embargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<EmbargoCuentaConcepto> InsertarEmbargoCuentaConcepto(EmbargoCuentaConcepto ecc)
        {

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_VALOR), ecc.ECC_VALOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_FECHA_INICIO_EMBARGO), ecc.ECC_FECHA_INICIO_EMBARGO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_FECHA_FIN_EMBARGO), ecc.ECC_FECHA_FIN_EMBARGO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_INDICADOR_CESANTIAS), ecc.ECC_INDICADOR_CESANTIAS);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.EBA_ID), ecc.EBA_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.TRE_ID), ecc.TRE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.TIE_ID), ecc.TIE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.CTA_ID), ecc.CTA_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.CCT_ID), ecc.CCT_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.EBA_CREADOPOR), ecc.EBA_CREADOPOR);

            return await GetAsyncFirst<EmbargoCuentaConcepto>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        public async Task<Embargo> ObtenerEmbargoWorkManeger(string numero)
        {

            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.EBA_RADICADO_WORK_MANAGER), numero);

            return await GetAsyncFirst<Embargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<EmbargoCuentaConcepto>> ObtenerEmbargosCuentaConcepto()
        {
            return await GetAsyncList<EmbargoCuentaConcepto>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<EmbargoCuentaConcepto> EliminarEmbargoCuentaConcepto(Guid Id)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_ID), Id);
            return await GetAsyncFirst<EmbargoCuentaConcepto>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<EmbargoCuentaConcepto> ActualizarEmbargoCuentaConcepto(EmbargoCuentaConcepto ecc)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_ID), ecc.ECC_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_VALOR), ecc.ECC_VALOR);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_FECHA_INICIO_EMBARGO), ecc.ECC_FECHA_INICIO_EMBARGO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_FECHA_FIN_EMBARGO), ecc.ECC_FECHA_FIN_EMBARGO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_INDICADOR_CESANTIAS), ecc.ECC_INDICADOR_CESANTIAS);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.EBA_ID), ecc.EBA_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.TRE_ID), ecc.TRE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.TIE_ID), ecc.TIE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.CTA_ID), ecc.CTA_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.CCT_ID), ecc.CCT_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.EBA_ACTUALIZADOPOR), ecc.EBA_ACTUALIZADOPOR);

            return await GetAsyncFirst<EmbargoCuentaConcepto>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TipoRetencion>> ObtenerTiposRetenciones()
        {
            return await GetAsyncList<TipoRetencion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<BeneficiariosPagoEmbargo> InsertarBeneficiariosPagoEmbargos(BeneficiariosPagoEmbargo be)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.EBA_ID), be.EBA_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.TID_ID), be.TID_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_NUMERO_IDENTIFICACION), be.BPE_NUMERO_IDENTIFICACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_PRIMER_NOMBRE), be.BPE_PRIMER_NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_SEGUNDO_NOMBRE), be.BPE_SEGUNDO_NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_PRIMER_APELLIDO), be.BPE_PRIMER_APELLIDO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_SEGUNGO_APELLIDO), be.BPE_SEGUNGO_APELLIDO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_CREADOPOR), be.BPE_CREADOPOR);

            return await GetAsyncFirst<BeneficiariosPagoEmbargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<BeneficiariosPagoEmbargo> ActualizarBeneficiariosPagoEmbargos(BeneficiariosPagoEmbargo be)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_ID), be.BPE_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.EBA_ID), be.EBA_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.TID_ID), be.TID_ID);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_NUMERO_IDENTIFICACION), be.BPE_NUMERO_IDENTIFICACION);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_PRIMER_NOMBRE), be.BPE_PRIMER_NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_SEGUNDO_NOMBRE), be.BPE_SEGUNDO_NOMBRE);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_PRIMER_APELLIDO), be.BPE_PRIMER_APELLIDO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_SEGUNGO_APELLIDO), be.BPE_SEGUNGO_APELLIDO);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_ACTUALIZADOPOR), be.BPE_ACTUALIZADOPOR);

            return await GetAsyncFirst<BeneficiariosPagoEmbargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        public async Task<BeneficiariosPagoEmbargo> EliminarBeneficiariosPagoEmbargos(Guid Id)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumBeneficiariosPagoEmbargo.BPE_ID), Id);
            return await GetAsyncFirst<BeneficiariosPagoEmbargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<BeneficiariosPagoEmbargo>> ObtenerBeneficiariosEmbargo()
        {
            return await GetAsyncList<BeneficiariosPagoEmbargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<Embargo>> ObtenerEmbargosRangoFecha(DateTime FechaInicial, DateTime FechaFinal)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.FECHA_INICIAL), FechaInicial);
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoParameters.FECHA_FINAL), FechaFinal);
            return await GetAsyncList<Embargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);  
        }

        public async Task<Desembargo> InsertarDesembargo(Guid Id)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.ECC_ID), Id);
            return await GetAsyncFirst<Desembargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ObtenerDesembargo>> ObtenerDesembargo()
        {
            return await GetAsyncList<ObtenerDesembargo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
    
        }

        public async Task<TipoIdentificacion> ObtenerTipoIdentificacionById(int Tipo)
        {
            DynamicParameters parametros = new DynamicParameters();
            parametros.Add(HelpersEnums.GetEnumDescription(EnumEmbargoscuentaConcepto.TID_ID), Tipo);
            return await GetAsyncFirst<TipoIdentificacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parametros, CommandType.StoredProcedure);
        }
    }
}
