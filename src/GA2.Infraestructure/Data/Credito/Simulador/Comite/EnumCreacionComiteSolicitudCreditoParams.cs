using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumCreacionComiteSolicitudCreditoParams
    {
        [Description("@COS_ID")]
        idComiteSolicitud,

        [Description("@SOC_ID")]
        idSolicitudCredito,

        [Description("@COC_ID")]
        idComiteCredito,

        [Description("@COS_RESULTADO")]
        resultado,

        [Description("@COS_APROBADA")]
        aprobada,

        [Description("@COS_RECHAZADA")]
        rechazada,

        [Description("@COS_CREADO_POR")]
        creadoPor,

        [Description("@COS_FECHA_CREACION")]
        fechaCreacion,

        [Description("@COS_ACTUALIZADO_POR")]
        actualizadoPor,

        [Description("@COS_FECHA_ACTUALIZACION")]
        fechaActualizacion,

        [Description("@COS_VALOR_CREDITO ")]
        valorCredito,

        [Description("@COS_PLAZO_CREDITO ")]
        plazoCredito,

        [Description("@COS_TEA_CREDITO")]
        teaCredito
    }
}
