using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Parametros Enum Anadidos BD
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>13/08/2021</date>
    public enum EnumAnadidosParameter
    {
        [Description("AND_ID")]
        AND_ID,
        [Description("TRA_ID")]
        TRA_ID,
        [Description("AND_NOMBREANADIDO")]
        AND_NOMBREANADIDO,
        [Description("AND_FILE")]
        AND_FILE,
        [Description("AND_TIPO")]
        AND_TIPO,
        [Description("AND_CREATEDOPOR")]
        AND_CREATEDOPOR,
        [Description("AND_FECHACREACION")]
        AND_FECHACREACION,
        [Description("AND_MODIFICADOPOR")]
        AND_MODIFICADOPOR,
        [Description("AND_FECHAMODIFICACION")]
        AND_FECHAMODIFICACION
    }
}
