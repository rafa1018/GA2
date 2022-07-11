using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumRequestSolicCreditoInfTecInmParams
    {
        [Description("@STI_ID")]
        idSolicitudInformaciontecnicaInmueble,

        [Description("@SIT_ID")]
        idSolicitudInformacionTecnica,

        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@IND")]
        indicador

    }
}
