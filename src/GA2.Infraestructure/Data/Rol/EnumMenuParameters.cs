using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Menu parametros dapper
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>28/04/2021</date>
    public enum EnumMenuParameters
    {
        [Description("@MNU_ID")]
        MNU_ID,

        [Description("@APP_ID")]
        APP_ID,

        [Description("@MNU_DESCRIPCION")]
        MNU_DESCRIPCION,

        [Description("@MNU_VISIBLE")]
        MNU_VISIBLE,

        [Description("@FRM_ID")]
        FRM_ID,

        [Description("@MNU_LINK")]
        MNU_LINK,

        [Description("@MNU_ICONO")]
        MNU_ICONO,

        [Description("@MNU_MODIFICADOPOR")]
        MNU_MODIFICADOPOR,

        [Description("@MNU_FECHAMODIFICACION")]
        MNU_FECHAMODIFICACION,

        [Description("@MNU_CREADOPOR")]
        MNU_CREADOPOR,

        [Description("@MNU_FECHACREACION")]
        MNU_FECHACREACION,

        [Description("@MNU_ESTADO")]
        MNU_ESTADO,
    }
}