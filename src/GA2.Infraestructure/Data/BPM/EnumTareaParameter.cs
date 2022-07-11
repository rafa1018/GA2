using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Enum parameters Tareas
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>09/08/2021</date>
    public enum EnumTareaParameter
    {
        [Description("TRA_ID")]
        TRA_ID,
        [Description("PCS_ID")]
        PCS_ID,
        [Description("TRA_NOMBRE")]
        TRA_NOMBRE,
        [Description("TRA_FECHAINICIO")]
        TRA_FECHAINICIO,
        [Description("TRA_FECHAFIN")]
        TRA_FECHAFIN,
        [Description("TRA_CIERRE_ESTIMADO")]
        TRA_CIERRE_ESTIMADO,
        [Description("TRA_ACTIVA")]
        TRA_ACTIVA,
        [Description("RL_ID_RESPONSABLE")]
        RL_ID_RESPONSABLE,
        [Description("TRA_ACTORES")]
        TRA_ACTORES,
        [Description("TRA_CREATEDOPOR")]
        TRA_CREATEDOPOR,
        [Description("TRA_FECHACREACION")]
        TRA_FECHACREACION,
        [Description("TRA_MODIFICADOPOR")]
        TRA_MODIFICADOPOR,
        [Description("TRA_FECHAMODIFICACION")]
        TRA_FECHAMODIFICACION,
        [Description("TRA_ID_ENTRADA")]
        TRA_ID_ENTRADA,
        [Description("TRA_ID_SALIDA")]
        TRA_ID_SALIDA
    }
}
