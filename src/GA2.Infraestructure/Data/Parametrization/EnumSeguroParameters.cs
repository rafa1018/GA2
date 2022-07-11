using System.ComponentModel;

namespace GA2.Infraestructure.Data.Parametrization
{
    /// <summary>
    /// Data de parametrizacion de seguro
    /// <author>Andres Riaño</author>
    /// <date>15/03/2021</date>
    /// </summary>
    public enum EnumSeguroParameters
    {
        [Description("@ID")]
        ID,

        [Description("@VIDA")]
        VIDA,

        [Description("@TODORIESGO")]
        TODORIESGO,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@ESTADO")]
        ESTADO
    }
}
