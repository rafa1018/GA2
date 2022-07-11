using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Lista de los parametros de un Movimiento de nomina
    /// </summary>
    /// <author>Nicolas Florez Sarrazola</author>
	/// <date>12/04/2021</date>
    public enum EnumMovimientoParameters
    {
        [Description("@MVT_ID")]
        Id,

        [Description("@CTA_ID")]
        Cuenta,

        [Description("@CNC_ID")]
        Concepto,

        [Description("@MVT_VALOR")]
        Valor,

        [Description("@CAT_TIPO_MOVIMIENTO")]
        TipoMovimiento,

        [Description("@MVT_FECHA_PROCESO")]
        FechaProceso,

        [Description("@DCT_ID")]
        IdDocumento,

        [Description("@MVT_ANO_PERIODO")]
        AñoAportes,

        [Description("@MVT_MES_PERIODO")]
        MesAportes,

        [Description("@MVT_FECHA_MOVIMIENTO")]
        FechaMovimiento,
    }
}
