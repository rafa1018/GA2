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
    public class CuentasConceptosRepository : DapperGenerycRepository, ICuentasConceptosRepository
    {
        public CuentasConceptosRepository(IConfiguration configuration) : base(configuration){}

        public async Task<BloqueoCuentaConcepto> InsertarBoqueoCuentaConcecto(BloqueoCuentaConcepto bloqueo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoCuentaConceptoParameters.CSB_ID),bloqueo.CSB_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoCuentaConceptoParameters.CTA_ID), bloqueo.CTA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoCuentaConceptoParameters.CCT_ID), bloqueo.CCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoCuentaConceptoParameters.BCC_TIPO_BLOQUEO), bloqueo.BCC_TIPO_BLOQUEO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoCuentaConceptoParameters.BCC_MONTO), bloqueo.BCC_MONTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoCuentaConceptoParameters.BCC_VALOR), bloqueo.BCC_VALOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumBloqueoCuentaConceptoParameters.BCC_CREADOPOR),bloqueo.BCC_CREADOPOR);
                   
            return await GetAsyncFirst<BloqueoCuentaConcepto>(HelperDBParameters.BuilderFunction( HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);

        }

        public async Task<InsertCuentaConcepto> InsertarNuevaCuenta(InsertCuentaConcepto bloqueo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CTA_ID_INTEGRACION), bloqueo.CTA_ID_INTEGRACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CTA_NUMERO), bloqueo.CTA_NUMERO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CLI_ID), bloqueo.CLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.TCT_ID), bloqueo.TCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.ECT_ID), bloqueo.ECT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CCN_ID), bloqueo.CCN_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.DCT_ID), bloqueo.DCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CTA_SALDO), bloqueo.CTA_SALDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CTA_SALDO_CANJE), bloqueo.CTA_SALDO_CANJE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CTA_CUOTAS), bloqueo.CTA_CUOTAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CTA_BLOQUEO), bloqueo.CTA_BLOQUEO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CTA_SALDO_DISPONIBLE), bloqueo.CTA_SALDO_DISPONIBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.EJE_UNIDAD_EJECUTORA), bloqueo.EJE_UNIDAD_EJECUTORA);

            return await GetAsyncFirst<InsertCuentaConcepto>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<CausalBloqueoCuenta>> ObtenerCausalBloqueoCuentasConceptos()
        {
            return await GetAsyncList<CausalBloqueoCuenta>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, typeCommand: CommandType.StoredProcedure);

        }

       

        public async Task<InfoCliente> ObtenerInformacionCliente(int tpo_identificacion, string num_identificacion)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientConsultaParameters.TID_ID), tpo_identificacion);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientConsultaParameters.CLI_IDENTIFICACION), num_identificacion);

            return await GetAsyncFirst<InfoCliente>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }

        public async Task<InsertCuentaConcepto> validarExisteCuenta(int num_cuenta)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CTA_NUMERO), num_cuenta);
            return await GetAsyncFirst<InsertCuentaConcepto>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }

        public async Task<InsertCuentaConcepto> validarExisteCuentaTipo(int id_clente, int? tipoCuenta)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.CLI_ID), id_clente);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumNuevaCuentaConceptoParameters.TCT_ID), tipoCuenta);
            return await GetAsyncFirst<InsertCuentaConcepto>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }
        


        public async Task<IEnumerable<CuentaCliente>> ObtenerCuentasCliente(int clienteId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientConsultaParameters.CLI_ID), clienteId);
            return await GetAsyncList<CuentaCliente>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ConceptoCuenta>> ObtenerConceptosCuentas(int cuentaId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_ID), cuentaId);
            return await GetAsyncList<ConceptoCuenta>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);

    
        }

        public async Task<IEnumerable<AportesCliente>> ObtenerAportesCategoriaCliente(int clienteId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumClientConsultaParameters.CLI_ID), clienteId);
            return await GetAsyncList<AportesCliente>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MovimientosCuenta>> ObtenerMovimientosCuentaAfiliado(int cuentaId)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_ID), cuentaId);
            return await GetAsyncList<MovimientosCuenta>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);

        }

        public async Task<IEnumerable<MovimientosCuenta>> ObtenerMovimientosConceptos(int cuentaId, int conceptoId)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_ID), cuentaId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CNC_ID), conceptoId);

            return await GetAsyncList<MovimientosCuenta>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }
    }
}
