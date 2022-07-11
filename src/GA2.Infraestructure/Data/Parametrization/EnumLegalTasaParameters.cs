using System.ComponentModel;

namespace GA2.Infraestructure.Data.Parametrization
{
    /// <summary>
    /// Data de parametrizacion legal tasa
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public enum EnumLegalTasaParameters
    {
        [Description("@ID")]
        ID,

        [Description("@TASAFRECH")]
        TASAFRECH,

        [Description("@VIGENCIATASAFRECH")]
        VIGENCIATASAFRECH,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@ESTADO")]
        ESTADO
    }
}
