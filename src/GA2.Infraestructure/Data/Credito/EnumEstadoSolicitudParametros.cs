using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumEstadoSolicitudParametros
    {
        [Description("@ESS_ID")]
        ESS_ID,
        [Description("@ESS_DESCRIPCION")]
        ESS_DESCRIPCION,
        [Description("@ESS_SIGLA")]
        ESS_SIGLA,
        [Description("@ESS_ESTADO")]
        ESS_ESTADO,
        [Description("@ESS_CREADO_POR")]
        ESS_CREADO_POR,
        [Description("@ESS_FECHA_CREACION")]
        ESS_FECHA_CREACION,
        [Description("@ESS_MODIFICADO_POR")]
        ESS_MODIFICADO_POR,
        [Description("@ESS_FECHA_MODIFICACION")]
        ESS_FECHA_MODIFICACION
    }
}
