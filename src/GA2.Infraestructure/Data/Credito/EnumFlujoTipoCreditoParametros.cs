using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumFlujoTipoCreditoParametros
    {
        [Description("@FTC_ID")]
        FTC_ID,
        [Description("@FLU_ID")]
        FLU_ID,
        [Description("@TCR_ID")]
        TCR_ID,
        [Description("@FTC_ESTADO")]
        FTC_ESTADO,
        [Description("@FTC_CREADO_POR")]
        FTC_CREADO_POR,
        [Description("@FTC_FECHA_CREACION")]
        FTC_FECHA_CREACION,
        [Description("@FTC_MODIFICADO_POR")]
        FTC_MODIFICADO_POR,
        [Description("@FTC_FECHA_MODIFICACION")]
        FTC_FECHA_MODIFICACION
    }
}
