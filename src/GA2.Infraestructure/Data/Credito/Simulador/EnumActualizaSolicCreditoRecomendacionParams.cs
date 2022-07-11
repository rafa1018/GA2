using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumActualizaSolicCreditoRecomendacionParams
    {
        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@SOC_VALOR_RECOMENDADO_CREDITO")]
        valorRecomendadoCredito,

        [Description("@SOC_OBSERVACION_RECOMENDACION ")]
        observacionRecomendacion,

        [Description("@SOC_ACTUALIZADO_POR")]
        actualizadoPor,

        [Description("@SOC_FECHA_ACTUALIZA")]
        fechaActualiza,

        [Description("@SOC_TIPO_ALIVIO")]
        tipoAlivio,
    }
}
