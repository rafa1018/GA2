using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Parametros entidad Formulario
    /// <author>Oscar julian Rojas</author>
    /// <date>21/04/2021</date>
    /// </summary>
    public enum EnumFormularioParametros
    {
        [Description("@FRM_ID")]
        FRM_ID,

        [Description("@SBM_ID")]
        SBM_ID,

        [Description("@FRM_DESCRIPCION")]
        FRM_DESCRIPCION,

        [Description("@FRM_VISIBLE")]
        FRM_VISIBLE,

        [Description("@FRM_MODIFICADOPOR")]
        FRM_MODIFICADOPOR,

        [Description("@FRM_FECHAMODIFICACION")]
        FRM_FECHAMODIFICACION,

        [Description("@FRM_CREADOPOR")]
        FRM_CREADOPOR,

        [Description("@FRM_FECHACREACION")]
        FRM_FECHACREACION,

        [Description("@FRM_ESTADO")]
        FRM_ESTADO,
    }
}
