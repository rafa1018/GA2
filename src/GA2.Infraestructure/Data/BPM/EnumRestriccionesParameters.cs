using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Enum restricciones parametros
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>17/08/2021</date>
    public enum EnumRestriccionesParameters
    {
        [Description("TRA_ID")]
        TRA_ID,
        [Description("RTC_ID")]
        RTC_ID,
        [Description("RTC_NOMBRE")]
        RTC_NOMBRE,
        [Description("TRA_ID_RESTRICCION")]
        TRA_ID_RESTRICCION,
        [Description("RTC_CREATEDOPOR")]
        RTC_CREATEDOPOR,
        [Description("RTC_FECHACREACION")]
        RTC_FECHACREACION,
        [Description("RTC_MODIFICADOPOR")]
        RTC_MODIFICADOPOR,
        [Description("RTC_FECHAMODIFICACION")]
        RTC_FECHAMODIFICACION
    }
}
