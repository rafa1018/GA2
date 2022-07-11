using System.ComponentModel;

namespace GA2.Infraestructure.Data.State
{
    /// <summary>
    /// Data de estado
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public enum EnumEstadoParameters
    {
        [Description("@ID")]
        ID,

        [Description("@CODIGO")]
        CODIGO,

        [Description("@CONCEPTO")]
        CONCEPTO,

        [Description("@DIASMORAACTIVAESTADO")]
        DIASMORAACTIVAESTADO,

        [Description("@SALDODEUDA")]
        SALDODEUDA,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@ESTADO")]
        ESTADO
    }
}