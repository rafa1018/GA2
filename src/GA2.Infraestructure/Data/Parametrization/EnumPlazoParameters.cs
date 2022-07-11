using System.ComponentModel;

namespace GA2.Infraestructure.Data.Parametrization
{
    /// <summary>
    /// Data de parametrizacion de plazos
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>08/04/2021</date>
    /// </summary>
    public enum EnumPlazoParameters
    {
        [Description("@ID")]
        ID,

        [Description("@YEARMIN")]
        YEARMIN,

        [Description("@MONTHMIN")]
        MONTHMIN,

        [Description("@YEARMAX")]
        YEARMAX,

        [Description("@MONTHMAX")]
        MONTHMAX,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@ESTADO")]
        ESTADO
    }
}
