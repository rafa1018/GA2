using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    /// <summary>
    /// Enum parametros PropiedadFormulario
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>29/04/2021</date>
    public enum EnumPropiedadFormularioParameters
    {
        [Description("@PFR_ID")]
        PFR_ID,

        [Description("@FRM_ID")]
        FRM_ID,

        [Description("@PFR_FORMID")]
        PFR_FORMID,

        [Description("@PFR_NOMBRE")]
        PFR_NOMBRE,

        [Description("@PFR_DESCRIPCION")]
        PFR_DESCRIPCION,

        [Description("@PFR_READONLY")]
        PFR_READONLY,

        [Description("@PFR_VISIBLE")]
        PFR_VISIBLE,

        [Description("@PFR_MODIFICADOPOR")]
        PFR_MODIFICADOPOR,

        [Description("@PFR_FECHAMODIFICACION")]
        PFR_FECHAMODIFICACION,

        [Description("@PFR_CREADOPOR")]
        PFR_CREADOPOR,

        [Description("@PFR_FECHACREACION")]
        PFR_FECHACREACION,

        [Description("@PFR_ESTADO")]
        PFR_ESTADO,
    }
}
