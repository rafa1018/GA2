using System.ComponentModel;

namespace GA2.Infraestructure.Data.Parametrization
{
    /// <summary>
    /// Data de parametrizacion legal alivio
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public enum EnumLegalAlivioParameters
    {
        [Description("@ID")]
        ID,

        [Description("@ALIVIOCUOTA")]
        ALIVIOCUOTA,

        [Description("@VIGENCIAALIVIOCUOTA")]
        VIGENCIAALIVIOCUOTA,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@ESTADO")]
        ESTADO
    }
}
