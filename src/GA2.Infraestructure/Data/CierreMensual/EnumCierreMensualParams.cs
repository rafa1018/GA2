using System.ComponentModel;

namespace GA2.Infraestructure.Data
{

    public enum EnumCierreMensualParams
    {
        [Description("@CNC_ID")]
        CNC_ID,

        [Description("@CONCEPTO")]
        CONCEPTOS,

        [Description("@TIPO_PROCESO")]
        TIPO_PROCESO,

        [Description("@GENERA_ACTUALIZACION")]
        GENERA_ACTUALIZACION,

        [Description("@CUENTA_ABONO_AHORRO")]
        CUENTA_ABONO_AHORRO,

        [Description("@CONCEPTOS_AHORRO")]
        CONCEPTOS_AHORRO,

        [Description("@CUENTA_ABONO_CESANTIAS")]
        CUENTA_ABONO_CESANTIAS,

        [Description("@CONCEPTOS_CESANTIAS")]
        CONCEPTOS_CESANTIAS,

        [Description("@IPC")]
        IPC,

        [Description("@ANIO")]
        ANIO,

        [Description("@MES")]
        MES,

        [Description("@USUARIO")]
        USUARIO,

        [Description("@ID")]
        ID_PROGRAMACION,

        [Description("@CCT_ID")]
        CCT_ID,

        [Description("@CCT_ESTADO")]
        CCT_ESTADO,


    }
}
