using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumSolicCreditoInfTecnicaParameters
    {

        [Description("@SIT_ID")]
        idSolicitudInformacionTecnica,

        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@SIT_VALOR_AVALUO_COMERCIAL")]
        valorAvaluoComercial,

        [Description("@SIT_VALOR_VENTA_INMUEBLE")]
        valorVentaInmueble,

        [Description("@SIT_CONSIDERACIONES_FINALES")]
        consideracionesFinales,

        [Description("@SIT_DECLARA_CUMPLIMIENTO")]
        declaraCumplimiento,

        [Description("@SIT_CONDICIONES_SALVEADES")]
        condicionesSalvedades,

        [Description("@SIT_CONCEPTO_EST_TECNICO")]
        conceptoEstTecnico,

        [Description("@SIT_ESTRATO")]
        estrato,

        [Description("@SIT_CREADO_POR")]
        creadoPor,

        [Description("@SIT_FECHA_CREACION")]
        fechaCreacion

    }
}
