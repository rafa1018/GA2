using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumCuentaParametros
    {
        [Description("@CLI_ID")]
        CLI_ID,

        [Description("@CTA_ID")]
        CTA_ID,

        [Description("@CNC_ID")]
        CNC_ID,

        [Description("@CTA_ID_INTEGRACION")]
        CTA_ID_INTEGRACION,

        [Description("@CTA_NUMERO")]
        CTA_NUMERO,

        [Description("@CTA_SUBCUENTA")]
        CTA_SUBCUENTA,

        [Description("@TCT_ID")]
        TCT_ID,

        [Description("@CTA_SALDO")]
        CTA_SALDO,

        [Description("@CTA_FECHA_CREACION")]
        CTA_FECHA_CREACION,

        [Description("@ECT_ID")]
        ECT_ID,

        [Description("@CCN_ID")]
        CCN_ID,

        [Description("@DCT_ID")]
        DCT_ID,

        [Description("@TPA_ID")]
        TPA_ID,

        [Description("@CTA_CUOTAS")]
        CTA_CUOTAS,

        [Description("@CTA_FECHA_CIERRE")]
        CTA_FECHA_CIERRE,

        [Description("@CTA_ID_CUENTAHABIENTE")]
        CTA_ID_CUENTAHABIENTE,

        [Description("@CTA_CUOTAS_PENDIENTES")]
        CTA_CUOTAS_PENDIENTES,

        [Description("@CTA_FECHA_PRIMER_APORTE")]
        CTA_FECHA_PRIMER_APORTE,

        [Description("@CTA_SALDO_CANJE")]
        CTA_SALDO_CANJE,

        [Description("@CTA_SALDO_DISPONIBLE")]
        CTA_SALDO_DISPONIBLE,

        [Description("@CTA_PRINCIPAL")]
        CTA_PRINCIPAL,

        [Description("@CTA_CREADO_POR")]
        CTA_CREADO_POR,

        [Description("@CTA_MODIFICADO_POR")]
        CTA_MODIFICADO_POR,

        [Description("@CTA_FECHA_MODIFICACION")]
        CTA_FECHA_MODIFICACION,

        [Description("@CTA_ESTADO")]
        CTA_ESTADO,
    }
}