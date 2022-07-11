using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumEstadoActividadParametros
    {
        [Description("@ESA_ID")]
        ESA_ID,

        [Description("@ESA_DESCRIPCION")]
        ESA_DESCRIPCION,

        [Description("@ESA_ESTADO")]
        ESA_ESTADO,

        [Description("@ESA_CREADO_POR")]
        ESA_CREADO_POR,

        [Description("@ESA_FECHA_CREACION")]
        ESA_FECHA_CREACION,

        [Description("@ESA_MODIFICADO_POR")]
        ESA_MODIFICADO_POR,

        [Description("@ESA_FECHA_MODIFICACION")]
        ESA_FECHA_MODIFICACION

    }
}
