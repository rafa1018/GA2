using System.ComponentModel;

namespace GA2.Infraestructure.Data.Producto
{
    /// <summary>
    /// Lista de atributos de parametros de carga de nómina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
    /// <date>12/04/2021</date>
    public enum EnumProductoParameters
    {
        [Description("@PRD_ID")]
        PRD_ID,

        [Description("@TCR_ID")]
        TCR_ID,

        [Description("@PRD_NUMERO_CREDITO")]
        PRD_NUMERO_CREDITO,

        [Description("@PRD_FECHA_ALTA")]
        PRD_FECHA_ALTA,

        [Description("@PRD_ESTADO")]
        PRD_ESTADO,

        [Description("@PRD_FECHA_ESTADO")]
        PRD_FECHA_ESTADO,

        [Description("@PRD_FECHA_PAGO")]
        PRD_FECHA_PAGO,

        [Description("@PRD_DIAS_MORA")]
        PRD_DIAS_MORA,

        [Description("@PRD_VALOR")]
        PRD_VALOR,

        [Description("@TIV_VIVIENDA_ID")]
        TIV_VIVIENDA_ID,

        [Description("@ESV_ESTADO_VIVIENDA")]
        ESV_ESTADO_VIVIENDA,

        [Description("@PRD_CREDITO")]
        PRD_CREDITO,

        [Description("@PRD_DEUDA")]
        PRD_DEUDA,

        [Description("@PRD_MORA")]
        PRD_MORA,

        [Description("@PRD_CUOTA_ANO")]
        PRD_CUOTA_ANO,

        [Description("@PRD_CUOTA_MES")]
        PRD_CUOTA_MES,

        [Description("@PRD_SEGURO_VIDA")]
        PRD_SEGURO_VIDA,

        [Description("@PRD_SEGURO_TODO_RIESGO")]
        PRD_SEGURO_TODO_RIESGO,

        [Description("@PRD_TASA_EFECTIVA_ANUAL")]
        PRD_TASA_EFECTIVA_ANUAL,

        [Description("@PRD_TASA_NOMINAL_MENSUAL")]
        PRD_TASA_NOMINAL_MENSUAL,

        [Description("@PRD_TASA_FRECH_APLICA")]
        PRD_TASA_FRECH_APLICA,

        [Description("@PRD_TASA_FRECH")]
        PRD_TASA_FRECH,

        [Description("@PRD_ALIVIO_COUTA_APLICA")]
        PRD_ALIVIO_CUOTA_APLICA,

        [Description("@PRD_ALIVIO_CUOTA")]
        PRD_ALIVIO_CUOTA

    }
}
