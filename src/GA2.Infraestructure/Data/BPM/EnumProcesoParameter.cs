using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Proceso parameters
    /// </summary>
    /// <author>OScar Julian Rojas</author>
    /// <date>09/08/2021</date>
    public enum EnumProcesoParameter
    {
        [Description("PCS_ID")]
        PCS_ID,
        [Description("PCS_NOMBRE")]
        PCS_NOMBRE,
        [Description("PCS_DESCRIPCION")]
        PCS_DESCRIPCION,
        [Description("PCS_ESTADO")]
        PCS_ESTADO,
        [Description("PSC_CREATEDOPOR")]
        PSC_CREATEDOPOR,
        [Description("PSC_FECHACREACION")]
        PSC_FECHACREACION,
        [Description("PSC_MODIFICADOPOR")]
        PSC_MODIFICADOPOR,
        [Description("PSC_FECHAMODIFICACION")]
        PSC_FECHAMODIFICACION,
        [Description("PSC_VERSION")]
        PSC_VERSION

    }
}
