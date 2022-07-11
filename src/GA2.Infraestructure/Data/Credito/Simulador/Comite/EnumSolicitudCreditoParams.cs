using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumSolicitudCreditoParams
    {
        [Description("@SOC_ID")]
        idSolicitud,

        [Description("@SOC_NUMERO_SOLICITUD")]
        numeroSolicitud,

        [Description("@TCR_ID")]
        idTipoCredito,

        [Description("@TIPO_CREDITO")]
        tipoCredito,

        [Description("@CLI_IDENTIFICACION")]
        identificacion,

        [Description("@COC_ID")]
        idComiteCredito,

        [Description("@NOMBRE_CLIENTE")]
        nombreCliente,

        [Description("@RESULTADO")]
        resultado,

        [Description("@APROBADA")]
        aprobada,

        [Description("@RECHAZADA")]
        rechazada,

        [Description("PROCESADA@")]
        procesada,

        [Description("@USUARIO_CREACION")]
        usuarioCreacion,

        [Description("@FECHA_CREACION")]
        fechaCreacion
    }
}
