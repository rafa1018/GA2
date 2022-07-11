using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnmuCrearTemaComiteCreditoParams
    {
        [Description("@COT_ID")]
        idTema,

        [Description("@COC_ID")]
        idComiteCredito,

        [Description("@TCO_ID")]
        codigoTema,

        [Description("@COT_ORDEN")]
        orden,

        [Description("@COT_OBSERVACION")]
        observacion,

        [Description("@COT_CREADO_POR")]
        creadoPor,

        [Description("@COT_FECHA_CREACION")]
        fechaCreacion
    }
}
