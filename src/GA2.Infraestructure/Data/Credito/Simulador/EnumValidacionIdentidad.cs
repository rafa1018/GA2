using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumValidacionIdentidad
    {
        [Description("@VLI_ID")]
        VLI_ID,

        [Description("@TID_ID")]
        TID_ID,

        [Description("@VLI_FECHA_EXPEDICION")]
        VLI_FECHA_EXPEDICION,

        [Description("@VLI_NUMERO_DOCUMENTO")]
        VLI_NUMERO_DOCUMENTO,

        [Description("@VLI_NUMERO_CELULAR")]
        VLI_NUMERO_CELULAR,

        [Description("@VLI_ACEPTA_HABEAS")]
        VLI_ACEPTA_HABEAS,

        [Description("@VLI_ACEPTA_TERMINOS")]
        VLI_ACEPTA_TERMINOS,

        [Description("@VLI_FECHA_VALIDA_IDEN")]
        VLI_FECHA_VALIDA_IDEN,

        [Description("@VLI_FECHA_VALIDA_OTP")]
        VLI_FECHA_VALIDA_OTP,

        [Description("@VLI_CODIGO_OTP")]
        VLI_CODIGO_OTP,

        [Description("@VLI_PASO_VALIDACION")]
        VLI_PASO_VALIDACION,

        [Description("@VLI_USUARIO_ACTUALIZA")]
        VLI_USUARIO_ACTUALIZA,

        [Description("@VLI_FECHA_ACTUALIZA")]
        VLI_FECHA_ACTUALIZA
    }
}
