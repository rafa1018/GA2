using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumSolicCreditoInfTecInmParams
    {
        [Description("@STI_ID")]
        idSolicitudInfoTecnicaInmueble,

        [Description("@SIT_ID")]
        idSolicitudtecnica,

        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@STI_NUMERO_MATRICULA")]
        numeroMatricula,

        [Description("@STI_FECHA_MATRICULA")]
        fechaMatricula,

        [Description("@STI_NUMERO_CHIP")]
        numeroChip,

        [Description("@STI_CEDULA_CATASTRAL")]
        cedulaCatastral,

        [Description("@STI_CREADO_POR")]
        creadoPor,

        [Description("@STI_FECHA_CREACION")]
        fechaCreacion
    }
}
