using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Enumeracion de parametros submenu
    /// </summary>
    /// <autor>Oscar Julian Rojas</autor>
    /// <date>28/04/2021</date>
    public enum EnumSumbMenuParameters
    {
        [Description("@FRM_ID")]
        FRM_ID,

        [Description("@SBM_ID")]
        SBM_ID,

        [Description("@MNU_ID")]
        MNU_ID,

        [Description("@SBM_LINK")]
        SBM_LINK,

        [Description("@SBM_ICONO")]
        SBM_ICONO,

        [Description("@SBM_DESCRIPCION")]
        SBM_DESCRIPCION,

        [Description("@SBM_VISIBLE")]
        SBM_VISIBLE,

        [Description("@SBM_MODIFICADOPOR")]
        SBM_MODIFICADOPOR,

        [Description("@SBM_FECHAMODIFICACION")]
        SBM_FECHAMODIFICACION,

        [Description("@SBM_CREADOPOR")]
        SBM_CREADOPOR,

        [Description("@SBM_FECHACREACION")]
        SBM_FECHACREACION,

        [Description("@SBM_ESTADO")]
        SBM_ESTADO,
    }
}

