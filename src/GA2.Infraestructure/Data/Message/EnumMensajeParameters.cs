using System.ComponentModel;

namespace GA2.Infraestructure.Data.Message
{
    /// <summary>
    /// Data de Mensaje
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>28/05/2021</date>
    /// </summary>
    public enum EnumMensajeParameters
    {
        [Description("@ID")]
        ID,

        [Description("@CODIGO")]
        CODIGO,

        [Description("@MENSAJE")]
        MENSAJE,

        [Description("@CREADOPOR")]
        CREADOPOR,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@FECHACREACION")]
        FECHACREACION,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@ESTADO")]
        ESTADO
    }
}