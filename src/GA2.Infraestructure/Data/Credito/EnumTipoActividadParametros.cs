using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumTipoActividadParametros
    {
        [Description("@TAC_ID")]
        TAC_ID,

        [Description("@TAC_DESCRIPCION")]
        TAC_DESCRIPCION,

        [Description("@TAC_ESTADO")]
        TAC_ESTADO,

        [Description("@TAC_CREADO_POR")]
        TAC_CREADO_POR,

        [Description("@TAC_FECHA_CREACION")]
        TAC_FECHA_CREACION,

        [Description("@TAC_MODIFICADO_POR")]
        TAC_MODIFICADO_POR,

        [Description("@TAC_FECHA_MODIFICACION")]
        TAC_FECHA_MODIFICACION

    }
}
