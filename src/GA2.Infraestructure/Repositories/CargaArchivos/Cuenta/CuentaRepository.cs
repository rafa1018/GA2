using Dapper;
using GA2.Application.Dto;
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
    /// <summary>
    /// Cuenta repositorio
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/05/2021</date>
    public class CuentaRepository : DapperGenerycRepository, ICuentaRepository
    {
        /// <summary>
        /// Constructor cuenta repository
        /// </summary>
        /// <param name="configuration">Configuracion de aplicacion</param>
        public CuentaRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Crear cuenta base de datos
        /// </summary>
        /// <param name="cuenta">Cuenta a crear</param>
        /// <returns>Cuenta creada</returns>
        public async Task<Cuenta> CrearCuenta(Cuenta cuenta)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_ID), cuenta.CTA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_NUMERO), cuenta.CTA_NUMERO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.TCT_ID), cuenta.TCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_SALDO), cuenta.CTA_SALDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_FECHA_CREACION), cuenta.CTA_FECHA_CREACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.ECT_ID), cuenta.ECT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CCN_ID), cuenta.CCN_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.DCT_ID), cuenta.DCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.TPA_ID), cuenta.TPA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_FECHA_CIERRE), cuenta.CTA_FECHA_CIERRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_FECHA_PRIMER_APORTE), cuenta.CTA_FECHA_PRIMER_APORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_SALDO_CANJE), cuenta.CTA_SALDO_CANJE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_SALDO_DISPONIBLE), cuenta.CTA_SALDO_DISPONIBLE);

            return await GetAsyncFirst<Cuenta>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Actualizar cuenta en base datos
        /// </summary>
        /// <param name="cuenta">Cuenta a actualizar</param>
        /// <returns>Cuenta actualizada</returns>
        public async Task<Cuenta> ActualizarCuenta(Cuenta cuenta)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_ID), cuenta.CTA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_NUMERO), cuenta.CTA_NUMERO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.TCT_ID), cuenta.TCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_SALDO), cuenta.CTA_SALDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_FECHA_CREACION), cuenta.CTA_FECHA_CREACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.ECT_ID), cuenta.ECT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CCN_ID), cuenta.CCN_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.DCT_ID), cuenta.DCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.TPA_ID), cuenta.TPA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_FECHA_CIERRE), cuenta.CTA_FECHA_CIERRE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_FECHA_PRIMER_APORTE), cuenta.CTA_FECHA_PRIMER_APORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_SALDO_CANJE), cuenta.CTA_SALDO_CANJE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_SALDO_DISPONIBLE), cuenta.CTA_SALDO_DISPONIBLE);

            return await GetAsyncFirst<Cuenta>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Eliminar cuenta 
        /// </summary>
        /// <param name="cuenta">Cuenta a eliminar</param>
        /// <returns>Cuenta eliminada</returns>
        public async Task<Cuenta> EliminarCuenta(Cuenta cuenta)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_ID), cuenta.CTA_ID);

            return await GetAsyncFirst<Cuenta>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener cuenta por id
        /// </summary>
        /// <param name="cuentaId">Cuenta id</param>
        /// <returns>Cuenta obtenido por id</returns>
        public async Task<IEnumerable<Cuenta>> ObtenerCuentaPorCuentaId(Guid cuentaId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_ID), cuentaId);

            return await GetAsyncList<Cuenta>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener cuenta por estado
        /// </summary>
        /// <param name="cuentaId">Cuenta id</param>
        /// <returns>Lista de cuentas obtenidos</returns>
        public async Task<IEnumerable<Cuenta>> ObtenerCuentaPorEstado(Guid cuentaId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumCuentaParametros.CTA_ID), cuentaId);

            return await GetAsyncList<Cuenta>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }

        /// <summary>
        /// validacion y creacion de cuenta
        /// </summary>
        /// <param name="verificarafiliado">Cuenta a crear</param>
        /// <returns>Cuenta creada</returns>
        /// <author>Cristian gonzalez</author>
        public async Task<VerificarAfiliado> VerificarAfiliado (VerificarAfiliado verificarafiliado)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CLI_ID), verificarafiliado.CLI_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.TCT_ID), verificarafiliado.TCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.ECT_ID), verificarafiliado.ECT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CCN_ID), verificarafiliado.CCN_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.DCT_ID), verificarafiliado.DCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CTA_FECHA_CREACION), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CTA_FECHA_CIERRE), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CTA_FECHA_PRIMER_APORTE), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CTA_SALDO), verificarafiliado.CTA_SALDO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CTA_SALDO_CANJE), verificarafiliado.CTA_SALDO_CANJE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CTA_SALDO_DISPONIBLE), verificarafiliado.CTA_SALDO_DISPONIBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CTA_CUOTAS), verificarafiliado.CTA_CUOTAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CNC_ID), verificarafiliado.CNC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.MVT_VALOR), verificarafiliado.MVT_VALOR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.CAT_TIPO_MOVIMIENTO), verificarafiliado.CAT_TIPO_MOVIMIENTO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.MVT_FECHA_PROCESO), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.MVT_ANO_PERIODO), verificarafiliado.MVT_ANO_PERIODO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumVerificarAfiliadoParametros.MVT_FECHA_MOVIMIENTO), DateTime.Now);

            return await GetAsyncFirst<VerificarAfiliado>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, typeCommand: CommandType.StoredProcedure);
        }
        /// <summary>
        /// Obtener id cliente por numero de identificacion
        /// </summary>
        /// <param name="idafiliado"></param>
        /// <author>Cristian Gonzalez</author>
        /// <date>24/04/2021</date>
        /// 
        public async Task<AfiliadoporIdentificacion> ObtenerAfiliadoporIdentificacion(string idafiliado)
        {
            DynamicParameters parametros = new DynamicParameters();

            parametros.Add(HelpersEnums.GetEnumDescription(EnumAfiliadoporIdentificacionParametros.CLI_IDENTIFICACION), idafiliado);

            return await GetAsyncFirst<AfiliadoporIdentificacion>(HelperDBParameters.BuilderFunction(
                 HelperDBParameters.EnumSchemas.DBO), parametros, System.Data.CommandType.StoredProcedure);
        }
    }
}
