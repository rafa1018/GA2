using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumTramiteSolicitudParameters
    {
        [Description("@FECHA_SOL")]
        fecha,

        [Description("@CLI_IDENTIFICACION")]
        identificacion,

        [Description("@USUARIO_ID")]
        usuario,

        [Description("@ESTADO_ACT")]
        estado,

        [Description("@TCR_ID")]
        tipoCredito

    }
}
