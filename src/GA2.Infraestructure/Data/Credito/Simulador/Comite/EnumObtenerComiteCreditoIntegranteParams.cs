using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumObtenerComiteCreditoIntegranteParams
    {
        [Description("@COI_ID")]
        idIntegrantePorComite,

        [Description("@COC_ID")]
        idComite,

        [Description("@IND")]
        indicador
    }
}
