using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumAplicarPago
    {
        [Description("@CPG_ID")]
        IdAplicacionPago,

        [Description("@CRE_ID")]
        IdCredito,

        [Description("@CPG_FECHA_PAGO")]
        FechaPago,

        [Description("@CPG_FECHA_APLICACION")]
        FechaAplicacion,

        [Description("@CPG_ABONO_SEGURO_HOGAR")]
        AbonoSeguroHogar,

        [Description("@CPG_ABONO_SEGURO_VIDA")]
        AbonoSeguroVida,

        [Description("@CPG_ABONO_INTERES_CORRIENTE")]
        AbonoInteresCorriente,

        [Description("@CPG_ABONO_INTERES_MORA")]
        AbonoInteresMora,

        [Description("@CPG_ABONO_CAPITAL")]
        AbonoCapital,

        [Description("@CPG_VALOR_PAGO")]
        ValorPago,

        [Description("@DCT_ID")]
        IdDct,

        [Description("@CPG_CREADO_POR")]
        CreadoPor,

        [Description("@CPG_FECHA_CREACION")]
        FechaCreacion,

        [Description("@CPG_MODIFICADO_POR")]
        ModificadoPor,

        [Description("@CPG_FECHA_MODIFICACION")]
        FechaModificacion

    }
}
