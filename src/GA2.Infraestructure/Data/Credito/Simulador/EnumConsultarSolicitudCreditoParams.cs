using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumConsultarSolicitudCreditoParams
    {
        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@NUMERO_DOCUMENTO")]
        identificacion,

        [Description("@ESTADO")]
        estado
    }
}
