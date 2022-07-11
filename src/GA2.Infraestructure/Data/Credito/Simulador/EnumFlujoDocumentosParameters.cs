using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumFlujoDocumentosParameters
    {
        [Description("@SOC_ID")]
        SOC_ID,

        [Description("@TCR_ID")]
        TCR_ID,

        [Description("@ORDEN")]
        ORDEN,

        [Description("@PRINCIPAL")]
        PRINCIPAL,
        
        [Description("@AFL_ID")]
        AFL_ID
    }
}
