using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GA2.Infraestructure.Data
{
    public enum EnumBloqueoCuentaConceptoParameters
    {
        [Description("@BCC_ID")]
        BCC_ID,

        [Description("@CSB_ID")]
        CSB_ID,

        [Description("@CTA_ID")]
        CTA_ID,

        [Description("@CCT_ID")]
        CCT_ID,

        [Description("@BCC_TIPO_BLOQUEO")]
        BCC_TIPO_BLOQUEO,

        [Description("@BCC_MONTO")]
        BCC_MONTO,

        [Description("@BCC_VALOR")]
        BCC_VALOR,

        [Description("@BCC_FECHA")]
        BCC_FECHA,

        [Description("@BCC_CREADOPOR")]
        BCC_CREADOPOR,

        [Description("@BCC_ESTADO")]
        BCC_ESTADO,


    }

    public enum EnumNuevaCuentaConceptoParameters
    {

        [Description("@CTA_ID_INTEGRACION")] CTA_ID_INTEGRACION,

        [Description("@CTA_NUMERO")] CTA_NUMERO,

        [Description("@CLI_ID")] CLI_ID,

        [Description("@TCT_ID")] TCT_ID,

        [Description("@ECT_ID")] ECT_ID,

        [Description("@CCN_ID")] CCN_ID,

        [Description("@DCT_ID")] DCT_ID,

        [Description("@CTA_FECHA_CREACION")] CTA_FECHA_CREACION,

        [Description("@CTA_FECHA_CIERRE")] CTA_FECHA_CIERRE,

        [Description("@CTA_FECHA_PRIMER_APORTE")] CTA_FECHA_PRIMER_APORTE,

        [Description("@CTA_SALDO ")] CTA_SALDO,

        [Description("@CTA_SALDO_CANJE")] CTA_SALDO_CANJE,

        [Description("@CTA_SALDO_DISPONIBLE")] CTA_SALDO_DISPONIBLE,

        [Description("@CTA_CUOTAS")] CTA_CUOTAS,

        [Description("@CTA_BLOQUEO")] CTA_BLOQUEO,

        [Description("@BCC_ID")] BCC_ID,

        [Description("@EJE_UNIDAD_EJECUTORA")] EJE_UNIDAD_EJECUTORA,


    }

}
