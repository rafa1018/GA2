using System.ComponentModel;

namespace GA2.Infraestructure.Data.Parametrization
{
    /// <summary>
    /// Data de parametrizacion legal gmf
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public enum EnumLegalGmfParameters
    {
        [Description("@ID")]
        ID,

        [Description("@GMF")]
        GMF,

        [Description("@VIGENCIAGMF")]
        VIGENCIAGMF,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@ESTADO")]
        ESTADO
    }
}
