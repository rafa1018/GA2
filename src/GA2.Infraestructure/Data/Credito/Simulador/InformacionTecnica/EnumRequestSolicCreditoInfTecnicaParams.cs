using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumRequestSolicCreditoInfTecnicaParams
    {
        [Description("@SIT_ID")]
        idSolicitudInformacionJuridica,

        [Description("@SOC_ID")]
        solicitudCredito,

        [Description("@IND")]
        indicador,
    }
}
