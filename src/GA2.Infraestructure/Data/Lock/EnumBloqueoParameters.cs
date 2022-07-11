using System.ComponentModel;

namespace GA2.Infraestructure.Data.Lock
{
    /// <summary>
    /// Data de bloqueo
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>20/04/2021</date>
    /// </summary>
    public enum EnumBloqueoParameters
    {
        [Description("@ID")]
        ID,

        [Description("@CODIGO")]
        CODIGO,

        [Description("@CONCEPTO")]
        CONCEPTO,

        [Description("@DIASMORA")]
        DIASMORA,

        [Description("@REVERSIBLE")]
        REVERSIBLE,

        [Description("@ACELERACIONDEUDA")]
        ACELERACIONDEUDA,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@ESTADO")]
        ESTADO
    }
}