using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumCrearIntegranteParams
    {
        [Description("@COI_ID")]
        idIntegranteComite,

        [Description("@COC_ID")]
        idComiteCredito,

        [Description("@ICO_ID")]
        idAsistente,

        [Description("@COI_ORDEN")]
        orden,

        [Description("@COI_CREADO_POR")]
        creadoPor,

        [Description("@COI_FECHA_CREACION")]
        fechaCreacion

    }
}
