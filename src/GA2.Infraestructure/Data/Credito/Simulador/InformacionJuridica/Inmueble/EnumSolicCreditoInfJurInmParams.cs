using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumSolicCreditoInfJurInmParams
    {
        [Description("@SJI_ID")]
        IdSolicitudInfJuridicaInmueble,

        [Description("@SIJ_ID")]
        idSolicitudInformacionJuridica,

        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@SJI_NUMERO_MATRICULA")]
        numeroMatricula,

        [Description("@SJI_CEDULA_CATASTRAL")]
        cedulaCatastral,

        [Description("@SJI_AREA_PRIVADA")]
        areaPrivada,

        [Description("@SJI_VALOR_AVALUO_COMERCIAL")]
        avaluoComercial,

        [Description("@SJI_VALOR_AVALUO_CATASTRAL")]
        avaluoCatastral,

        [Description("@SJI_CREADO_POR")]
        creadoPor,

        [Description("@SJI_FECHA_CREACION")]
        fechaCreacion
    }
}
