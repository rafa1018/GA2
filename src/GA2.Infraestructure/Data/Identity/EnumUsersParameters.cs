using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Enum parametros Users
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>24/02/2021</date>
    /// </summary>
    public enum EnumUsersParameters
    {
        [Description("@USR_ID")]
        USR_ID,
        [Description("@USR_NOMBRE")]
        USR_NOMBRE,
        [Description("@USR_SEGUNDONOMBRE")]
        USR_SEGUNDONOMBRE,
        [Description("@USR_APELLIDO")]
        USR_APELLIDO,
        [Description("@USR_SEGUNDOAPELLIDO")]
        USR_SEGUNDOAPELLIDO,
        [Description("@USR_EMAIL")]
        USR_EMAIL,
        [Description("@USR_USERNAME")]
        USR_USERNAME,
        [Description("@USR_PASSWORD")]
        USR_PASSWORD,
        [Description("@RL_ID")]
        RL_ID,
        [Description("@USR_IDENTIFICACION")]
        USR_IDENTIFICACION,
        [Description("@TID_ID")]
        TID_ID,
        [Description("@USR_FECHAMODIFICACION")]
        USR_FECHAMODIFICACION,
        [Description("@USR_MODIFICADOPOR")]
        USR_MODIFICADOPOR,
        [Description("@USR_CREADOPOR")]
        USR_CREADOPOR,
        [Description("@USR_FECHACREACION")]
        USR_FECHACREACION,
        [Description("@USR_ESTADO")]
        USR_ESTADO,
        [Description("@TOKEN")]
        TOKEN,
        [Description("@ACTIVE_DIRECTORY")]
        ACTIVE_DIRECTORY,
    }
}
