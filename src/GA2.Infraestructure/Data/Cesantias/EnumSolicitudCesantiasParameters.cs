using System.ComponentModel;

namespace GA2.Infraestructure.Data
{
    public enum EnumSolicitudCesantiasParameters
    {
        [Description("@SOL_ID")]
        solicitudId,

        [Description("@TPS_SUB_ID")]
        subModalidadId,

        [Description("@CLI_ID")]
        idCliente
    }
}
