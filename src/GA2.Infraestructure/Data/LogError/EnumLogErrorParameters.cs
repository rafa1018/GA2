using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Enum parametros LogError
    /// <author>Oscar Julian Rojas Garces</author>
    /// <date>24/02/2021</date>
    /// </summary>
    public enum EnumLogErrorParameters
    {

        [Description("@LOGERRORID")]
        @LogErrorId,

        [Description("@CLIENTID")]
        CLIENT_ID,

        [Description("@MESSAGE")]
        MESSAGE,

        [Description("@CONTROLLERNAME")]
        CONTROLLER_NAME,

        [Description("@ACTIONNAME")]
        ACTION_NAME,

        [Description("@STACKTRACE")]
        STACK_TRACE,

        [Description("@ERRORCODE")]
        ERROR_CODE,

        [Description("@REQUESTIP")]
        REQUEST_IP,

        [Description("@LOGDATE")]
        LOG_DATE
    }
}

