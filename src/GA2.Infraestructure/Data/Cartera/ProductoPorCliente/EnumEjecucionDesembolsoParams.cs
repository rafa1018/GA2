using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumEjecucionDesembolsoParams
    {
        [Description("@CRE_ID")]
        IdCredito,

        [Description("@SOC_SCORE")]
        Score,

        [Description("@CRE_FECHA_DESEMBOLSO")]
        FechaDesembolso,

        [Description("@CRE_VALOR_DESEMBOLSO")]
        ValorDesembolso,

        [Description("@CRE_VALOR_CUOTA")]
        ValorCuota,

        [Description("@CRE_PLAZO_TOTAL")]
        PlazoTotal,

        [Description("@TCR_ID")]
        IdTipoCredito,

        [Description("@CRE_DIA_PAGO")]
        DiaPago,

        [Description("@ESC_ID")]
        IdEstadoCartera,

        [Description("@CRE_FECHA_ESTADO")]
        FechaEstadoCartera,

        [Description("@CRE_DIAS_MORA")]
        DiasMora,

        [Description("@CRE_VALOR_VIVIENDA")]
        ValorVivienda,

        [Description("@TIV_ID")]
        IdTipoVivienda,

        [Description("@TVV_ID")]
        IdTipoViviendaV,

        [Description("@CRE_SALDO_CAPITAL")]
        SaldoCapital,

        [Description("@CRE_SALDO_CAPITAL_MORA")]
        SaldoCapitalMora,

        [Description("@CRE_PLAZO_ACTUAL")]
        PlazoActual,

        [Description("@CRE_TASA_SEGURO_VIDA")]
        TasaSeguroVida,

        [Description("@CRE_TASA_SEGURO_HOGAR")]
        TasaSeguroHogar,

        [Description("@CRE_TASA_CREDITO_EA")]
        TasaCreditoEA,

        [Description("@CRE_TASA_CREDITO_PER")]
        TasaCreditoPer,

        [Description("@CRE_TASA_FRECH")]
        TasaFrech,

        [Description("@CRE_VALOR_ALIVIO_CUOTA")]
        ValorAlivioCuota,

        [Description("@CRE_FECHA_ULTIMO_PAGO")]
        FechaUltimoPago,

        [Description("@CRE_FECHA_PROXIMO_PAGO")]
        FechaProximoPago,

        [Description("@CRE_TIPO_ABONO_EXTRA")]
        TipoAbonoExtra,

        [Description("@CRE_VALOR_ABONO_EXTRA")]
        ValorAbonoExtra,

        [Description("@CRE_VALOR_DEUDA_REMANENTE")]
        ValorDeudaRemanente,

        [Description("@CRE_VALOR_CANON_INICIAL")]
        ValorCanonInicial,

        [Description("@CRE_VALOR_OPCION_COMPRA")]
        ValorOpcionCompra,

        [Description("@CRE_POR_CANON_INICIAL")]
        PorcentajeCanonInicial,

        [Description("@CRE_POR_OPCION_COMPRA")]
        PorcentajeOpcionCompra,

        [Description("@CRE_ACUMULADO_INTERES_MORA")]
        AcumuladoInteresMora,

        [Description("@CRE_FECHA_ULTIMO_PAGO_INTERES_MORA")]
        UltimoPagoInteresMora,

        [Description("@CRE_ACUMULADO_INTERES_CORRIENTE")]
        AcumuladoInteresCorriente,

        [Description("@CRE_FECHA_ULTIMO_PAGO_INTERES_CORRIENTE")]
        UltimoPagoInteresCorriente,

        [Description("@CRE_ACUMULADO_SEGURO_HOGAR")]
        AcumuladoSeguroHogar,

        [Description("@CRE_FECHA_ULTIMO_PAGO_SEGURO_HOGAR")]
        UltimoPagoSeguroHogar,

        [Description("@CRE_ACUMULADO_SEGURO_VIDA")]
        AcumuladoSeguroVida,

        [Description("@CRE_FECHA_ULTIMO_PAGO_SEGURO_VIDA")]
        UltimoPagoSeguroVida,

        [Description("@CRE_ALIVIO_FRECH")]
        AlivioFrech,

        [Description("@CRE_NUMERO_CUOTAS_CANCELADAS")]
        NumeroCuotasCanceladas,

        [Description("@CRE_CREADO_POR")]
        CreadoPor,

        [Description("@CRE_FECHA_CREACION")]
        FechaCreacion,

        [Description("@CRE_MODIFICADO_POR")]
        ModificadoPor,

        [Description("@CRE_FECHA_MODIFICACION")]
        FechaModificacion,

        [Description("@CRE_NRO_CREDITO")]
        NumeroCredito,

        [Description("@CLI_IDENTIFICACION")]
        Identificacion,

        [Description("@TIPO_IDENTIFICACION")]
        TipoIdentificacion,

        [Description("@CATEGORIA")]
        Categoria,
        [Description("@GRADO")]
        Grado,
        [Description("@CRE_DIRECCION_INMUEBLE")]
        DireccionInmueble,
        [Description("@CIUDAD_INMUEBLE")]
        CiudadInmueble,
        [Description("@NUMERO_MATRICULA")]
        NoMatricula,
        [Description("@ESCRITURA_INMUEBLE")]
        Escritura,
        [Description("@FECHA_ESCRITURA")]
        FechaEscritura,
        [Description("@NOTARIA")]
        Notaria,
        [Description("@SIJ_LINDEROS")]
        Linderos,
        [Description("@DESCRIPCION_INMUEBLE")]
        DescripcionInmueble,
        [Description("@FECHA_SOLICITUD")]
        FechaSolicitud,
        [Description("@CRE_FECHA_FINALIZA_PAGOS")]
        FechaFinPagos,
        [Description("@CLI_EDAD")]
        Edad,
        [Description("@CRE_CANON_EXTRAORDINARIO")]
        CanonExtraordinario,
        [Description("@CLASE_INMUEBLE")]
        ClaseInmueble,
        [Description("@CRE_FECHA_CAUSACION")]
        FechaCausacion
    }
}
