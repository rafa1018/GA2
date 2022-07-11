using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumSolicitudActividadTramiteParameters
    {
        [Description("@AFL_ID")]
        AFL_ID,

        [Description("@TRS_ID")]
        TRS_ID,

        [Description("@ACT_OBSERVACION")]
        ACT_OBSERVACION,

        [Description("@ACT_MODIFICADO_POR")]
        ACT_MODIFICADO_POR,

        [Description("@ACT_FECHA_MODIFICACION")]
        ACT_FECHA_MODIFICACION
    }
}
