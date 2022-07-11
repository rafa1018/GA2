using System.ComponentModel;

namespace GA2.Infraestructure.Data.Notification
{
    /// <summary>
    /// Data de Notificacion
    /// <author>Camilo Andres Yaya Poveda</author>
    /// <date>17/05/2021</date>
    /// </summary>
    public enum EnumNotificacionParameters
    {
        [Description("@ID")]
        ID,

        [Description("@MENSAJE")]
        MENSAJE,

        [Description("@RECEPTOR")]
        RECEPTOR,

        [Description("@TIPO")]
        TIPO,

        [Description("@VISTO")]
        VISTO,

        [Description("@EMISOR")]
        EMISOR,

        [Description("@FECHA_CREACION")]
        FECHACREACION,

        [Description("@ESTADO")]
        ESTADO
    }
}