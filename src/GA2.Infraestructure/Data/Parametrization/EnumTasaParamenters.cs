using System.ComponentModel;

namespace GA2.Infraestructure.Data.Parametrization
{
    /// <summary>
    /// Data de parametrizacion de tasas
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>08/04/2021</date>
    /// </summary>
    public enum EnumRateParameters
    {
        [Description("@ID")]
        ID,

        [Description("@TASAUSURAEA")]
        TASAUSURAEA,

        [Description("@TASAUSURANM")]
        TASAUSURANM,

        [Description("@TASACORRIENTEEA")]
        TASACORRIENTEEA,

        [Description("@TASACORRIENTENM")]
        TASACORRIENTENM,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@ESTADO")]
        ESTADO
    }
}
