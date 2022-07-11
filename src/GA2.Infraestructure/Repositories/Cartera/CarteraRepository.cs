
using Dapper;
using GA2.Application.Dto;
using GA2.Domain.Entities;
using GA2.Infraestructure.Data;
using GA2.Transversals.Commons;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA2.Infraestructure.Repositories 
{
    public class CarteraRepository : DapperGenerycRepository, ICarteraRepository
    {
        public CarteraRepository(IConfiguration configuration) : base(configuration)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateCredito"></param>
        /// <returns></returns>
        /// <Author>Sergio Ortega Fula</Author>
        /// <Date>19/10/2021</Date>
        public async Task<InformacionCredito> ActualizarCredito(InformacionCredito updateCredito)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.IdCredito), updateCredito.CRE_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.NumeroCredito), updateCredito.CRE_NRO_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.FechaDesembolso), updateCredito.CRE_FECHA_DESEMBOLSO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.ValorDesembolso), updateCredito.CRE_VALOR_DESEMBOLSO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.ValorCuota), updateCredito.CRE_VALOR_CUOTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.PlazoTotal), updateCredito.CRE_PLAZO_TOTAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.IdTipoCredito), updateCredito.TCR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.DiaPago), updateCredito.CRE_DIA_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.IdEstadoCartera), updateCredito.ESC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.FechaEstado), updateCredito.CRE_FECHA_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.DiasMora), updateCredito.CRE_DIAS_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.ValorVivienda), updateCredito.CRE_VALOR_VIVIENDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.IdTipoVivienda), updateCredito.TIV_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.IdEstadoVivienda), updateCredito.TVV_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.SaldoCapital), updateCredito.CRE_SALDO_CAPITAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.SaldoCapitalMora), updateCredito.CRE_SALDO_CAPITAL_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.PlazoActual), updateCredito.CRE_PLAZO_ACTUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.TasaSeguroVida), updateCredito.CRE_TASA_SEGURO_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.TasaSeguroHogar), updateCredito.CRE_TASA_SEGURO_HOGAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.TasaCreditoEfectivaAnual), updateCredito.CRE_TASA_CREDITO_EA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.TasaCreditoPer), updateCredito.CRE_TASA_CREDITO_PER);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.TasaFrech), updateCredito.CRE_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.ValorAlivioCuota), updateCredito.CRE_VALOR_ALIVIO_CUOTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.FechaUltimoPago), updateCredito.CRE_FECHA_ULTIMO_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.FechaProximoPago), updateCredito.CRE_FECHA_PROXIMO_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.TipoAbonoExtra), updateCredito.CRE_TIPO_ABONO_EXTRA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.ValorAbonoExtra), updateCredito.CRE_VALOR_ABONO_EXTRA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.ValorDeudaRemanente), updateCredito.CRE_VALOR_DEUDA_REMANENTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.ValorCanonInicial), updateCredito.CRE_VALOR_CANON_INICIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.ValorOpcionCompra), updateCredito.CRE_VALOR_OPCION_COMPRA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.PorcentajeCanonInicial), updateCredito.CRE_POR_CANON_INICIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.PorcentajePorOpcionCompra), updateCredito.CRE_POR_OPCION_COMPRA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.AcumuladoInteresMora), updateCredito.CRE_ACUMULADO_INTERES_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.AcumuladoInteresCorriente), updateCredito.CRE_ACUMULADO_INTERES_CORRIENTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.AcumuladoSeguroHogar), updateCredito.CRE_ACUMULADO_SEGURO_HOGAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.AcumuladoSeguroVida), updateCredito.CRE_ACUMULADO_SEGURO_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.FechaUltimoPagoInteresMora), updateCredito.CRE_FECHA_ULTIMO_PAGO_INTERES_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.FechaUltimoPagoInteresCorriente), updateCredito.CRE_FECHA_ULTIMO_PAGO_INTERES_CORRIENTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.FechaUltimoPagoSeguroHogar), updateCredito.CRE_FECHA_ULTIMO_PAGO_SEGURO_HOGAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.FechaUltimoPagoSeguroVida), updateCredito.CRE_FECHA_ULTIMO_PAGO_SEGURO_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.AlivioFrech), updateCredito.CRE_ALIVIO_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.NumeroCuotasCanceladas), updateCredito.CRE_NUMERO_CUOTAS_CANCELADAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.CreadoPor), updateCredito.CRE_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.FechaCreacion), updateCredito.CRE_FECHA_CREACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.ModificadoPor), updateCredito.CRE_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActualizarCreditoParams.FechaModificacion), updateCredito.CRE_FECHA_MODIFICACION);
           

            return await GetAsyncFirst<InformacionCredito>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aplicacionPago"></param>
        /// <returns></returns>
        public async Task<AplicacionPago> AplicarPago(AplicacionPago aplicacionPago)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.IdAplicacionPago), aplicacionPago.CPG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.IdCredito), aplicacionPago.CRE_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.FechaPago), aplicacionPago.CPG_FECHA_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.FechaAplicacion), aplicacionPago.CPG_FECHA_APLICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.AbonoSeguroHogar), aplicacionPago.CPG_ABONO_SEGURO_HOGAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.AbonoSeguroVida), aplicacionPago.CPG_ABONO_SEGURO_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.AbonoInteresCorriente), aplicacionPago.CPG_ABONO_INTERES_CORRIENTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.AbonoInteresMora), aplicacionPago.CPG_ABONO_INTERES_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.AbonoCapital), aplicacionPago.CPG_ABONO_CAPITAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.ValorPago), aplicacionPago.CPG_VALOR_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.IdDct), aplicacionPago.DCT_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.CreadoPor), aplicacionPago.CPG_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.FechaCreacion), aplicacionPago.CPG_FECHA_CREACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.ModificadoPor), aplicacionPago.CPG_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.FechaModificacion), aplicacionPago.CPG_FECHA_MODIFICACION);

            return await GetAsyncFirst<AplicacionPago>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtener Abono Extra
        /// </summary>
        /// <param name="identificacion"></param>
        /// <returns></returns>
        public async Task<AbonoExtra> ObtenerAbonoExtra(string identificacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAbonoExtraParams.Identificacion), identificacion);

            return await GetAsyncFirst<AbonoExtra>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <Author>Sergio Ortega Fula</Author>
        /// <Date>19/10/2021</Date>
        public async Task<InformacionCredito> ObtenerCreditoCartera(int request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreditoCarteraParams.NumeroCredito), request);

            return await GetAsyncFirst<InformacionCredito>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene parametros pagos
        /// </summary>
        /// <returns></returns>
        public async Task<ParametrosAplicacionPagos> ObtenerParametrosAplicacionPagos()
        {
            return await GetAsyncFirst<ParametrosAplicacionPagos>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene los productos de cada cliente
        /// </summary>
        /// <param name="productoCliente"></param>
        /// <returns></returns>
        /// <Author>Sergio Ortega Fula</Author>
        /// <Date>06/09/2021</Date>
        public async Task<IEnumerable<ProductoCliente>> ObtenerProductoCliente(int tipoIdentificacion, string identificacion)

        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductosPorClienteParameters.identificacion), identificacion);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductosPorClienteParameters.tipoIdentificacion), tipoIdentificacion);

            var result = await GetAsyncList<ProductoCliente>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            return result;
        }

       

        /// <summary>
        /// Ejecutar desembolso
        /// </summary>
        /// <param name="producto"></param>
        /// <returns></returns>
        public async Task<ProductoCliente> EjecutarDesembolso(ProductoCliente producto)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.IdCredito), producto.CRE_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.FechaDesembolso), producto.CRE_FECHA_DESEMBOLSO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.ValorDesembolso), producto.CRE_VALOR_DESEMBOLSO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.ValorCuota), producto.CRE_VALOR_CUOTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.PlazoTotal), producto.CRE_PLAZO_TOTAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.IdTipoCredito), producto.TCR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.DiaPago), producto.CRE_DIA_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.IdEstadoCartera), producto.ESC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.FechaEstadoCartera), producto.CRE_FECHA_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.DiasMora), producto.CRE_DIAS_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.ValorVivienda), producto.CRE_VALOR_VIVIENDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.IdTipoVivienda), producto.TIV_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.IdTipoViviendaV), producto.TVV_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.SaldoCapital), producto.CRE_SALDO_CAPITAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.SaldoCapitalMora), producto.CRE_SALDO_CAPITAL_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.PlazoActual), producto.CRE_PLAZO_ACTUAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.TasaSeguroVida), producto.CRE_TASA_SEGURO_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.TasaSeguroHogar), producto.CRE_TASA_SEGURO_HOGAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.TasaCreditoEA), producto.CRE_TASA_CREDITO_EA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.TasaCreditoPer), producto.CRE_TASA_CREDITO_PER);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.TasaFrech), producto.CRE_TASA_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.ValorAlivioCuota), producto.CRE_VALOR_ALIVIO_CUOTA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.FechaUltimoPago), producto.CRE_FECHA_ULTIMO_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.FechaProximoPago), producto.CRE_FECHA_PROXIMO_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.TipoAbonoExtra), producto.CRE_TIPO_ABONO_EXTRA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.ValorAbonoExtra), producto.CRE_VALOR_ABONO_EXTRA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.ValorDeudaRemanente), producto.CRE_VALOR_DEUDA_REMANENTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.ValorCanonInicial), producto.CRE_VALOR_CANON_INICIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.ValorOpcionCompra), producto.CRE_VALOR_OPCION_COMPRA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.PorcentajeCanonInicial), producto.CRE_POR_CANON_INICIAL);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.PorcentajeOpcionCompra), producto.CRE_POR_OPCION_COMPRA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.AcumuladoInteresMora), producto.CRE_ACUMULADO_INTERES_MORA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.UltimoPagoInteresCorriente), producto.CRE_FECHA_ULTIMO_PAGO_INTERES_CORRIENTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.AcumuladoInteresCorriente), producto.CRE_ACUMULADO_INTERES_CORRIENTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.AcumuladoSeguroHogar), producto.CRE_ACUMULADO_SEGURO_HOGAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.UltimoPagoSeguroHogar), producto.CRE_FECHA_ULTIMO_PAGO_SEGURO_HOGAR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.AcumuladoSeguroVida), producto.CRE_ACUMULADO_SEGURO_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.UltimoPagoSeguroVida), producto.CRE_FECHA_ULTIMO_PAGO_SEGURO_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.AlivioFrech), producto.CRE_ALIVIO_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.NumeroCuotasCanceladas), producto.CRE_NUMERO_CUOTAS_CANCELADAS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.CreadoPor), producto.CRE_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.FechaCreacion), producto.CRE_FECHA_CREACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.ModificadoPor), producto.CRE_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.FechaModificacion), producto.CRE_FECHA_MODIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.NumeroCredito), producto.CRE_NRO_CREDITO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.Identificacion), producto.CLI_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.Score), producto.SOC_SCORE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.TipoIdentificacion), producto.TIPO_IDENTIFICACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.Categoria), producto.CATEGORIA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.Grado), producto.GRADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.DireccionInmueble), producto.CRE_DIRECCION_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.CiudadInmueble), producto.CIUDAD_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.NoMatricula), producto.NUMERO_MATRICULA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.Escritura), producto.ESCRITURA_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.FechaEscritura), producto.FECHA_ESCRITURA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.Notaria), producto.NOTARIA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.Linderos), producto.SIJ_LINDEROS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.DescripcionInmueble), producto.DESCRIPCION_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.FechaSolicitud), producto.FECHA_SOLICITUD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.FechaFinPagos), producto.CRE_FECHA_FINALIZA_PAGOS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.Edad), producto.CLI_EDAD);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.CanonExtraordinario), producto.CRE_CANON_EXTRAORDINARIO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.ClaseInmueble), producto.CLASE_INMUEBLE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.FechaCausacion), producto.CRE_FECHA_CAUSACION);

            parameters.Add(HelpersEnums.GetEnumDescription(EnumEjecucionDesembolsoParams.UltimoPagoInteresMora), producto.CRE_FECHA_ULTIMO_PAGO_INTERES_MORA);


            var result = await GetAsyncFirst<ProductoCliente>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            return result;
        }

        public async Task<ProductoCliente> PrepararEjecucionDesembolso(int tipoIdentificacion, string identificacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductosPorClienteParameters.identificacion), identificacion);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumProductosPorClienteParameters.tipoIdentificacion), tipoIdentificacion);

            var result = await GetAsyncFirst<ProductoCliente>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
            return result;
        }

        public async Task<TasaSimulador> ActualizarTasasSimulacion(TasaSimulador tasaUpdate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.IdSimulacion), tasaUpdate.SIM_ID );
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.Descripcion), tasaUpdate.SIM_DESCRIPCION );
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.TasaEA), tasaUpdate.SIM_TASA_EA );
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.MinimoPlazoMeses), tasaUpdate.SIM_MINIMO_MESES_PLAZO );
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.MaximoPlazoMeses), tasaUpdate.SIM_MAXIMO_MESES_PLAZO );
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.Estado), tasaUpdate.SIM_ESTADO );
            //parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.CreadoPor), tasaUpdate.SIM_CREADO_POR );
            //parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.FechaCreacion), tasaUpdate.SIM_FECHA_CREACION );
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.ModificadoPor), tasaUpdate.SIM_MODIFICADO_POR );
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.FechaModificacion), DateTime.Now);

            return await GetAsyncFirst<TasaSimulador>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TasaSimulador>> ObtenerTasasSimulador()
        {
            return await GetAsyncList<TasaSimulador>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<TasaSimulador> CrearTasasSimulacion(TasaSimulador tasaCreate )
        {
            DynamicParameters parameters = new DynamicParameters();
            //parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.IdSimulacion), tasaCreate.SIM_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.Descripcion), tasaCreate.SIM_DESCRIPCION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.TasaEA), tasaCreate.SIM_TASA_EA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.MinimoPlazoMeses), tasaCreate.SIM_MINIMO_MESES_PLAZO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.MaximoPlazoMeses), tasaCreate.SIM_MAXIMO_MESES_PLAZO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.Estado), 1);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.CreadoPor), tasaCreate.SIM_CREADO_POR );
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.FechaCreacion), DateTime.Now );
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.ModificadoPor), tasaCreate.SIM_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.FechaModificacion), DateTime.Now);

            return await GetAsyncFirst<TasaSimulador>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task <TasaSimulador> EliminarRegistroSimuladorPorId(TasaSimulador tasaDelete)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.IdSimulacion), tasaDelete.SIM_ID);

            return await GetAsyncFirst<TasaSimulador>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TasaSimulador>> ConsultarTipoActorById(TasaSimulador consultaExcepcion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.IdSimulacion), consultaExcepcion.SIM_ID);

            return await GetAsyncList<TasaSimulador>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<TipoActor>> ObtenerTipoActor()
        {
            
            return await GetAsyncList<TipoActor>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<ParametrosTasaActor> CrearTasaActor(ParametrosTasaActor actorCreate)
        {
            DynamicParameters parameters = new DynamicParameters();
            //parameters.Add(HelpersEnums.GetEnumDescription(EnumTasaSimuladorParams.IdSimulacion), tasaCreate.SIM_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.SimuladorId), actorCreate.SIM_ID);
            //parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.ParametroId), actorCreate.PAR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.TipoId), actorCreate.TPA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.ParametroTasaEa), actorCreate.PAR_TASA_EA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.ParametroCreadoPor), actorCreate.PAR_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.ParametroFechaCreacion), DateTime.Now);


           return await GetAsyncFirst <ParametrosTasaActor>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }


        public async Task<ParametrosTasaActor> ActualizarTasaSimuladorActor(ParametrosTasaActor actorUpdate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.ParametroId), actorUpdate.PAR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.TipoId), actorUpdate.TPA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.ParametroTasaEa), actorUpdate.PAR_TASA_EA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.ParametroModificadoPor), actorUpdate.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.ParametroFechaModificacion), DateTime.Now);
           

            return await GetAsyncFirst<ParametrosTasaActor>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<ParametrosTasaActor> EliminarParametroSimuladorActor(ParametrosTasaActor actorDelete)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumActorSimuladorParams.ParametroId), actorDelete.PAR_ID);

            return await GetAsyncFirst<ParametrosTasaActor>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

       public async Task<IEnumerable<UnidadesEjecutoras>> ObtenerUnidadesEjecutorasPorId(UnidadesEjecutoras consultaUnidadEjecutora)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.idSimulacion), consultaUnidadEjecutora.SIM_ID);

            return  await GetAsyncList<UnidadesEjecutoras>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<UnidadesEjecutoras> CrearUnidadEjecutoraSimulador(UnidadesEjecutoras unidadEjecutoraCreate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.idSimulacion), unidadEjecutoraCreate.SIM_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.idUnidadEjecutora), unidadEjecutoraCreate.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.tasaEa), unidadEjecutoraCreate.PAR_TASA_EA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.creadoPor), unidadEjecutoraCreate.PAR_CREADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.fechaCreacion), DateTime.Now);


            return await GetAsyncFirst<UnidadesEjecutoras>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UnidadesEjecutoras>> ConsultarUnidadEjecutora()
        {

            return await GetAsyncList<UnidadesEjecutoras>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<UnidadesEjecutoras> ActualizarUnidadEjecutoraSimulador(UnidadesEjecutoras unidadEjecutoraUpdate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.idParametro), unidadEjecutoraUpdate.PAR_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.idUnidadEjecutora), unidadEjecutoraUpdate.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.tasaEa), unidadEjecutoraUpdate.PAR_TASA_EA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.modificadoPor), unidadEjecutoraUpdate.PAR_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.fechaModificacion), DateTime.Now);


            return await GetAsyncFirst<UnidadesEjecutoras>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<UnidadesEjecutoras> EliminarUnidadEjecutoraSimulador(UnidadesEjecutoras unidadEjecutoraDelete)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUnidadesEjecutorasParams.idParametro), unidadEjecutoraDelete.PAR_ID);

            return await GetAsyncFirst<UnidadesEjecutoras>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
       }

        public async Task<ParamGeneralesCreditoYCartera> ObtenerParamGeneralesCreditoYCartera()
        {

            return await GetAsyncFirst<ParamGeneralesCreditoYCartera>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task<ParamGeneralesCreditoYCartera> ActualizarParamGeneralesCreditoYCartera(ParamGeneralesCreditoYCartera paramCreditoYCarteraUpdate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.parametroSalarioMinimo), paramCreditoYCarteraUpdate.PRM_SMLV);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.porcentajeInflacion), paramCreditoYCarteraUpdate.PRM_PORC_INFLACION);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.porcentajeViviendaVis), paramCreditoYCarteraUpdate.PRM_PORC_FINANCIA_VIS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.porcentajeViviendaNoVis), paramCreditoYCarteraUpdate.PRM_PORC_FINANCIA_NO_VIS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.limiteSalariosVis), paramCreditoYCarteraUpdate.PRM_NO_SALARIO_MIN_VIS);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.diasPreaprobado), paramCreditoYCarteraUpdate.PRM_DIAS_VALIDO_PREAPROB);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.puntajeMinimoCentrales), paramCreditoYCarteraUpdate.PRM_SCORE_MINIMO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.porcentajeMinimoEndeudamiento), paramCreditoYCarteraUpdate.PRM_PORC_CAPACIDAD_ENDEUDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.vigenciaDiasConsultaCentrales), paramCreditoYCarteraUpdate.PRM_VIGENCIA_CONSULTA_BURO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.porcentajeMinimoCanonInicial), paramCreditoYCarteraUpdate.PRM_PORC_CANON_INI_LSG);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.porcentajeMaximoCanonInicial), paramCreditoYCarteraUpdate.PRM_PORC_CANON_FIN_LSG);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.porcentajeMaximoOpcionCompra), paramCreditoYCarteraUpdate.PRM_PORC_OPC_COMPRA_LSG);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.maximoMesesAlivioTasa), paramCreditoYCarteraUpdate.PRM_MESES_LEY_FRECH);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesCreditoYCartera.numeroMesesAlivio), paramCreditoYCarteraUpdate.PRM_MESES_SUBSIDIO_CUOTA);


            return await GetAsyncFirst<ParamGeneralesCreditoYCartera>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<InformacionCredito> ObtenerCreditoCarteraByIdentificacion(string identificacion)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumCreditoCarteraParams.Identificacion), identificacion);

            return await GetAsyncFirst<InformacionCredito>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        //endpoints excepcion plazo credito
        public async Task<IEnumerable<ParamGeneralesExcepcionPlazo>> ObtenerParametrosGeneralesPlazoCredito()
        {
            return await GetAsyncList<ParamGeneralesExcepcionPlazo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }
        
        public async Task<ParamGeneralesExcepcionPlazo> CrearExcepcionPlazo(ParamGeneralesExcepcionPlazo plazoCreate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMinimoAnio), plazoCreate.PLAZ_YEAR_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMinimoMes), plazoCreate.PLAZ_MONTH_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMaximoAnio), plazoCreate.PLAZ_YEAR_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMaximoMes), plazoCreate.PLAZ_MONTH_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoModificadoPor), plazoCreate.PLAZ_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoFechaModificacion), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.IdTipoActor), plazoCreate.TPA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.tipoCredito), plazoCreate.TCR_ID);


            return await GetAsyncFirst<ParamGeneralesExcepcionPlazo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
        
        public async Task<ParamGeneralesExcepcionPlazo> ActualizarParametrosGeneralesPlazoCredito(ParamGeneralesExcepcionPlazo plazo)

        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoId), plazo.PLAZ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMinimoAnio), plazo.PLAZ_YEAR_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMinimoMes), plazo.PLAZ_MONTH_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMaximoAnio), plazo.PLAZ_YEAR_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMaximoMes), plazo.PLAZ_MONTH_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoFechaModificacion), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoEstado), plazo.PLAZ_ESTADO);
            

            return await GetAsyncFirst<ParamGeneralesExcepcionPlazo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }


        public async Task<ParamGeneralesExcepcionPlazo> EliminarExcepcionPlazo(ParamGeneralesExcepcionPlazo plazoDelete)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoId), plazoDelete.PLAZ_ID);

            return await GetAsyncFirst<ParamGeneralesExcepcionPlazo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<ParamGeneralesExcepcionPlazo> ActualizarExcepcionesPlazo(ParamGeneralesExcepcionPlazo excepcionUpdate)

        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoId), excepcionUpdate.PLAZ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMinimoAnio), excepcionUpdate.PLAZ_YEAR_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMinimoMes), excepcionUpdate.PLAZ_MONTH_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMaximoAnio), excepcionUpdate.PLAZ_YEAR_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMaximoMes), excepcionUpdate.PLAZ_MONTH_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoFechaModificacion), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoEstado), excepcionUpdate.PLAZ_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.IdTipoActor), excepcionUpdate.TPA_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.idExcepcion), excepcionUpdate.ID_EXE_PLAZO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoModificadoPor), excepcionUpdate.PLAZ_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.tipoCredito), excepcionUpdate.TCR_ID);

            return await GetAsyncFirst<ParamGeneralesExcepcionPlazo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ParamGeneralesExcepcionPlazo>> ObtenerExcepcionesPlazo(ParamGeneralesExcepcionPlazo getPlazo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.tipoCredito), getPlazo.TCR_ID);


            return await GetAsyncList<ParamGeneralesExcepcionPlazo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<ParamGeneralesExcepcionPlazo>> ObtenerExcepcionPlazoPorUnidadEjecutora(ParamGeneralesExcepcionPlazo getPlazo)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.tipoCredito), getPlazo.TCR_ID);


            return await GetAsyncList<ParamGeneralesExcepcionPlazo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<ParamGeneralesExcepcionPlazo> CrearExcepcionPlazoUnidadEjecutora(ParamGeneralesExcepcionPlazo plazoCreate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMinimoAnio), plazoCreate.PLAZ_YEAR_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMinimoMes), plazoCreate.PLAZ_MONTH_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMaximoAnio), plazoCreate.PLAZ_YEAR_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMaximoMes), plazoCreate.PLAZ_MONTH_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoModificadoPor), plazoCreate.PLAZ_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoFechaModificacion), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.unidadEjecutoraId), plazoCreate.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.tipoCredito), plazoCreate.TCR_ID);


            return await GetAsyncFirst<ParamGeneralesExcepcionPlazo>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<ParamGeneralesExcepcionPlazo> ActualizarExcepcionPlazoUnidadEjecutora(ParamGeneralesExcepcionPlazo excepcionUpdate)

        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoId), excepcionUpdate.PLAZ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMinimoAnio), excepcionUpdate.PLAZ_YEAR_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMinimoMes), excepcionUpdate.PLAZ_MONTH_MIN);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMaximoAnio), excepcionUpdate.PLAZ_YEAR_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoMaximoMes), excepcionUpdate.PLAZ_MONTH_MAX);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoFechaModificacion), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoEstado), excepcionUpdate.PLAZ_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.unidadEjecutoraId), excepcionUpdate.UEJ_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.idExcepcionPlazo), excepcionUpdate.ID_EXC_PLAZO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.plazoModificadoPor), excepcionUpdate.PLAZ_MODIFICADO_POR);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamGeneralesExcepcionPlazo.tipoCredito), excepcionUpdate.TCR_ID);

            return await GetAsyncFirst<ParamGeneralesExcepcionPlazo>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }


        //endpoints seguro general

        public async Task<IEnumerable<ParamGeneralesSeguros>> ObtenerSeguroGeneral()
        {
            return await GetAsyncList<ParamGeneralesSeguros>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }


        public async Task<ParamGeneralesSeguros> ActualizarSeguroGeneral(ParamGeneralesSeguros segurosUpdate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.idSeguro), segurosUpdate.SEG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.seguroVida), segurosUpdate.SEG_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.seguroTodoRiesgo), segurosUpdate.SEG_TODO_RIESGO);

            return await GetAsyncFirst<ParamGeneralesSeguros>(HelperDBParameters.BuilderFunction(
                HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }

        //endpoints excepcion por municipio

        public async Task<IEnumerable<ParamGeneralesSeguros>> ObtenerExcepSeguroPorMunicipio()
        {
            return await GetAsyncList<ParamGeneralesSeguros>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);
        }

        public async Task <ParamGeneralesSeguros> CrearExcepcionPorMunicipio (ParamGeneralesSeguros seguroExcepcionCreate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.departamentoId), seguroExcepcionCreate.DPP_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.departamentoCodigo), seguroExcepcionCreate.DPD_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.ciudadId), seguroExcepcionCreate.DPC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.ciudadCodigo), seguroExcepcionCreate.DPC_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.idSeguro), seguroExcepcionCreate.SEG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.seguroVida), seguroExcepcionCreate.SEG_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.seguroEstado), seguroExcepcionCreate.SEG_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.seguroTodoRiesgo), seguroExcepcionCreate.SEG_TODO_RIESGO);

            return await GetAsyncFirst<ParamGeneralesSeguros>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }
        
        public async Task <ParamGeneralesSeguros> ActualizarExcepSeguroPorMunicipio(ParamGeneralesSeguros seguroExcepcionUpdate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.idExcepcionSeguro), seguroExcepcionUpdate.ID_EXC_SEGURO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.departamentoId), seguroExcepcionUpdate.DPP_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.departamentoCodigo), seguroExcepcionUpdate.DPD_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.ciudadId), seguroExcepcionUpdate.DPC_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.ciudadCodigo), seguroExcepcionUpdate.DPC_CODIGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.idSeguro), seguroExcepcionUpdate.SEG_ID);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.seguroVida), seguroExcepcionUpdate.SEG_VIDA);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.seguroEstado), seguroExcepcionUpdate.SEG_ESTADO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.seguroFechaModificacion), DateTime.Now);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.seguroTodoRiesgo), seguroExcepcionUpdate.SEG_TODO_RIESGO);

            return await GetAsyncFirst<ParamGeneralesSeguros>(HelperDBParameters.BuilderFunction(
               HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        public async Task<ParamGeneralesSeguros> EliminarExcepcionSeguroPorMunicipio(ParamGeneralesSeguros seguroExcepcionDelete)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumSeguroGeneral.idSeguro), seguroExcepcionDelete.SEG_ID);

            return await GetAsyncFirst<ParamGeneralesSeguros>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);
        }

        /// <summary>
        /// Obtiene la liquidacion general params
        /// </summary>
        /// <returns></returns>
        public async Task<DatosLiquidacion> ObtenerLiquidacionGeneral()
        {
            return await GetAsyncFirst<DatosLiquidacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), null, CommandType.StoredProcedure);

        }

        /// <summary>
        /// Actualiza params generales liquidacion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DatosLiquidacion> ActualizarLiquidacionGeneral(DatosLiquidacion request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamsLiquidacion.FechaPago), request.LIQ_FECHA_PAGO);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamsLiquidacion.FechaCorte), request.LIQ_FECHA_CORTE);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumParamsLiquidacion.FechaModificacion), request.LIQ_FECHA_MODIFICACION);
           
            return await GetAsyncFirst<DatosLiquidacion>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), parameters, CommandType.StoredProcedure);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AplicacionPago>> ObtenerAplicacionPago(Guid request)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumAplicarPago.IdCredito), request);
            return await GetAsyncList<AplicacionPago>(HelperDBParameters.BuilderFunction(HelperDBParameters.EnumSchemas.DBO), 
                parameters, CommandType.StoredProcedure);

        }
    }
}
