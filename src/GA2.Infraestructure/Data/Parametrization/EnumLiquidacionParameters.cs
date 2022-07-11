using System.ComponentModel;

namespace GA2.Infraestructure.Data.Parametrization
{
    /// <summary>
    /// Data de parametrizacion liquidacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public enum EnumLiquidacionParameters
    {
        [Description("@ID")]
        ID,

        [Description("@FECHACORTE")]
        FECHACORTE,

        [Description("@FECHAPAGO")]
        FECHAPAGO,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@ESTADO")]
        ESTADO
    }
}
