using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumFlujoParametros
    {
        [Description("@FLU_ID")]
        FLU_ID,

        [Description("@FLU_DESCRIPCION")]
        FLU_DESCRIPCION,
        [Description("@FLU_ORDEN")]
        FLU_ORDEN,
        [Description("@FLU_ESTADO")]
        FLU_ESTADO,

        [Description("@FLU_CREADO_POR")]
        FLU_CREADO_POR,

        [Description("@FLU_FECHA_CREACION")]
        FLU_FECHA_CREACION,

        [Description("@FLU_MODIFICADO_POR")]
        FLU_MODIFICADO_POR,
        [Description("@FLU_FECHA_MODIFICACION")]
        FLU_FECHA_MODIFICACION


    }
}
