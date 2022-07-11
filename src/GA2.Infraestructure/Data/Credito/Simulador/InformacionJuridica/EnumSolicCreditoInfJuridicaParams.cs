using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumSolicCreditoInfJuridicaParams
    {
        [Description("@SIJ_ID")]
        idSolicitudInformacionJuridica,

        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@SIJ_LINDEROS")]
        linderos,

        [Description("@SIJ_TIPO_PARQUEADERO")]
        tipoParqueadero,

        [Description("@SIJ_EDAD_JURIDICA")]
        edadJuridica,

        [Description("@SIJ_FECHA_PRIMER_ACTO")]
        fechaPrimerActo,

        [Description("@SIJ_TRADICION_INMUEBLE")]
        tradicionInmueble,

        [Description("@SIJ_ANALISIS_ULT_20_AÑOS")]
        analisisUlt20Años,

        [Description("@SIJ_ANALISIS_SIT_JURIDICA")]
        analisisSitJuridica,

        [Description("@SIJ_ANALISIS_REG_PROP_HOR")]
        AnalisisRegPropHorizontal,

        [Description("@SIJ_ANALISIS_PAZ_Y_SALVO")]
        analisisPazySalvo,

        [Description("@SIJ_ANALISIS_VENDEDOR")]
        analisisVendedor,

        [Description("@SIJ_VIABILIDAD_JUR_NEGOCIO")]
        viabilidadJurNegocio,

        [Description("@SIJ_RECOMENDACIONES")]
        recomendaciones,

        [Description("@SIJ_CONCEPTO_JURIDICO_FIN")]
        conceptoJuridicoFin,

        [Description("@SIJ_CONCEPTO_EST_JURIDICO")]
        conceptoEstJuridicio,

        [Description("@SIJ_DIRECCION")]
        direccion,

        [Description("@DPD_ID")]
        departamento,

        [Description("@DPC_ID")]
        ciudad,

        [Description("@SIJ_CREADO_POR")]
        creadoPor,

        [Description("@SIJ_FECHA_CREACION")]
        fechaCreacion

    }
}
