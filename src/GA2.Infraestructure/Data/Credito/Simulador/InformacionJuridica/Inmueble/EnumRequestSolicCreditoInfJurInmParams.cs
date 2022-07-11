using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumRequestSolicCreditoInfJurInmParams
    {
        [Description("@SJI_ID")]
        idSolicitudInformacionJuridicaInmueble,

        [Description("@SIJ_ID")]
        idSolicitudInformacionJuridica,

        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@IND")]
        indicador
    }
}
