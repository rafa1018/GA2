using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Enumeracion de rol parameters
    /// </summary>
    /// <autor>Oscar Julian Rojas</autor>
    /// <date>28/04/2021</date>
    public enum EnumRolParameters
    {
        [Description("@RL_ID")]
        RL_ID,

        [Description("@RL_DESCRIPCION")]
        RL_DESCRIPCION,

        [Description("@RL_FECHACREACION")]
        RL_FECHACREACION,

        [Description("@RL_CREADOPOR")]
        RL_CREADOPOR,

        [Description("@RL_MODIFICADOPOR")]
        RL_MODIFICADOPOR,

        [Description("@RL_FECHAMODIFICACION")]
        RL_FECHAMODIFICACION,

        [Description("@RL_ESTADO")]
        RL_ESTADO
    }
}

