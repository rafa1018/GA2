using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Parametros para el blob storage
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>06/05/2021</date>
    public enum EmunBlobstorageParameters
    {
        [Description("@ID")]
        ID,

        [Description("@CONTAINERNAME")]
        CONTAINERNAME,

        [Description("@BLOBNAME")]
        BLOBNAME,

        [Description("@MODULO")]
        MODULO,

        [Description("@FILE")]
        FILE,

        [Description("@MODIFICADOPOR")]
        MODIFICADOPOR,

        [Description("@FECHAMODIFICACION")]
        FECHAMODIFICACION,

        [Description("@CREADOPOR")]
        CREADOPOR,

        [Description("@FECHACREACION")]
        FECHACREACION,

        [Description("@ESTADO")]
        ESTADO
    }
}
